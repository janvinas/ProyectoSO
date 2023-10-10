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
    public partial class Signup : Form
    {
        Socket server;
        public Signup(Socket server)
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
        public string GetMail()
        {
            return MailTextbox.Text;
        }
        public string GetGenero()
        {
            return Genero;
        }
        string Genero;
        private void Registrarse_Click(object sender, EventArgs e)
        {
            if (MailTextbox.Text == "" || UsuarioTextbox.Text == "" || ContraseñaTextbox.Text == "" || RepetirContraseñaTextbox.Text == "")
            {
                MessageBox.Show("Debes rellenar todos los campos.", "Error", MessageBoxButtons.OK);
            }
            else if (!Hombre.Checked && !Mujer.Checked)
            {
                MessageBox.Show("Debes seleccionar Hombre/Mujer.", "Error", MessageBoxButtons.OK);
            }
            else if (!ContraseñaTextbox.Text.Equals(RepetirContraseñaTextbox.Text))
            {
                MessageBox.Show("Las contraseñas no coinciden.", "Error", MessageBoxButtons.OK);
            }
            else if (UsuarioTextbox.Text.Contains(" "))
            {
                MessageBox.Show("El nombre de usuario no puede contener espacios.", "Error", MessageBoxButtons.OK);
            }
            else
            {
                if (Hombre.Checked)
                    Genero = "H";
                else if (Mujer.Checked)
                    Genero = "M";

                string mensaje = "2/" + UsuarioTextbox.Text + "/" + ContraseñaTextbox.Text + "/" + MailTextbox.Text +
                    "/" + Genero;
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

                //Recibimos la respuesta del servidor
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                if (Convert.ToInt32(mensaje) == 1)
                {
                    MessageBox.Show("Registro Exitoso");
                    Close();
                }
                else if(Convert.ToInt32(mensaje) == 0)
                {
                    MessageBox.Show("El usuario ya existe");
                    UsuarioTextbox.Text = "";
                    ContraseñaTextbox.Text = "";
                    RepetirContraseñaTextbox.Text = "";
                    MailTextbox.Text = "";
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
    }
}
