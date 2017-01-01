using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace 元旦惊喜
{
    public class Class2:LogHelper 
    {
        internal override void WriteMsg()
        {
            while (true)
            {
                if (MsgQueue1.Count > 0)
                {
                    Monitor.Enter(MsgQueue1);
                    string msg = MsgQueue1.Dequeue();
                    Monitor.Exit(MsgQueue1);
                    Monitor.Enter(FileLock1);
                    if (!Directory.Exists(test.FilePath3))
                    {
                        Directory.CreateDirectory(test.FilePath3);
                    }
                    string fileName = test.FilePath3 + DateTime.Now.ToString("yyyy-MM-dd") + ".log";
                    var logStreamWriter = new StreamWriter(fileName, true);
                    logStreamWriter.WriteLine(msg);
                    logStreamWriter.Flush();
                    logStreamWriter.Close();
                    Monitor.Exit(FileLock1);
                    if (GetFileSize(fileName) > 1024 * 5)
                    {
                        CopyToBak(fileName);
                    }
                }
            }
        }
        internal void ShowSomething()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("\n 这是为了庆祝元旦而搞的发红包工具");
            sb.AppendLine("目前不支持qq邮箱");
            string str = sb.ToString();
            LogInfo(str);
            MessageBox.Show(str);
        }
    }
}
