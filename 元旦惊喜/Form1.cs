using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
namespace 元旦惊喜
{
    public partial class Form1 : Form,IDisposable
    {
        public Form1()
        {
            InitializeComponent();
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
        public void StopAndClean()
        {
            GC.Collect(GC.GetGeneration(this),GCCollectionMode.Forced,true);
        }
        ~Form1()
        {
            Process.GetCurrentProcess().Kill();
            Dispose(true);
        }
        public new void Dispose()
        {
            StopAndClean();
        }
    }
}
