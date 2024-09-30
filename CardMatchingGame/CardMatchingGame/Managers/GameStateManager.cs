using CardMatchingGame.GameStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardMatchingGame.Managers
{
    internal static class GameStateManager
    {
        public static Dictionary<GameStateEnum, GameState> States { get; } = new();
        static GameStateManager()
        {
            States.Clear();
            States.Add(GameStateEnum.FlipFirstCard,new FlipFirstCardState());
            States.Add(GameStateEnum.FlipSecondCard,new FlipSecondCardState());
            States.Add(GameStateEnum.ResolveTurn,new ResolveTurnState());
            States.Add(GameStateEnum.Win,new  WinState());
        }
    }
}
