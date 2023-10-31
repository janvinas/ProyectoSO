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
            this.button1 = new System.Windows.Forms.Button();
            this.listaConectados = new System.Windows.Forms.DataGridView();
            this.actualizarListaConectados = new System.Windows.Forms.Button();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.listaConectados)).BeginInit();
            this.SuspendLayout();
            // 
            // Conectar
            // 
            this.Conectar.Location = new System.Drawing.Point(362, 62);
            this.Conectar.Name = "Conectar";
            this.Conectar.Size = new System.Drawing.Size(170, 46);
            this.Conectar.TabIndex = 0;
            this.Conectar.Text = "Conectarse";
            this.Conectar.UseVisualStyleBackColor = true;
            this.Conectar.Click += new System.EventHandler(this.Conectar_Click);
            // 
            // IP
            // 
            this.IP.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IP.Location = new System.Drawing.Point(130, 75);
            this.IP.Name = "IP";
            this.IP.Size = new System.Drawing.Size(193, 32);
            this.IP.TabIndex = 1;
            this.IP.Text = "192.168.56.102";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(54, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 46);
            this.label1.TabIndex = 2;
            this.label1.Text = "IP";
            // 
            // desconectar
            // 
            this.desconectar.Location = new System.Drawing.Point(594, 62);
            this.desconectar.Name = "desconectar";
            this.desconectar.Size = new System.Drawing.Size(170, 46);
            this.desconectar.TabIndex = 3;
            this.desconectar.Text = "Desconectarse";
            this.desconectar.UseVisualStyleBackColor = true;
            this.desconectar.Click += new System.EventHandler(this.desconectar_Click);
            // 
            // login
            // 
            this.login.Location = new System.Drawing.Point(277, 271);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(136, 48);
            this.login.TabIndex = 4;
            this.login.Text = "Login";
            this.login.UseVisualStyleBackColor = true;
            this.login.Click += new System.EventHandler(this.login_Click);
            // 
            // signup
            // 
            this.signup.Location = new System.Drawing.Point(443, 271);
            this.signup.Name = "signup";
            this.signup.Size = new System.Drawing.Size(136, 48);
            this.signup.TabIndex = 5;
            this.signup.Text = "Signup";
            this.signup.UseVisualStyleBackColor = true;
            this.signup.Click += new System.EventHandler(this.signup_Click);
            // 
            // consultasBasicas
            // 
            this.consultasBasicas.Enabled = false;
            this.consultasBasicas.Location = new System.Drawing.Point(610, 271);
            this.consultasBasicas.Name = "consultasBasicas";
            this.consultasBasicas.Size = new System.Drawing.Size(174, 48);
            this.consultasBasicas.TabIndex = 6;
            this.consultasBasicas.Text = "Consultas Básicas";
            this.consultasBasicas.UseVisualStyleBackColor = true;
            this.consultasBasicas.Click += new System.EventHandler(this.consultasBasicas_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(392, 400);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(138, 48);
            this.button1.TabIndex = 7;
            this.button1.Text = "Juego";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listaConectados
            // 
            this.listaConectados.AllowUserToAddRows = false;
            this.listaConectados.AllowUserToDeleteRows = false;
            this.listaConectados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listaConectados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nombre});
            this.listaConectados.Location = new System.Drawing.Point(25, 171);
            this.listaConectados.Name = "listaConectados";
            this.listaConectados.ReadOnly = true;
            this.listaConectados.RowHeadersWidth = 62;
            this.listaConectados.RowTemplate.Height = 28;
            this.listaConectados.Size = new System.Drawing.Size(180, 277);
            this.listaConectados.TabIndex = 8;
            // 
            // actualizarListaConectados
            // 
            this.actualizarListaConectados.Location = new System.Drawing.Point(109, 454);
            this.actualizarListaConectados.Name = "actualizarListaConectados";
            this.actualizarListaConectados.Size = new System.Drawing.Size(96, 33);
            this.actualizarListaConectados.TabIndex = 9;
            this.actualizarListaConectados.Text = "Actualizar";
            this.actualizarListaConectados.UseVisualStyleBackColor = true;
            this.actualizarListaConectados.Click += new System.EventHandler(this.actualizarListaConectados_Click);
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.MinimumWidth = 8;
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 150;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 511);
            this.Controls.Add(this.actualizarListaConectados);
            this.Controls.Add(this.listaConectados);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.consultasBasicas);
            this.Controls.Add(this.signup);
            this.Controls.Add(this.login);
            this.Controls.Add(this.desconectar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.IP);
            this.Controls.Add(this.Conectar);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.listaConectados)).EndInit();
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView listaConectados;
        private System.Windows.Forms.Button actualizarListaConectados;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
    }
}

