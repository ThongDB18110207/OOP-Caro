namespace GameCaro_OOP_TuongThong
{
    partial class MediaPlayer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MediaPlayer));
            this.bt_Open = new System.Windows.Forms.Button();
            this.lbx_listFile = new System.Windows.Forms.ListBox();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.SuspendLayout();
            // 
            // bt_Open
            // 
            this.bt_Open.AutoSize = true;
            this.bt_Open.Location = new System.Drawing.Point(348, 214);
            this.bt_Open.Name = "bt_Open";
            this.bt_Open.Size = new System.Drawing.Size(75, 28);
            this.bt_Open.TabIndex = 5;
            this.bt_Open.Text = "&Open";
            this.bt_Open.UseVisualStyleBackColor = true;
            this.bt_Open.Click += new System.EventHandler(this.bt_Open_Click);
            // 
            // lbx_listFile
            // 
            this.lbx_listFile.FormattingEnabled = true;
            this.lbx_listFile.ItemHeight = 16;
            this.lbx_listFile.Location = new System.Drawing.Point(348, 12);
            this.lbx_listFile.Name = "lbx_listFile";
            this.lbx_listFile.Size = new System.Drawing.Size(187, 196);
            this.lbx_listFile.TabIndex = 4;
            this.lbx_listFile.SelectedIndexChanged += new System.EventHandler(this.lbx_listFile_SelectedIndexChanged);
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(12, 12);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(330, 230);
            this.axWindowsMediaPlayer1.TabIndex = 3;
            // 
            // MediaPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 247);
            this.Controls.Add(this.bt_Open);
            this.Controls.Add(this.lbx_listFile);
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.Name = "MediaPlayer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MediaPlayer";
            this.Load += new System.EventHandler(this.MediaPlayer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_Open;
        private System.Windows.Forms.ListBox lbx_listFile;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
    }
}