using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Season_Renamer
{
    public partial class Form1 : Form
    {
        string path = "";
        string[] files;
        TextBox txtbox, type;

        public Form1()
        {
            InitializeComponent();
            Controls.Add(CreateButton(100, 20, "Rename", 20, 0, DOIT));
            Controls.Add((txtbox = CreateTextBox(100, 20, 50, 0)));
            Controls.Add((type = CreateTextBox(100, 20, 70, 0)));
            Shown += FormShown;
        }

        private void DOIT(object sender, EventArgs e)
        {
            int episode = 1;
            int season;
            try
            {
                season = int.Parse(txtbox.Text);
            }
            catch
            {
                return;
            }
            foreach (string s in files)
            {
                try
                {
                    if (s != path + "\\Season Renamer.exe")
                        File.Move(s, path + "/S" + season.ToString("00") + "E" + episode++.ToString("00") + "." + type.Text);
                }
                catch
                {

                }
            }
        }

        private void FormShown(object sender, EventArgs e)
        {
            path = Directory.GetCurrentDirectory();
            files = Directory.GetFiles(path);
        }

        private Button CreateButton(int w, int h, string txt, int y, int x, EventHandler act)
        {
            Button btn = new Button();
            btn.Width = w;
            btn.Height = h;
            btn.Text = txt;
            btn.Left = x;
            btn.Top = y;
            btn.Click += act;
            return btn;
        }
        
        private TextBox CreateTextBox(int w, int h, int y, int x)
        {
            TextBox txt = new TextBox();
            txt.Width = w;
            txt.Height = h;
            txt.Left = x;
            txt.Top = y;
            return txt;
        }
    }
}
