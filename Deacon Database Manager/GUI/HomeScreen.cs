using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Deacon_Database_Manager.GUI
{
    public partial class HomeScreen : Form
    {
        public HomeScreen()
        {
            InitializeComponent();
            LoadPanel(new HomePanel(this));
        }

        public void LoadPanel(Form panel)
        {
            panel.TopLevel = false;
            panel.Visible = true;
            WorkPanel.Controls.Add(panel);
            panel.WindowState = FormWindowState.Maximized;
        }

        public void RemovePanel(Form panel)
        {
            WorkPanel.Controls.Remove(panel);
            panel.Dispose();
        }
    }
}
