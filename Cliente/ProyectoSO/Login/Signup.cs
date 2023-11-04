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
            }
        }

        public void onResponse(string mensaje)
        {
            if (Convert.ToInt32(mensaje) == 1)
            {
                MessageBox.Show("Registro Exitoso");
                Close();
            }
            else if (Convert.ToInt32(mensaje) == 0)
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

        public void onResponseColor(string mensaje)
        {
            if (mensaje == "1")
            {
                UsuarioTextbox.ForeColor = Color.Red;
            }
            else if (mensaje == "0")
            {
                UsuarioTextbox.ForeColor = Color.Green;
            }
            else
            {
                UsuarioTextbox.ForeColor = Color.Black;
            }
        }

        private void cerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void UsuarioTextbox_TextChanged(object sender, EventArgs e)
        {
            if (UsuarioTextbox.Text.Length == 0)
            {
                return;
            }

            string mensaje = "3/" + UsuarioTextbox.Text;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            UsuarioTextbox.ForeColor = Color.DarkGray;
            server.Send(msg);            
        }
    }
}
