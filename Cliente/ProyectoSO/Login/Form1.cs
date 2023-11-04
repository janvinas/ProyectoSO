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
using System.Threading;
using System.Runtime.Remoting.Messaging;

namespace Login
{
    public partial class Form1 : Form
    {
        Socket server;
        Thread atender;
        string Usuario;
        string Password;
        string Mail;
        string Genero;
        Login loginForm;
        Signup signupForm;
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            login.Enabled = false;
            signup.Enabled = false;
        }

        private void AtenderServidor()
        {
            while (true)
            {
                byte[] msg2 = new byte[300];
                server.Receive(msg2);
                string[] trozos = Encoding.ASCII.GetString(msg2).Split('/');
                int codigo = Convert.ToInt32(trozos[0]);
                string mensaje = trozos[1].Split('\0')[0];
                switch (codigo)
                {
                    case 1:
                        loginForm.onResponse(mensaje);
                        break;
                    case 2:
                        signupForm.onResponse(mensaje);
                        break;
                    case 3:
                        signupForm.onResponseColor(mensaje);
                        break;
                    case 4:
                        
                        break;
                    case 5:
                        
                        break;
                    case 6:

                        break;
                    case 7:
                        actualizarListaConnenctados(mensaje);
                        break;
                }
            }
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
            ThreadStart ts = delegate { AtenderServidor(); };
            atender = new Thread(ts);
            atender.Start();
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
            loginForm = new Login(server);
            loginForm.ShowDialog();
            Usuario = loginForm.GetUsuario();
            Password = loginForm.GetPassword();
        }

        private void signup_Click(object sender, EventArgs e)
        {
            signupForm = new Signup(server);
            signupForm.ShowDialog();
            Usuario= signupForm.GetUsuario();
            Password= signupForm.GetPassword();
            Mail = signupForm.GetMail();
            Genero = signupForm.GetGenero();
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
            PantallaJuegos pantallaJuego = new PantallaJuegos();
            pantallaJuego.ShowDialog();
        }
        private void actualizarListaConnenctados(string mensaje)
        {
            string[] tokens = mensaje.Split('/');

            listaConectados.Rows.Clear();
            int i = 1;
            while (i < tokens.Length)
            {
                listaConectados.Rows.Add(tokens[i]);
                i++;
            }
        }
    }
}
