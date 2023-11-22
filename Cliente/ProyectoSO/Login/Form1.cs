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
        Login loginForm;
        Signup signupForm;
        ConsultasBasicas consultasBasicasForm;
        int idPartida;

        delegate void delegadoActualizarListaConectados(string text);
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


        int receiveBufferPosition = 0;
        byte[] receiveBuffer = new byte[1024];
        private void AtenderServidor()
        {
            while (true)
            {
                if (server == null || !server.Connected) return;

                server.Receive(receiveBuffer, receiveBufferPosition, 1, SocketFlags.None);

                if (receiveBuffer[receiveBufferPosition] == '\n')
                {
                    string respuesta = Encoding.ASCII.GetString(receiveBuffer, 0, receiveBufferPosition).Split('\0')[0];
                    string[] trozos = respuesta.Split(new[] { '/' }, 2);
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
                            consultasBasicasForm.Consulta1(mensaje);
                            break;
                        case 5:
                            consultasBasicasForm.Consulta2(mensaje);
                            break;
                        case 6:
                            consultasBasicasForm.Consulta3(mensaje);
                            break;
                        case 7:
                            //actualizarListaConectados(mensaje);
                            this.Invoke(new delegadoActualizarListaConectados(actualizarListaConectados),
                                new object[] { mensaje });
                            break;
                        case 8:
                            MessageBox.Show("Has enviado una invitación!");
                            break;
                        case 9:
                            this.Invoke(new Action(() => MostrarNotificacionInvitacion(mensaje)));
                            break;
                        case 10:
                            //no hagas nada
                            break;
                        case 11:
                            MessageBox.Show(mensaje.Split('/')[1] + " ha aceptado la invitación!");
                            break;
                        case 12:
                            //No hagas nada
                            break;
                        case 13:
                            EscribirMensaje(mensaje);
                            break;
                    }
                    receiveBufferPosition = 0;
                }
                else
                {
                    receiveBufferPosition++;
                }
            }

        }

        private void MostrarNotificacionInvitacion(string mensaje)
        {
            idPartida = Convert.ToInt32(mensaje.Split('/')[0]);
            DialogResult res = MessageBox.Show(mensaje.Split('/')[1] + " te ha invitado a una partida! Aceptas?", "Invitación", MessageBoxButtons.YesNo);
            string message;
            if (res == DialogResult.Yes)
            {
                message = "10/" + idPartida + "/1";   //partida aceptada
            }
            else
            {
                message = "10/" + idPartida + "/0";   //partida rechazada
            }

            byte[] msg = Encoding.ASCII.GetBytes(message);
            server.Send(msg);
        }

        private void Conectar_Click(object sender, EventArgs e)
        {
            //Creamos un IPEndPoint con el ip del servidor y puerto del servidor 
            //al que deseamos conectarnos

            //IPAddress direc = IPAddress.Parse(IP.Text);
            IPAddress direc = Dns.GetHostAddresses(IP.Text)[0];
            IPEndPoint ipep = new IPEndPoint(direc, 50065);


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
                atender.Abort();
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
            login.Enabled = false;
        }

        private void signup_Click(object sender, EventArgs e)
        {
            signupForm = new Signup(server);
            signupForm.ShowDialog();
        }

        private void consultasBasicas_Click(object sender, EventArgs e)
        {
            consultasBasicasForm = new ConsultasBasicas(server);
            consultasBasicasForm.ShowDialog();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (server == null || !server.Connected)
            {
                return;
            }

            string mensaje = "0/";
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
            // Se terminó el servicio. 
            // Nos desconectamos
            this.BackColor = Color.Gray;
            atender.Abort();
            server.Shutdown(SocketShutdown.Both);
            server.Close();
            login.Enabled = false;
            signup.Enabled = false;
            consultasBasicas.Enabled = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            PantallaJuegos pantallaJuego = new PantallaJuegos();
            pantallaJuego.ShowDialog();
        }
        private void actualizarListaConectados(string mensaje)
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

        private void botonInvitar_Click(object sender, EventArgs e)
        {
            string message = "8/" + listaConectados.SelectedCells.Count;
            foreach(DataGridViewCell cell in listaConectados.SelectedCells)
            {
                if ( (string) cell.Value == Usuario) continue;
                message += "/" + cell.Value;
            }
            byte[] msg = Encoding.ASCII.GetBytes(message);
            server.Send(msg);
        }

        private void enviar_Click(object sender, EventArgs e)
        {
            string mensaje = "12/" + idPartida + "/" + frase.Text;
            frase.Text = "";
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
        }
        private void EscribirMensaje(string mensaje)
        {
            string nombreEscritor = mensaje.Split('/')[0];
            string fraseEscritor = mensaje.Split('/')[1];
            textoEnviado.Text = textoEnviado.Text + '\n' + nombreEscritor + ": " + fraseEscritor;
        }
    }
}
