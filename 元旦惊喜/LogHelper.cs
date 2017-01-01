using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 元旦惊喜
{
public  class LogHelper
{
    private static readonly Thread WriteThread;
    private static readonly Queue<string> MsgQueue;
    private static readonly object FileLock;
    private static readonly string FilePath;
    private static readonly LogHelper l = new LogHelper();
    internal static Queue<string> MsgQueue1
    {
       get
       {
        return MsgQueue;
        }
    }
        internal static object FileLock1
        {
            get
            {
                return FileLock;
            }
        }

        internal static string FilePath1
        {
            get
            {
                return FilePath;
            }
        }

        static LogHelper()
    {
        FileLock = new object();
        FilePath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "log\\";
        WriteThread = new Thread(l.WriteMsg);
        MsgQueue = new Queue<string>();
        WriteThread.Start();
    }
    public virtual  void LogInfo(string msg)
    {
        Monitor.Enter(MsgQueue);
        MsgQueue.Enqueue(string.Format("{0} {1} {2}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:sss"), "Info", msg));
        Monitor.Exit(MsgQueue);
    }
    public virtual  void LogError(string msg)
    {
        Monitor.Enter(MsgQueue);
        MsgQueue.Enqueue(string.Format("{0} {1} {2}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:sss"), "Error", msg));
        Monitor.Exit(MsgQueue);
    }
    public virtual  void LogWarn(string msg)
    {
        Monitor.Enter(MsgQueue);
        MsgQueue.Enqueue(string.Format("{0} {1} {2}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:sss"), "Warn", msg));
        Monitor.Exit(MsgQueue);
    }
    internal virtual  void WriteMsg()
    {
        while (true)
        {
            if (MsgQueue.Count > 0)
            {
                Monitor.Enter(MsgQueue);
                string msg = MsgQueue.Dequeue();
                Monitor.Exit(MsgQueue);
                Monitor.Enter(FileLock);
                if (!Directory.Exists(FilePath))
                {
                    Directory.CreateDirectory(FilePath);
                }
                string fileName = FilePath + DateTime.Now.ToString("yyyy-MM-dd") + ".log";
                var logStreamWriter = new StreamWriter(fileName, true);
                logStreamWriter.WriteLine(msg);
                logStreamWriter.Flush();
                logStreamWriter.Close();
                Monitor.Exit(FileLock);
                if (GetFileSize(fileName) > 1024 * 5)
                {
                    CopyToBak(fileName);
                }
            }
        }
    }
    internal static long GetFileSize(string fileName)
    {
        long strRe = 0;
        if (File.Exists(fileName))
        {
            Monitor.Enter(FileLock);
            var myFs = new FileStream(fileName, FileMode.Open);
            strRe = myFs.Length / 1024;
            myFs.Close();
            myFs.Dispose();
            Monitor.Exit(FileLock);
        }
        return strRe;
    }
    internal static void CopyToBak(string sFileName)
    {
        int fileCount = 0;
        string sBakName = "";
        Monitor.Enter(FileLock);
        do
        {
            fileCount++;
            sBakName = sFileName + "." + fileCount + ".BAK";
        }
        while (File.Exists(sBakName));
        File.Copy(sFileName, sBakName);
        File.Delete(sFileName);
        Monitor.Exit(FileLock);
    }
}  
}