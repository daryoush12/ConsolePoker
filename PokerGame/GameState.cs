using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGame
{
   public abstract class GameState
    {
        public GameState(GameHandler game)
        {
            this._game = game;
        }
        private GameHandler _game;

        public virtual void OnStateEnter() { }
        public virtual void OnStateExit() { }
        public abstract Type Tick();
    }
}
