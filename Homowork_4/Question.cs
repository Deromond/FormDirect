using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homowork_4
{
    public partial class Question : Form
    {
        private string question;
        public Question()
        {
            InitializeComponent();
        }
        public string Quest()
        {
            return textBox1.Text;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
