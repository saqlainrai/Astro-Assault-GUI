using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace newGameProject.GL
{
    public class Meteoroid : GameEnemy
    {
        public Meteoroid(Image image, GameCell currentCell) : base(image, currentCell, GameDirection.Down)
        {
            
        }
        public override void move()
        {
            //used to switch between cells
            GameCell currentCell = this.CurrentCell;
            GameCell nextCell = currentCell.nextCell(objectDirection);
            this.CurrentCell = nextCell;    
            
            //this will always remove the previous object
            currentCell.setGameObject(Game.getBlankGameObject());
        }
    }
}
