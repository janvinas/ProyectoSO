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
            byte[] msg2 = new byte[80];
            server.Receive(msg2);
            mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];

            if(mensaje == "-1")
            {
                MessageBox.Show("Error de base de datos");
                return;
            }
            else if(mensaje == "0")
            {
                MessageBox.Show("No se ha encontrado ningún resultado");
                return;
            }

            dataGridView1.Rows.Clear();
            string[] elementos = mensaje.Split('/');
            int i = 0;
            while(i < elementos.Length)
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
            string mensaje = "5/" + consulta2.Text;
            byte[] msg = Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
            byte[] msg2 = new byte[80];
            server.Receive(msg2);
            mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];

            if(mensaje == "-1") 
            {
                MessageBox.Show("El usuario que has puesto no existe");
            }else if(mensaje == "0")
            {
                MessageBox.Show("El dinero que tiene " + consulta2.Text + " es de: " + mensaje);
            }
        }
    }
}
