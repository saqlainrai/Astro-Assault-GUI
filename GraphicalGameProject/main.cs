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
using GraphicalGameProject.GL;
using GraphicalGameProject.Properties;

namespace GraphicalGameProject
{
    public partial class main : Form
    {
        List<PictureBox> healths = new List<PictureBox>();
        Random random = new Random();
        List<PictureBox> bullets;
        List<Enemy> enemies;
        List<PictureBox> enemyBullets;
        int timer = 0;
        int health = 3;
        public main()
        {
            InitializeComponent();
            globalProgress.Location = new System.Drawing.Point(1140, 30);
            flash.Location = new System.Drawing.Point(1115, 20);
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
                //moveEnemy(enemies[i]);
                enemies[i].move();
            }


            if (timer % 13 == 0)
            {
                PictureBox enemyBullet = createBullet(Properties.Resources.orange, enemies[0].enemy);
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
        private PictureBox createEnemy(Image g, int x1, int x2)
        {
            PictureBox p = new PictureBox();
            p.Image = g;
            p.BackColor = Color.Transparent;

            p.Width = g.Width;
            p.Height = g.Height;

            p.Left = random.Next(x1, x2);
            p.Top = random.Next(50, 100);
            return p;
        }
        private void moveEnemy(Enemy e)
        {
            if (e.direction == "MovingLeft")
            {
                e.enemy.Left -= 10;
                enemies[0].progressBar.Left -= 10;
            }
            if (e.direction == "MovingRight")
            {
                e.enemy.Left += 10;
                enemies[0].progressBar.Left += 10;
            }
            if ((e.enemy.Left + e.enemy.Width) > this.Width - 150)
            {
                e.direction = "MovingLeft";
            }
            if (e.enemy.Left <= 75)
            {
                e.direction = "MovingRight";
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
                        globalProgress.Value -= 50;
                    }
                    else
                    {
                        progressBar.Value = 0;
                        globalProgress.Value = 0;
                    }
                    this.Controls.Remove(enemyBullets[x]);
                    enemyBullets.Remove(enemyBullets[x]);
                }
            }
            if (progressBar.Value == 0)
            {
                if (health != 0)
                {
                    health--;
                    int count = healths.Count;
                    this.Controls.Remove(healths[count - 1]);
                    healths.Remove(healths[count - 1]);
                    //MessageBox.Show("Player Died!");
                    Reload();
                }
            }
            if (health == 0)
            {
                timer1.Enabled = false;
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
            enemies = new List<Enemy>();
            
            System.Windows.Forms.ProgressBar progressBarEnemy1 = new System.Windows.Forms.ProgressBar();
            System.Windows.Forms.ProgressBar progressBarEnemy2 = new System.Windows.Forms.ProgressBar();
            System.Windows.Forms.ProgressBar progressBarEnemy3 = new System.Windows.Forms.ProgressBar();

            // random object(prompt random values) is created in the function
            string enemy1Direction = "MovingLeft";
            string enemy2Direction = "MovingRight";

            timer = 0;
            health = 3;

            for (int i=0; i < health; i++)
            {
                Image icon = Properties.Resources.heart;
                
                PictureBox p = new PictureBox();
                p.Image = icon;
                p.Width = icon.Width;
                p.Height = icon.Height;
                p.BackColor = Color.Transparent;
                p.Location = new System.Drawing.Point(1145 + (i*20), 10);
                this.Controls.Add(p);
                healths.Add(p);
            }

            PictureBox enemy1 = createEnemy(Properties.Resources.enemy1, 1, 500);
            PictureBox enemy2= createEnemy(Properties.Resources.enemy2, 501, 1000);
            PictureBox enemy3= createEnemy(Properties.Resources.enemy3, 200, 800);
            
            progressBarEnemy1.Left = enemy1.Left + 10;
            progressBarEnemy1.Top = enemy1.Top - 12;
            progressBarEnemy1.Value = 100;
            progressBarEnemy1.Enabled = true;
            progressBarEnemy1.Size = new Size(80, 17);
            
            progressBarEnemy2.Left = enemy2.Left + 10;
            progressBarEnemy2.Top = enemy2.Top - 12;
            progressBarEnemy2.Value = 100;
            progressBarEnemy2.Enabled = true;
            progressBarEnemy2.Size = new Size(80, 17);
            
            progressBarEnemy3.Left = enemy3.Left + 30;
            progressBarEnemy3.Top = enemy3.Top - 12;
            progressBarEnemy3.Value = 100;
            progressBarEnemy3.Enabled = true;
            progressBarEnemy3.Size = new Size(80, 17);

            Enemy temp = new Enemy(enemy1, progressBarEnemy1, enemy1Direction);
            Enemy temp2 = new Enemy(enemy2, progressBarEnemy2, enemy2Direction);
            Enemy temp3 = new Enemy(enemy3, progressBarEnemy3, enemy1Direction);

            enemies.Add(temp);
            enemies.Add(temp2);
            enemies.Add(temp3);
            this.Controls.Add(enemy1);
            this.Controls.Add(progressBarEnemy1);
            this.Controls.Add(enemy2);
            this.Controls.Add(progressBarEnemy2);
            this.Controls.Add(enemy3);
            this.Controls.Add(progressBarEnemy3);

            player.Top += 400;
            progressBar.Top += 400;
        }
        private void Reload()
        {
            progressBar.Value = 100;
            globalProgress.Value = 100;
        }
    }
}