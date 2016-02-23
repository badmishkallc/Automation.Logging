###
# ==++==
#
# Copyright (c) Bad Mishka LLC. All rights reserved.
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
#
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
#
###
@{
    GUID = "f5d76eef-e10e-4b8a-bbf7-2fdbacb6a6bb"
    Author = "Michael Herndon"
	Description = "Posh-WriteLog imports a Write-Log cmdlet for writing to rolling log files."
    CompanyName = "Bad Mishka LLC"
    Copyright = "(C) Bad Mishka LLC. All rights reserved."
    ModuleVersion = "0.1.5"
    PowerShellVersion = "3.0"
    ClrVersion = "4.0"
    RootModule = "BadMishka.Automation.Logging.dll"
	PrivateData = @{
		PSData = @{
			ReleaseNotes = "
Quick Usage Sample

PS C:\Users\user> Install-Module Posh-WriteLog
PS C:\Users\user> Add-WriteLogConsoleEmitter 
PS C:\Users\user> Add-WriteLogFile -File `"`$env:USERPROFILE\Desktop\awesomelog-{Date}.txt`" -Rolling
PS C:\Users\user> Write-LogDebug `"Message`"
PS C:\Users\user> Write-Log `"Info Message`"
PS C:\Users\user> Write-Log -Level Warning `"Explicit Warning Message`"

0.1.5
  - streamlined the api
  - fixed a Write-Log that kept the log level at None.  			"
			ProjectUri = "https://github.com/badmishkallc/Automation.Logging"
			LicenseURI = "https://raw.githubusercontent.com/badmishkallc/Automation.Logging/master/LICENSE"
			IconUri = "https://s3.amazonaws.com/badbadmishka.com/public/bad-posh.png"
			Tags = @("Logging", "LogFile", "WriteLog", "Rolling File", "File")
		}
	}
    CmdletsToExport = @(
        'Add-WriteLogFile',
		'Add-WriteLogConsoleEmitter',
        'Get-WriteLogLevel', 
        'Resume-WriteLog',
        'Set-WriteLogLevel',
        'Suspend-WriteLog',
        'Write-Log',
        'Write-LogDebug',
        'Write-LogError',
		'Write-LogInformation',
		'Write-LogVerbose',
        'Write-LogWarning'
	)
}
