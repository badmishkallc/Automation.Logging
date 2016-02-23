using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Threading.Tasks;

namespace BadMishka.Automation.Logging
{
   
    [Cmdlet("Write", "Log")]
    [CLSCompliant(false)]
    public class WriteLogCmdlet : WriteLogCmdletBase
    {
        public WriteLogCmdlet()
        {
            this.Level = LogLevel.Information;
        }

        [Parameter()]
        public new LogLevel Level
        {
            get { return base.Level; }
            set { base.Level = value; }
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
        }
    }
}
