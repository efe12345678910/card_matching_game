using CardMatchingGame.Managers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardMatchingGame.GameStates
{
    internal class FlipFirstCardState : PlayState
    {
        public override void Update(GameManager gameManager)
        {
            base.Update(gameManager);
            var clickedCard = gameManager.Board.GetClickedCard();
            if (clickedCard != null)
            {
                clickedCard.Flip();
                gameManager.FirstCardSelected = clickedCard;
                gameManager.ChangeGameState(GameStateEnum.FlipSecondCard);
                ScoreManager.Start();
            }
        }
    }
}
