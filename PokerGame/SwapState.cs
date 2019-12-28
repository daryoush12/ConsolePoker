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
        private ConsoleKeyInfo cki;
        private List<Card> _chosen;

        public SwapState(GameHandler game) : base(game)
        {
            this._game = game;
        }

        public override void OnStateEnter()
        {
            _chosen = new List<Card>();
           
        }

        public override Type Tick()
        {
            PromptCards();
            if (PromptNextStage())
            {
                Console.WriteLine("Next Stage");
                _game.SwitchCards(_chosen.ToArray());
                return typeof(EvaluationState);

            }
            else
            {
                return null;
            }
        }

        private void ChooseCards(int num)
        {
           
            try
            {
           
                if (_chosen != null)
                {
                    if (!_chosen.Contains(_game._hand.GetCards()[num - 1]))
                        _chosen.Add(_game._hand.GetCards()[num - 1]);
                    else
                        _chosen.Remove(_game._hand.GetCards()[num - 1]);
                }
                else
                {
                    _chosen.Add(_game._hand.GetCards()[num - 1]);
                }

            }catch(Exception e)
            {
                PromptCards();
                Console.WriteLine("You are not pressing wanted keys.. \n \n "+e);
            }
        
        }

        private void PromptCards()
        {
            Console.Clear();
            Console.WriteLine("Which cards would you like to switch? (press number key's)");
            Console.WriteLine(":HAND: \n");
            if (_chosen != null)
            {
                for (int i = 0; i < _game._hand.GetCards().Length; i++)
                {
                    if (_chosen.Contains(_game._hand.GetCards()[i]))
                    {
                        Console.WriteLine((i + 1) + ". " + _game._hand.GetCards()[i].CardNumber + "  " + _game._hand.GetCards()[i].Country + "  (Chosen) \n");
                    }
                    else
                        Console.WriteLine((i + 1) + ". " + _game._hand.GetCards()[i].CardNumber + "  " + _game._hand.GetCards()[i].Country + " \n");
                }
            }
            else
            {
                for (int i = 0; i < _game._hand.GetCards().Length; i++)
                {
                    Console.WriteLine((i + 1) + ". " + _game._hand.GetCards()[i].CardNumber + "  " + _game._hand.GetCards()[i].Country + " \n");
                }
            }
            Console.WriteLine(":-------: \n");
            Console.WriteLine("Press enter number confírm switch \n");
        }


        private bool PromptNextStage()
        {
            cki = Console.ReadKey();
            if (cki.Key.ToString() != "Enter")
            {
                int num = Int32.Parse((cki.Key.ToString().Trim('D')));
                ChooseCards(num);
                return false;
            }
            else
            {
                return true;
            }
        }

    }

  

   
}
