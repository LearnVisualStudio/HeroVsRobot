Set-AzureSubscription -SubscriptionName "Visual Studio Ultimate with MSDN" -CurrentStorageAccount "herovsduck"

.\New-AzureWebsitewithDB.ps1 -WebSiteName "herovsduck" -Location "East US" -StorageAccountName "herovsduck" -ClientIPAddress "71.164.128.6"

