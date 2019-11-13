using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homowork_4
{
    public partial class Form1 : Form
    {
        private string pf;
        private string ps;
        Functional fun = new Functional();

        public Form1()
        {
            InitializeComponent();
            pf = ps = Directory.GetCurrentDirectory();
            CurrentLocal(listView1, pf, groupBox1);
            CurrentLocal(listView2, ps, groupBox2);
        }
        private void listView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (listView1.SelectedItems.Count == 0)
                    return;
                ListViewItem item = listView1.SelectedItems[0];
                pf = pf + @"\"+ item.Text;
                CurrentLocal(listView1, pf, groupBox1);
            }
        }
        private void listView2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (listView2.SelectedItems.Count == 0)
                    return;
                ListViewItem item = listView2.SelectedItems[0];
                ps = ps + @"\" + item.Text;
                CurrentLocal(listView2, ps, groupBox2);
            }
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            pf = fun.BackL(pf);
            CurrentLocal(listView1, pf, groupBox1);
        }
        private void button2_Click(object sender, EventArgs e)
        {
           ps = fun.BackR(ps);
           CurrentLocal(listView2, ps, groupBox2);
        }
        private void button3_Click(object sender, EventArgs e)
        {
           pf = fun.MyHomeL();
           CurrentLocal(listView1, pf, groupBox1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
           ps = fun.MyHomeR();
           CurrentLocal(listView2, ps, groupBox2);
        } 

        private void button5_Click(object sender, EventArgs e)
        {
            Question f = new Question();
            f.ShowDialog();
            fun.Create(pf + @"\" + f.Quest());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Question f = new Question();
            f.ShowDialog();
            fun.Delete(pf+@"\"+ f.Quest());
        }
        private void CurrentLocal(ListView l, string path, GroupBox b)
        {
            b.Text = path;
            l.Items.Clear();
            l.SmallImageList = imageList1;
            for (int i = 0; i < fun.AllFiles(path).Length; i++)
            {
                    l.Items.Add(fun.AllFiles(path)[i]);
                    l.Items[i].SubItems.Add(fun.TimeAllFiles(fun.Direct(path).Length, fun.Files(path).Length, path)[i]);
            }
            for (int i = 0; i < fun.Direct(path).Length; i++)
            {
                l.Items[i].ImageIndex = 1;
            }
            for (int i = fun.Direct(path).Length; i < fun.Files(path).Length + fun.Direct(path).Length; i++)
            {
                l.Items[i].ImageIndex = 0;
            }
            

        }
        private void button7_Click(object sender, EventArgs e)
        {
            Question f = new Question();
            f.ShowDialog();
            Process.Start(pf+@"\" + f.Quest());
        }

        private void button10_Click(object sender, EventArgs e)
        {
            fun.Create(ps);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            fun.Delete(ps);
        }

        private void светлоеБудущееToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("Fun.mp3");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Question f = new Question();
            f.ShowDialog();
            Process.Start(ps + f.Quest());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < fun.Drives().Length; i++)
            {
                comboBox1.Items.Add(fun.Drives()[i]);
                comboBox2.Items.Add(fun.Drives()[i]);
            }
            comboBox1.SelectedIndex = comboBox2.SelectedIndex = 0;
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            pf = comboBox1.Text;
            CurrentLocal(listView1, pf, groupBox1);
        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            ps = comboBox2.Text;
            CurrentLocal(listView2, ps, groupBox2);
        }

        private void listView1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void listView1_DragDrop(object sender, DragEventArgs e)
        {
            listView1.Items.Add(e.Data.ToString());
        }

        private void listView2_DragDrop(object sender, DragEventArgs e)
        {
            listView2.Items.Add(e.Data.ToString());
        }
    }
}

