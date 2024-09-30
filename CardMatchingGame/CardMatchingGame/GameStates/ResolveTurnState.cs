using CardMatchingGame.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardMatchingGame.GameStates
{
    internal class ResolveTurnState : GameState
    {
        public override void Update(GameManager gameManager)
        {
            if (InputManager.MouseClicked)
            {
                if (gameManager.FirstCardSelected.ID == gameManager.SecondCardSelected.ID)
                {
                    gameManager.FirstCardSelected.Visible = false;
                    gameManager.SecondCardSelected.Visible = false; 
                }
                //meaning;matching attempt failed 
                else
                {
                    gameManager.FirstCardSelected.Flip();
                    gameManager.SecondCardSelected.Flip();
                }
                gameManager.ChangeGameState(new FlipFirstCardState());
            }
        }
    }
}
