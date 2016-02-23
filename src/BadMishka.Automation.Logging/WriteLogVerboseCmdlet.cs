using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Threading.Tasks;

namespace BadMishka.Automation.Logging
{
    [Cmdlet("Write", "LogVerbose")]
    [CLSCompliant(false)]
    public class WriteLogVerboseCmdlet : WriteLogCmdletBase
    {

        public WriteLogVerboseCmdlet()
        {
            if (Util.IsInverted)
                this.Level = Microsoft.Extensions.Logging.LogLevel.Debug;
            else
                this.Level = Microsoft.Extensions.Logging.LogLevel.Verbose;
        }
    }
}
