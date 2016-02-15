using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Threading.Tasks;

namespace BadMishka.Automation.Logging
{
    [Cmdlet("Write", "LogInformation")]
    [CLSCompliant(false)]
    public class WriteLogInformationCmdlet : WriteLogCmdletBase
    {

        public WriteLogInformationCmdlet()
        {
            this.Level = Microsoft.Extensions.Logging.LogLevel.Information;
        }
    }
}
