using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 元旦惊喜
{
    partial class AboutBox1 : Form
    {
        public AboutBox1()
        {
            InitializeComponent();
            this.Text = string.Format("关于 {0}", test.AssemblyTitle);
            this.labelProductName.Text = test.AssemblyProduct;
            this.labelVersion.Text = string.Format("版本 {0}", test.AssemblyVersion);
            this.labelCopyright.Text = test.AssemblyCopyright;
            this.labelCompanyName.Text = test.AssemblyCompany;
            this.textBoxDescription.Text = test.AssemblyDescription;
        }
        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
