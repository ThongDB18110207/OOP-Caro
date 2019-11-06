namespace GameCaro
{
    partial class Form1
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
            this.pnl_BanCo = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pgB_Timedown = new System.Windows.Forms.ProgressBar();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_BanCo
            // 
            this.pnl_BanCo.BackColor = System.Drawing.Color.Transparent;
            this.pnl_BanCo.Location = new System.Drawing.Point(13, 13);
            this.pnl_BanCo.Name = "pnl_BanCo";
            this.pnl_BanCo.Size = new System.Drawing.Size(810, 791);
            this.pnl_BanCo.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.pgB_Timedown);
            this.panel3.Location = new System.Drawing.Point(837, 369);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(328, 435);
            this.panel3.TabIndex = 2;
            // 
            // pgB_Timedown
            // 
            this.pgB_Timedown.Location = new System.Drawing.Point(9, 122);
            this.pgB_Timedown.Name = "pgB_Timedown";
            this.pgB_Timedown.Size = new System.Drawing.Size(226, 32);
            this.pgB_Timedown.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.BackgroundImage = global::GameCaro.Properties.Resources.p714;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Location = new System.Drawing.Point(837, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(328, 351);
            this.panel2.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1177, 803);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnl_BanCo);
            this.Name = "Form1";
            this.Text = "Game Caro";
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_BanCo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ProgressBar pgB_Timedown;
    }
}

