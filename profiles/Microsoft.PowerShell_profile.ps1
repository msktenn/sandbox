
Import-Module 'C:\tools\poshgit\dahlbyk-posh-git-9bda399\src\posh-git.psd1'
Start-SshAgent

function codedir {set-location c:\code}
function resdir {set-location c:\code\Restrak}
function userdir {set-location C:\Users\mskte}

Set-Alias -Name list -Value get-childitem
Remove-Item alias:curl
