using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGame
{
   public class Hand
    {
        private Card[] _cards;

        public Hand(Card[] cards)
        {
            _cards = cards;
        }

        public Card[] GetCards()
        {
            return _cards;
        }

        public void SetCards(Card[] cards)  { _cards = cards; }

        public void PrintHand()
        {
            Console.WriteLine(":HAND: \n");
            for (int i = 0; i < _cards.Length; i++)
            {
                Console.WriteLine(i + " " + _cards[i].CardNumber + "  " + _cards[i].Country + " \n");
            }
            Console.WriteLine(":-------: \n");
        }

    }
}
