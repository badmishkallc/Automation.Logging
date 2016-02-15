using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Threading.Tasks;

namespace BadMishka.Automation.Logging
{
    [Cmdlet("Resume", "WriteLog")]
    [CLSCompliant(false)]
    public class ResumeWriteLogCmdlet : PSCmdlet
    {

        protected override void ProcessRecord()
        {
            Util.Resume();

            base.ProcessRecord();
        }
    }
}
