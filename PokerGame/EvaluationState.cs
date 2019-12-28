using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGame
{
    public class EvaluationState : GameState
    {
        private GameHandler _game;

        public EvaluationState(GameHandler game) : base(game)
        {
            this._game = game;
        }

        public override void OnStateEnter()
        {
            HandEvaluator eval = new HandEvaluator();
            HandType result = eval.Evaluate(_game._hand.GetCards());
            Console.Clear();
            Console.WriteLine("You've got: " + result.name);
            _game._hand.PrintHand();
        }

        public override Type Tick()
        {
            Console.WriteLine("Press anything to restart..");
            Console.ReadKey();
            return typeof(DealState);
        }
    }
}
