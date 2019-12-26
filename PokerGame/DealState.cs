using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGame
{
  public class DealState : GameState
    {
        private GameHandler _game;

        public DealState(GameHandler game) : base(game)
        {
            this._game = game;
        }

        public override void OnStateEnter()
        {
            _game.SetupDeck();
            _game.ShuffleDeck();
        }
        public override Type Tick()
        {
            Console.WriteLine("Player is being dealt a hand");
            _game.DealHand();
            Console.ReadKey();
            return typeof(SwapState);
        }
    }
}
