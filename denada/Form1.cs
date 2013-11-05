using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars.Docking;
using denada.USerControl;

namespace denada
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void navBarItem2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (xtraScrollableControl1.Controls.Count > 0) xtraScrollableControl1.Controls.RemoveAt(0);
            xtraScrollableControl1.Controls.Add(new Compagnes());
        }

        private void navBarItem3_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if(xtraScrollableControl1.Controls.Count>0) xtraScrollableControl1.Controls.RemoveAt(0);
            xtraScrollableControl1.Controls.Add(new Filtres());
        }

        private void navBarItem8_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (xtraScrollableControl1.Controls.Count > 0) xtraScrollableControl1.Controls.RemoveAt(0);
            xtraScrollableControl1.Controls.Add(new ListePrix());
        }

        private void navBarItem9_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (xtraScrollableControl1.Controls.Count > 0) xtraScrollableControl1.Controls.RemoveAt(0);
            xtraScrollableControl1.Controls.Add(new Optimization());
        }


    }
}
