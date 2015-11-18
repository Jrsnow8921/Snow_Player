namespace SnowPlayer
{
    partial class VISTA_Track
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.BLUE_Thumb = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.BLUE_Thumb)).BeginInit();
            this.SuspendLayout();
            // 
            // toolTip
            // 
            this.toolTip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(153)))), ((int)(((byte)(190)))));
            this.toolTip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(76)))), ((int)(((byte)(99)))));
            // 
            // BLUE_Thumb
            // 
            this.BLUE_Thumb.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BLUE_Thumb.BackgroundImage = global::SnowPlayer.Properties.Resources.TRACK_Thumb;
            this.BLUE_Thumb.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BLUE_Thumb.Location = new System.Drawing.Point(106, 0);
            this.BLUE_Thumb.Margin = new System.Windows.Forms.Padding(0);
            this.BLUE_Thumb.Name = "BLUE_Thumb";
            this.BLUE_Thumb.Size = new System.Drawing.Size(11, 9);
            this.BLUE_Thumb.TabIndex = 5;
            this.BLUE_Thumb.TabStop = false;
            this.BLUE_Thumb.Visible = false;
            this.BLUE_Thumb.MouseDown += new System.Windows.Forms.MouseEventHandler(this.THUMB_MouseDown);
            this.BLUE_Thumb.MouseMove += new System.Windows.Forms.MouseEventHandler(this.THUMB_MouseMove);
            this.BLUE_Thumb.MouseUp += new System.Windows.Forms.MouseEventHandler(this.THUMB_MouseUp);
            // 
            // VISTA_Track
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(41)))));
            this.Controls.Add(this.BLUE_Thumb);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MinimumSize = new System.Drawing.Size(14, 9);
            this.Name = "VISTA_Track";
            this.Size = new System.Drawing.Size(223, 9);
            this.Load += new System.EventHandler(this.TRACK_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TRACK_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.THUMB_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.THUMB_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.BLUE_Thumb)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox BLUE_Thumb;
        private System.Windows.Forms.ToolTip toolTip;
    }
}
