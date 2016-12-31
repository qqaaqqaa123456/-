using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
namespace 元旦惊喜
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
         Class1 c = new Class1();
        private  void button1_Click(object sender, EventArgs e)
        {
            try
            {
            if (textBox1.Text!=""&&textBox2.Text!="")
            {
               string text = "你好，祝你新年快乐！";
               c.sendTheMail(textBox1.Text, textBox5.Text, textBox6.Text, textBox3.Text,textBox4.Text, textBox2.Text, "新年快乐", text);
               Class2 c2 = new Class2();
               c2.Test(text); 
            }
            }
            catch 
            {
               
            }
        }
    }
}
