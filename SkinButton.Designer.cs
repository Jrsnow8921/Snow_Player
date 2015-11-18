namespace SnowPlayer
{
    partial class SkinButton
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // SkinButton
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(41)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.FlatAppearance.BorderSize = 0;
            this.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(153)))), ((int)(((byte)(190)))));
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Size = new System.Drawing.Size(80, 23);
            this.UseVisualStyleBackColor = false;
            this.MouseLeave += new System.EventHandler(this.BTN_MouseLeave);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BTN_MouseDown);
            this.Resize += new System.EventHandler(this.SKIN_Resize);
            this.MouseEnter += new System.EventHandler(this.BTN_MouseEnter);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BTN_MouseUp);
            this.EnabledChanged += new System.EventHandler(this.BTN_EnabledChanged);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
