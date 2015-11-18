//Justin Snow SnowPlayer

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

using Win32;

namespace SkinEngine
{
    class SK
    {
        private static string usenamespace = null;
        public static string UseNameSpace
        {
            get { return usenamespace; }
            set { usenamespace = value; }
        }

        private static bool ismaximized = false;
        public static bool IsMaximized
        {
            get { return ismaximized; }
            set { ismaximized = value; }
        }

        private static bool isresizable = true;
        public static bool IsResizable
        {
            get { return isresizable; }
            set { isresizable = value; }
        }

        private static bool isdocked = false;
        public static bool IsDocked
        {
            get { return isdocked; }
            set { isdocked = value; }
        }

        private static Color tooltipbackcolor = SystemColors.Info;
        public static Color TooltipBackColor
        {
            get { return tooltipbackcolor; }
            set { tooltipbackcolor = value; }
        }

        private static Color tooltipforecolor = SystemColors.InfoText;
        public static Color TooltipForeColor
        {
            get { return tooltipforecolor; }
            set { tooltipforecolor = value; }
        }

        private static Color colorlayerbackground;
        public static Color ColorLayerBackground
        {
            get { return colorlayerbackground; }
            set { colorlayerbackground = value; }
        }

        private static Color colorcaptionenabled;
        public static Color ColorCaptionEnabled
        {
            get { return colorcaptionenabled; }
            set { colorcaptionenabled = value; }
        }

        private static Color colorcaptiondisabled;
        public static Color ColorCaptionDisabled
        {
            get { return colorcaptiondisabled; }
            set { colorcaptiondisabled = value; }
        }

        private static byte opacitylayerbackground = 254;
        public static byte OpacityLayerBackground
        {
            get { return opacitylayerbackground; }
            set { opacitylayerbackground = (byte)Math.Min((byte)value, (byte)254); }
        }

        private static byte alpha;
        public static byte Alpha
        {
            get { return alpha; }
            set { alpha = value; }
        }

        private static int lastrgnwidth;
        public static int LastRgnWidth
        {
            get { return lastrgnwidth; }
            set { lastrgnwidth = value; }
        }

        private static int lastrgnheight;
        public static int LastRgnHeight
        {
            get { return lastrgnheight; }
            set { lastrgnheight = value; }
        }

        private static int fixcaptionleft;
        public static int FixCaptionLeft
        {
            get { return fixcaptionleft; }
            set { fixcaptionleft = value; }
        }

        private static int fixcaptionright;
        public static int FixCaptionRight
        {
            get { return fixcaptionright; }
            set { fixcaptionright = value; }
        }

        private static int fixcaptionheight;
        public static int FixCaptionHeight
        {
            get { return fixcaptionheight; }
            set { fixcaptionheight = value; }
        }

        private static int undockingheight;
        public static int UnDockingHeight
        {
            get { return undockingheight; }
            set { undockingheight = value; }
        }

        private static int fixbottomheight;
        public static int FixBottomHeight
        {
            get { return fixbottomheight; }
            set { fixbottomheight = value; }
        }

        private static int dockheight;    // Docking
        public static int DockHeight      // Docking
        {
            get { return dockheight; }
            set { dockheight = value; }
        }

        private static int dockheightmax; // Docking
        public static int DockHeightMax   // Docking
        {
            get { return dockheightmax; }
            set { dockheightmax = value; }
        }

        private static int dockmin;       // Docking
        public static int DockMin         // Docking
        {
            get { return dockmin; }
            set { dockmin = value; }
        }

        private static bool usetransprencycolortopleft = false;
        public static bool UseTransparencyColorTopLeft
        {
            get { return usetransprencycolortopleft; }
            set { usetransprencycolortopleft = value; }
        }

        public unsafe static GraphicsPath CreateRegion(Bitmap bitmap)
        {
            GraphicsUnit unit = GraphicsUnit.Pixel;
            RectangleF boundsF = bitmap.GetBounds(ref unit);
            Rectangle bounds = new Rectangle((int)boundsF.Left, (int)boundsF.Top,
                               (int)boundsF.Width, (int)boundsF.Height);

            Color transparencyKey;
            if (UseTransparencyColorTopLeft)
            { transparencyKey = bitmap.GetPixel(0, 0); }
            else
            { transparencyKey = Color.FromArgb(255, 255, 0, 255); }

            uint key = (uint)((transparencyKey.A << 24) |
                              (transparencyKey.R << 16) |
                              (transparencyKey.G << 8) |
                              (transparencyKey.B << 0));

            // Access raw bits of the image
            BitmapData bitmapData = bitmap.LockBits(bounds, ImageLockMode.ReadOnly,
                                    PixelFormat.Format32bppArgb);
            uint* pixelPtr = (uint*)bitmapData.Scan0.ToPointer();

            // Get it only once
            int yMax = (int)boundsF.Height;
            int xMax = (int)boundsF.Width;

            // To store the rectangles
            GraphicsPath path = new GraphicsPath();

            for (int y = 0; y < yMax; y++)
            {
                // Store pointer to get next line from it
                byte* basePos = (byte*)pixelPtr;

                for (int x = 0; x < xMax; x++, pixelPtr++)
                {   // Is it transparent?
                    if (*pixelPtr == key) continue; // Yes, go on with the loop

                    // Store where scan starts
                    int x0 = x;
                    //not transparent - scan until we find the next transparent byte
                    while (x < xMax && (*pixelPtr != key))
                    {
                        ++x; pixelPtr++;
                    }
                    //add rectangle found to path
                    path.AddRectangle(new Rectangle(x0, y, x - x0, 1));
                }
                // Goto next line
                pixelPtr = (uint*)(basePos + bitmapData.Stride);
            }
            bitmap.UnlockBits(bitmapData);
            return path;
        }

        public static void CreateFormRegion(Control control, Bitmap bitmap)
        {   // Bail out if either control or bitmap are null
            if (control == null || bitmap == null) return;
            // Cast to a Form object
            Form form = (Form)control;
            // Create the region
            GraphicsPath path = CreateRegion(bitmap);
            // Apply new region to form
            form.Region = new Region(path);
            // Clean up
            path.Dispose();
        }

        // Combine child regions altogether. 
        public static void CombineRegion(ref IntPtr hRgnClip, IntPtr hRgn, int xOffset, int yOffset, int bmW, int bmH, int rgnX, int rgnY)
        {
            IntPtr hRgnTemp = Api.CreateRectRgn(0, 0, bmW, bmH);
            Api.OffsetRgn(hRgnTemp, xOffset, yOffset);
            Api.CombineRgn(hRgnClip, hRgnClip, hRgnTemp, Api.RGN_DIFF);
            Api.OffsetRgn(hRgnTemp, -xOffset, -yOffset);

            hRgnTemp = Api.CreateRectRgn(0, 0, bmW, bmH);
            Api.OffsetRgn(hRgn, rgnX, rgnY);
            Api.CombineRgn(hRgnTemp, hRgnTemp, hRgn, Api.RGN_AND);
            Api.OffsetRgn(hRgn, -rgnX, -rgnY);

            Api.OffsetRgn(hRgnTemp, xOffset, yOffset);
            Api.CombineRgn(hRgnClip, hRgnClip, hRgnTemp, Api.RGN_OR);
            Api.DeleteObject(hRgnTemp);
        }

        public static Bitmap GetBitmapFromResource(string imgName)
        {
            string path = string.Format("{0}.Properties.Resources", UseNameSpace);
            System.Resources.ResourceManager resourceManager = new System.Resources.ResourceManager(path, typeof(SK).Assembly);
            object obj = resourceManager.GetObject(imgName);
            return ((System.Drawing.Bitmap)(obj));
        }

        private static bool ispushbutton = false;
        private static bool IsPushButon
        {
            get { return ispushbutton; }
            set { ispushbutton = value; }
        }

        // Public properties
        public static Bitmap GetResourceBitmap(string ResourceName)
        {
            IsPushButon = false;
            Bitmap bmp = null;
            switch (ResourceName)
            {
                case "BTN_Up":         // Don't change the case
                case "BTN_Left":       // Don't change the case
                case "BTN_Right":      // Don't change the case
                case "BTN_Down":       // Don't change the case
                case "BTN_Reset":      // Don't change the case
                case "BTN_Pause":      // Don't change the case
                case "BTN_Play":       // Don't change the case
                case "BTN_SelectFile": // Don't change the case
                case "BTN_FullScreen": // Don't change the case
                case "BTN_Mute_On":    // Don't change the case
                case "BTN_Mute_Off":   // Don't change the case
                case "BTN_Stop":       // Don't change the case

                case "BTN_Close":      // Don't change the case
                case "BTN_Iconize":    // Don't change the case
                case "BTN_Restore":    // Don't change the case
                case "BTN_Maximize":   // Don't change the case
                case "BTN_DockOut":    // Don't change the case
                case "BTN_DockIn":     // Don't change the case
                case "BTN_About":      // Don't change the case
                    bmp = GetBitmapFromResource(ResourceName);
                    break;
                default: bmp = GetBitmapFromResource("BTN_Push"); IsPushButon = true; break;
            }
            return bmp;
        }

        public static void USE_BTN_Image(Button btn, int UseImage)
        {
            Bitmap bmpBack = new Bitmap(btn.Width, btn.Height);
            Bitmap bmp = GetResourceBitmap(btn.Name);
            if (bmp != null)
            {
                StretchBltButton(UseImage, btn, bmp, bmpBack);
                btn.BackgroundImage = bmpBack;
            }
        }

        public static void InitButton(Button btn)
        {
            int UseImage;
            if (btn.Enabled) { UseImage = 1; } else { UseImage = 3; }
            USE_BTN_Image(btn, UseImage);
        }

        private static void StretchBltButton(int UseImage, Button btn, Bitmap bmp, Bitmap bmpBack)
        {
            if (btn == null || bmp == null || bmpBack == null) return;

            Graphics g = Graphics.FromImage(bmpBack);

            Rectangle srceRect, destRect;
            int x, bmpWidth = bmp.Width / 5;

            x = (bmpWidth * UseImage) - bmpWidth;

            if (IsPushButon) // Adapt the size of the bitmap to the button's.
            {
                int xSet = 4;
                int ySet = 4;

                // Horizontal up
                destRect = new Rectangle(btn.Width - xSet, 0, xSet, ySet); ;
                srceRect = new Rectangle(bmpWidth * UseImage - xSet, 0, xSet, ySet);
                g.DrawImage(bmp, destRect, srceRect, GraphicsUnit.Pixel);
                destRect = new Rectangle(xSet, 0, btn.Width - xSet * 2, ySet);
                srceRect = new Rectangle(x + xSet, 0, bmpWidth - xSet * 2, ySet);
                g.DrawImage(bmp, destRect, srceRect, GraphicsUnit.Pixel);

                // Vertical left
                destRect = new Rectangle(0, 0, xSet, ySet);
                srceRect = new Rectangle(x, 0, xSet, ySet);
                g.DrawImage(bmp, destRect, srceRect, GraphicsUnit.Pixel);
                destRect = new Rectangle(0, ySet, xSet, btn.Height - ySet * 2);
                srceRect = new Rectangle(x, ySet, xSet, bmp.Height - ySet * 2);
                g.DrawImage(bmp, destRect, srceRect, GraphicsUnit.Pixel);
                destRect = new Rectangle(0, btn.Height - ySet, xSet, ySet);
                srceRect = new Rectangle(x, bmp.Height - ySet, xSet, ySet);
                g.DrawImage(bmp, destRect, srceRect, GraphicsUnit.Pixel);

                // Middle button
                destRect = new Rectangle(xSet, ySet, btn.Width - xSet * 2, btn.Height - ySet * 2);
                srceRect = new Rectangle(x + xSet, ySet, bmpWidth - xSet * 2, bmp.Height - ySet * 2);
                g.DrawImage(bmp, destRect, srceRect, GraphicsUnit.Pixel);

                // Horizontal down
                destRect = new Rectangle(xSet, btn.Height - ySet, btn.Width - xSet * 2, ySet);
                srceRect = new Rectangle(x + xSet, bmp.Height - ySet, bmpWidth - xSet * 2, ySet);
                g.DrawImage(bmp, destRect, srceRect, GraphicsUnit.Pixel);

                // Vertical right
                destRect = new Rectangle(btn.Width - xSet, ySet, xSet, btn.Height - ySet * 2);
                srceRect = new Rectangle(bmpWidth * UseImage - xSet, ySet, xSet, bmp.Height - ySet * 2);
                g.DrawImage(bmp, destRect, srceRect, GraphicsUnit.Pixel);
                destRect = new Rectangle(btn.Width - xSet, btn.Height - ySet, xSet, ySet);
                srceRect = new Rectangle(bmpWidth * UseImage - xSet, bmp.Height - ySet, xSet, ySet);
                g.DrawImage(bmp, destRect, srceRect, GraphicsUnit.Pixel);

            }
            else
            {
                destRect = new Rectangle(0, 0, btn.Width, btn.Height);
                srceRect = new Rectangle(x, 0, bmpWidth, bmp.Height);
                g.DrawImage(bmp, destRect, srceRect, GraphicsUnit.Pixel);
            }

            g.Dispose();
        }

        public static void CreateButtonRegion(Control control)
        {

            if (control == null) return; // Bail out if control is null
            // Cast to a button object
            Button btn = (Button)control;

            Bitmap bmp = GetResourceBitmap(btn.Name);

            if (bmp == null) return;// Bail if bmp is null

            Bitmap bmpBack = new Bitmap(btn.Width, btn.Height);

            StretchBltButton(1, btn, bmp, bmpBack);

            // Create the region
            GraphicsPath path = CreateRegion(bmpBack);
            // Apply new region
            btn.Region = new Region(path);
            // Clean up
            bmpBack.Dispose();
            bmp.Dispose();
            path.Dispose();

            // Init btn (to show enabled/disabled mode)
            InitButton(btn);
        }

        public static Bitmap DrawBackGround(int RgnWidth, int RgnHeight)
        {
            if ((RgnWidth == 0) || (RgnHeight == 0)) return null;

            Rectangle srceRect, destRect;
            Bitmap bmpFrmBack, bmp;

            bmpFrmBack = new Bitmap(RgnWidth, RgnHeight);

            Graphics g = Graphics.FromImage(bmpFrmBack);

            bmp = GetBitmapFromResource("TopLeft");
            srceRect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            destRect = new Rectangle(0,
                                     0,
                                     FixCaptionLeft,
                                     FixCaptionHeight);
            g.DrawImage(bmp, destRect, srceRect, GraphicsUnit.Pixel);
            bmp.Dispose();

            bmp = GetBitmapFromResource("SideLeft");
            srceRect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            destRect = new Rectangle(0,
                                     FixCaptionHeight,
                                     FixCaptionLeft,
                                     Math.Max(RgnHeight - FixCaptionHeight - FixBottomHeight + 4, 0));
            g.DrawImage(bmp, destRect, srceRect, GraphicsUnit.Pixel);
            bmp.Dispose();

            bmp = GetBitmapFromResource("BottomLeft");
            srceRect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            destRect = new Rectangle(0,
                                     RgnHeight - FixBottomHeight,
                                     FixCaptionLeft,
                                     FixBottomHeight);
            g.DrawImage(bmp, destRect, srceRect, GraphicsUnit.Pixel);
            bmp.Dispose();

            bmp = GetBitmapFromResource("TopSide");
            srceRect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            destRect = new Rectangle(FixCaptionLeft,
                                     0,
                                     Math.Max(RgnWidth - FixCaptionLeft - FixCaptionRight + 8, 0),
                                     FixCaptionHeight);
            g.DrawImage(bmp, destRect, srceRect, GraphicsUnit.Pixel);
            bmp.Dispose();

            bmp = GetBitmapFromResource("Center");
            srceRect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            destRect = new Rectangle(FixCaptionLeft,
                                     FixCaptionHeight,
                                     Math.Max(RgnWidth - FixCaptionLeft - FixCaptionRight + 8, 0),
                                     Math.Max(RgnHeight - FixCaptionHeight - FixBottomHeight + 4, 0));
            g.DrawImage(bmp, destRect, srceRect, GraphicsUnit.Pixel);
            bmp.Dispose();

            bmp = GetBitmapFromResource("BottomSide");
            srceRect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            destRect = new Rectangle(FixCaptionLeft,
                                     RgnHeight - FixBottomHeight,
                                     Math.Max(RgnWidth - FixCaptionLeft - FixCaptionRight + 8, 0),
                                     FixBottomHeight);
            g.DrawImage(bmp, destRect, srceRect, GraphicsUnit.Pixel);
            bmp.Dispose();

            bmp = GetBitmapFromResource("TopRight");
            srceRect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            destRect = new Rectangle(RgnWidth - FixCaptionRight,
                                     0,
                                     FixCaptionRight,
                                     FixCaptionHeight);
            g.DrawImage(bmp, destRect, srceRect, GraphicsUnit.Pixel);
            bmp.Dispose();

            bmp = GetBitmapFromResource("SideRight");
            srceRect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            destRect = new Rectangle(RgnWidth - FixCaptionRight,
                                     FixCaptionHeight,
                                     FixCaptionRight,
                                     Math.Max(RgnHeight - FixCaptionHeight - FixBottomHeight + 4, 0));
            g.DrawImage(bmp, destRect, srceRect, GraphicsUnit.Pixel);
            bmp.Dispose();

            bmp = GetBitmapFromResource("BottomRight");
            srceRect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            destRect = new Rectangle(RgnWidth - FixCaptionRight,
                                     RgnHeight - FixBottomHeight,
                                     FixCaptionRight,
                                     FixBottomHeight);
            g.DrawImage(bmp, destRect, srceRect, GraphicsUnit.Pixel);
            bmp.Dispose();

            g.Dispose();

            return bmpFrmBack;
        }

        // Rebuild new region from previous one 
        public static void BuildRegion(IntPtr hWnd)
        {
            IntPtr hRgnClip = IntPtr.Zero;
            Api.RECT rw = new Api.RECT();
            Api.GetWindowRect(hWnd, ref rw);
            int RgnWidth = rw.right - rw.left, RgnHeight = rw.bottom - rw.top;

            // Avoid changing region when iconized !
            if (RgnHeight < DockMin) return;

            if ((LastRgnWidth == RgnWidth) && (LastRgnHeight == RgnHeight)) return;

            IntPtr hRgn = Api.CreateRectRgn(0, 0, 0, 0);
            if (hRgn != IntPtr.Zero)
            {
                if (Api.GetWindowRgn(hWnd, hRgn))
                {
                    hRgnClip = Api.CreateRectRgn(0, 0, RgnWidth, RgnHeight);
                    if (hRgnClip != IntPtr.Zero)
                    {
                        // Top left corner.
                        int rgnX = 0; int rgnY = 0;
                        CombineRegion(ref hRgnClip, hRgn, 0, 0, FixCaptionLeft, FixCaptionHeight, rgnX, rgnY);

                        // Top right corner.
                        rgnX = -LastRgnWidth + FixCaptionRight; rgnY = 0;
                        CombineRegion(ref hRgnClip, hRgn, RgnWidth - FixCaptionRight, 0, FixCaptionRight, FixCaptionHeight, rgnX, rgnY);

                        // Bottom left corner.
                        rgnX = 0; rgnY = -LastRgnHeight + FixBottomHeight;
                        CombineRegion(ref hRgnClip, hRgn, 0, RgnHeight - FixBottomHeight, FixCaptionLeft, FixBottomHeight, rgnX, rgnY);

                        // Bottom right corner.
                        rgnX = -LastRgnWidth + FixCaptionRight; rgnY = -LastRgnHeight + FixBottomHeight;
                        CombineRegion(ref hRgnClip, hRgn, RgnWidth - FixCaptionRight, RgnHeight - FixBottomHeight, FixCaptionRight, FixBottomHeight, rgnX, rgnY);

                        Form.FromHandle(hWnd).BackgroundImage = (Bitmap)SK.DrawBackGround(RgnWidth, RgnHeight);

                        // Set the new region to the form.
                        Api.SetWindowRgn(hWnd, hRgnClip, false);

                        // Save the new region size
                        LastRgnWidth = RgnWidth; LastRgnHeight = RgnHeight;
                    }
                }
                Api.DeleteObject(hRgn);
            }
        }

    }
}

