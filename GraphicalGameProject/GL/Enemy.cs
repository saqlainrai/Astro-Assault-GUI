using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicalGameProject.GL
{
    public class Enemy
    {
        public PictureBox enemy;
        public ProgressBar progressBar;
        public string direction;

        public Enemy(PictureBox box, ProgressBar progress, string direction)
        {
            this.enemy = box;
            this.progressBar = progress;
            this.direction = direction;
        }

        public virtual void move()
        {
            if (direction == "MovingLeft")
            {
                enemy.Left -= 10;
                progressBar.Left -= 10;
            }
            if (direction == "MovingRight")
            {
                enemy.Left += 10;
                progressBar.Left += 10;
            }
            if ((enemy.Left + enemy.Width) > 1150)
            {
                direction = "MovingLeft";
            }
            if (enemy.Left <= 175)
            {
                direction = "MovingRight";
            }
        }
    }
}
