using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardMatchingGame.Managers
{
    internal class GameManager
    {
        private readonly Board _board;
        public GameManager()
        {
            _board = new Board();
        }
        public void Draw()
        {
            _board.Draw();
        }
        public void Update()
        {
            InputManager.Update();
            var clickedCard = _board.GetClickedCard();
            if (clickedCard != null)
            {
                clickedCard.Flip();
            }
        }
    }
}
