namespace Login
{
    partial class Login
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
            this.UsuarioTextbox = new System.Windows.Forms.TextBox();
            this.ContraseñaTextbox = new System.Windows.Forms.TextBox();
            this.iniciarSesion = new System.Windows.Forms.Button();
            this.cerrar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // UsuarioTextbox
            // 
            this.UsuarioTextbox.Location = new System.Drawing.Point(155, 178);
            this.UsuarioTextbox.Name = "UsuarioTextbox";
            this.UsuarioTextbox.Size = new System.Drawing.Size(164, 26);
            this.UsuarioTextbox.TabIndex = 0;
            // 
            // ContraseñaTextbox
            // 
            this.ContraseñaTextbox.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ContraseñaTextbox.Location = new System.Drawing.Point(155, 278);
            this.ContraseñaTextbox.Name = "ContraseñaTextbox";
            this.ContraseñaTextbox.PasswordChar = '·';
            this.ContraseñaTextbox.Size = new System.Drawing.Size(164, 26);
            this.ContraseñaTextbox.TabIndex = 1;
            // 
            // iniciarSesion
            // 
            this.iniciarSesion.Location = new System.Drawing.Point(180, 366);
            this.iniciarSesion.Name = "iniciarSesion";
            this.iniciarSesion.Size = new System.Drawing.Size(105, 33);
            this.iniciarSesion.TabIndex = 2;
            this.iniciarSesion.Text = "Login";
            this.iniciarSesion.UseVisualStyleBackColor = true;
            this.iniciarSesion.Click += new System.EventHandler(this.iniciarSesion_Click_1);
            // 
            // cerrar
            // 
            this.cerrar.Location = new System.Drawing.Point(374, 405);
            this.cerrar.Name = "cerrar";
            this.cerrar.Size = new System.Drawing.Size(81, 33);
            this.cerrar.TabIndex = 3;
            this.cerrar.Text = "Cerrar";
            this.cerrar.UseVisualStyleBackColor = true;
            this.cerrar.Click += new System.EventHandler(this.cerrar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(149, 149);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 26);
            this.label1.TabIndex = 4;
            this.label1.Text = "Usuario";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(149, 243);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 26);
            this.label2.TabIndex = 5;
            this.label2.Text = "Contraseña";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cerrar);
            this.Controls.Add(this.iniciarSesion);
            this.Controls.Add(this.ContraseñaTextbox);
            this.Controls.Add(this.UsuarioTextbox);
            this.Name = "Login";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox UsuarioTextbox;
        private System.Windows.Forms.TextBox ContraseñaTextbox;
        private System.Windows.Forms.Button iniciarSesion;
        private System.Windows.Forms.Button cerrar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}