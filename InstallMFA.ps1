Stop-Service adfssrv -Force
$path = Read-Host "Enter Directory containing install files (eg C:\Admin)"
Copy-Item C:\Admin\OktaMFA-ADFS.dll.config -Destination C:\Windows\ADFS\OktaMFA-ADFS.dll.config -Force
Set-Location C:\Admin
[System.Reflection.Assembly]::Load("System.EnterpriseServices, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")
$newton = New-Object System.EnterpriseServices.Internal.Publish
$newton.GacInstall("C:\Admin\Newtonsoft.Json.dll")
$publish = New-Object System.EnterpriseServices.Internal.Publish
$publish.GacInstall("C:\Admin\OktaMFA-ADFS.dll")
$publish1 = New-Object System.EnterpriseServices.Internal.Publish
$publish1.GacInstall("C:\Admin\OktaMFASMS-ADFS.dll")
$typeName = "OktaMFASMS_ADFS.AuthenticationAdapter, OktaMFASMS-ADFS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=2b0ec32601026327"
$typeName1 = "OktaMFA_ADFS.AuthenticationAdapter, OktaMFA-ADFS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=2b0ec32601026327"
Start-Service adfssrv
Register-AdfsAuthenticationProvider -TypeName $typeName -Name "OktaMFASMS-ADFS" -Verbose
Register-AdfsAuthenticationProvider -TypeName $typeName1 -Name "OktaMFA-ADFS" -Verbose
Restart-Service adfssrv -Force
