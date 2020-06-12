using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Concrete;
using SportsStore.Domain.Entities;
namespace SportsStore.WebUI.Utility
{
    public enum LogTarget
    {
        File, Database, EventLog
    }
    public abstract class LogBase
    {
        public abstract void Log(logDetail message);
    }
    public class FileLogger : LogBase
    {
        public string filePath = @"D:\IDGLog.txt";
        public override void Log(logDetail message)
        {
            using (StreamWriter streamWriter = new StreamWriter(filePath))
            {
                streamWriter.WriteLine(message.ActionName);
                streamWriter.Close();
            }
        }
    }

    public class DBLogger : LogBase
    {
        string connectionString = string.Empty;
        public override void Log(logDetail message)
        {

            LogProcessToDB SaveToDBObj = new LogProcessToDB();
            SaveToDBObj.LoginDb(message);
            //Code to log data to the database
        }
    }

    public class EventLogger : LogBase
    {
        public override void Log(logDetail message)
        {
            EventLog eventLog = new EventLog("Application");              
            eventLog.Source = "Application";
            eventLog.WriteEntry("Log message example", EventLogEntryType.Information, 101, 1);

        }
    }
}