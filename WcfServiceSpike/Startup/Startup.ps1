$featureName = 'AS-TCP-Activation'

Write-Host "Installing Windows feature: $featureName"
Install-WindowsFeature -Name $featureName 