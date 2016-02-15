using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Threading.Tasks;
using Serilog;
using Serilog.Sinks.RollingFile;

namespace BadMishka.Automation.Logging
{
    
    [Cmdlet("Add", "WriteLogProvider")]
    [CLSCompliant(false)]
    public class AddWriteLogProvider : PSCmdlet
    {

        [Parameter(Mandatory = true, Position = 0)]
        public object Provider { get; set; }

        protected override void ProcessRecord()
        {
            if (this.Provider == null)
                throw new ArgumentNullException("Provider");

            if(this.Provider is ILoggerProvider)
            {
                Util.GetFactory().AddProvider((ILoggerProvider)this.Provider);
                base.ProcessRecord();
                return;
            }

            var providerName = this.Provider.ToString().ToLower();
            switch(providerName)
            {
                case "console":
                    Util.GetFactory().AddConsole();
                    break;

                default:
                    throw new NotSupportedException("Unknown LoggerProvider " + providerName);
            }
     
            base.ProcessRecord();
        }
    }
}
