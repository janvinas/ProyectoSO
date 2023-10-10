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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Login
{
    public partial class Login : Form
    {
        Socket server;
        public Login(Socket server)
        {
            InitializeComponent();
            this.server = server;
        }
        public string GetUsuario()
        {
            return UsuarioTextbox.Text;
        }
        public string GetPassword()
        {
            return ContraseñaTextbox.Text;
        }
        private void Login_Load(object sender, EventArgs e)
        {

        }
        private void iniciarSesion_Click_1(object sender, EventArgs e)
        {
            if (UsuarioTextbox.Text == "" || ContraseñaTextbox.Text == "")
            {
                MessageBox.Show("Debes rellenar todos los campos.", "Error", MessageBoxButtons.OK);
            }
            else
            {
                string mensaje = "1/" + UsuarioTextbox.Text + "/" + ContraseñaTextbox.Text;
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

                //Recibimos la respuesta del servidor
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                if (Convert.ToInt32(mensaje) == 1)
                {
                    MessageBox.Show("Inicio de Sesion Exitoso");
                    Close();
                }
                else if(Convert.ToInt32(mensaje) == 0)
                {
                    MessageBox.Show("Usuario o contraseña incorrectos");
                    UsuarioTextbox.Text = "";
                    ContraseñaTextbox.Text = "";
                }
                else
                {
                    MessageBox.Show("Error de base de datos");
                }
            }
        }

        private void cerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
