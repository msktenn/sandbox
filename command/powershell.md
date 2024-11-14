Enable-PSRemoting -Force
Set-Item wsman:\localhost\client\trustedhosts *
Set-Item WSMan:\localhost\Client\TrustedHosts -Value 137.116.46.174 -Force
Restart-Service WinRM
Test-WsMan COMPUTER
Invoke-Command -ComputerName COMPUTER -ScriptBlock { COMMAND } -credential USERNAME
Invoke-Command -ComputerName 10.0.0.22 -ScriptBlock { Get-ChildItem C:\ } -credential wjgle
Enter-PSSession -ComputerName 137.116.46.174 -Credential restrak

Invoke-Sqlcmd -Query "SELECT * From ConfigSettings" -ServerInstance "." -Database "RestrakUAT"
PSEdit

Invoke-Sqlcmd -Query "SELECT Id, Name, Value From ConfigSetting" -ServerInstance "." -Database "RestrakUAT"


Get-Service -Name "win*" 
Stop-Service -Name "Restrak UAT Task Service"