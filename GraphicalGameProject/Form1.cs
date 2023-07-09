using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using EZInput;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GraphicalGameProject
{
    public partial class main : Form
    {
        List<PictureBox> bullets = new List<PictureBox>();
        List<PictureBox> enemies = new List<PictureBox>();
        List<PictureBox> enemyBullets = new List<PictureBox>();
        System.Windows.Forms.ProgressBar progressBarEnemy;
        string enemy1Direction = "MovingRight";
        string enemy2Direction = "MovingRight";
        int timer = 0;
        public main()
        {
            InitializeComponent();
        }
        public void timerMovement()
        {
            timer++;
            for (int i = 0; i < bullets.Count; i++)
            {
                bullets[i].Top = bullets[i].Top - 10;
                if (bullets[i].Bottom < 0)
                {
                    bullets.Remove(bullets[i]);
                }
            }
            for (int x = 0; x < bullets.Count; x++)
            {
                for (int y = 0; y < enemyBullets.Count; y++)
                {
                    if (bullets[x].Bounds.IntersectsWith(enemyBullets[y].Bounds))
                    {
                        this.Controls.Remove(bullets[x]);
                        this.Controls.Remove(enemyBullets[y]);
                        
                        bullets.Remove(bullets[x]);
                        enemyBullets.Remove(enemyBullets[y]);
                    }
                }
            }
            for (int i = 0; i < enemyBullets.Count; i++)
            {
                foreach (PictureBox p in enemyBullets)
                {
                    p.Top += 5;
                }
            }
            for (int i = 0; i < enemies.Count; i++)
            {
                moveEnemy(enemies[i], ref enemy1Direction);
            }


            if (timer % 13 == 0)
            {
                PictureBox enemyBullet = createBullet(Properties.Resources.orange, enemies[0]);
                this.Controls.Add(enemyBullet);
                enemyBullets.Add(enemyBullet);
            }
        }
        private PictureBox createBullet(Image image, PictureBox source)
        {
            PictureBox p = new PictureBox();
            p.Image = image;
            p.Width = image.Width;
            p.Height = image.Height;
            p.BackColor = Color.Transparent;
            p.Location = new System.Drawing.Point(source.Left + (source.Width / 2) - 5, source.Top);
            return p;
        }
        private PictureBox createEnemy(Image g)
        {
            Random random = new Random();

            PictureBox p = new PictureBox();
            p.Image = g;
            p.BackColor = Color.Transparent;

            p.Width = g.Width;
            p.Height = g.Height;

            p.Left = random.Next(1, 101);
            p.Top = random.Next(15, 50);
            return p;
        }
        private void moveEnemy(PictureBox enemy, ref string enemyDirection)
        {
            if (enemyDirection == "MovingLeft")
            {
                enemy.Left -= 10;
                progressBarEnemy.Left -= 10;
            }
            if (enemyDirection == "MovingRight")
            {
                enemy.Left += 10;
                progressBarEnemy.Left += 10;
            }
            if ((enemy.Left + enemy.Width) > this.Width - 150)
            {
                enemyDirection = "MovingLeft";
            }
            if (enemy.Left <= 75)
            {
                enemyDirection = "MovingRight";
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Keyboard.IsKeyPressed(Key.RightArrow))
            {
                player.Left += 25;
                progressBar.Left += 25;
            }
            if (Keyboard.IsKeyPressed(Key.LeftArrow))
            {
                player.Left -= 25;
                progressBar.Left -= 25;
            }
            if (Keyboard.IsKeyPressed(Key.UpArrow))
            {
                player.Top -= 25;
                progressBar.Top -= 25;
            }
            if (Keyboard.IsKeyPressed(Key.DownArrow))
            {
                player.Top += 25;
                progressBar.Top += 25;
            }

            if (Keyboard.IsKeyPressed(Key.Space))
            {
                Image image = Properties.Resources.fireshot;
                PictureBox bullet = new PictureBox();
                bullet.Image = image;

                bullet.Top = player.Top - 70;
                bullet.Left = player.Left + (player.Width / 2) - 30;

                bullet.Height = image.Height;
                bullet.Width = image.Width;

                bullet.BackColor = Color.Transparent;

                this.Controls.Add(bullet);
                bullets.Add(bullet);
            }
            for (int x = 0; x < enemyBullets.Count; x++)
            {
                if (enemyBullets[x].Bounds.IntersectsWith(player.Bounds))
                {
                    if (progressBar.Value >= 10)
                    {
                        progressBar.Value -= 50;
                    }
                    else
                    {
                        progressBar.Value = 0;
                    }
                    this.Controls.Remove(enemyBullets[x]);
                    enemyBullets.Remove(enemyBullets[x]);
                }
            }
            if (progressBar.Value == 0)
            {
                timer1.Enabled = false;
                //MessageBox.Show("You Lose", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Form f = new EndScreen();
                this.Hide();
                f.Show();
            }
            timerMovement();
        }// end of timer

        private void main_Load(object sender, EventArgs e)
        {
            Restart();
        }
        //protected override void OnPaint(PaintEventArgs e)
        //{
        //    base.OnPaint(e);

        //    // Specify the desired color for the progress bar
        //    Color desiredColor = Color.Blue;

        //    // Calculate the width of the progress bar
        //    int width = (int)(progressBar.Width * ((double)progressBar.Value / progressBar.Maximum));

        //    // Create a brush with the desired color
        //    using (Brush brush = new SolidBrush(desiredColor))
        //    {
        //        // Fill the progress bar with the specified color
        //        e.Graphics.FillRectangle(brush, progressBar.Left, progressBar.Top, width, progressBar.Height);
        //    }

        //}
        private void Restart()
        {
            //this.Controls.Clear();
            bullets = new List<PictureBox>();
            enemyBullets = new List<PictureBox>();
            enemies = new List<PictureBox>();
            
            progressBarEnemy = new System.Windows.Forms.ProgressBar();

            // random object(prompt random values) is created in the function
            enemy1Direction = "MovingLeft";
            enemy2Direction = "MovingRight";
            timer = 0;

            PictureBox enemy = createEnemy(Properties.Resources.enemy2);
            progressBarEnemy.Left = enemy.Left + 10;
            progressBarEnemy.Top = enemy.Top - 12;

            progressBarEnemy.Value = 100;
            progressBarEnemy.Enabled = true;
            progressBarEnemy.Size = new Size(80, 17);
            this.Controls.Add(progressBarEnemy);

            enemies.Add(enemy);
            this.Controls.Add(enemy);

            player.Top += 400;
            progressBar.Top += 400;
        }
    }
}
