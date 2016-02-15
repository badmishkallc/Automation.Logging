using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Threading.Tasks;

namespace BadMishka.Automation.Logging
{
    [Cmdlet("Write", "LogWarning")]
    [CLSCompliant(false)]
    public class WriteLogWarningCmdlet : WriteLogCmdletBase
    {

        public WriteLogWarningCmdlet()
        {
            this.Level = Microsoft.Extensions.Logging.LogLevel.Warning;
        }
    }
}
