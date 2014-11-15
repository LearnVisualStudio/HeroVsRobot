<#
.SYNOPSIS
    Creates a Windows Azure Website and links to a SQL Azure DB and a storage account.  
.DESCRIPTION 
   Creates a new website and a new SQL Azure database.  If the storage account 
   specified doesn't exist, it will create a new storage account.

   When the SQL Azure database server is created, a firewall rule is added for the
   ClientIPAddress and also for Azure services (to connect to from the WebSite).

   The user is prompted for administrator credentials to be used when creating 
   the login for the new SQL Azure database.
.EXAMPLE
   .\New-AzureWebsitewithDB.ps1 -WebSiteName "myWebSiteName" -Location "West US" `
        -StorageAccountName "myStorageAccountName" -ClientIPAddress "123.123.123.123"
#>
param(
    [CmdletBinding( SupportsShouldProcess=$true)]
         
    # The webSite Name you want to create
    [Parameter(Mandatory = $true)] 
    [string]$WebSiteName,
        
    # The Azure Data center Location
    [Parameter(Mandatory = $true)] 
    [string]$Location,
    
    # The Storage account that will be linked to the website
    [Parameter(Mandatory = $true)]
    [String]$StorageAccountName,

    # Users machine IP.  Used to configure firewall rule for new SQL DB.
    [Parameter(Mandatory = $true)]
    [ValidatePattern("\b(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\b")]
    [String]$ClientIPAddress)

# The script has been tested on Powershell 3.0
Set-StrictMode -Version 3

# Following modifies the Write-Verbose behavior to turn the messages on globally for this session
$VerbosePreference = "Continue"

# Check if Windows Azure Powershell is avaiable
if ((Get-Module -ListAvailable Azure) -eq $null)
{
    throw "Windows Azure Powershell not found! Please install from http://www.windowsazure.com/en-us/downloads/#cmd-line-tools"
}
   
<#
.SYNOPSIS
    creates a sql db and set server firewall rule based on the parameters location, 
    name, user id, password
.DESCRIPTION
   This function creates a database server, sets up server firewall rules and then 
   creates a Database. It uses New-AzureSqlDatabaseServer cmdlet to create the server, 
   New-AzureSqlDatabaseServerFirewallRule to create the firewall rule, 
   New-AzureSqlDatabase cmdlet to create the database. 
 
    `
.EXAMPLE
    $db = CreateDatabase -Location "West US" -AppDatabaseName "AppDatabaseName"
     -UserName "UserName" -Password "Password" -RuleName "RuleName" 
     -FirewallRuleName "FirewallRuleName" -StartIPAddress "0.0.0.0" -EndIPAddress "0.0.0.0"
#>

function CreateDatabase($Location,$AppDatabaseName, $Credential, $ClientIP)
{
    # Create Database Server
    Write-Verbose "Creating SQL Azure Database Server."
    $databaseServer = New-AzureSqlDatabaseServer -AdministratorLogin $Credential.UserName `
        -AdministratorLoginPassword $Credential.GetNetworkCredential().Password -Location $Location
    Write-Verbose ("SQL Azure Database Server '" + $databaseServer.ServerName + "' created.")
    
    # Apply Firewall Rules
    $clientFirewallRuleName = "ClientIPAddress_" + [DateTime]::UtcNow
    Write-Verbose "Creating client firewall rule '$clientFirewallRuleName'."
    New-AzureSqlDatabaseServerFirewallRule -ServerName $databaseServer.ServerName `
        -RuleName $clientFirewallRuleName -StartIpAddress $ClientIP -EndIpAddress $ClientIP | Out-Null  

    $azureFirewallRuleName = "AzureServices"
    Write-Verbose "Creating Azure Services firewall rule '$azureFirewallRuleName'."
    New-AzureSqlDatabaseServerFirewallRule -ServerName $databaseServer.ServerName `
        -RuleName $azureFirewallRuleName -StartIpAddress "0.0.0.0" -EndIpAddress "0.0.0.0"
    
    # Create Database
    $serverName = $databaseServer.ServerName
    $context = New-AzureSqlDatabaseServerContext -ServerName $serverName -Credential $Credential
    Write-Verbose "Creating database '$AppDatabaseName' in database server $serverName."
    New-AzureSqlDatabase -DatabaseName $AppDatabaseName -Context $context
   
    return $serverName;
}

# Create the website 
$website = Get-AzureWebsite | Where-Object {$_.Name -eq $WebSiteName }
if ($website -eq $null) 
{   
    Write-Verbose "Creating website '$WebSiteName'." 
    $website = New-AzureWebsite -Name $WebSiteName -Location $Location 
}
else 
{
    throw "Website already exists.  Please try a different website name."
}

# Create storage account if it does not already exist.
$storageAccount = Get-AzureStorageAccount | Where-Object { $_.StorageAccountName -eq $StorageAccountName }
if($storageAccount -eq $null) 
{
    Write-Verbose "Creating storage account '$StorageAccountName'."
    $storage = New-AzureStorageAccount -StorageAccountName $StorageAccountName -Location $Location 
}

# Construct a storage account app settings hashtable.
$storageAccountKey = Get-AzureStorageKey -StorageAccountName $StorageAccountName
$storageSettings = @{"STORAGE_ACCOUNT_NAME" = $StorageAccountName; 
                     "STORAGE_ACCESS_KEY"   = $storageAccountKey.Primary }

# Get credentials from user to setup administrator access to new SQL Azure Server
Write-Verbose "Prompt user for administrator credentials to use when provisioning the SQL Azure Server"
$credential = Get-Credential
Write-Verbose "Administrator credentials captured.  Use these credentials when logging into the SQL Azure Server."

# Create the SQL DB
$AppDatabaseName = $WebSiteName + "_db"
Write-Verbose "Creating database '$AppDatabaseName'."
$dbName = CreateDatabase -Location $Location -AppDatabaseName $AppDatabaseName `
              -Credential $credential -ClientIP $ClientIPAddress

# Create a connection string for the database.
$appDBConnStr  = "Server=tcp:{0}.database.windows.net,1433;Database={1};" 
$appDBConnStr += "User ID={2}@{0};Password={3};Trusted_Connection=False;Encrypt=True;Connection Timeout=30;"
$appDBConnStr = $appDBConnStr -f `
                    $dbName, $AppDatabaseName, `
                    $Credential.GetNetworkCredential().Password, `
                    $Credential.GetNetworkCredential().Password

# Instantiate a ConnStringInfo object to add connection string infomation to website.
$appDBConnStrInfo = New-Object Microsoft.WindowsAzure.Management.Utilities.Websites.Services.WebEntities.ConnStringInfo;
$appDBConnStrInfo.Name=$AppDatabaseName;
$appDBConnStrInfo.ConnectionString=$appDBConnStr;
$appDBConnStrInfo.Type="SQLAzure";

# Add new ConnStringInfo objecto list of connection strings for website.
$connStrSettings = (Get-AzureWebsite $WebSiteName).ConnectionStrings;
$connStrSettings.Add($appDBConnStrInfo);

# Link the website to the storage account and SQL Azure database.
Write-Verbose "Linking storage account '$StorageAccountName' and SQL Azure Database '$AppDatabaseName' to website '$WebSiteName'."
Set-AzureWebsite -Name $WebSiteName -AppSettings $storageSettings -ConnectionStrings $connStrSettings
Write-Verbose "Complete!"
