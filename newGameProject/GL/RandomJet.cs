using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newGameProject.GL
{
    public class RandomJet : Jet
    {
        Random random = new Random();
        int timer = 0;
        public RandomJet(Image image, GameCell cell) :base(image, cell, GameDirection.Left)
        {

        }
        public override void move()
        {
            timer++;
            if (timer == 10)
            {
                setObjectDirection();
                timer = 0;
            }
            GameCell currentCell = this.CurrentCell;
            GameCell nextCell = currentCell.nextCell(objectDirection);
            if (nextCell.CurrentGameObject.GameObjectType == GameObjectType.WALL)
            {
                setObjectDirection();
            }
            this.CurrentCell = nextCell;
            if (currentCell != nextCell)
            {
                currentCell.setGameObject(Game.getBlankGameObject());
            }
        }
        private void setObjectDirection()
        {
            GameDirection[] allDirections = { GameDirection.Up, GameDirection.Down, GameDirection.Left, GameDirection.Right };
            int rand = random.Next(0, 4);
            objectDirection = allDirections[rand];
        }
    }
}
