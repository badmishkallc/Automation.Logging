# BadMishka.Automation.Logging

A Powershell Logging module that wraps Microsoft.Extensions.Logging & Serilog

## Notes
Sadly, Asp.Net 5x and Serilog currently 
[invert Verbose and Debug](https://github.com/serilog/serilog-extensions-logging/issues/14). 


## Quickstart
```powershell
PS C:\Users\user> Install-Module Posh-WriteLog
PS C:\Users\user> Add-WriteLogConsoleEmitter 
PS C:\Users\user> Add-WriteLogFile -File "$env:USERPROFILE\Desktop\awesomelog-{Date}.txt" -Rolling
PS C:\Users\user> Write-LogDebug "Message"
PS C:\Users\user> Write-Log "Info Message"
PS C:\Users\user> Write-Log -Level Warning "Explicit Warning Message"
```

# Why?

Sometimes a log file is needed for automation scripts that does not trap the 
output from Write-Host, Verbose, or other internal objects. 

I've written log functions a few times and did not see a module that quite 
fit the nitch of using existing logging libraries or writing in hooks 
to enable switching between logging frameworks later. 




 
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
