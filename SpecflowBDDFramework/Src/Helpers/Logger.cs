using System;
using log4net;
using log4net.Appender;
using log4net.Core;
using log4net.Layout;
using log4net.Repository.Hierarchy;

namespace SpecflowBDDFramework.Src.Helpers
{
    public static class Logger
    {

        public static ILog Get()
        {
            return LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }

        public static void Init()
        {
            Hierarchy hierarchy = (Hierarchy)LogManager.GetRepository();

            PatternLayout patternLayout = new PatternLayout();
            patternLayout.ConversionPattern = "%date [%thread] %-5level %logger - %message%newline";
            patternLayout.ActivateOptions();

            /*RollingFileAppender roller = new RollingFileAppender();
            roller.AppendToFile = false;
            roller.File = @"EventLog.txt";
            roller.Layout = patternLayout;
            roller.MaxSizeRollBackups = 5;
            roller.MaximumFileSize = "1GB";
            roller.RollingStyle = RollingFileAppender.RollingMode.Size;
            roller.StaticLogFileName = true;
            roller.ActivateOptions();
            hierarchy.Root.AddAppender(roller);*/

            ConsoleAppender console = new ConsoleAppender();
            console.Layout = patternLayout;
            console.Threshold = Level.Info;
            console.ActivateOptions();
            hierarchy.Root.AddAppender(console);


            hierarchy.Root.Level = Level.Info;
            hierarchy.Configured = true;
        }
    }
}
