using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGame
{
    public class HandEvaluator
    {
        private Dictionary<HandType, Func<bool>> _winningHands;
        private Card[] _tobeEvaluated;
        
        public HandEvaluator()
        {
            SetupWinningHands();
        }

        private void SetupWinningHands()
        {
            _winningHands = new Dictionary<HandType, Func<bool>>()
            {
                {new HandType("Pairs", 2), is2Pairs},
                {new HandType("Three of kind", 4), isThreeofKind},
                {new HandType("Flush", 6), isFlush},
                {new HandType("Straight", 8),isStraight},
                {new HandType("Royal Flush", 12),isStraightFlush},
                {new HandType("Four of kind", 24),isFourofKind}
            };
            
        }

        public HandType Evaluate(Card[] hand)
        {
            _winningHands.Reverse();
            _tobeEvaluated = hand;
            HandType result = new HandType("Nothing", 0);
            foreach (HandType s in _winningHands.Keys)
            {
                if (_winningHands[s].Invoke())
                {
                    result = s;
                }
            }
                return result;
        }

        private bool isFlush()
        {
            int amounted = 0;
            CardCountry country = CardCountry.clubs;
            for (int i = 0; i < _tobeEvaluated.Length; i++)
            {
                if (i == 0)
                {
                    country = _tobeEvaluated[i].Country;
                    amounted = 1;
                }
                else if (_tobeEvaluated[i].Country == country)
                {
                    amounted++;
                }
            }


            return (amounted == _tobeEvaluated.Length);
        }

        private bool isStraight()
        {
            Array.Sort<Card>(_tobeEvaluated);
            int amounted = 0;
            Card current = _tobeEvaluated[0];

            for (int i = 0; i < _tobeEvaluated.Length; i++)
            {
                if (i == 0)
                {
                    amounted = 1;
                }
                else if (_tobeEvaluated[i].CardNumber - current.CardNumber == 1)
                {
                    amounted++;
                    current = _tobeEvaluated[i];
                }
            }

            return (amounted == 5);
        }

        private bool is2Pairs()
        {
            if (_tobeEvaluated != null)
            {
                int amountOfPairs = 0;
                Card current = null;

                foreach (Card c in _tobeEvaluated)
                {
                    if (current == null)
                    {
                        current = c;
                    }
                    else if (current.CardNumber == c.CardNumber)
                    {
                        amountOfPairs++;
                        current = null;
                    }
                }

                return (amountOfPairs == 2);
            }
            return false;
        }

        private bool isStraightFlush()
        {
            return (isFlush() && isStraight());
        }

        private bool isThreeofKind()
        {
            int amountOfMatches = 0;

            foreach (Card x in _tobeEvaluated)
            {
                foreach (Card c in _tobeEvaluated)
                {
                    if (c.CardNumber == x.CardNumber)
                        amountOfMatches++;
                }
                if (amountOfMatches == 3)
                    break;
                else
                    amountOfMatches = 0;
            }

            return (amountOfMatches == 3);
        }

        private bool isFourofKind()
        {
            int amountOfMatches = 0;

            foreach (Card x in _tobeEvaluated)
            {
                foreach (Card c in _tobeEvaluated)
                {
                    if (x.CardNumber == c.CardNumber)
                        amountOfMatches++;
                }
                if (amountOfMatches == 4)
                    break;
                else
                    amountOfMatches = 0;
            }

            return (amountOfMatches == 4);
        }

    }

    public struct HandType
    {
        public HandType(string name, int points)
        {
            this.name = name;
            this.points = points;
        }

        public string name;
        public int points;
    }
}
