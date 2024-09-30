using CardMatchingGame.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardMatchingGame.GameStates
{
    internal class FlipSecondCardState : PlayState
    {
        public override void Update(GameManager gameManager)
        {
            var clickedCard = gameManager.Board.GetClickedCard();
            if (clickedCard != null && clickedCard != gameManager.FirstCardSelected)
            {
                clickedCard.Flip();
                gameManager.SecondCardSelected = clickedCard;
                gameManager.ChangeGameState(new ResolveTurnState());
            }
        }
    }
}
