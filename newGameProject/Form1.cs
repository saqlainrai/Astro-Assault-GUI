using newGameProject.GL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using EZInput;
using newGameProject.DL;

namespace newGameProject
{
    public partial class Form1 : Form
    {
        Random random = new Random();
        GameGrid grid;
        GamePlayer fighter;
        bool loop1 = true;
        int timer = 0;
        int score = 0;

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            grid = new GameGrid("maze.txt", 25, 50);
            Image pacManImage = Game.getGameObjectImage('P');
            GameCell startCell = grid.getCell(20, 30);
            fighter = new GamePlayer(pacManImage, startCell);

            printMaze(grid);

            progressBar1.Value = 100;
            //progressBar1.Location = new System.Drawing.Point(100, 100);
            progressBar1.Location = new System.Drawing.Point(44 * 30, 35);
            label1.Location = new System.Drawing.Point(43 * 30, 65);
            textBox1.Location = new System.Drawing.Point(44 * 30 + 20, 65);

            progressBar1.Show();
            progressBar1.BringToFront();

            Jet jet1 = new Jet(Properties.Resources.enemy1, grid.getCell(7, 46), GameDirection.Left);
            Jet jet2 = new Jet(Properties.Resources.enemy2, grid.getCell(3, 40), GameDirection.Right);
            Jet jet3 = new Jet(Properties.Resources.enemy3, grid.getCell(2, 30), GameDirection.Left);
            Jet jet4 = new Jet(Properties.Resources.spaceship1, grid.getCell(5, 10), GameDirection.Right);
            Jet jet5 = new Jet(Properties.Resources.spaceship2, grid.getCell(4, 20), GameDirection.Left);
            EnemyDL.allJets.Add(jet1);
            EnemyDL.allJets.Add(jet2);
            EnemyDL.allJets.Add(jet3);
            EnemyDL.allJets.Add(jet4);
            EnemyDL.allJets.Add(jet5);
        }
        void printMaze(GameGrid grid)
        {
            for (int x = 0; x < grid.Rows; x++)
            {
                for (int y = 0; y < grid.Cols; y++)
                {
                    GameCell cell = grid.getCell(x, y);
                    cell.PictureBox.BackColor = Color.Transparent;
                    this.Controls.Add(cell.PictureBox);
                    //printCell(cell);
                }
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer++;
            //timer = 3;
            textBox1.Text = score.ToString();
            if (Keyboard.IsKeyPressed(Key.LeftArrow) || Keyboard.IsKeyPressed(Key.A))
            {
                fighter.move(GameDirection.Left);
            }
            if (Keyboard.IsKeyPressed(Key.RightArrow) || Keyboard.IsKeyPressed(Key.D))
            {
                fighter.move(GameDirection.Right);
            }
            if (Keyboard.IsKeyPressed(Key.UpArrow) || Keyboard.IsKeyPressed(Key.W))
            {
                fighter.move(GameDirection.Up);
            }
            if (Keyboard.IsKeyPressed(Key.DownArrow) || Keyboard.IsKeyPressed(Key.S))
            {
                fighter.move(GameDirection.Down);
            }

            if (Keyboard.IsKeyPressed(Key.Space))
            {
                GameCell temp = grid.getCell(fighter.CurrentCell.X - 1, fighter.CurrentCell.Y);
                Bullet bullet = new Bullet(Properties.Resources.fireBullet, temp, GameObjectType.PLAYER);
                BulletDL.allBullets.Add(bullet);
            }
            if (Keyboard.IsKeyPressed(Key.Z))
            {
                Jet jet1 = new Jet(Properties.Resources.enemy1, grid.getCell(7, 46), GameDirection.Left);
                Jet jet2 = new Jet(Properties.Resources.enemy2, grid.getCell(3, 40), GameDirection.Right);
                Jet jet3 = new Jet(Properties.Resources.enemy3, grid.getCell(2, 30), GameDirection.Left);
                Jet jet4 = new Jet(Properties.Resources.spaceship1, grid.getCell(5, 10), GameDirection.Right);
                Jet jet5 = new Jet(Properties.Resources.spaceship2, grid.getCell(4, 20), GameDirection.Left);
                EnemyDL.allJets.Add(jet1);
                EnemyDL.allJets.Add(jet2);
                EnemyDL.allJets.Add(jet3);
                EnemyDL.allJets.Add(jet4);
                EnemyDL.allJets.Add(jet5);
            }

            //if (loop1)
            //{
                //foreach (Meteoroid j in EnemyDL.allMeteoroids)
                //{
                //    foreach (Bullet i in BulletDL.allBullets)
                //    {
                //        GameCell reference = i.CurrentCell;
                //        GameCell nextCell = reference.nextCell(GameDirection.Up);
                //        if (nextCell.CurrentGameObject.GameObjectType == GameObjectType.ENEMY)
                //        {
                //            BulletDL.allBullets.Remove(i);
                //            EnemyDL.allMeteoroids.Remove(j);
                //        }
                //        i.move();
                //    }
                //    j.move();
                //}
                //for (int i = 0, j = 0; i < EnemyDL.allMeteoroids.Count; i++, j++)
                //{
                //    //for (int j = 0; j < BulletDL.allBullets.Count; j++)
                //    //{
                //        GameCell reference = BulletDL.allBullets[j].CurrentCell;
                //        GameCell nextCell = reference.nextCell(GameDirection.Up);
                //        if (nextCell.CurrentGameObject.GameObjectType == GameObjectType.ENEMY)
                //        {
                //            BulletDL.allBullets.Remove(BulletDL.allBullets[j]);
                //            EnemyDL.allMeteoroids.Remove(EnemyDL.allMeteoroids[i]);
                //        }
                //        else
                //        {
                //            BulletDL.allBullets[j].move();
                //        }
                //    //}
                //    EnemyDL.allMeteoroids[i].move();
                //}
            //    loop1 = false;
            //}
            //else
            //{
            //    loop1 = true;  
            //}

            //loop1 will reduce the execution to one half
            if (loop1)
            {
                // moving Bullets
                for (int i = 0; i < BulletDL.allBullets.Count; i++)
                {
                    //GameCell reference = BulletDL.allBullets[i].CurrentCell;
                    //GameCell nextCell = reference.nextCell(GameDirection.Up);
                    //if (nextCell.CurrentGameObject.GameObjectType == GameObjectType.NONE)
                    //{
                    //    BulletDL.allBullets[i].CurrentCell = nextCell;
                    //    reference.setGameObject(Game.getBlankGameObject());
                    //}
                    //else if (nextCell.CurrentGameObject.GameObjectType == GameObjectType.ENEMY)
                    //{
                    //    score += 5;
                    //    reference.setGameObject(Game.getBlankGameObject());
                    //    nextCell.setGameObject(Game.getBlankGameObject());
                    //    //nextCell.CurrentGameObject.Collided = true;
                    //    BulletDL.allBullets.Remove(BulletDL.allBullets[i]);
                    //}
                    //else
                    //{
                    //    reference.setGameObject(Game.getBlankGameObject());
                    //    BulletDL.allBullets.Remove(BulletDL.allBullets[i]);
                    //}
                    BulletDL.allBullets[i].move();
                    
                }

                //foreach (Meteoroid i in EnemyDL.allMeteoroids)
                //{
                //    if (i.Collided == true)
                //    {
                //        EnemyDL.allMeteoroids.Remove(i);
                //    }
                //}

                //moving enemies
                for (int x = 0; x < EnemyDL.allMeteoroids.Count; x++)
                {
                    //GameCell reference = EnemyDL.allMeteoroids[x].CurrentCell;
                    //GameCell nextCell = reference.nextCell(GameDirection.Down);
                    //if (nextCell.CurrentGameObject.GameObjectType == GameObjectType.NONE)
                    //{
                    //    EnemyDL.allMeteoroids[x].CurrentCell = nextCell;
                    //    reference.setGameObject(Game.getBlankGameObject());
                    //}
                    //else if (nextCell.CurrentGameObject.GameObjectType == GameObjectType.BULLET)
                    //{
                    //    reference.setGameObject(Game.getBlankGameObject());
                    //    nextCell.setGameObject(Game.getBlankGameObject());
                    //    progressBar1.Value -= 10;
                    //    EnemyDL.allMeteoroids.Remove(EnemyDL.allMeteoroids[x]);
                    //}
                    //else
                    //{
                    //    reference.setGameObject(Game.getBlankGameObject());
                    //    EnemyDL.allMeteoroids.Remove(EnemyDL.allMeteoroids[x]);
                    //}

                    GameCell reference = EnemyDL.allMeteoroids[x].CurrentCell;
                    GameCell nextCell = reference.nextCell(GameDirection.Down);
                    if (nextCell.CurrentGameObject.GameObjectType == GameObjectType.PLAYER)
                    {
                        if (progressBar1.Value < 10)
                        {
                            GameOver();
                        }
                        else
                        {
                            progressBar1.Value -= 10;
                        }
                    }
                    EnemyDL.allMeteoroids[x].move();
                }
                for (int y = 0; y < EnemyDL.allJets.Count; y++)
                {
                    //GameCell reference = EnemyDL.allJets[y].CurrentCell;
                    //GameCell nextCell = reference.nextCell(GameDirection.Down);
                    //if (nextCell.CurrentGameObject.GameObjectType == GameObjectType.NONE)
                    //{
                    //    EnemyDL.allJets[y].CurrentCell = nextCell;
                    //    reference.setGameObject(Game.getBlankGameObject());
                    //}
                    //else if (nextCell.CurrentGameObject.GameObjectType == GameObjectType.BULLET)
                    //{
                    //    reference.setGameObject(Game.getBlankGameObject());
                    //    nextCell.setGameObject(Game.getBlankGameObject());
                    //    progressBar1.Value -= 10;
                    //    EnemyDL.allJets.Remove(EnemyDL.allJets[y]);
                    //}
                    //else
                    //{
                    //    reference.setGameObject(Game.getBlankGameObject());
                    //    EnemyDL.allJets.Remove(EnemyDL.allJets[y]);
                    //}
                    EnemyDL.allJets[y].move();
                }
                loop1 = false;
            }
            else
            {
                loop1 = true;
            }

            if (timer % 23 == 0)
            {
                int x = random.Next(1, 15);
                int y = random.Next(1, 49);
                Meteoroid temp = new Meteoroid(Properties.Resources.meteoroid1, grid.getCell(x, y));
                //temp.Index = EnemyDL.allMeteoroids.Count;
                EnemyDL.allMeteoroids.Add(temp);
            }
            else if (timer % 41 == 0)
            {
                int x = random.Next(1, 10);
                int y = random.Next(10, 49);
                Meteoroid temp = new Meteoroid(Properties.Resources.meteoroid2, grid.getCell(x, y));
                //temp.Index = EnemyDL.allMeteoroids.Count;
                EnemyDL.allMeteoroids.Add(temp);
            }
            else if (timer % 51 == 0)
            {
                int x = random.Next(1, 10);
                int y = random.Next(1, 40);
                Meteoroid temp = new Meteoroid(Properties.Resources.meteoroid3, grid.getCell(x, y));
                //temp.Index = EnemyDL.allMeteoroids.Count;
                EnemyDL.allMeteoroids.Add(temp);
            }

            if (timer == 100)
            {
                Jet jet = new Jet(Properties.Resources.monster, grid.getCell(10, 35), GameDirection.Down);
                EnemyDL.allJets.Add(jet);
                timer = 0;
            }
        }
        private void GameOver()
        {
            Form form = new EndScreen();
            form.Show();
            this.Close();
        }
    }
}
