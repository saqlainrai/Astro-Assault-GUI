using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newGameProject.GL
{
    public abstract class GameEnemy : GameObject
    {
        public GameDirection objectDirection;
        public GameEnemy(Image image, GameCell startCell, GameDirection direction) : base(GameObjectType.ENEMY, image)
        {
            this.CurrentCell = startCell;
            objectDirection = direction;
        }
        public abstract GameCell move();
    }
}
