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
    }
}
