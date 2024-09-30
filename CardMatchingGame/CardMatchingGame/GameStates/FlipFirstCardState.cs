using CardMatchingGame.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardMatchingGame.GameStates
{
    internal class FlipFirstCardState : GameState
    {
        public override void Update(GameManager gameManager)
        {
            var clickedCard = gameManager.Board.GetClickedCard();
            if (clickedCard != null)
            {
                clickedCard.Flip();
            }
        }
    }
}
