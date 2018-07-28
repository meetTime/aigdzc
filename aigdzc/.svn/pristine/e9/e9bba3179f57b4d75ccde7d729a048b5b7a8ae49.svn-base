using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CCITU.Common
{
    public class Logger
    {
        public Logger(string logFolder)
        {
            this.LogFolder = logFolder;
            if (!Directory.Exists(LogFolder))
            {
                Directory.CreateDirectory(LogFolder);
            }

            this.Encoding = Encoding.UTF8;
            this.NewFileMode = NewFileMode.EveryDay;            
        }
        
        public Encoding Encoding
        {
            get;
            set;
        }

        public string LogFolder
        {
            get;
            set;
        }

        public NewFileMode NewFileMode
        {
            get;
            set;
        }

        public static string EndLine = "------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------";

        public void Info(string message,params object[] args)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("时间:{0}", DateTime.Now));
            sb.AppendLine(string.Format("Message:{0}", string.Format(message, args)));
            sb.AppendLine(EndLine);
            this.WriteLog(LogLevel.Info, message);
        }

        public void Debug(string message, params object[] args)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("时间:{0}", DateTime.Now));
            sb.AppendLine(string.Format("Message:{0}", string.Format(message, args)));
            sb.AppendLine(EndLine);
            this.WriteLog(LogLevel.Debug, message);
        }

        public void Error(string message, params object[] args)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("时间:{0}", DateTime.Now));
            sb.AppendLine(string.Format("Message:{0}", string.Format(message, args)));
            sb.AppendLine(EndLine);
            this.WriteLog(LogLevel.Error, message);
        }

        public void Error(Exception ex, object data = null)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("时间:{0}", DateTime.Now));
            sb.AppendLine(string.Format("Message:{0}", ex.Message));
            sb.AppendLine(string.Format("Source:{0}", ex.Source));
            sb.AppendLine(string.Format("StackTrace:{0}", ex.StackTrace));
            sb.AppendLine(string.Format("Data:{0}", (string)data));
            sb.AppendLine("------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            this.WriteLog(LogLevel.Error, sb.ToString());
        }
        
        public string BuildLogFileName(LogLevel logLevel)
        {
            string namePart1 = "Info";
            if (logLevel == LogLevel.Error)
            {
                namePart1 = "Error";
            }
            else if (logLevel == LogLevel.Debug)
            {
                namePart1 = "Debug";
            }

            string namePart2 = DateTime.Now.ToString("yyyyMMdd");
            if (this.NewFileMode == NewFileMode.EveryYear)
            {
                namePart2= DateTime.Now.ToString("yyyy");
            }
            else if (this.NewFileMode == NewFileMode.EveryMonth)
            {
                namePart2= DateTime.Now.ToString("yyyyMM");
            }

            return string.Format("{0}_{1}.log",namePart1,namePart2);
        }

        private void WriteLog(LogLevel level, string message)
        {
            string fileName = BuildLogFileName(level);
            string fullFileName = Path.Combine(LogFolder, fileName);
            WriteLog(fullFileName, message);
        }

        private async void WriteLogAsync(string fullFileName, string message)
        {
            using (FileStream fs = File.Open(fullFileName, FileMode.OpenOrCreate))
            {
                var buffer = Encoding.GetBytes(message);
                var task= fs.WriteAsync(buffer, 0, buffer.Length);
                await task;
            }
        }

        private void WriteLog(string fullFileName, string message)
        {
            FileStream fs = new FileStream(fullFileName, FileMode.Append, FileAccess.Write);
            var buffer = Encoding.GetBytes(message);
            fs.Write(buffer, 0, buffer.Length);
            fs.Close();

            //FileStream fs = new FileStream(fullFileName, FileMode.Append, FileAccess.Write, FileShare.Write, 1024, FileOptions.SequentialScan);
            //fs.BeginWrite(buffer, 0, buffer.Length, new AsyncCallback(WriteLogAsyncCallback), fs);
        }

        private void WriteLogAsyncCallback(IAsyncResult result)
        {   
            FileStream stream = (FileStream)result.AsyncState;
            
            stream.EndWrite(result);
            stream.Close();
        }

    }

    public enum LogLevel
    {
        Info = 1,
        Debug = 2,
        Error = 9
    }

    public enum NewFileMode
    {
        EveryDay = 1,        
        EveryMonth = 3,
        EveryYear = 4
    }

    public class LogUtils
    {
        static Logger Logger;

        static LogUtils()
        {
            Logger = CreateLogger();
        }

        private static Logger CreateLogger()
        {
            if (string.IsNullOrEmpty(LogFolder))
            {
                throw new ConfigurationErrorsException("请在配置文件中配置日志项:CCITU.Common.Log:Folder");
            }

            if (string.IsNullOrEmpty(NewFileMode))
            {
                throw new ConfigurationErrorsException("请在配置文件中配置日志项:CCITU.Common.Log:NewFileMode");
            }

            var logger = new Logger(LogFolder);
            logger.NewFileMode = Utils.GetEnumItem<NewFileMode>(NewFileMode);

            return logger;
        }

        public static string LogFolder
        {
            get
            {
                return ConfigurationManager.AppSettings["CCITU.Common.Log:Folder"];
            }
        }

        private static string NewFileMode
        {
            get
            {
                return ConfigurationManager.AppSettings["CCITU.Common.Log:NewFileMode"];
            }
        }

        
        public static void Info(string message, params object[] args)
        {
            Logger.Info(message,args);
        }

        public static void Debug(string message, params object[] args)
        {
            Logger.Debug(message, args);
        }

        public static void Error(string message, params object[] args)
        {
            Logger.Error(message, args);
        }

        public static void Error(Exception ex, object data = null)
        {
            Logger.Error(ex,data);
        }

       
    }


}
