# BadMishka.Automation.Logging

A Powershell Logging module that wraps Microsoft.Extensions.Logging & Serilog

## Notes
Sadly, Asp.Net 5x and Serilog currently 
[invert Verbose and Debug](https://github.com/serilog/serilog-extensions-logging/issues/14). 


## Quickstart
```powershell
PS C:\Users\user> Import-Module c:\Users\path\to\BadMishka.Automation.Logging.dll
PS C:\Users\user> Set-WriteLogLevel "Debug"
PS C:\Users\user> Add-WriteLogFile -File "awesomelog-{Date}.txt" -Rolling
PS C:\Users\user> Add-WriteLogProvider "console"
PS C:\Users\user> Write-LogDebug "Message"
PS C:\Users\user> Write-Log -Level "Debug" -Message "Debug Message"
```
 
## Guidelines

 - [Code of Conduct](CODE-OF-CONDUCT.md)
 - [Contributing](CONTRIBUTING.md)

## License 

   Copyright 2016 Bad Mishka LLC

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
