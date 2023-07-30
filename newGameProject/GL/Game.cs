using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace newGameProject.GL
{
	public class Game
	{
		public static GameObject getBlankGameObject()
		{
			GameObject blankGameObject = new GameObject(GameObjectType.NONE, Properties.Resources.simplebox);
			return blankGameObject;
		}
		public static Image getGameObjectImage(char displayCharacter)
		{
			Image img = Properties.Resources.simplebox;
			if (displayCharacter == '|' || displayCharacter == '%')
			{
				img = Properties.Resources.vertical;
			}
			if (displayCharacter == '#')
			{
				img = Properties.Resources.horizontal;
			}
			if ((displayCharacter == 'F'))
			{
				img = Properties.Resources.flash;
			}
			if ((displayCharacter =='P'))
			{
				img = Properties.Resources.jet;
			}
			if (displayCharacter == '.')
			{
				img = Properties.Resources.pallet;
			}
			return img;
		}
	}
}
