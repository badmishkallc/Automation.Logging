using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Threading.Tasks;

namespace BadMishka.Automation.Logging
{
    [Cmdlet("Suspend", "WriteLog")]
    [CLSCompliant(false)]
    public class SuspendWriteLogCmdlet : PSCmdlet 
    {

        protected override void ProcessRecord()
        {
            Util.Pause();

            base.ProcessRecord();
        }
    }
}
