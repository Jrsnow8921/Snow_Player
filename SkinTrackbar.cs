//+--------------------------------------------------------------------------+
//|                                                                          |
//|                            VISTA_Track class                             |
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
//|   Started on : 10-17-2006 (MM-DD-YYYY)                                   |
//| Last revised : 12-15-2006 (MM-DD-YYYY)                                   |
//+--------------------------------------------------------------------------+

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

using Win32;
//using SkinEngine;

namespace SnowPlayer
{
    public partial class VISTA_Track : UserControl
    {
        private const bool Vert = false;
        private const bool Horz = true;

        private double value = 50;
        private double minimum = 0;
        private double maximum = 100;

        private bool ThumbMoving = false;
        private static int WasValue = 0;

        public VISTA_Track()
        {
            InitializeComponent();
        }

        private void TRACK_Load(object sender, EventArgs e)
        {
            if (minimum == 0 && maximum == 0)
            {
                // Set default value
                value = 50;
                if (Orientation() == Horz)
                { minimum = 0; maximum = 100; }
                else
                { minimum = 100; maximum = 0; }
            }
            // FORM_Tooltip colors
            //toolTip.BackColor = SK.TooltipBackColor;
            //toolTip.ForeColor = SK.TooltipForeColor;
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case Api.WM_ERASEBKGND:
                    Bitmap bmp;
                    Rectangle srceRect;
                    Rectangle destRect;

                    // Create a memory bitmap to use as double buffer
                    Bitmap offScreenBmp;
                    offScreenBmp = new Bitmap(this.Width, this.Height);
                    Graphics g = Graphics.FromImage(offScreenBmp);
                                       
                    if (this.BackgroundImage != null)
                    {
                        bmp = new Bitmap(this.BackgroundImage);
                        srceRect = new Rectangle(0, 0, bmp.Width, bmp.Height);
                        destRect = new Rectangle(0, 0, this.Width + 100, this.Height);
                        g.DrawImage(bmp, destRect, srceRect, GraphicsUnit.Pixel);
                        bmp.Dispose(); }
                    else {
                        SolidBrush myBrush = new SolidBrush(this.BackColor);
                        g.FillRectangle(myBrush, 0, 0, this.Width, this.Height);
                        myBrush.Dispose();
                    }

                    Pen LEFTorTOPblue = new Pen(Color.FromArgb(95, 140, 180));
                    Pen LEFTorTOPdark = new Pen(Color.FromArgb(55, 60, 74));
                    Pen MIDDLEblue = new Pen(Color.FromArgb(21, 56, 152));

                    Pen MIDDLEdark = new Pen(Color.FromArgb(0, 0, 0));
                    Pen RIGHTorBOTTOMblue = new Pen(Color.FromArgb(99, 130, 208));
                    Pen RIGHTorBOTTOMdark = new Pen(Color.FromArgb(87, 94, 110));

                    if (Orientation() == Horz) {
                        int y = ClientRectangle.Height / 2;
                        if (y * 2 < ClientRectangle.Height) y -= 1;

                        if (Minimum > Maximum)
                        {
                            g.DrawLine(LEFTorTOPdark, new Point(0, y - 1), new Point(BLUE_Thumb.Left + BLUE_Thumb.Width / 2, y - 1));
                            g.DrawLine(LEFTorTOPblue, new Point(BLUE_Thumb.Left + 1 + BLUE_Thumb.Width / 2, y - 1), new Point(ClientRectangle.Width, y - 1));
                            g.DrawLine(MIDDLEdark, new Point(0, y), new Point(BLUE_Thumb.Left + BLUE_Thumb.Width / 2, y));
                            g.DrawLine(MIDDLEblue, new Point(BLUE_Thumb.Left + 1 + BLUE_Thumb.Width / 2, y), new Point(ClientRectangle.Width, y));
                            g.DrawLine(RIGHTorBOTTOMdark, new Point(0, y + 1), new Point(BLUE_Thumb.Left + BLUE_Thumb.Width / 2, y + 1));
                            g.DrawLine(RIGHTorBOTTOMblue, new Point(BLUE_Thumb.Left + 1 + BLUE_Thumb.Width / 2, y + 1), new Point(ClientRectangle.Width, y + 1));
                        }
                        else
                        {
                            g.DrawLine(LEFTorTOPblue, new Point(0, y - 1), new Point(BLUE_Thumb.Left + BLUE_Thumb.Width / 2, y - 1));
                            g.DrawLine(LEFTorTOPdark, new Point(BLUE_Thumb.Left + 1 + BLUE_Thumb.Width / 2, y - 1), new Point(ClientRectangle.Width, y - 1));
                            g.DrawLine(MIDDLEblue, new Point(0, y), new Point(BLUE_Thumb.Left + BLUE_Thumb.Width / 2, y));
                            g.DrawLine(MIDDLEdark, new Point(BLUE_Thumb.Left + 1 + BLUE_Thumb.Width / 2, y), new Point(ClientRectangle.Width, y));
                            g.DrawLine(RIGHTorBOTTOMblue, new Point(0, y + 1), new Point(BLUE_Thumb.Left + BLUE_Thumb.Width / 2, y + 1));
                            g.DrawLine(RIGHTorBOTTOMdark, new Point(BLUE_Thumb.Left + 1 + BLUE_Thumb.Width / 2, y + 1), new Point(ClientRectangle.Width, y + 1));
                        }
                    }
                    else {
                        int x = ClientRectangle.Width / 2;

                        if (Minimum > Maximum)
                        {
                            g.DrawLine(LEFTorTOPdark, new Point(x - 1, 0), new Point(x - 1, BLUE_Thumb.Top + BLUE_Thumb.Width / 2));
                            g.DrawLine(LEFTorTOPblue, new Point(x - 1, BLUE_Thumb.Top + 1 + BLUE_Thumb.Width / 2), new Point(x - 1, ClientRectangle.Height));
                            g.DrawLine(MIDDLEdark, new Point(x, 0), new Point(x, BLUE_Thumb.Top + BLUE_Thumb.Width / 2));
                            g.DrawLine(MIDDLEblue, new Point(x, BLUE_Thumb.Top + 1 + BLUE_Thumb.Width / 2), new Point(x, ClientRectangle.Height));
                            g.DrawLine(RIGHTorBOTTOMdark, new Point(x + 1, 0), new Point(x + 1, BLUE_Thumb.Top + BLUE_Thumb.Width / 2));
                            g.DrawLine(RIGHTorBOTTOMblue, new Point(x + 1, BLUE_Thumb.Top + 1 + BLUE_Thumb.Width / 2), new Point(x + 1, ClientRectangle.Height));
                        }
                        else
                        {
                            g.DrawLine(LEFTorTOPblue, new Point(x - 1, 0), new Point(x - 1, BLUE_Thumb.Top + BLUE_Thumb.Width / 2));
                            g.DrawLine(LEFTorTOPdark, new Point(x - 1, BLUE_Thumb.Top + 1 + BLUE_Thumb.Width / 2), new Point(x - 1, ClientRectangle.Height));
                            g.DrawLine(MIDDLEblue, new Point(x, 0), new Point(x, BLUE_Thumb.Top + BLUE_Thumb.Width / 2));
                            g.DrawLine(MIDDLEdark, new Point(x, BLUE_Thumb.Top + 1 + BLUE_Thumb.Width / 2), new Point(x, ClientRectangle.Height));
                            g.DrawLine(RIGHTorBOTTOMblue, new Point(x + 1, 0), new Point(x + 1, BLUE_Thumb.Top + BLUE_Thumb.Width / 2));
                            g.DrawLine(RIGHTorBOTTOMdark, new Point(x + 1, BLUE_Thumb.Top + 1 + BLUE_Thumb.Width / 2), new Point(x + 1, ClientRectangle.Height));
                        }
                    }

                    // Draw thumb tracker
                    bmp = new Bitmap(BLUE_Thumb.BackgroundImage);
                    bmp.MakeTransparent(Color.FromArgb(255, 0, 255));
                    srceRect = new Rectangle(0, 0, BLUE_Thumb.Width, BLUE_Thumb.Height);
                    destRect = new Rectangle(BLUE_Thumb.Left, BLUE_Thumb.Top, BLUE_Thumb.Width, BLUE_Thumb.Height);
                    g.DrawImage(bmp, destRect, srceRect, GraphicsUnit.Pixel);
                    bmp.Dispose();

                    // Release pen resources
                    LEFTorTOPblue.Dispose();
                    LEFTorTOPdark.Dispose();
                    MIDDLEblue.Dispose();
                    MIDDLEdark.Dispose();
                    RIGHTorBOTTOMblue.Dispose();
                    RIGHTorBOTTOMdark.Dispose();

                    // Release graphics
                    g.Dispose();

                    // Swap memory bitmap (End double buffer)
                    g = Graphics.FromHdc(m.WParam);
                    g.DrawImage(offScreenBmp, 0, 0);
                    g.Dispose();
                    offScreenBmp.Dispose();

                    break;

                default:
                    base.WndProc(ref m);
                    break;
            }
        }

//----------------------------------------
        [Category("Action"), Description("Occurs when the slider is moved")]
        public event EventHandler ValueChanged;

        private void SendNotification()
        {
            if (ValueChanged != null)
            {
                ValueChanged(this, new EventArgs());
            }
            else
            {
                Api.SendMessage(Api.GetForegroundWindow(), Api.WM_COMMAND, (uint)this.Handle, (int)this.Handle);
            }
        }
//----------------------------------------

        private void SetThumbLocation()
        {
            Point pos = PointToClient(Cursor.Position);

            if (Orientation() == Horz)
            {
                BLUE_Thumb.Left = Math.Min(Math.Max(pos.X - BLUE_Thumb.Width / 2, 0), BLUE_Thumb.Parent.Width - BLUE_Thumb.Width);
                BLUE_Thumb.Top = ((ClientRectangle.Height - BLUE_Thumb.Width ) / 2);
                int range = ClientRectangle.Width - BLUE_Thumb.Width;
                double increment = (maximum - minimum) / range;
                value = (increment * BLUE_Thumb.Left) + minimum;
            }
            else
            {
                BLUE_Thumb.Left = (ClientRectangle.Width - BLUE_Thumb.Width) / 2 + 1;
                BLUE_Thumb.Top = Math.Min(Math.Max(pos.Y - BLUE_Thumb.Height / 2, 0), BLUE_Thumb.Parent.Height - BLUE_Thumb.Height);

                int range = ClientRectangle.Height - BLUE_Thumb.Height;
                double increment = (maximum - minimum) / range;
                value = (increment * BLUE_Thumb.Top) + minimum;
            }
            Value = value;

            if (WasValue != (int)value)
            {
                this.Invalidate();
                SendNotification();
                WasValue = (int)value;

                if (CheckOverThumb(pos.X, pos.Y))
                {
                    toolTip.SetToolTip(this, ((int)value).ToString());
                }
            }
        }

        private void THUMB_MouseDown(object sender, MouseEventArgs e)
        {
            ThumbMoving = true;
        }
        
        private bool CheckOverThumb(int x, int y)
        {
            Api.RECT r = new Api.RECT();
            r.left = BLUE_Thumb.Left;
            r.top = BLUE_Thumb.Top;
            r.right = r.left + BLUE_Thumb.Width;
            r.bottom = r.top + BLUE_Thumb.Height;
            Api.POINT p = new Api.POINT();
            p.x = x; p.y = y;
            return (Api.PtInRect(ref r, p));
        }

        private void THUMB_MouseMove(object sender, MouseEventArgs e)
        {
            if (ThumbMoving) SetThumbLocation();

            //BUG Vista, the animation stops while the tooltip is being shown!
            //----------------------------------------------------------------
            if (CheckOverThumb(e.X, e.Y) == false)
            {
            //    toolTip.SetToolTip(this, ((int)value).ToString());
            //}
            //else
            //{
                toolTip.SetToolTip(this, "");
            }

        }

        private void TRACK_MouseDown(object sender, MouseEventArgs e)
        {
            ThumbMoving = true;
            SetThumbLocation();
        }

        private void THUMB_MouseUp(object sender, MouseEventArgs e)
        {
            ThumbMoving = false;
        }

        // Retrieve the control orientation
        private bool Orientation()
        {
            bool orientation = Vert;
            if (this.Width > this.Height) orientation = Horz;
            return orientation;
        }

        public double Minimum
        {
            get
            {
                return (minimum);
            }
            set
            {
                double minimumBackup = minimum;
                minimum = value;
                ShowThumbPos();
            }
        }

        public double Maximum
        {
            get
            {
                return (maximum);
            }
            set
            {
                double maximumBackup = maximum;
                maximum = value;
                ShowThumbPos();
            }
        }

        public double Value
        {
            get
            {
                return (value);
            }
            set
            {
                double valueBackup = this.value;
                if (minimum > maximum)
                {
                    this.value = Math.Max(Math.Min(value, minimum), maximum);
                }
                else
                {
                    this.value = Math.Max(Math.Min(value, maximum), minimum);
                }
                ShowThumbPos();
            }
        }

        private void ShowThumbPos()
        {
            if (Orientation() == Horz)
            {
                BLUE_Thumb.Top = (ClientRectangle.Height - BLUE_Thumb.Width) / 2;
                int range = ClientRectangle.Width - BLUE_Thumb.Width;
                double increment = (maximum - minimum) / range;
                if (increment == 0) {
                    BLUE_Thumb.Left = 0; }
                else {
                BLUE_Thumb.Left = (int)((value - minimum) / increment);
                }
            }
            else
            {
                BLUE_Thumb.Left = (ClientRectangle.Width - BLUE_Thumb.Width) / 2 + 1;
                int range = ClientRectangle.Height - BLUE_Thumb.Height;
                double increment = (maximum - minimum) / range;
                if (increment == 0) { 
                    BLUE_Thumb.Top = 0; }
                else {
                BLUE_Thumb.Top = (int)((value - minimum) / increment);
                }
            }
            this.Invalidate();
        }

        //private void toolTip_Popup(object sender, PopupEventArgs e)
        //{

        //}

    }
}
