# If you have any problemms with this script, read this article:
# http://blogs.msdn.com/b/cindygross/archive/2014/04/19/getting-started-with-azure-powershell-cmdlets-subscription-management.aspx

#copy SUBSCRIPTION ID from portal 
#lower left, settings, management certificates
$subID = "xxxxxxxx-1f05-4a0a-9f2e-8e9b70eb5503"
#copy THUMBPRINT from portal 
#lower left, settings, management certificates
$thumbprint = "xxxxxxxx607F6A11379103F18C8682CC77A08515"
$myCert = Get-Item cert:\\CurrentUser\My\$thumbprint  


#subname to be used locally
#usually you will choose the actual subscription name
#stored in %appdata%\Windows Azure PowerShell\WindowsAzureProfile.xml
$localSubName = "Visual Studio Ultimate with MSDN"

Set-AzureSubscription –SubscriptionName $localSubName `
–SubscriptionId $subID -Certificate $myCert

#optionally set "current" storage account for this sub
#$defaultStorageAccount = 'MyFavStorageAccount'

#Set-AzureSubscription -SubscriptionName $localSubName `
#-CurrentStorageAccount $defaultStorageAccount

#Select-AzureSubscription –Default $localSubName
Select-AzureSubscription –Default -SubscriptionName $localSubName


Get-AzureSubscription –Current

(Get-AzureSubscription -Current).SubscriptionName

Get-AzureService | select ServiceName