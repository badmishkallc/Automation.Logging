$hd = Split-Path $MyInvocation.MyCommand.Path; 

$root = "$hd\src\BadMishka.Automation.Logging"

$path = "$root\BadMishka.Automation.Logging.csproj"

if((Test-Path "$root\bin\Release")) {
    Remove-Item -Path "$root\bin\Release" -Force -Recurse 
}

if((Test-Path "$hd\.build\Posh-WriteLog")) {
    Remove-Item -Path "$hd\.build\Posh-WriteLog" -Force -Recurse
}

$dev = "C:\Program Files (x86)\Microsoft Visual Studio 14.0\Common7\IDE\devenv.exe"
& $dev "$hd/BadMishka.Automation.Logging.sln" /build Release /project "src/BadMishka.Automation.Logging/BadMishka.Automation.Logging.csproj" /projectconfig Release

while($true) {
    sleep -Seconds 1
    if((Test-Path "$root\bin\Release")) {
        $items = gci "$root\bin\Release"
        if($items.Length -gt 0) {
            break;
        }
    }
}

if(-not (Test-Path "$hd\.build\Posh-WriteLog")) {
    New-Item -Path "$hd\.build\Posh-WriteLog" -ItemType Directory
}

 Copy-Item "$root\bin\Release\*.*"  "$hd\.build\Posh-WriteLog" -Recurse