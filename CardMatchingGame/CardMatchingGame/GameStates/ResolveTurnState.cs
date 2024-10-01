using CardMatchingGame.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardMatchingGame.GameStates
{
    internal class ResolveTurnState : PlayState
    {
        public override void Update(GameManager gameManager)
        {
            base.Update(gameManager);
            if (InputManager.MouseClicked)
            {
                if (gameManager.FirstCardSelected.ID == gameManager.SecondCardSelected.ID)
                {
                    gameManager.Board.Collect(gameManager.FirstCardSelected,gameManager.SecondCardSelected);
                    ScoreManager.NextTurn();
                }
                //meaning;matching attempt failed 
                else
                {
                    gameManager.FirstCardSelected.Flip();
                    gameManager.SecondCardSelected.Flip();
                    ScoreManager.Miss();
                }
                if (gameManager.Board.CardsLeft <= 0)
                {
                    gameManager.ChangeGameState(GameStateEnum.Win);
                    ScoreManager.Stop();
                }
                else
                {
                    gameManager.ChangeGameState(GameStateEnum.FlipFirstCard);
                }
            }
        }
    }
}
