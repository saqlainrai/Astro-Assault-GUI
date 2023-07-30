using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newGameProject.GL
{
    public class SmartJet : Jet
    {
        Random random = new Random();
        public SmartJet(Image image, GameCell cell, GameDirection direction) :base(image, cell, direction)
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
            return nextCell;
        }
    }
}
