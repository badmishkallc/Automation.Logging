$hd = Split-Path $MyInvocation.MyCommand.Path; 

$keyJsonFile = "$env:UserProfile\nugetgallery.json"
if(-not (Test-Path $keyJsonFile)) {
    Write-Error "nugetgallery.json is not found"
    exit
}

$keyJson = [System.IO.File]::ReadAllText($keyJsonFile)
$keyConfig = ConvertFrom-Json $keyJson
$key = $keyConfig.apiKey

$publishParams = @{
    NuGetApiKey = $key
    Path = "$hd\.build\Posh-WriteLog"
}

Publish-Module @publishParams