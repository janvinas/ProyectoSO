using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{
    public partial class ConsultasBasicas : Form
    {
        Socket server;
        public ConsultasBasicas(Socket server)
        {
            this.server = server;
            InitializeComponent();
        }

        private void ejecutar1_Click(object sender, EventArgs e)
        {
            string mensaje = "4/Terminal";
            byte[] msg = Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
        }
        public void Consulta1(string mensaje)
        {
            if (mensaje == "-1")
            {
                MessageBox.Show("Error de base de datos");
                return;
            }
            else if (mensaje == "0")
            {
                MessageBox.Show("No se ha encontrado ningún resultado");
                return;
            }

            dataGridView1.Rows.Clear();
            string[] elementos = mensaje.Split('/');
            int i = 0;
            while (i < elementos.Length)
            {
                string[] cells = new string[3];
                for (int j = 0; j < 3; j++)
                {
                    cells[j] = elementos[i];
                    i++;

                }
                dataGridView1.Rows.Add(cells);
            }
        }
        private void ejecutar2_Click(object sender, EventArgs e)
        {
            if (consulta2.Text != "")
            {
                string mensaje = "5/" + consulta2.Text;
                byte[] msg = Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);                
            }
            else
            {
                MessageBox.Show("Debes escribir el Usuario");
            }
        }
        public void Consulta2(string mensaje)
        {
            if (mensaje == "-2")
            {
                MessageBox.Show("El usuario que has puesto no existe");
            }
            else if (mensaje == "-1")
            {
                MessageBox.Show("Error de base de datos");
            }
            else
            {
                MessageBox.Show("El dinero que tiene " + consulta2.Text + " es de: " + mensaje);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string mensaje = "6/";
            byte[] msg = Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
        }
        public void Consulta3(string mensaje)
        {
            if (mensaje == "-1")
            {
                MessageBox.Show("Error de base de datos");
                return;
            }
            else if (mensaje == "0")
            {
                MessageBox.Show("No se ha encontrado ningún resultado");
                return;
            }

            dataGridView2.Rows.Clear();
            string[] elementos = mensaje.Split('/');
            int i = 0;
            while (i < elementos.Length)
            {
                string[] cells = new string[3];
                for (int j = 0; j < 2; j++)
                {
                    cells[j] = elementos[i];
                    i++;

                }
                dataGridView2.Rows.Add(cells);
            }
        }
    }
}
