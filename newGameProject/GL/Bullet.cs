using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newGameProject.GL
{
    public class Bullet : GameObject
    {
        GameObjectType reference;
        public Bullet(Image image, GameCell currentCell, GameObjectType reference) : base(GameObjectType.BULLET, image)
        {
            this.CurrentCell = currentCell;
            this.reference = reference;
        }
        public GameCell move()
        {
            //used to switch between cells
            GameCell currentCell = this.CurrentCell;
            GameCell nextCell = currentCell.nextCell(GameDirection.Up);
            this.CurrentCell = nextCell;

            //this will always remove the previous object
            currentCell.setGameObject(Game.getBlankGameObject());
            return null;
        }
    }
}
