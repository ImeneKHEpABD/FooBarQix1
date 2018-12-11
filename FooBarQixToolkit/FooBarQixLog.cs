/*
 * Title: FooBarQixToolkit
 * File: FooBarQixLog.cs
 * Description: The logging class.
 * Author:Imene Khemiri
 * Copyright: Copyright (c) 2018
 * @version 1.0.0
 * */
using NLog;
using NLog.Targets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FooBarQixToolkit
{
    public class FooBarQixLog
    {
        #region Attributes
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        private string strfilepath;
        private string strFileName;
        private Dictionary<string, int> DicLogLevels;

        
        #endregion

        #region Constructor
        /// <summary>
        /// the log File Constructor.
        /// </summary>
        /// <PARAM name=""></PARAM>
        public FooBarQixLog()
        {
            strfilepath = "";
            strFileName = "";
            DicLogLevels = new Dictionary<string, int>
            {
                ["Trace"] = 0,
                ["Debug"] = 1,
                ["Info"] = 2,
                ["Warn"] = 3,
                ["Error"] = 4,
                ["Fatal"] = 5,
                ["Off"] = 6
            };

        }
        #endregion
        #region Methods
        /// <summary>
        /// the log initialization method.
        /// </summary>
        /// <return>returns 0 if the initialization was successfull and -1 if not</return>
        public int InitializeLog()
        {
            
            try
            {        
                string strlogfile;
                LogLevel LogLevel;
                bool bArchiveOldFileOnStartup;
                int iBufferSize;
                int iMaxArchiveFiles;
                GetLogParametersFromIniFile(out strlogfile, out LogLevel,out bArchiveOldFileOnStartup,out iBufferSize,out iMaxArchiveFiles);          
                var config = new NLog.Config.LoggingConfiguration();
                var logfile = new NLog.Targets.FileTarget("logfile") { FileName = strlogfile };
                var logconsole = new NLog.Targets.ConsoleTarget("logconsole");
                logfile.ArchiveOldFileOnStartup = bArchiveOldFileOnStartup;
                logfile.BufferSize = iBufferSize;
                logfile.MaxArchiveFiles = iMaxArchiveFiles;
                logfile.Header = "==         FooBarQixToolkit		   ==" + Environment.NewLine +
                                 "==         Version : 1.0.0           ==" + Environment.NewLine +
                                 "==         Copyright ©  2018         ==";
                config.AddRule(LogLevel.Info, LogLevel.Fatal, logconsole);
                config.AddRule(LogLevel, LogLevel.Fatal, logfile);                 
                NLog.LogManager.ThrowConfigExceptions = true;
                NLog.LogManager.Configuration = config;
                return 0;
            }
            catch(Exception ex)
            {
                return -1;

            }
            
        }
        /// <summary>
        /// This method returns the log parameters in the ini config file and creates a default ini config file if it does not exist.
        /// </summary>
        /// <PARAM name="strlogfile">The log file name to be returned from the ini file</PARAM>
        /// <PARAM name="logLevel">The log level to be returned from the ini file</PARAM>
        private void GetLogParametersFromIniFile(out string strlogfile,out LogLevel logLevel,out bool bArchiveOldFileOnStartup, out int iBufferSize, out int iMaxArchiveFiles)
        {
            strlogfile = "";
            logLevel = LogLevel.Trace;
            iMaxArchiveFiles = 0;
            iBufferSize = 100;
            bArchiveOldFileOnStartup = true;
            try
            {
                string Level;
                System.IO.FileInfo fileinfo = new System.IO.FileInfo(System.Reflection.Assembly.GetExecutingAssembly().Location);//IKH in 07062016
                FooBarQixLogConfig ConfigFile = new FooBarQixLogConfig(fileinfo.Directory + "\\"+ Constants.LOGINIFILENAME);
                System.IO.FileInfo configFileInfo = new System.IO.FileInfo(fileinfo.Directory + "\\" + Constants.LOGINIFILENAME);
               
                if (configFileInfo.Exists)
                {
                    strfilepath = ConfigFile.IniReadValue(Constants.LOGCONFIGSECTION, Constants.LOGCONFIGFILEPATH);
                    strFileName = ConfigFile.IniReadValue(Constants.LOGCONFIGSECTION, Constants.LOGCONFIGFILENAME);
                    Level = ConfigFile.IniReadValue(Constants.LOGCONFIGSECTION, Constants.LOGCONFIGLEVEL);
                    if(!Boolean.TryParse(ConfigFile.IniReadValue(Constants.LOGCONFIGSECTION, Constants.LOGCONFIGARCHIVEOLDFILE), out bArchiveOldFileOnStartup))
                    {
                        bArchiveOldFileOnStartup = true;
                    }
                    if(!Int32.TryParse(ConfigFile.IniReadValue(Constants.LOGCONFIGSECTION, Constants.LOGCONFIGBUFFERSIZE), out iBufferSize))
                    {
                        iBufferSize = 100;
                    }
                    if(!Int32.TryParse(ConfigFile.IniReadValue(Constants.LOGCONFIGSECTION, Constants.LOGCONFIGMAXARCHIVEFILES), out iMaxArchiveFiles))
                    {
                        iMaxArchiveFiles = 0;

                    }

                    

                }
                else
                {
                    strFileName = Constants.LOGFILENAME;
                    strfilepath = fileinfo.Directory.ToString();
                    Level = LogLevel.Info.ToString();
                    bArchiveOldFileOnStartup = true;
                    iBufferSize = 100;
                    iMaxArchiveFiles = 0;
                    ConfigFile.IniWriteValue(Constants.LOGCONFIGSECTION, Constants.LOGCONFIGFILEPATH, fileinfo.Directory.ToString());
                    ConfigFile.IniWriteValue(Constants.LOGCONFIGSECTION, Constants.LOGCONFIGFILENAME, strFileName);
                    ConfigFile.IniWriteValue(Constants.LOGCONFIGSECTION, Constants.LOGCONFIGLEVEL, LogLevel.Info.ToString());
                    ConfigFile.IniWriteValue(Constants.LOGCONFIGSECTION, Constants.LOGCONFIGARCHIVEOLDFILE, bArchiveOldFileOnStartup.ToString());
                    ConfigFile.IniWriteValue(Constants.LOGCONFIGSECTION, Constants.LOGCONFIGMAXARCHIVEFILES, iMaxArchiveFiles.ToString());
                    ConfigFile.IniWriteValue(Constants.LOGCONFIGSECTION, Constants.LOGCONFIGBUFFERSIZE, iBufferSize.ToString());

                }
                strFileName = string.IsNullOrEmpty(strFileName.Trim()) ? Constants.LOGFILENAME : strFileName.Trim();
                strlogfile = string.IsNullOrEmpty(strfilepath.Trim()) ? fileinfo.Directory + "\\" + strFileName : strfilepath + "\\" + strFileName;
                logLevel = DicLogLevels.ContainsKey(Level) ? LogLevel.FromString(Level) : LogLevel.Trace;
            }
            catch(Exception ex)
            {

            }
        }
        /// <summary>
        /// The trace log method.It writes log message to the log file
        /// </summary>
        /// <PARAM name="loglevel">The log level</PARAM>
        /// <PARAM name="strMsg">The log message</PARAM>
        public void TraceLog(LogLevel loglevel, String strMsg)
        {
            logger.Log(loglevel, strMsg);   
            
        }
        /// <summary>
        /// The trace exception log method.It writes the exception log message to the log file
        /// </summary>
        /// <PARAM name="ex">The raised exception</PARAM>
        /// <PARAM name="strMsg">The log message</PARAM>
        public void TraceException(Exception ex,String strMsg)
        {
            logger.Error(ex, strMsg);
        }
        /// <summary>
        /// The release log method.
        /// </summary>
        /// <PARAM name=""></PARAM>
        public void ReleaseLog()
        {
            DicLogLevels.Clear();
            NLog.LogManager.Shutdown();
        }
        #endregion
    }
}
