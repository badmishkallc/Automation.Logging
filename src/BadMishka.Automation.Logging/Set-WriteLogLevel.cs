using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace BadMishka.Automation.Logging
{
    [Cmdlet("Set", "WriteLogLevel")]
    [CLSCompliant(false)]
    public class SetWriteLogLevel : PSCmdlet
    {
        [Parameter(Position = 0, Mandatory = true)]
        public LogLevel Level { get; set; }

        protected override void ProcessRecord()
        {
            Util.Level = this.Level;
            base.ProcessRecord();
        }
    }
}
