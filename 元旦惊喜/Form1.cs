using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
namespace 元旦惊喜
{
    public partial class Form1 : Form,IDisposable
    {
        public Form1()
        {
            InitializeComponent();
            this.ControlBox = false;  
            test.c2.ShowSomething();
        }

        private  void button1_Click(object sender, EventArgs e)
        {
            try
            {
            if (textBox1.Text!=""&&textBox2.Text!="" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "")
            {
               string text = "你好，祝你新年快乐！";
               test.c1.sendTheMail(textBox1.Text, textBox5.Text, textBox6.Text, textBox3.Text,textBox4.Text, textBox2.Text, "新年快乐", text);
            }
            }
            catch (Exception ex)
            {
                test.log.LogError(ex.Message);
            }
        }
        private void A(object sender, MouseEventArgs e)
        {
            if (this.checkBox1.Checked)
            {
                textBox4.Text = "yh20021212@126.com";
                textBox6.Text = "yh20021212";
                textBox3.Text = "123456ABCD!@";
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            AboutBox1 about = new AboutBox1();
            about.ShowDialog();
        }
        public  void StopAndClean()
        {
            Thread.CurrentThread.Abort();
            Process.GetCurrentProcess().Kill();
            if (Debugger.IsAttached)
            Dispose();
        }
        public new void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
            return;
        }
        delegate void TEST(object a, object b, object c, object d);
        private  void testtest(object a,object b,object c,object d)
        {
            Close();
            StopAndClean();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            testtest(1, 2, 3, 4);
        }
    }
}
