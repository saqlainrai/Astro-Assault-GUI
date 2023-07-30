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
        public override GameCell move()
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
            return nextCell;
        }
    }
}
