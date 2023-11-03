using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{

    public partial class PantallaJuegos : Form
    {
        bool goLeft, goRight, goUp, goDown;
        int playerSpeed=5;
        public PantallaJuegos()
        {
            InitializeComponent();
        }

        private void MainGameTimerEvent(object sender, EventArgs e)
        {
            if(goRight == true && player.Left < this.ClientSize.Width-player.Size.Width)
            {
                player.Left += playerSpeed;
                player.Image = Properties.Resources.car_right;
                Size size = new Size(50, 30);
                player.Size = size;

            }
            else if (goLeft == true && player.Left > 0)
            {
                player.Left -= playerSpeed;
                player.Image = Properties.Resources.car_leftpng;
                Size size = new Size(50, 30);
                player.Size = size;

            }
            else if (goUp == true && player.Top > 0)
            {
                player.Top -= playerSpeed;
                player.Image = Properties.Resources.car_up;
                Size size = new Size(30, 50);
                player.Size = size;

            }
            else if (goDown == true && player.Top < this.ClientSize.Height - player.Size.Height)
            {
                player.Top += playerSpeed;
                player.Image = Properties.Resources.car_down;
                Size size = new Size(30, 50);
                player.Size = size;
                
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
        }
        private void Restart()
        {

        }
    }
}
