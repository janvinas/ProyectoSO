namespace Login
{
    partial class Signup
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
            this.Registrarse = new System.Windows.Forms.Button();
            this.cerrar = new System.Windows.Forms.Button();
            this.UsuarioTextbox = new System.Windows.Forms.TextBox();
            this.ContraseñaTextbox = new System.Windows.Forms.TextBox();
            this.RepetirContraseñaTextbox = new System.Windows.Forms.TextBox();
            this.MailTextbox = new System.Windows.Forms.TextBox();
            this.Hombre = new System.Windows.Forms.RadioButton();
            this.Mujer = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Registrarse
            // 
            this.Registrarse.Location = new System.Drawing.Point(176, 422);
            this.Registrarse.Name = "Registrarse";
            this.Registrarse.Size = new System.Drawing.Size(106, 40);
            this.Registrarse.TabIndex = 0;
            this.Registrarse.Text = "Registrarse";
            this.Registrarse.UseVisualStyleBackColor = true;
            this.Registrarse.Click += new System.EventHandler(this.Registrarse_Click);
            // 
            // cerrar
            // 
            this.cerrar.Location = new System.Drawing.Point(363, 456);
            this.cerrar.Name = "cerrar";
            this.cerrar.Size = new System.Drawing.Size(81, 33);
            this.cerrar.TabIndex = 1;
            this.cerrar.Text = "Cerrar";
            this.cerrar.UseVisualStyleBackColor = true;
            this.cerrar.Click += new System.EventHandler(this.cerrar_Click);
            // 
            // UsuarioTextbox
            // 
            this.UsuarioTextbox.Location = new System.Drawing.Point(144, 85);
            this.UsuarioTextbox.Name = "UsuarioTextbox";
            this.UsuarioTextbox.Size = new System.Drawing.Size(166, 26);
            this.UsuarioTextbox.TabIndex = 2;
            // 
            // ContraseñaTextbox
            // 
            this.ContraseñaTextbox.Location = new System.Drawing.Point(144, 156);
            this.ContraseñaTextbox.Name = "ContraseñaTextbox";
            this.ContraseñaTextbox.PasswordChar = '*';
            this.ContraseñaTextbox.Size = new System.Drawing.Size(166, 26);
            this.ContraseñaTextbox.TabIndex = 3;
            // 
            // RepetirContraseñaTextbox
            // 
            this.RepetirContraseñaTextbox.Location = new System.Drawing.Point(144, 229);
            this.RepetirContraseñaTextbox.Name = "RepetirContraseñaTextbox";
            this.RepetirContraseñaTextbox.PasswordChar = '*';
            this.RepetirContraseñaTextbox.Size = new System.Drawing.Size(166, 26);
            this.RepetirContraseñaTextbox.TabIndex = 4;
            // 
            // MailTextbox
            // 
            this.MailTextbox.Location = new System.Drawing.Point(144, 297);
            this.MailTextbox.Name = "MailTextbox";
            this.MailTextbox.Size = new System.Drawing.Size(166, 26);
            this.MailTextbox.TabIndex = 5;
            // 
            // Hombre
            // 
            this.Hombre.AutoSize = true;
            this.Hombre.Location = new System.Drawing.Point(144, 371);
            this.Hombre.Name = "Hombre";
            this.Hombre.Size = new System.Drawing.Size(91, 24);
            this.Hombre.TabIndex = 6;
            this.Hombre.TabStop = true;
            this.Hombre.Text = "Hombre";
            this.Hombre.UseVisualStyleBackColor = true;
            // 
            // Mujer
            // 
            this.Mujer.AutoSize = true;
            this.Mujer.Location = new System.Drawing.Point(241, 371);
            this.Mujer.Name = "Mujer";
            this.Mujer.Size = new System.Drawing.Size(73, 24);
            this.Mujer.TabIndex = 7;
            this.Mujer.TabStop = true;
            this.Mujer.Text = "Mujer";
            this.Mujer.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(139, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 26);
            this.label1.TabIndex = 8;
            this.label1.Text = "Usuario";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(139, 268);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 26);
            this.label3.TabIndex = 10;
            this.label3.Text = "Mail";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(139, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(200, 26);
            this.label4.TabIndex = 11;
            this.label4.Text = "Repetir Contraseña";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(140, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 26);
            this.label2.TabIndex = 12;
            this.label2.Text = "Contraseña";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(139, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 26);
            this.label5.TabIndex = 13;
            this.label5.Text = "Contraseña";
            // 
            // Signup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 501);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Mujer);
            this.Controls.Add(this.Hombre);
            this.Controls.Add(this.MailTextbox);
            this.Controls.Add(this.RepetirContraseñaTextbox);
            this.Controls.Add(this.ContraseñaTextbox);
            this.Controls.Add(this.UsuarioTextbox);
            this.Controls.Add(this.cerrar);
            this.Controls.Add(this.Registrarse);
            this.Name = "Signup";
            this.Text = "Registrarse";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Registrarse;
        private System.Windows.Forms.Button cerrar;
        private System.Windows.Forms.TextBox UsuarioTextbox;
        private System.Windows.Forms.TextBox ContraseñaTextbox;
        private System.Windows.Forms.TextBox RepetirContraseñaTextbox;
        private System.Windows.Forms.TextBox MailTextbox;
        private System.Windows.Forms.RadioButton Hombre;
        private System.Windows.Forms.RadioButton Mujer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
    }
}