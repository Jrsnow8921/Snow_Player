//+--------------------------------------------------------------------------+
//|                                                                          |
//|                            SkinButton class                              |
//|                                                                          |
//+--------------------------------------------------------------------------+
//|                                                                          |
//|                         Author Patrice TERRIER                           |
//|                           copyright (c) 2006                             |
//|                                                                          |
//|                        pterrier@zapsolution.com                          |
//|                                                                          |
//|                          www.zapsolution.com                             |
//|                                                                          |
//+--------------------------------------------------------------------------+
//|                  Project started on : 11-08-2006 (MM-DD-YYYY)            |
//|                        Last revised : 11-09-2006 (MM-DD-YYYY)            |
//+--------------------------------------------------------------------------+

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using SkinEngine;
using Win32;

namespace SnowPlayer
{
    public partial class SkinButton : System.Windows.Forms.Button
    {
        [Category("Configuration"), Browsable(true), Description("The bitmap resource name")]
        public String Resource
        {
            get { return this.Name; }
            set { this.Name = value; }
        }

        public SkinButton()
        {
            InitializeComponent();
            CreateButtonRegion();
        }

        private void CreateButtonRegion()
        {
            SK.UseNameSpace = this.GetType().Namespace;
            // Use default Magenta, instead of TopLeft(0,0) pixel color
            SK.UseTransparencyColorTopLeft = true; // false;
            // Create the button region
            Button btn = ((Button)this);
            SK.CreateButtonRegion(btn);
        }

        private void SKIN_Resize(object sender, EventArgs e)
        {
            CreateButtonRegion();
        }

        private void BTN_MouseEnter(object sender, EventArgs e)
        {
            Button btn = ((Button)sender);
            SK.USE_BTN_Image(btn, 5);
        }

        private void BTN_MouseLeave(object sender, EventArgs e)
        {
            Button btn = ((Button)sender);
            SK.USE_BTN_Image(btn, 1);
        }

        private void BTN_MouseUp(object sender, MouseEventArgs e)
        {
            Button btn = ((Button)sender);
            SK.USE_BTN_Image(btn, 1);
        }

        private void BTN_MouseDown(object sender, MouseEventArgs e)
        {
            Button btn = ((Button)sender);
            SK.USE_BTN_Image(btn, 2);
        }

        private void BTN_EnabledChanged(object sender, EventArgs e)
        {
            Button btn = ((Button)sender);
            SK.InitButton(btn);
        }

        private void BTN_TextChanged(object sender, EventArgs e)
        {

        }

    }
}

