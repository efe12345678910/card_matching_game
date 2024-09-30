using CardMatchingGame.Managers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardMatchingGame.GameStates
{
    class PlayState : GameState
    {
        public override void Update(GameManager gameManager)
        {
        }
        public override void Draw(GameManager gameManager)
        {
            gameManager.Board.Draw();
            ScoreManager.Draw();
        }
    }
}
