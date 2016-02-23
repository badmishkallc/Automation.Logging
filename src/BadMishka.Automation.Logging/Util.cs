
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Serilog;
using System;

namespace BadMishka.Automation.Logging
{
    internal sealed class Util
    {
        private static Microsoft.Extensions.Logging.ILogger s_rootLogger;
        private static ILoggerFactory s_factory;
        private static bool s_paused = false;
        private static bool s_serilog = false;
        private static readonly object s_syncLock = new object();
        private static readonly Func<object, Exception, string> s_messageFormatter = (state, ex) => state.ToString();
        private static Serilog.Core.LoggingLevelSwitch s_switch = new Serilog.Core.LoggingLevelSwitch();

        public static Func<object, Exception, string> Formatter
        {
            get { return s_messageFormatter; }
        }
        
        static Util()
        {
            Level = LogLevel.Debug;
            IsInverted = true;
            AddSerilog(new Serilog.LoggerConfiguration()
                    .MinimumLevel.ControlledBy(Util.Switch)
                    .WriteTo
                    .ColoredConsole(Util.Switch.MinimumLevel)
                    .CreateLogger());
        }

        public static bool IsInverted { get; set; }

        public static Serilog.Core.LoggingLevelSwitch Switch { get { return s_switch; } }

        public static LogLevel Level
        {
            get { return GetFactory().MinimumLevel; }
            set
            {
                GetFactory().MinimumLevel = value;
                s_rootLogger = null;
                switch (value)
                {
                    case Microsoft.Extensions.Logging.LogLevel.Debug:
                        s_switch.MinimumLevel = Serilog.Events.LogEventLevel.Verbose;
                        break;
                    case Microsoft.Extensions.Logging.LogLevel.Information:
                        s_switch.MinimumLevel = Serilog.Events.LogEventLevel.Information;
                        break;
                    case Microsoft.Extensions.Logging.LogLevel.Verbose:
                        s_switch.MinimumLevel = Serilog.Events.LogEventLevel.Debug;
                        break;
                    case Microsoft.Extensions.Logging.LogLevel.Warning:
                        s_switch.MinimumLevel = Serilog.Events.LogEventLevel.Warning;
                        break;
                    case Microsoft.Extensions.Logging.LogLevel.Error:
                        s_switch.MinimumLevel = Serilog.Events.LogEventLevel.Error;
                        break;
                    case Microsoft.Extensions.Logging.LogLevel.Critical:
                        s_switch.MinimumLevel = Serilog.Events.LogEventLevel.Fatal;
                        break;
                    case Microsoft.Extensions.Logging.LogLevel.None:
                        Util.Pause();
                        break;
                    default:
                        s_switch.MinimumLevel = Serilog.Events.LogEventLevel.Verbose;
                        break;
                }
            }
        }

        public static bool IsPaused
        {
            get
            {
                lock(s_syncLock)
                {
                    return s_paused;
                }
            }
        }

        public static void AddSerilog(Serilog.ILogger logger = null)
        {
           var factory = GetFactory();
           lock(s_syncLock)
            {
                if(!s_serilog)
                {
                    Serilog.SerilogLoggerFactoryExtensions.AddSerilog(factory, logger);
                }
            }    
        }

        public static ILoggerFactory GetFactory()
        {
            lock(s_syncLock)
            {
                if (s_factory == null)
                {
                    s_factory = new LoggerFactory();
                    s_factory.MinimumLevel = Level;
                }

                return s_factory;
            }
        }

        public static Microsoft.Extensions.Logging.ILogger GetLogger(string name = "PowerShell")
        {
            lock(s_syncLock)
            {
                if (s_rootLogger == null)
                {
                    s_rootLogger = GetFactory().CreateLogger(name);
                   
                }

                return s_rootLogger;
            }
        }

        public static void Pause()
        {
            lock(s_syncLock)
            {
                s_paused = true;
            }
        }

        public static void Resume()
        {
            lock(s_syncLock)
            {
                s_paused = false;
            }
        }
    }
}
