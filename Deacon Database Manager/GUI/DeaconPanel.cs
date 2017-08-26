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
    public partial class DeaconPanel : Form
    {
        private HomeScreen homeScreen;
        public DeaconPanel(HomeScreen homeScreen)
        {
            InitializeComponent();
            this.homeScreen = homeScreen;
        }
    }
}
