using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardMatchingGame.GameStates;
namespace CardMatchingGame.Managers
{
    internal class GameManager
    {
        public Board Board { get; }
        private GameState _gameState; 
        public GameManager()
        {
            Board = new Board();
            _gameState = new FlipFirstCardState();
        }
        public void ChangeGameState(GameState gameState)
        {
            if (gameState != null)
            {
                _gameState = gameState;
            }
        }
        public void Draw()
        {
            Board.Draw();
        }
        public void Update()
        {
            InputManager.Update();
            _gameState.Update(this);
        }
    }
}
