using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Threading.Tasks;

namespace BadMishka.Automation.Logging
{
    [Cmdlet("Write", "LogDebug")]
    [CLSCompliant(false)]
    public class WriteLogDebugCmdlet : WriteLogCmdletBase
    {

        public WriteLogDebugCmdlet()
        {
            this.Level = Microsoft.Extensions.Logging.LogLevel.Debug;
        }
    }
}
