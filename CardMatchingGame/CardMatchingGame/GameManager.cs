using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardMatchingGame
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
    }
}
