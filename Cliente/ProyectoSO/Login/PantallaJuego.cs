using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{

    public partial class PantallaJuegos : Form
    {
        bool goLeft, goRight, goUp, goDown,escape;
        int ax, ay;
        int friccion = 1;
        int vy, vx;
        int playerSpeed=5;
        public PantallaJuegos()
        {
            InitializeComponent();
        }

        private void PantallaJuegos_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel1.Enabled = false;
            panel1.Location = new Point(this.Width/2-panel1.Width/2, this.Height / 2 - panel1.Height / 2);
            panel2.Visible = false;
            panel2.Enabled = false;
            panel2.Location = new Point(this.Width / 2 - panel2.Width / 2, this.Height / 2 - panel2.Height / 2);
        }

        private void cerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void continua_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel1.Enabled = false;
        }

        private void opciones_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel1.Enabled = false;
            panel2.Visible = true;
            panel2.Enabled = true;
        }

        private void cerrar_opt_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel2.Enabled = false;
            panel1.Visible = true;
            panel1.Enabled = true;
        }

        private void MainGameTimerEvent(object sender, EventArgs e)
        {
            if (goDown)
            {
                ay = 3;
                player.Image = Properties.Resources.car_down;
                Size size = new Size(30, 50);
                player.Size = size;
            }
            else if (goUp)
            {
                ay = -3;
                player.Image = Properties.Resources.car_up;
                Size size = new Size(30, 50);
                player.Size = size;
            }
            else if (goLeft)
            {
                ax = -3;
                player.Image = Properties.Resources.car_leftpng;
                Size size = new Size(50, 30);
                player.Size = size;
            }
            else if (goRight)
            {
                ax = 3;
                player.Image = Properties.Resources.car_right;
                Size size = new Size(50, 30);
                player.Size = size;
            }
            else
            {
                ax = 0;
                ay = 0;
            }

            if (escape == true)
            {
                panel1.Visible = true;
                panel1.Enabled = true;
            }
            if(player.Left >= this.ClientSize.Width-player.Size.Width)
            {
                vx = 0;
                player.Left -= 1;
            }
            else if (player.Left <= 0)
            {
                vx = 0;
                player.Left += 1;
            }
            else if (player.Top <= 0)
            {
                vy = 0;
                player.Top += 1;
            }
            else if (player.Top >= this.ClientSize.Height - player.Size.Height)
            {
                vy = 0;
                player.Top -= 1;
            }
            else
            {
                vx += ax - friccion * Math.Sign(vx);
                vy += ay - friccion * Math.Sign(vy);

                player.Top += vy;
                player.Left += vx;
            }
  
            foreach(Control x in this.Controls)
            {
                if(x is PictureBox)
                {
                    if ((string)x.Tag == "Tree")
                    {
                        if (player.Top == x.Top - player.Size.Height)
                            goUp = false;
                    }
                }
            }
        }

        private void PantallaJuego_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }
            if (e.KeyCode == Keys.Up)
            {
                goUp = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                goDown = false;
            }
            if(e.KeyCode == Keys.Escape)
            {
                escape = false;
            }
        }

        private void PantallaJuego_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Left)
            {
                goLeft = true;
            }
            if(e.KeyCode == Keys.Right) 
            {
                goRight = true;
            }
            if (e.KeyCode == Keys.Up)
            {
                goUp = true;
            }
            if (e.KeyCode == Keys.Down)
            {
                goDown = true;
            }
            if (e.KeyCode == Keys.Escape)
            {
                escape = true;
            }
        }
        private void Restart()
        {

        }
    }
}
