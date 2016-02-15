using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Threading.Tasks;

namespace BadMishka.Automation.Logging
{
    [CLSCompliant(false)]
    public class WriteLogCmdletBase : PSCmdlet
    {

        protected LogLevel Level { get; set; }

        [Parameter(
            Position = 0,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public object Message { get; set; }

        [Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public object[] MessageArgs { get; set; }

        [Parameter()]
        public int EventId { get; set; }

        [Parameter()]
        public Exception Exception { get; set; }

        protected override void ProcessRecord()
        {
            if (Util.IsPaused)
                return;

            var logger = Util.GetLogger();
            if (logger == null)
                throw new NullReferenceException("logger");

            object state = null;
            if (this.Message != null)
            {
                if (this.Message is string)
                {
                    state = new FormattedLogValues(this.Message as string,
                        this.MessageArgs ?? new object[0]);
                }
                else
                {
                    state = this.Message;
                }
            }

            logger.Log(this.Level, this.EventId, state, this.Exception, Util.Formatter);

            base.ProcessRecord();
        }
    }
}
