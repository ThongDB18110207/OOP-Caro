namespace GameCaro_OOP_TuongThong
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pnl_BanCo = new System.Windows.Forms.Panel();
            this.pnl_AnhNen = new System.Windows.Forms.Panel();
            this.pctb_AnhNen = new System.Windows.Forms.PictureBox();
            this.pnl_LuatChoi = new System.Windows.Forms.Panel();
            this.bt_LAN = new System.Windows.Forms.Button();
            this.tbx_IP = new System.Windows.Forms.TextBox();
            this.prcbCoolDown = new System.Windows.Forms.ProgressBar();
            this.pctb_QuanKeTiep = new System.Windows.Forms.PictureBox();
            this.tbx_TenNguoiChoi = new System.Windows.Forms.TextBox();
            this.tm_CoolDown = new System.Windows.Forms.Timer(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playerVsPlayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playerVsComToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.level0ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.level1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.level2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.level3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.level4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lANToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mP3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnl_AnhNen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctb_AnhNen)).BeginInit();
            this.pnl_LuatChoi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctb_QuanKeTiep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_BanCo
            // 
            this.pnl_BanCo.BackColor = System.Drawing.SystemColors.Control;
            this.pnl_BanCo.Location = new System.Drawing.Point(13, 31);
            this.pnl_BanCo.Name = "pnl_BanCo";
            this.pnl_BanCo.Size = new System.Drawing.Size(700, 700);
            this.pnl_BanCo.TabIndex = 0;
            // 
            // pnl_AnhNen
            // 
            this.pnl_AnhNen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_AnhNen.Controls.Add(this.pctb_AnhNen);
            this.pnl_AnhNen.Enabled = false;
            this.pnl_AnhNen.Location = new System.Drawing.Point(727, 31);
            this.pnl_AnhNen.Name = "pnl_AnhNen";
            this.pnl_AnhNen.Size = new System.Drawing.Size(410, 410);
            this.pnl_AnhNen.TabIndex = 1;
            // 
            // pctb_AnhNen
            // 
            this.pctb_AnhNen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pctb_AnhNen.BackgroundImage = global::GameCaro_OOP_TuongThong.Properties.Resources.unnamed;
            this.pctb_AnhNen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pctb_AnhNen.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pctb_AnhNen.ErrorImage")));
            this.pctb_AnhNen.Location = new System.Drawing.Point(3, 2);
            this.pctb_AnhNen.Name = "pctb_AnhNen";
            this.pctb_AnhNen.Size = new System.Drawing.Size(405, 405);
            this.pctb_AnhNen.TabIndex = 0;
            this.pctb_AnhNen.TabStop = false;
            // 
            // pnl_LuatChoi
            // 
            this.pnl_LuatChoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_LuatChoi.BackColor = System.Drawing.SystemColors.Control;
            this.pnl_LuatChoi.Controls.Add(this.bt_LAN);
            this.pnl_LuatChoi.Controls.Add(this.tbx_IP);
            this.pnl_LuatChoi.Controls.Add(this.prcbCoolDown);
            this.pnl_LuatChoi.Controls.Add(this.pctb_QuanKeTiep);
            this.pnl_LuatChoi.Controls.Add(this.tbx_TenNguoiChoi);
            this.pnl_LuatChoi.Location = new System.Drawing.Point(730, 450);
            this.pnl_LuatChoi.Name = "pnl_LuatChoi";
            this.pnl_LuatChoi.Size = new System.Drawing.Size(408, 281);
            this.pnl_LuatChoi.TabIndex = 2;
            // 
            // bt_LAN
            // 
            this.bt_LAN.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_LAN.Location = new System.Drawing.Point(8, 148);
            this.bt_LAN.Name = "bt_LAN";
            this.bt_LAN.Size = new System.Drawing.Size(200, 38);
            this.bt_LAN.TabIndex = 4;
            this.bt_LAN.Text = "JOIN IN LAN";
            this.bt_LAN.UseVisualStyleBackColor = true;
            this.bt_LAN.Click += new System.EventHandler(this.bt_LAN_Click);
            // 
            // tbx_IP
            // 
            this.tbx_IP.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_IP.Location = new System.Drawing.Point(9, 106);
            this.tbx_IP.Name = "tbx_IP";
            this.tbx_IP.Size = new System.Drawing.Size(200, 32);
            this.tbx_IP.TabIndex = 3;
            this.tbx_IP.Text = "192.168.1.1";
            // 
            // prcbCoolDown
            // 
            this.prcbCoolDown.Location = new System.Drawing.Point(9, 58);
            this.prcbCoolDown.Name = "prcbCoolDown";
            this.prcbCoolDown.Size = new System.Drawing.Size(200, 32);
            this.prcbCoolDown.TabIndex = 2;
            // 
            // pctb_QuanKeTiep
            // 
            this.pctb_QuanKeTiep.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pctb_QuanKeTiep.Location = new System.Drawing.Point(225, 12);
            this.pctb_QuanKeTiep.Name = "pctb_QuanKeTiep";
            this.pctb_QuanKeTiep.Size = new System.Drawing.Size(175, 175);
            this.pctb_QuanKeTiep.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctb_QuanKeTiep.TabIndex = 1;
            this.pctb_QuanKeTiep.TabStop = false;
            // 
            // tbx_TenNguoiChoi
            // 
            this.tbx_TenNguoiChoi.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_TenNguoiChoi.Location = new System.Drawing.Point(8, 10);
            this.tbx_TenNguoiChoi.Name = "tbx_TenNguoiChoi";
            this.tbx_TenNguoiChoi.ReadOnly = true;
            this.tbx_TenNguoiChoi.Size = new System.Drawing.Size(201, 32);
            this.tbx_TenNguoiChoi.TabIndex = 0;
            // 
            // tm_CoolDown
            // 
            this.tm_CoolDown.Tick += new System.EventHandler(this.tm_CoolDown_Tick);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.mP3ToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1140, 28);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem,
            this.undoToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(60, 24);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playerVsPlayerToolStripMenuItem,
            this.playerVsComToolStripMenuItem,
            this.lANToolStripMenuItem});
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.newGameToolStripMenuItem.Text = "New game";
            // 
            // playerVsPlayerToolStripMenuItem
            // 
            this.playerVsPlayerToolStripMenuItem.Name = "playerVsPlayerToolStripMenuItem";
            this.playerVsPlayerToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.playerVsPlayerToolStripMenuItem.Text = "Player vs Player";
            this.playerVsPlayerToolStripMenuItem.Click += new System.EventHandler(this.playerVsPlayerToolStripMenuItem_Click);
            // 
            // playerVsComToolStripMenuItem
            // 
            this.playerVsComToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.level0ToolStripMenuItem,
            this.level1ToolStripMenuItem,
            this.level2ToolStripMenuItem,
            this.level3ToolStripMenuItem,
            this.level4ToolStripMenuItem});
            this.playerVsComToolStripMenuItem.Name = "playerVsComToolStripMenuItem";
            this.playerVsComToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.playerVsComToolStripMenuItem.Text = "Player vs Com";
            // 
            // level0ToolStripMenuItem
            // 
            this.level0ToolStripMenuItem.Name = "level0ToolStripMenuItem";
            this.level0ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.level0ToolStripMenuItem.Text = "Level 0";
            this.level0ToolStripMenuItem.Click += new System.EventHandler(this.level0ToolStripMenuItem_Click);
            // 
            // level1ToolStripMenuItem
            // 
            this.level1ToolStripMenuItem.Name = "level1ToolStripMenuItem";
            this.level1ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.level1ToolStripMenuItem.Text = "Level 1";
            this.level1ToolStripMenuItem.Click += new System.EventHandler(this.level1ToolStripMenuItem_Click);
            // 
            // level2ToolStripMenuItem
            // 
            this.level2ToolStripMenuItem.Name = "level2ToolStripMenuItem";
            this.level2ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.level2ToolStripMenuItem.Text = "Level 2";
            this.level2ToolStripMenuItem.Click += new System.EventHandler(this.level2ToolStripMenuItem_Click);
            // 
            // level3ToolStripMenuItem
            // 
            this.level3ToolStripMenuItem.Name = "level3ToolStripMenuItem";
            this.level3ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.level3ToolStripMenuItem.Text = "Level 3";
            this.level3ToolStripMenuItem.Click += new System.EventHandler(this.level3ToolStripMenuItem_Click);
            // 
            // level4ToolStripMenuItem
            // 
            this.level4ToolStripMenuItem.Name = "level4ToolStripMenuItem";
            this.level4ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.level4ToolStripMenuItem.Text = "Level 4";
            this.level4ToolStripMenuItem.Click += new System.EventHandler(this.level4ToolStripMenuItem_Click);
            // 
            // lANToolStripMenuItem
            // 
            this.lANToolStripMenuItem.Name = "lANToolStripMenuItem";
            this.lANToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.lANToolStripMenuItem.Text = "LAN";
            this.lANToolStripMenuItem.Click += new System.EventHandler(this.lANToolStripMenuItem_Click);
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.undoToolStripMenuItem.Text = "Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // mP3ToolStripMenuItem
            // 
            this.mP3ToolStripMenuItem.Name = "mP3ToolStripMenuItem";
            this.mP3ToolStripMenuItem.Size = new System.Drawing.Size(52, 24);
            this.mP3ToolStripMenuItem.Text = "MP3";
            this.mP3ToolStripMenuItem.Click += new System.EventHandler(this.mP3ToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(64, 24);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1140, 745);
            this.Controls.Add(this.pnl_LuatChoi);
            this.Controls.Add(this.pnl_AnhNen);
            this.Controls.Add(this.pnl_BanCo);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game Caro";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.pnl_AnhNen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pctb_AnhNen)).EndInit();
            this.pnl_LuatChoi.ResumeLayout(false);
            this.pnl_LuatChoi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctb_QuanKeTiep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnl_BanCo;
        private System.Windows.Forms.Panel pnl_AnhNen;
        private System.Windows.Forms.Panel pnl_LuatChoi;
        private System.Windows.Forms.PictureBox pctb_AnhNen;
        private System.Windows.Forms.PictureBox pctb_QuanKeTiep;
        private System.Windows.Forms.TextBox tbx_TenNguoiChoi;
        private System.Windows.Forms.ProgressBar prcbCoolDown;
        private System.Windows.Forms.Timer tm_CoolDown;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mP3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playerVsPlayerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playerVsComToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem level0ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem level1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem level2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem level4ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lANToolStripMenuItem;
        private System.Windows.Forms.Button bt_LAN;
        private System.Windows.Forms.TextBox tbx_IP;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem level3ToolStripMenuItem;
    }
}

