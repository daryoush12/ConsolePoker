using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGame
{
    class SwapState : GameState
    {
        private GameHandler _game;

        public SwapState(GameHandler game) : base(game)
        {
            this._game = game;
        }

        public override Type Tick()
        {
            Console.WriteLine("Which cards would you like to switch? (press number key's)");
            _game.PrintHand();
            Console.ReadKey();
            return null;
        }
    }
}
