namespace Login
{
    partial class ConsultasBasicas
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
            this.label1 = new System.Windows.Forms.Label();
            this.ejecutar1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.X = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Y = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ejecutar2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.consulta2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.Logro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Jugador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(633, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Consulta 1: Obtiene la posición y el ID de partida de dónde estan ubicados todos " +
    "los edificios de terminal:";
            // 
            // ejecutar1
            // 
            this.ejecutar1.Location = new System.Drawing.Point(15, 47);
            this.ejecutar1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ejecutar1.Name = "ejecutar1";
            this.ejecutar1.Size = new System.Drawing.Size(144, 29);
            this.ejecutar1.TabIndex = 1;
            this.ejecutar1.Text = "Ejecutar consulta 1";
            this.ejecutar1.UseVisualStyleBackColor = true;
            this.ejecutar1.Click += new System.EventHandler(this.ejecutar1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.X,
            this.Y});
            this.dataGridView1.Location = new System.Drawing.Point(173, 47);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(817, 158);
            this.dataGridView1.TabIndex = 2;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 8;
            this.ID.Name = "ID";
            this.ID.Width = 150;
            // 
            // X
            // 
            this.X.HeaderText = "X";
            this.X.MinimumWidth = 8;
            this.X.Name = "X";
            this.X.Width = 150;
            // 
            // Y
            // 
            this.Y.HeaderText = "Y";
            this.Y.MinimumWidth = 8;
            this.Y.Name = "Y";
            this.Y.Width = 150;
            // 
            // ejecutar2
            // 
            this.ejecutar2.Location = new System.Drawing.Point(321, 306);
            this.ejecutar2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ejecutar2.Name = "ejecutar2";
            this.ejecutar2.Size = new System.Drawing.Size(144, 29);
            this.ejecutar2.TabIndex = 4;
            this.ejecutar2.Text = "Ejecutar consulta 2";
            this.ejecutar2.UseVisualStyleBackColor = true;
            this.ejecutar2.Click += new System.EventHandler(this.ejecutar2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 265);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(441, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Consulta 2: Obtiene el dinero que tiene la persona que se introduja abajo:";
            // 
            // consulta2
            // 
            this.consulta2.Location = new System.Drawing.Point(140, 310);
            this.consulta2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.consulta2.Name = "consulta2";
            this.consulta2.Size = new System.Drawing.Size(138, 22);
            this.consulta2.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 394);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(734, 32);
            this.label3.TabIndex = 6;
            this.label3.Text = "Consulta 3: Obtiene los nombres de los jugadores y la descripción de los logros q" +
    "ue cada jugador ha obtenido, pero no ha\r\nreclamado su recompensa.";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 464);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(144, 29);
            this.button1.TabIndex = 7;
            this.button1.Text = "Ejecutar consulta 3";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Logro,
            this.Jugador});
            this.dataGridView2.Location = new System.Drawing.Point(209, 438);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(781, 159);
            this.dataGridView2.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(58, 309);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 24);
            this.label4.TabIndex = 9;
            this.label4.Text = "Usuario";
            // 
            // Logro
            // 
            this.Logro.HeaderText = "Jugador";
            this.Logro.MinimumWidth = 6;
            this.Logro.Name = "Logro";
            this.Logro.Width = 125;
            // 
            // Jugador
            // 
            this.Jugador.HeaderText = "Logro";
            this.Jugador.MinimumWidth = 6;
            this.Jugador.Name = "Jugador";
            this.Jugador.Width = 125;
            // 
            // ConsultasBasicas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1015, 609);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.consulta2);
            this.Controls.Add(this.ejecutar2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.ejecutar1);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ConsultasBasicas";
            this.Text = "ConsultasBasicas";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ejecutar1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn X;
        private System.Windows.Forms.DataGridViewTextBoxColumn Y;
        private System.Windows.Forms.Button ejecutar2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox consulta2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Logro;
        private System.Windows.Forms.DataGridViewTextBoxColumn Jugador;
    }
}