using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newGameProject.GL
{
    public class Jet : GameEnemy
    {
        public Jet(Image image, GameCell currentCell, GameDirection direction) :base(image, currentCell, direction)
        {

        }
        public override void move()
        {
            GameCell currentCell = this.CurrentCell;
            GameCell nextCell = currentCell.nextCell(objectDirection);
            this.CurrentCell = nextCell;
            if (currentCell != nextCell)
            {
                currentCell.setGameObject(Game.getBlankGameObject());
            }
            if (nextCell == currentCell)
            {
                if (objectDirection == GameDirection.Left)
                {
                    objectDirection = GameDirection.Right;
                }
                else if (objectDirection == GameDirection.Right)
                {
                    objectDirection = GameDirection.Left;
                }
            }
        }
        public virtual Bullet createBullet()
        {
            GameCell bulletCell = this.CurrentCell.nextCell(GameDirection.Down);
            Bullet b = new Bullet(Properties.Resources.red, bulletCell, GameObjectType.ENEMY);
            return b;
        }
    }
}
