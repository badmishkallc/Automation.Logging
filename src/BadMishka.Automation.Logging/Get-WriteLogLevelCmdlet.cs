using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace BadMishka.Automation.Logging
{
    [Cmdlet("Get", "WriteLogLevel")]
    [CLSCompliant(false)]
    public class GetWriteLogLevelCmdlet : PSCmdlet
    {

        protected override void ProcessRecord()
        {
            this.WriteObject(Util.Level);
            base.ProcessRecord();
        }
    }
}
