using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{
    public partial class Form1 : Form
    {
        Socket server;
        string Usuario;
        string Password;
        string Mail;
        string Genero;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            login.Enabled = false;
            signup.Enabled = false;
        }

        private void Conectar_Click(object sender, EventArgs e)
        {
            //Creamos un IPEndPoint con el ip del servidor y puerto del servidor 
            //al que deseamos conectarnos
            IPAddress direc = IPAddress.Parse(IP.Text);
            IPEndPoint ipep = new IPEndPoint(direc, 9050);


            //Creamos el socket 
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                server.Connect(ipep);//Intentamos conectar el socket
                this.BackColor = Color.Green;
                MessageBox.Show("Conectado");
                login.Enabled = true;
                signup.Enabled = true;
                consultasBasicas.Enabled = true;
                Conectar.Enabled = false;

            }
            catch (SocketException ex)
            {
                //Si hay excepcion imprimimos error y salimos del programa con return 
                MessageBox.Show("No he podido conectar con el servidor");
                return;
            }
        }

        private void desconectar_Click(object sender, EventArgs e)
        {
            if (server != null) //se tiene q intenar hacer un try pero peta
            {
                string mensaje = "0/";
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
                // Se terminó el servicio. 
                // Nos desconectamos
                this.BackColor = Color.Gray;
                server.Shutdown(SocketShutdown.Both);
                server.Close();
                login.Enabled = false;
                signup.Enabled = false;
                consultasBasicas.Enabled = false;
                Conectar.Enabled = true;
            }
            else
                MessageBox.Show("No estas conectado con el servidor");
        }

        private void login_Click(object sender, EventArgs e)
        {
            Login login = new Login(server);
            login.ShowDialog();
            Usuario = login.GetUsuario();
            Password = login.GetPassword();
        }

        private void signup_Click(object sender, EventArgs e)
        {
            Signup signup = new Signup(server);
            signup.ShowDialog();
            Usuario=signup.GetUsuario();
            Password=signup.GetPassword();
            Mail = signup.GetMail();
            Genero = signup.GetGenero();
        }

        private void consultasBasicas_Click(object sender, EventArgs e)
        {
            ConsultasBasicas consultasBasicas= new ConsultasBasicas(server);
            consultasBasicas.ShowDialog();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (server != null) //se tiene q intenar hacer un try pero peta
            {
                string mensaje = "0/";
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
                // Se terminó el servicio. 
                // Nos desconectamos
                this.BackColor = Color.Gray;
                server.Shutdown(SocketShutdown.Both);
                server.Close();
                login.Enabled = false;
                signup.Enabled = false;
                consultasBasicas.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PantallaJuego pantallaJuego = new PantallaJuego();
            pantallaJuego.ShowDialog();
        }

        private void actualizarListaConectados_Click(object sender, EventArgs e)
        {
            if (server == null) return;

            string mensaje = "7/";
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            byte[] msg2 = new byte[300];
            server.Receive(msg2);
            mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];

            string[] tokens = mensaje.Split('/');

            listaConectados.Rows.Clear();
            int i = 1;
            while(i < tokens.Length)
            {
                listaConectados.Rows.Add(tokens[i]);
            }
        }
    }
}
