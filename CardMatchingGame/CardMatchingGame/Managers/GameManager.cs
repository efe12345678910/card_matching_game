using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardMatchingGame.GameStates;
using System.Diagnostics;
namespace CardMatchingGame.Managers
{
    internal class GameManager
    {
        public Board Board { get; }
        private GameState _gameState; 
        public Card FirstCardSelected { get; set; }
        public Card SecondCardSelected { get; set; }
        public GameManager()
        {
            Board = new Board();
            _gameState = new FlipFirstCardState();
            Restart();
        }
        public void ChangeGameState(GameStateEnum gameState)
        {
            _gameState = GameStateManager.States[gameState];
        }
        public void Restart()
        {
            Board.ResetBoard();
            ChangeGameState(GameStateEnum.FlipFirstCard);
        }
        public void Draw()
        {
            _gameState.Draw(this);
        }
        public void Update()
        {
            InputManager.Update();
            _gameState.Update(this);
            if (InputManager.MouseRightClicked)
            {
                Restart();
            }
        }
    }
}
