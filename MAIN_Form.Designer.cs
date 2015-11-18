namespace SnowPlayer
{
    partial class MAIN_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MAIN_Form));
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadMovieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Screen = new System.Windows.Forms.Panel();
            this.Movie_OpenFile = new System.Windows.Forms.OpenFileDialog();
            this.CommandPanel = new System.Windows.Forms.Panel();
            this.ShowTime = new System.Windows.Forms.Label();
            this.durationTime = new System.Windows.Forms.Label();
            this.Movie_Track = new SnowPlayer.VISTA_Track();
            this.BTN_Stop = new SnowPlayer.SkinButton();
            this.Sound_Track = new SnowPlayer.VISTA_Track();
            this.BTN_Mute_On = new SnowPlayer.SkinButton();
            this.BTN_Mute_Off = new SnowPlayer.SkinButton();
            this.BTN_Pause = new SnowPlayer.SkinButton();
            this.BTN_FullScreen = new SnowPlayer.SkinButton();
            this.currentTime = new System.Windows.Forms.Label();
            this.BTN_Play = new SnowPlayer.SkinButton();
            this.PANEl_Left = new System.Windows.Forms.PictureBox();
            this.PANEL_Center = new System.Windows.Forms.PictureBox();
            this.PANEL_Right = new System.Windows.Forms.PictureBox();
            this.PANEL_Fill = new System.Windows.Forms.PictureBox();
            this.FORM_Tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.Movie_Timer = new System.Windows.Forms.Timer(this.components);
            this.Movie_Menu = new System.Windows.Forms.MenuStrip();
            this.Menu_Movie = new System.Windows.Forms.ToolStripMenuItem();
            this.Open_movie_menu = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CommandPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PANEl_Left)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PANEL_Center)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PANEL_Right)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PANEL_Fill)).BeginInit();
            this.Movie_Menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // loadMovieToolStripMenuItem
            // 
            this.loadMovieToolStripMenuItem.Name = "loadMovieToolStripMenuItem";
            this.loadMovieToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // Screen
            // 
            this.Screen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Screen.BackColor = System.Drawing.Color.Black;
            this.Screen.Location = new System.Drawing.Point(12, 34);
            this.Screen.Name = "Screen";
            this.Screen.Size = new System.Drawing.Size(502, 238);
            this.Screen.TabIndex = 0;
            // 
            // Movie_OpenFile
            // 
            this.Movie_OpenFile.Filter = "Movies (*.avi, *.mpg, *.wmv)|*.avi;*.mpg;*.wmv|All files (*.*)|*.*";
            this.Movie_OpenFile.InitialDirectory = "c:\\";
            this.Movie_OpenFile.Title = "Select Movie";
            // 
            // CommandPanel
            // 
            this.CommandPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(41)))));
            this.CommandPanel.Controls.Add(this.ShowTime);
            this.CommandPanel.Controls.Add(this.durationTime);
            this.CommandPanel.Controls.Add(this.Movie_Track);
            this.CommandPanel.Controls.Add(this.BTN_Stop);
            this.CommandPanel.Controls.Add(this.Sound_Track);
            this.CommandPanel.Controls.Add(this.BTN_Mute_On);
            this.CommandPanel.Controls.Add(this.BTN_Mute_Off);
            this.CommandPanel.Controls.Add(this.BTN_Pause);
            this.CommandPanel.Controls.Add(this.BTN_FullScreen);
            this.CommandPanel.Controls.Add(this.currentTime);
            this.CommandPanel.Controls.Add(this.BTN_Play);
            this.CommandPanel.Controls.Add(this.PANEl_Left);
            this.CommandPanel.Controls.Add(this.PANEL_Center);
            this.CommandPanel.Controls.Add(this.PANEL_Right);
            this.CommandPanel.Controls.Add(this.PANEL_Fill);
            this.CommandPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.CommandPanel.Location = new System.Drawing.Point(0, 279);
            this.CommandPanel.Name = "CommandPanel";
            this.CommandPanel.Size = new System.Drawing.Size(526, 69);
            this.CommandPanel.TabIndex = 3;
            // 
            // ShowTime
            // 
            this.ShowTime.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ShowTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.ShowTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ShowTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ShowTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(153)))), ((int)(((byte)(190)))));
            this.ShowTime.Location = new System.Drawing.Point(131, 35);
            this.ShowTime.Margin = new System.Windows.Forms.Padding(0);
            this.ShowTime.Name = "ShowTime";
            this.ShowTime.Size = new System.Drawing.Size(49, 13);
            this.ShowTime.TabIndex = 13;
            this.ShowTime.Text = "00:00:00";
            // 
            // durationTime
            // 
            this.durationTime.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.durationTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.durationTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.durationTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.durationTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(153)))), ((int)(((byte)(190)))));
            this.durationTime.Location = new System.Drawing.Point(337, 35);
            this.durationTime.Name = "durationTime";
            this.durationTime.Size = new System.Drawing.Size(60, 13);
            this.durationTime.TabIndex = 4;
            this.durationTime.Text = "/  00:00:00";
            // 
            // Movie_Track
            // 
            this.Movie_Track.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Movie_Track.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(41)))));
            this.Movie_Track.BackgroundImage = global::SnowPlayer.Properties.Resources.movie_track_back;
            this.Movie_Track.Location = new System.Drawing.Point(4, 2);
            this.Movie_Track.Margin = new System.Windows.Forms.Padding(0);
            this.Movie_Track.Maximum = 100D;
            this.Movie_Track.Minimum = 0D;
            this.Movie_Track.MinimumSize = new System.Drawing.Size(14, 6);
            this.Movie_Track.Name = "Movie_Track";
            this.Movie_Track.Size = new System.Drawing.Size(518, 9);
            this.Movie_Track.TabIndex = 0;
            this.Movie_Track.Value = 0D;
            this.Movie_Track.ValueChanged += new System.EventHandler(this.Movie_Track_ValueChanged);
            this.Movie_Track.Scroll += new System.Windows.Forms.ScrollEventHandler(this.Movie_Track_Scroll);
            this.Movie_Track.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Movie_Track_MouseDown);
            this.Movie_Track.MouseEnter += new System.EventHandler(this.Movie_Track_MouseEnter);
            this.Movie_Track.MouseLeave += new System.EventHandler(this.Movie_Track_MouseLeave);
            this.Movie_Track.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Movie_Track_MouseUp);
            // 
            // BTN_Stop
            // 
            this.BTN_Stop.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BTN_Stop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(41)))));
            this.BTN_Stop.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BTN_Stop.BackgroundImage")));
            this.BTN_Stop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BTN_Stop.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.BTN_Stop.FlatAppearance.BorderSize = 0;
            this.BTN_Stop.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BTN_Stop.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BTN_Stop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Stop.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_Stop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(153)))), ((int)(((byte)(190)))));
            this.BTN_Stop.Location = new System.Drawing.Point(211, 23);
            this.BTN_Stop.Margin = new System.Windows.Forms.Padding(0);
            this.BTN_Stop.Name = "BTN_Stop";
            this.BTN_Stop.Resource = "BTN_Stop";
            this.BTN_Stop.Size = new System.Drawing.Size(25, 25);
            this.BTN_Stop.TabIndex = 11;
            this.BTN_Stop.UseVisualStyleBackColor = true;
            this.BTN_Stop.Click += new System.EventHandler(this.BTN_Stop_Click);
            // 
            // Sound_Track
            // 
            this.Sound_Track.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Sound_Track.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(41)))));
            this.Sound_Track.BackgroundImage = global::SnowPlayer.Properties.Resources.sound_track_back;
            this.Sound_Track.Location = new System.Drawing.Point(425, 31);
            this.Sound_Track.Margin = new System.Windows.Forms.Padding(0);
            this.Sound_Track.Maximum = 100D;
            this.Sound_Track.Minimum = 1D;
            this.Sound_Track.MinimumSize = new System.Drawing.Size(14, 9);
            this.Sound_Track.Name = "Sound_Track";
            this.Sound_Track.Size = new System.Drawing.Size(77, 9);
            this.Sound_Track.TabIndex = 4;
            this.Sound_Track.Value = 50D;
            this.Sound_Track.ValueChanged += new System.EventHandler(this.Sound_Track_ValueChanged);
            // 
            // BTN_Mute_On
            // 
            this.BTN_Mute_On.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BTN_Mute_On.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(41)))));
            this.BTN_Mute_On.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BTN_Mute_On.BackgroundImage")));
            this.BTN_Mute_On.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BTN_Mute_On.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.BTN_Mute_On.FlatAppearance.BorderSize = 0;
            this.BTN_Mute_On.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BTN_Mute_On.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BTN_Mute_On.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Mute_On.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_Mute_On.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(153)))), ((int)(((byte)(190)))));
            this.BTN_Mute_On.Location = new System.Drawing.Point(398, 23);
            this.BTN_Mute_On.Margin = new System.Windows.Forms.Padding(0);
            this.BTN_Mute_On.Name = "BTN_Mute_On";
            this.BTN_Mute_On.Resource = "BTN_Mute_On";
            this.BTN_Mute_On.Size = new System.Drawing.Size(25, 25);
            this.BTN_Mute_On.TabIndex = 5;
            this.BTN_Mute_On.UseVisualStyleBackColor = true;
            this.BTN_Mute_On.Click += new System.EventHandler(this.BTN_Mute_On_Click);
            // 
            // BTN_Mute_Off
            // 
            this.BTN_Mute_Off.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BTN_Mute_Off.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(41)))));
            this.BTN_Mute_Off.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BTN_Mute_Off.BackgroundImage")));
            this.BTN_Mute_Off.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BTN_Mute_Off.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.BTN_Mute_Off.FlatAppearance.BorderSize = 0;
            this.BTN_Mute_Off.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BTN_Mute_Off.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BTN_Mute_Off.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Mute_Off.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_Mute_Off.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(153)))), ((int)(((byte)(190)))));
            this.BTN_Mute_Off.Location = new System.Drawing.Point(398, 23);
            this.BTN_Mute_Off.Margin = new System.Windows.Forms.Padding(0);
            this.BTN_Mute_Off.Name = "BTN_Mute_Off";
            this.BTN_Mute_Off.Resource = "BTN_Mute_Off";
            this.BTN_Mute_Off.Size = new System.Drawing.Size(25, 25);
            this.BTN_Mute_Off.TabIndex = 6;
            this.BTN_Mute_Off.UseVisualStyleBackColor = true;
            this.BTN_Mute_Off.Visible = false;
            this.BTN_Mute_Off.Click += new System.EventHandler(this.BTN_Mute_Off_Click);
            // 
            // BTN_Pause
            // 
            this.BTN_Pause.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BTN_Pause.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(41)))));
            this.BTN_Pause.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BTN_Pause.BackgroundImage")));
            this.BTN_Pause.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BTN_Pause.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.BTN_Pause.FlatAppearance.BorderSize = 0;
            this.BTN_Pause.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BTN_Pause.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BTN_Pause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Pause.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_Pause.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(153)))), ((int)(((byte)(190)))));
            this.BTN_Pause.Location = new System.Drawing.Point(240, 11);
            this.BTN_Pause.Margin = new System.Windows.Forms.Padding(0);
            this.BTN_Pause.Name = "BTN_Pause";
            this.BTN_Pause.Resource = "BTN_Pause";
            this.BTN_Pause.Size = new System.Drawing.Size(48, 50);
            this.BTN_Pause.TabIndex = 5;
            this.BTN_Pause.UseVisualStyleBackColor = true;
            this.BTN_Pause.Click += new System.EventHandler(this.BTN_Pause_Click);
            // 
            // BTN_FullScreen
            // 
            this.BTN_FullScreen.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BTN_FullScreen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(41)))));
            this.BTN_FullScreen.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BTN_FullScreen.BackgroundImage")));
            this.BTN_FullScreen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BTN_FullScreen.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.BTN_FullScreen.FlatAppearance.BorderSize = 0;
            this.BTN_FullScreen.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BTN_FullScreen.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BTN_FullScreen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_FullScreen.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_FullScreen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(153)))), ((int)(((byte)(190)))));
            this.BTN_FullScreen.Location = new System.Drawing.Point(181, 23);
            this.BTN_FullScreen.Margin = new System.Windows.Forms.Padding(0);
            this.BTN_FullScreen.Name = "BTN_FullScreen";
            this.BTN_FullScreen.Resource = "BTN_FullScreen";
            this.BTN_FullScreen.Size = new System.Drawing.Size(25, 25);
            this.BTN_FullScreen.TabIndex = 4;
            this.FORM_Tooltip.SetToolTip(this.BTN_FullScreen, "Play full screen");
            this.BTN_FullScreen.UseVisualStyleBackColor = true;
            this.BTN_FullScreen.Click += new System.EventHandler(this.BTN_FullScreen_Click);
            // 
            // currentTime
            // 
            this.currentTime.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.currentTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.currentTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.currentTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.currentTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(153)))), ((int)(((byte)(190)))));
            this.currentTime.Location = new System.Drawing.Point(288, 35);
            this.currentTime.Margin = new System.Windows.Forms.Padding(0);
            this.currentTime.Name = "currentTime";
            this.currentTime.Size = new System.Drawing.Size(49, 13);
            this.currentTime.TabIndex = 3;
            this.currentTime.Text = "00:00:00";
            // 
            // BTN_Play
            // 
            this.BTN_Play.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BTN_Play.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(41)))));
            this.BTN_Play.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BTN_Play.BackgroundImage")));
            this.BTN_Play.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BTN_Play.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.BTN_Play.FlatAppearance.BorderSize = 0;
            this.BTN_Play.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BTN_Play.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BTN_Play.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Play.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_Play.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(153)))), ((int)(((byte)(190)))));
            this.BTN_Play.Location = new System.Drawing.Point(240, 11);
            this.BTN_Play.Margin = new System.Windows.Forms.Padding(0);
            this.BTN_Play.Name = "BTN_Play";
            this.BTN_Play.Resource = "BTN_Play";
            this.BTN_Play.Size = new System.Drawing.Size(48, 50);
            this.BTN_Play.TabIndex = 6;
            this.BTN_Play.UseVisualStyleBackColor = true;
            this.BTN_Play.Click += new System.EventHandler(this.BTN_Play_Click);
            // 
            // PANEl_Left
            // 
            this.PANEl_Left.BackgroundImage = global::SnowPlayer.Properties.Resources.PANEL_Left;
            this.PANEl_Left.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.PANEl_Left.Location = new System.Drawing.Point(0, 0);
            this.PANEl_Left.Name = "PANEl_Left";
            this.PANEl_Left.Size = new System.Drawing.Size(26, 69);
            this.PANEl_Left.TabIndex = 8;
            this.PANEl_Left.TabStop = false;
            this.PANEl_Left.MouseEnter += new System.EventHandler(this.Movie_Track_MouseEnter);
            this.PANEl_Left.MouseLeave += new System.EventHandler(this.Movie_Track_MouseLeave);
            // 
            // PANEL_Center
            // 
            this.PANEL_Center.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.PANEL_Center.BackgroundImage = global::SnowPlayer.Properties.Resources.PANEL_Center;
            this.PANEL_Center.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.PANEL_Center.Location = new System.Drawing.Point(243, 0);
            this.PANEL_Center.Name = "PANEL_Center";
            this.PANEL_Center.Size = new System.Drawing.Size(40, 69);
            this.PANEL_Center.TabIndex = 7;
            this.PANEL_Center.TabStop = false;
            // 
            // PANEL_Right
            // 
            this.PANEL_Right.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PANEL_Right.BackgroundImage = global::SnowPlayer.Properties.Resources.PANEL_Right;
            this.PANEL_Right.Location = new System.Drawing.Point(502, 0);
            this.PANEL_Right.Name = "PANEL_Right";
            this.PANEL_Right.Size = new System.Drawing.Size(24, 69);
            this.PANEL_Right.TabIndex = 12;
            this.PANEL_Right.TabStop = false;
            this.PANEL_Right.MouseEnter += new System.EventHandler(this.Movie_Track_MouseEnter);
            this.PANEL_Right.MouseLeave += new System.EventHandler(this.Movie_Track_MouseLeave);
            // 
            // PANEL_Fill
            // 
            this.PANEL_Fill.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PANEL_Fill.BackgroundImage = global::SnowPlayer.Properties.Resources.PANEL_Fill;
            this.PANEL_Fill.Location = new System.Drawing.Point(25, 0);
            this.PANEL_Fill.Margin = new System.Windows.Forms.Padding(0);
            this.PANEL_Fill.Name = "PANEL_Fill";
            this.PANEL_Fill.Size = new System.Drawing.Size(501, 69);
            this.PANEL_Fill.TabIndex = 10;
            this.PANEL_Fill.TabStop = false;
            this.PANEL_Fill.MouseEnter += new System.EventHandler(this.Movie_Track_MouseEnter);
            this.PANEL_Fill.MouseLeave += new System.EventHandler(this.Movie_Track_MouseLeave);
            // 
            // FORM_Tooltip
            // 
            this.FORM_Tooltip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(153)))), ((int)(((byte)(190)))));
            this.FORM_Tooltip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(76)))), ((int)(((byte)(99)))));
            // 
            // Movie_Timer
            // 
            this.Movie_Timer.Tick += new System.EventHandler(this.Movie_Timer_Tick);
            // 
            // Movie_Menu
            // 
            this.Movie_Menu.BackgroundImage = global::SnowPlayer.Properties.Resources.menu_back;
            this.Movie_Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_Movie});
            this.Movie_Menu.Location = new System.Drawing.Point(0, 0);
            this.Movie_Menu.Name = "Movie_Menu";
            this.Movie_Menu.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.Movie_Menu.Size = new System.Drawing.Size(526, 24);
            this.Movie_Menu.TabIndex = 0;
            this.Movie_Menu.Text = "menuStrip1";
            // 
            // Menu_Movie
            // 
            this.Menu_Movie.BackColor = System.Drawing.Color.Transparent;
            this.Menu_Movie.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Open_movie_menu,
            this.aboutToolStripMenuItem});
            this.Menu_Movie.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Menu_Movie.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(153)))), ((int)(((byte)(190)))));
            this.Menu_Movie.Name = "Menu_Movie";
            this.Menu_Movie.Size = new System.Drawing.Size(53, 20);
            this.Menu_Movie.Text = "Movie";
            // 
            // Open_movie_menu
            // 
            this.Open_movie_menu.Image = global::SnowPlayer.Properties.Resources.movie;
            this.Open_movie_menu.Name = "Open_movie_menu";
            this.Open_movie_menu.Size = new System.Drawing.Size(417, 22);
            this.Open_movie_menu.Text = "Select movie to play from dialog, or Drag it from the Explorer";
            this.Open_movie_menu.Click += new System.EventHandler(this.openMovieToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Image = global::SnowPlayer.Properties.Resources.About;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(417, 22);
            this.aboutToolStripMenuItem.Text = "About ...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // MAIN_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(526, 348);
            this.Controls.Add(this.Screen);
            this.Controls.Add(this.CommandPanel);
            this.Controls.Add(this.Movie_Menu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.Movie_Menu;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "MAIN_Form";
            this.Text = "SnowPlayer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            this.Resize += new System.EventHandler(this.MAIN_Form_Resize);
            this.CommandPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PANEl_Left)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PANEL_Center)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PANEL_Right)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PANEL_Fill)).EndInit();
            this.Movie_Menu.ResumeLayout(false);
            this.Movie_Menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadMovieToolStripMenuItem;
        //private System.Windows.Forms.ToolStripMenuItem loadSubtitlesToolStripMenuItem;
        //private System.Windows.Forms.ToolStripSeparator wyjscieToolStripMenuItem;
        //private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        //private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        //private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog Movie_OpenFile;
        private System.Windows.Forms.Panel CommandPanel;
        private System.Windows.Forms.Panel Screen;
        private System.Windows.Forms.Label durationTime;
        private System.Windows.Forms.Label currentTime;
        private System.Windows.Forms.ToolTip FORM_Tooltip;
        private VISTA_Track Movie_Track;
        private VISTA_Track Sound_Track;
        private SkinButton BTN_FullScreen;
        private SkinButton BTN_Pause;
        private SkinButton BTN_Play;
        private SkinButton BTN_Mute_On;
        private SkinButton BTN_Mute_Off;
        private System.Windows.Forms.PictureBox PANEl_Left;
        private System.Windows.Forms.PictureBox PANEL_Fill;
        private SkinButton BTN_Stop;
        private System.Windows.Forms.PictureBox PANEL_Right;
        private System.Windows.Forms.PictureBox PANEL_Center;
        private System.Windows.Forms.ToolStripMenuItem Menu_Movie;
        private System.Windows.Forms.ToolStripMenuItem Open_movie_menu;
        private System.Windows.Forms.MenuStrip Movie_Menu;
        private System.Windows.Forms.Timer Movie_Timer;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Label ShowTime;
    }
}

