namespace GraphicalGameProject
{
    partial class main
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
            this.player = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.globalProgress = new System.Windows.Forms.ProgressBar();
            this.flash = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.flash)).BeginInit();
            this.SuspendLayout();
            // 
            // player
            // 
            this.player.BackColor = System.Drawing.Color.Transparent;
            this.player.BackgroundImage = global::GraphicalGameProject.Properties.Resources.jet;
            this.player.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.player.Location = new System.Drawing.Point(350, 190);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(94, 91);
            this.player.TabIndex = 0;
            this.player.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // progressBar
            // 
            this.progressBar.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.progressBar.ForeColor = System.Drawing.Color.Red;
            this.progressBar.Location = new System.Drawing.Point(337, 276);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(120, 25);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 1;
            this.progressBar.Value = 100;
            // 
            // globalProgress
            // 
            this.globalProgress.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.globalProgress.ForeColor = System.Drawing.Color.Red;
            this.globalProgress.Location = new System.Drawing.Point(786, 34);
            this.globalProgress.Name = "globalProgress";
            this.globalProgress.Size = new System.Drawing.Size(179, 23);
            this.globalProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.globalProgress.TabIndex = 2;
            this.globalProgress.Value = 100;
            // 
            // flash
            // 
            this.flash.BackColor = System.Drawing.Color.Transparent;
            this.flash.BackgroundImage = global::GraphicalGameProject.Properties.Resources.flash;
            this.flash.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.flash.Location = new System.Drawing.Point(786, 22);
            this.flash.Name = "flash";
            this.flash.Size = new System.Drawing.Size(40, 46);
            this.flash.TabIndex = 3;
            this.flash.TabStop = false;
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GraphicalGameProject.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(965, 351);
            this.Controls.Add(this.flash);
            this.Controls.Add(this.globalProgress);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.player);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game Menu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.flash)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox player;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.ProgressBar globalProgress;
        private System.Windows.Forms.PictureBox flash;
    }
}

