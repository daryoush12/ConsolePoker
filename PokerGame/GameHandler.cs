using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerGame
{
    public class GameHandler
    {
        private List<Card> _gameCards;
        private Card[] _hand;
        private const int _cardsPerCountry = 14;
        private bool _isrunning = true;
        private GameStateHandler _GameState;
        private Dictionary<Type, GameState> _gameStates;
        

        public void SetHand(Card[] hand)
        {
            this._hand = hand;
        }

        public void Start()
        {
            _GameState = new GameStateHandler();
            _gameStates = new Dictionary<Type, GameState>()
            {
                {typeof(DealState), new DealState(this)},
                {typeof(SwapState), new SwapState(this)}
            };

            _GameState.SetStates(_gameStates);
            do
            {
                _GameState.RefreshState();
            } while (_isrunning);
        }

        public void SetupDeck()
        {
            _gameCards = new List<Card>();
            for (int x = 0; x < Enum.GetNames(typeof(CardCountry)).Length; x++)
            {
                for (int i = 0; i < _cardsPerCountry; i++)
                {
                    _gameCards.Add(new Card(i + 1, (CardCountry)x));
                }
            }
        }

        public void PrintDeck()
        {
            foreach (Card c in _gameCards)
            {
                Console.WriteLine(c.Country + " " + c.CardNumber + " \n");
            }
        }

        public void PrintHand()
        {
            Console.WriteLine(":HAND: \n");
            for (int i = 0; i < _hand.Length; i++)
            {
                Console.WriteLine(i + " " + _hand[i].CardNumber + "  " + _hand[i].Country + " \n");
            }
            Console.WriteLine(":-------: \n");
        }

        public void DealHand()
        {
            Console.WriteLine("Cards : " + _gameCards.Count);
            _hand = _gameCards.Take(5).ToArray<Card>();
            _gameCards.RemoveRange(0, 5);
            Console.WriteLine("Cards : " + _gameCards.Count);
        }

        public void ShuffleDeck()
        {
            _gameCards.Shuffle();
        }


        public bool isFlush(Card[] hand)
        {
            int amounted = 0;
            CardCountry country = CardCountry.clubs;
            for (int i = 0; i < hand.Length; i++)
            {
                if(i == 0)
                {
                    country = hand[i].Country;
                    amounted = 1;
                }
                else if(hand[i].Country == country)
                {
                    amounted++;
                }
            }


            if (amounted == hand.Length)
                return true;
            else
                return false;
        }

        public bool isStraight(Card[] hand)
        {
            Array.Sort<Card>(hand);
            int amounted = 0;
            Card current = hand[0];

            for (int i = 0; i < hand.Length; i++)
            {
                if (i == 0)
                {
                    amounted = 1;
                }
                else if (hand[i].CardNumber - current.CardNumber == 1)
                {
                    amounted++;
                    current = hand[i];
                }
            }
            if(amounted == 5)
            {
                return true;
            }

            return false;
        }

        public bool is2Pairs(Card[] hand)
        {
            return false;
        }

        public bool isStraightFlush(Card[] hand)
        {
            return (isFlush(hand) && isStraight(hand));
        }
        
        public bool isThreeofKind()
        {
            return false;
        }

        public bool isFourofKind()
        {
            return false;
        }
    }
}