using Serilog;
using Serilog.Sinks.RollingFile;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Threading.Tasks;

namespace BadMishka.Automation.Logging
{
    [Cmdlet("Add", "WriteLogConsoleEmitter")]
    [CLSCompliant(false)]
    public class AddWriteLogConsoleEmitterCmdlet : PSCmdlet
    {

        public AddWriteLogConsoleEmitterCmdlet()
        {
            this.Template = "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level}] {Message}{NewLine}{Exception}";
        }

        [Parameter]
        public string Template { get; set; }

        protected override void ProcessRecord()
        {
            Util.AddSerilog(new LoggerConfiguration()
                .MinimumLevel.ControlledBy(Util.Switch)
                .WriteTo
                .ColoredConsole(Util.Switch.MinimumLevel, this.Template)
                .CreateLogger());              

            base.ProcessRecord();
        }
    }
}
