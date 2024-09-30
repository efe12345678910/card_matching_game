using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardMatchingGame.Managers;

namespace CardMatchingGame.GameStates
{
    internal abstract class GameState
    {
        public abstract void Update(GameManager gameManager);
        public abstract void Draw(GameManager gameManager);
    }
}
