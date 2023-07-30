using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace newGameProject.GL
{
    public class GamePlayer : GameObject
    {
        public GamePlayer(Image image, GameCell startCell) : base(GameObjectType.PLAYER, image)
        {
            this.CurrentCell = startCell;
        }
        public GameCell move(GameDirection direction)
        {
            GameCell newCell = this.CurrentCell;
            GameCell nextCell = newCell.nextCell(direction);
            this.CurrentCell = nextCell;
            if (newCell != nextCell)
            {
                newCell.setGameObject(Game.getBlankGameObject());
            }
            return nextCell;
        }
    }
}