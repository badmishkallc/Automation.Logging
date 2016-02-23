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
    [Cmdlet("Add", "WriteLogFile")]
    [CLSCompliant(false)]
    public class AddWriteLogFileCmdlet : PSCmdlet
    {

        public AddWriteLogFileCmdlet()
        {
            this.Template = "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level}] {Message}{NewLine}{Exception}";
        }

        [Parameter]
        public string File { get; set; }

        [Parameter]
        public SwitchParameter Rolling { get; set; }

        [Parameter]
        public string Template { get; set; }

        protected override void ProcessRecord()
        {
            if(this.File == null || !this.File.Contains(Path.DirectorySeparatorChar))
            {
                string fileName = this.File ?? "log.txt";
                
                var fi = new FileInfo(fileName);
                fileName = fi.FullName;
                if (this.Rolling.ToBool())
                    fileName = fileName.Replace(".txt", "-{Date}.txt");

                this.File = fileName;
            }

            

            
               
            if(this.Rolling.ToBool())
            {
                Util.AddSerilog(new LoggerConfiguration()
                    .MinimumLevel.ControlledBy(Util.Switch)
                    .WriteTo
                    .RollingFile(this.File, Util.Switch.MinimumLevel, Template)
                    .WriteTo
                    .ColoredConsole(Util.Switch.MinimumLevel)
                    .CreateLogger());
            } else
            {
                Util.AddSerilog(new LoggerConfiguration()
                    .MinimumLevel.ControlledBy(Util.Switch)
                    .WriteTo
                    .File(this.File, Util.Switch.MinimumLevel, Template)
                    .WriteTo
                    .ColoredConsole(Util.Switch.MinimumLevel)
                    .CreateLogger());
            }


            base.ProcessRecord();
        }
    }
}
