//Snowplay Justin Snow

using System;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;

using Win32;
using SkinEngine;

using Microsoft.DirectX.AudioVideoPlayback;

using Microsoft.Win32;
using System.IO;

namespace SnowPlayer
{
    public partial class MAIN_Form : Form
    {
        IntPtr hFORM_Main = IntPtr.Zero;         // Default to Zero

        //const string RegistryKey = @"HKEY_LOCAL_MACHINE\SOFTWARE\zMoviePlayer";
        //const string RegistryPath = "DefaultPathName";
        //const string RegistryAudioVolume = "AudioVolume";
        //const string RegistryStringData = "StringData";

        bool FullScreen = false;
        bool ScrollEnable = false;
        bool MuteMode = false;
        bool HDmovie = false;
        bool Movie_Timer_Enabled = false;
        Video Movie;
        Size MovieDefaultSize;
        string movieDuration;
        float Aspect;
        int hours, minutes, seconds, MovieDuration, MovieCurrentPosition;
        int CommandPanelHeight;
        int InitialClientWidth;

        public MAIN_Form(string MediaFile)
        {
            hFORM_Main = this.Handle;

            InitializeComponent();

            Size MovieArea;
            BTN_Play.Enabled = BTN_Pause.Enabled = BTN_Stop.Enabled = false;
            Aspect = (float)Screen.ClientSize.Width / (float)Screen.ClientSize.Height;
            MovieArea = new Size(this.Width - this.ClientSize.Width, this.Height - this.ClientSize.Height);
            InitialClientWidth = this.ClientSize.Width;
            this.MinimumSize = new Size(this.Width, MovieArea.Height + Movie_Menu.Height + CommandPanel.Height + 1);
            CommandPanelHeight = CommandPanel.Height;
            
            FORM_Tooltip.SetToolTip(BTN_Play, "Play");
            FORM_Tooltip.SetToolTip(BTN_Pause, "Pause");
            FORM_Tooltip.SetToolTip(BTN_Stop, "Stop");
            FORM_Tooltip.SetToolTip(BTN_Mute_On, "Mute");
            FORM_Tooltip.SetToolTip(BTN_Mute_Off, "Mute");
            FORM_Tooltip.SetToolTip(Movie_Track, "Search");
            FORM_Tooltip.SetToolTip(Sound_Track, "Volume");
            FORM_Tooltip.SetToolTip(BTN_FullScreen, "Full screen");

            DragAcceptFiles();

            Double Audiovolume = Convert.ToDouble(Registry.GetValue(Program.RegistryKey, Program.RegistryAudioVolume, -1));
            if (Audiovolume > -1.0f) Sound_Track.Value = Audiovolume;

            Movie_Timer.Enabled = true;

            CheckMovieName(MediaFile.ToLower());

        }

        protected override void WndProc(ref Message m)
        {
            string MediaFile = "";
            switch (m.Msg)
            {
                case Api.WM_DROPFILES:
                    uint hDrop = (uint)m.WParam;
                    int FilesDropped = Api.DragQueryFile(hDrop, -1, null, 0);
                    if (FilesDropped != 0)
                    {
                        StringBuilder sFileName = new StringBuilder(Api.MAX_PATH);
                        //for (int i = 0; i < FilesDropped; i++)
                        //{
                        //    Api.DragQueryFile(hDrop, i, sFileName, Api.MAX_PATH);
                        //    MediaFile = sFileName.ToString().ToLower(); break;
                        //}
                        Api.DragQueryFile(hDrop, 0, sFileName, Api.MAX_PATH);
                        MediaFile = sFileName.ToString().ToLower();
                    }
                    Api.DragFinish(hDrop);
                   
                    CheckMovieName(MediaFile);
                    break;

                case Api.WM_CLOSE:
                    UpdateRegistryAudioVolume(Sound_Track.Value);
                    break;

                case Api.WM_STRINGDATA:
                    MediaFile = (string)Registry.GetValue(Program.RegistryKey, Program.RegistryStringData, "");
                  
                    CheckMovieName(MediaFile);
                    break;
            }
            base.WndProc(ref m);
        }

        private void CheckMovieName(string MediaFile)
        {
            if (MediaFile.Length != 0)
            {
                Boolean DoIt = false;
                if (MediaFile.EndsWith(".avi")) DoIt = true;
                if (MediaFile.EndsWith(".wmv")) DoIt = true;
                if (MediaFile.EndsWith(".mpeg")) DoIt = true;
                if (MediaFile.EndsWith(".mpg")) DoIt = true;

                if (DoIt) PlayThisMovie(MediaFile);
            }
        }

        private void DragAcceptFiles()
        {
            Api.DragAcceptFiles(hFORM_Main, true);
        }

        private void MAIN_Form_Resize(object sender, EventArgs e)
        {
            int height = this.ClientSize.Height - Movie_Menu.Height - CommandPanel.Height;
            int width = this.ClientSize.Width;
            float temp = (float)width / (float)height;
            if (temp >= Aspect)
            {
                width = Convert.ToInt32(height * Aspect);
                Screen.Size = new Size(width, height);
                Screen.Location = new Point((this.ClientSize.Width - width) / 2, Movie_Menu.Height);
            }
            else
            {
                height = Convert.ToInt32(width / Aspect);
                Screen.Size = new Size(width, height);
                Screen.Location = new Point(0, (this.ClientSize.Height - Movie_Menu.Height - CommandPanel.Height - height) / 2 + Movie_Menu.Height);
            }
        }

        private void Movie_Timer_Tick(object sender, EventArgs e)
        {
            string HH, MM, SS;
            if (Movie_Timer_Enabled)
            {
                MovieCurrentPosition = (int)Movie.CurrentPosition;
                Movie_Track.Value = 10 * MovieCurrentPosition;
                hours = MovieCurrentPosition / 3600;
                minutes = (MovieCurrentPosition - hours * 3600) / 60;
                seconds = (MovieCurrentPosition - hours * 3600 - minutes * 60);

                HH = ("00" + hours.ToString());
                HH = HH.Substring(HH.Length - 2, 2);
                MM = ("00" + minutes.ToString());
                MM = MM.Substring(MM.Length - 2, 2);
                SS = ("00" + seconds.ToString());
                SS = SS.Substring(SS.Length - 2, 2);
                currentTime.Text = HH + ":" + MM + ":" + SS;

                if (currentTime.Text == movieDuration) BTN_Stop_Click(null, null);
            }

            DateTime dt = DateTime.Now;
            HH = ("00" + dt.Hour.ToString());
            HH = HH.Substring(HH.Length - 2, 2);
            MM = ("00" + dt.Minute.ToString());
            MM = MM.Substring(MM.Length - 2, 2);
            SS = ("00" + dt.Second.ToString());
            SS = SS.Substring(SS.Length - 2, 2);
            ShowTime.Text = HH + ":" + MM + ":" + SS;

        }

        private void Movie_Track_Scroll(object sender, EventArgs e)
        {
            if (ScrollEnable == true) {
                Movie.CurrentPosition = (double)(Movie_Track.Value / 10.0);
            }
        }

        private void Movie_Track_MouseDown(object sender, MouseEventArgs e)
        {
            if (Movie != null)
            {
                Movie.Pause();
                ScrollEnable = true;
                Movie_Track.Value = (int)((float)((float)e.X / (float)Movie_Track.Width) * (float)Movie_Track.Maximum);
                Movie_Track_Scroll(null, null);
            }
        }

        private void Movie_Track_MouseUp(object sender, MouseEventArgs e)
        {
            if (Movie != null)
            {
                ScrollEnable = false;
                if (BTN_Play.Visible == false)
                {
                    Movie.Play();
                    //Movie_Timer.Enabled = true;
                    Movie_Timer_Enabled = true;
                }
            }
        }

        private void Movie_Track_MouseEnter(object sender, EventArgs e)
        {
            if (FullScreen)
                CommandPanel.Height = CommandPanelHeight;
        }

        private void Movie_Track_MouseLeave(object sender, EventArgs e)
        {
            if (FullScreen)
                if (Cursor.Position.Y < this.Location.Y + CommandPanel.Location.Y)
                    CommandPanel.Height = 1;
        }

        private void Movie_Track_Scroll(object sender, ScrollEventArgs e)
        {
            if (ScrollEnable == true)
                Movie.CurrentPosition = (double)(Movie_Track.Value / 10.0);
        }

        private void Movie_Track_ValueChanged(object sender, EventArgs e)
        {
            if (ScrollEnable == true)
                Movie.CurrentPosition = (double)(Movie_Track.Value / 10.0);
        }

        private void BTN_FullScreen_Click(object sender, EventArgs e)
        {
            FullScreen = !FullScreen;
            if (FullScreen)
            {
                if (this.WindowState == FormWindowState.Maximized) {
                    this.WindowState = FormWindowState.Normal; }

                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
                Movie_Menu.Visible = false;
                CommandPanel.Height = 1;
            }
            else
            {
                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.WindowState = FormWindowState.Normal;
                Movie_Menu.Visible = true;
                CommandPanel.Height = CommandPanelHeight;
                // Drag & drop 
                DragAcceptFiles();
            }
        }

        private void BTN_Pause_Click(object sender, EventArgs e)
        {
            if (Movie != null)
            {
                BTN_Pause.Enabled = false;
                BTN_Play.Enabled = BTN_Stop.Enabled = true;
                //Movie_Timer.Enabled = false;
                Movie_Timer_Enabled = false;
                Movie.Pause();

                BTN_Pause.Visible = false;
                BTN_Play.Visible = true;
            }
        }

        private void BTN_Play_Click(object sender, EventArgs e)
        {
            if (Movie != null)
            {
                BTN_Play.Enabled = false;
                BTN_Stop.Enabled = BTN_FullScreen.Enabled = BTN_Pause.Enabled = true;
                BTN_FullScreen.Enabled = true;
                Movie.Play();
                //Movie_Timer.Enabled = true;
                Movie_Timer_Enabled = true;

                BTN_Play.Visible = false;
                BTN_Pause.Visible = true;
            }
        }

        private void Sound_Track_ValueChanged(object sender, EventArgs e)
        {
            if (Movie != null)
                Movie.Audio.Volume = Convert.ToInt32((100 - Sound_Track.Value) * -50);
        }

        private void BTN_Mute_Off_Click(object sender, EventArgs e)
        {
            BTN_Mute_Off.Visible = false;
            BTN_Mute_On.Visible = true;
            MuteMode = false;
            if (Movie != null)
                Movie.Audio.Volume = Convert.ToInt32((100 - Sound_Track.Value) * -50);
        }

        private void BTN_Mute_On_Click(object sender, EventArgs e)
        {
            BTN_Mute_On.Visible = false;
            BTN_Mute_Off.Visible = true;
            MuteMode = true;
            if (Movie != null) Movie.Audio.Volume = -10000;
        }

        private void PlayThisMovie(string sThisMovie)
        {
            if (Movie != null)
                Form_Closing(null, null);

            //Movie_Timer.Enabled = false;
            Movie_Timer_Enabled = false;
            Movie_Track.Enabled = false;
            Movie_Track.Value = 0;
            BTN_Play.Enabled = BTN_Pause.Enabled = BTN_Stop.Enabled = false;

            string sMovieName = sThisMovie;
            int LastIndex = sMovieName.LastIndexOf(@"\");
            sMovieName = sMovieName.Substring(LastIndex + 1, (sMovieName.Length - LastIndex - 1));

            try
            {
                Movie = new Video(sThisMovie);
            }
            catch
            {
                MessageBox.Show("Unable to play " + sMovieName);
                return;
            }


            MovieDefaultSize = Movie.DefaultSize;
            int UseWidth = Math.Max(MovieDefaultSize.Width, InitialClientWidth);
            int UseHeight = MovieDefaultSize.Height;
            Aspect = (float)((float)MovieDefaultSize.Width / (float)MovieDefaultSize.Height);
            HDmovie = false;
            if (UseWidth >= 1200) 
            {
                UseWidth = (int)(UseWidth * .5f);
                UseHeight = (int)(UseHeight * .5f);
                HDmovie = true;
            }

            this.ClientSize = new Size(UseWidth, UseHeight + Movie_Menu.Height + CommandPanel.Height);
            
            Movie.Owner = this.Screen;
            Movie_Track.Enabled = true;
            Movie_Track.Value = 0;
            MovieDuration = (int)Movie.Duration;
            Movie_Track.Maximum = 10 * MovieDuration;
            hours = MovieDuration / 3600;
            minutes = (MovieDuration - hours * 3600) / 60;
            seconds = (MovieDuration - hours * 3600 - minutes * 60);

            string HH = ("00" + hours.ToString());
            HH = HH.Substring(HH.Length - 2, 2);
            string MM = ("00" + minutes.ToString());
            MM = MM.Substring(MM.Length - 2, 2);
            string SS = ("00" + seconds.ToString());
            SS = SS.Substring(SS.Length - 2, 2);
            movieDuration = HH + ":" + MM + ":" + SS;
            durationTime.Text = "/  " + movieDuration;

            if (MuteMode)
            {
                Movie.Audio.Volume = -10000;
            }
            else
            {
                Movie.Audio.Volume = Convert.ToInt32((100 - Sound_Track.Value) * -50);
            }

            this.Text = sMovieName.ToLower();

            BTN_Play.Visible = false;
            BTN_Pause.Visible = true;
            BTN_Pause.Enabled = BTN_Stop.Enabled = BTN_FullScreen.Enabled = true;
            BTN_FullScreen.Enabled = true;

          
                MAIN_Form_Resize(null, null);

            Movie.Play();
            Movie_Timer_Enabled = true;
        }

        private string CompletePath(string UsePath)
        {
            return UsePath.TrimEnd('\\') + @"\";
        }

        private bool UpdateRegistryPath(string UsePath)
        {
            bool DoIt = false;
            Registry.SetValue(Program.RegistryKey, Program.RegistryPath, UsePath);
            if (UsePath == (string)Registry.GetValue(Program.RegistryKey, Program.RegistryPath, ""))
                DoIt = true;

            return DoIt;
        }

        private void UpdateRegistryAudioVolume(Double UseAudioVolume)
        {
            Registry.SetValue(Program.RegistryKey, Program.RegistryAudioVolume, Convert.ToInt32(UseAudioVolume), RegistryValueKind.DWord);
        }

        private void openMovieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string UsePath = "";
            UsePath = (string)Registry.GetValue(Program.RegistryKey, Program.RegistryPath, "");
            if (UsePath.Length != 0) {
                DirectoryInfo dirinfo = new DirectoryInfo(UsePath);
                if (!dirinfo.Exists) UsePath = "";
            }
            if (UsePath.Length == 0)
                UsePath = Path.GetPathRoot(Directory.GetCurrentDirectory());

            Movie_OpenFile.InitialDirectory = UsePath;
            if (Movie_OpenFile.ShowDialog() == DialogResult.OK)
            {
                this.Refresh(); 
                UsePath = Path.GetDirectoryName(Movie_OpenFile.FileName);
                UpdateRegistryPath(UsePath);
                PlayThisMovie(Movie_OpenFile.FileName);
            }
        }

        private void BTN_Stop_Click(object sender, EventArgs e)
        {
            BTN_Stop.Enabled = false;
            BTN_Play.Enabled = true;
            //Movie_Timer.Enabled = false;
            Movie_Timer_Enabled = false;
            Movie_Track.Value = 0;
            Movie.Stop();

            BTN_Play.Visible = true;
            BTN_Pause.Visible = false;
        }

        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            if (Movie != null)
            {
                BTN_Stop_Click(null, null);
                Movie.Dispose();
                Movie = null; // free up the media
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string MyTitle = "SnowPlayer 1.0";
            string MyMessage = "Developer Justin Snow\njrsnow8921@gmail.com";
            MessageBox.Show(MyMessage, MyTitle, MessageBoxButtons.OK, MessageBoxIcon.Information); 
        }
 
    }
}