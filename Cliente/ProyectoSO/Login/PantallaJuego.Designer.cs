namespace Login
{
    partial class PantallaJuego
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PantallaJuego));
            this.GameTimer = new System.Windows.Forms.Timer(this.components);
            this.Tree1 = new System.Windows.Forms.PictureBox();
            this.player = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Tree1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            this.SuspendLayout();
            // 
            // GameTimer
            // 
            this.GameTimer.Enabled = true;
            this.GameTimer.Interval = 10;
            this.GameTimer.Tick += new System.EventHandler(this.MainGameTimerEvent);
            // 
            // Tree1
            // 
            this.Tree1.BackColor = System.Drawing.Color.Transparent;
            this.Tree1.Image = ((System.Drawing.Image)(resources.GetObject("Tree1.Image")));
            this.Tree1.InitialImage = global::Login.Properties.Resources.Tree1;
            this.Tree1.Location = new System.Drawing.Point(440, 375);
            this.Tree1.Name = "Tree1";
            this.Tree1.Size = new System.Drawing.Size(50, 50);
            this.Tree1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.Tree1.TabIndex = 1;
            this.Tree1.TabStop = false;
            this.Tree1.Tag = "Tree";
            // 
            // player
            // 
            this.player.BackColor = System.Drawing.Color.Red;
            this.player.Location = new System.Drawing.Point(295, 513);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(35, 50);
            this.player.TabIndex = 0;
            this.player.TabStop = false;
            // 
            // PantallaJuego
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(878, 844);
            this.Controls.Add(this.Tree1);
            this.Controls.Add(this.player);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "PantallaJuego";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "PantallaJuego";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PantallaJuego_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.PantallaJuego_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.Tree1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer GameTimer;
        private System.Windows.Forms.PictureBox player;
        private System.Windows.Forms.PictureBox Tree1;
    }
}