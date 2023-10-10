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
            string mensaje = "4/'Terminal'";
            byte[] msg = Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
            byte[] msg2 = new byte[80];
            server.Receive(msg2);
            mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];

        }
    }
}
