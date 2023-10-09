using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Windows.Forms;

using FileCreateSupportClass;

namespace SimpleLogClass
{
    static class SimpleLog
    {
        static public string Write()
        {
            return Write("--");

        }

        static public string Write(string message)
        {
            var caller = new System.Diagnostics.StackFrame(1, false);
            string LogDirname = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), @"Log\" + caller.GetFileName());
            string LogFilename = Path.Combine(LogDirname, DateTime.Now.ToString(@"yyyy\\yyyyMM\\yyyyMMdd") + ".txt");
            DirectoryCheck.Create(Path.GetDirectoryName(LogFilename));

            string callCodeInfo = caller.GetMethod().Name + ", Line = " + caller.GetFileLineNumber().ToString();
            string logLine = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "\t" + callCodeInfo + "\t" + message ;
            File.AppendAllText(LogFilename, logLine + "\r\n");

            return logLine;

        }
    }
}
