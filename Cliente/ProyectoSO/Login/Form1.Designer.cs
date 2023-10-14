namespace Login
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.Conectar = new System.Windows.Forms.Button();
            this.IP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.desconectar = new System.Windows.Forms.Button();
            this.login = new System.Windows.Forms.Button();
            this.signup = new System.Windows.Forms.Button();
            this.consultasBasicas = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Conectar
            // 
            this.Conectar.Location = new System.Drawing.Point(241, 40);
            this.Conectar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Conectar.Name = "Conectar";
            this.Conectar.Size = new System.Drawing.Size(113, 30);
            this.Conectar.TabIndex = 0;
            this.Conectar.Text = "Conectarse";
            this.Conectar.UseVisualStyleBackColor = true;
            this.Conectar.Click += new System.EventHandler(this.Conectar_Click);
            // 
            // IP
            // 
            this.IP.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IP.Location = new System.Drawing.Point(87, 49);
            this.IP.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.IP.Name = "IP";
            this.IP.Size = new System.Drawing.Size(130, 24);
            this.IP.TabIndex = 1;
            this.IP.Text = "192.168.56.102";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(36, 40);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 31);
            this.label1.TabIndex = 2;
            this.label1.Text = "IP";
            // 
            // desconectar
            // 
            this.desconectar.Location = new System.Drawing.Point(396, 40);
            this.desconectar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.desconectar.Name = "desconectar";
            this.desconectar.Size = new System.Drawing.Size(113, 30);
            this.desconectar.TabIndex = 3;
            this.desconectar.Text = "Desconectarse";
            this.desconectar.UseVisualStyleBackColor = true;
            this.desconectar.Click += new System.EventHandler(this.desconectar_Click);
            // 
            // login
            // 
            this.login.Location = new System.Drawing.Point(101, 176);
            this.login.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(91, 31);
            this.login.TabIndex = 4;
            this.login.Text = "Login";
            this.login.UseVisualStyleBackColor = true;
            this.login.Click += new System.EventHandler(this.login_Click);
            // 
            // signup
            // 
            this.signup.Location = new System.Drawing.Point(263, 176);
            this.signup.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.signup.Name = "signup";
            this.signup.Size = new System.Drawing.Size(91, 31);
            this.signup.TabIndex = 5;
            this.signup.Text = "Signup";
            this.signup.UseVisualStyleBackColor = true;
            this.signup.Click += new System.EventHandler(this.signup_Click);
            // 
            // consultasBasicas
            // 
            this.consultasBasicas.Enabled = false;
            this.consultasBasicas.Location = new System.Drawing.Point(407, 176);
            this.consultasBasicas.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.consultasBasicas.Name = "consultasBasicas";
            this.consultasBasicas.Size = new System.Drawing.Size(116, 31);
            this.consultasBasicas.TabIndex = 6;
            this.consultasBasicas.Text = "Consultas Básicas";
            this.consultasBasicas.UseVisualStyleBackColor = true;
            this.consultasBasicas.Click += new System.EventHandler(this.consultasBasicas_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 332);
            this.Controls.Add(this.consultasBasicas);
            this.Controls.Add(this.signup);
            this.Controls.Add(this.login);
            this.Controls.Add(this.desconectar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.IP);
            this.Controls.Add(this.Conectar);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Conectar;
        private System.Windows.Forms.TextBox IP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button desconectar;
        private System.Windows.Forms.Button login;
        private System.Windows.Forms.Button signup;
        private System.Windows.Forms.Button consultasBasicas;
    }
}

