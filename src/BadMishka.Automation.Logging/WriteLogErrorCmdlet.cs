using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Threading.Tasks;

namespace BadMishka.Automation.Logging
{
    [Cmdlet("Write", "LogError")]
    [CLSCompliant(false)]
    public class WriteLogErrorCmdlet : WriteLogCmdletBase
    {

        public WriteLogErrorCmdlet()
        {
            this.Level = Microsoft.Extensions.Logging.LogLevel.Error;
        }
    }
}
