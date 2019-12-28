using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerGame
{
    public class GameHandler
    {
        private List<Card> _gameCards;
        public Hand _hand;
        private const int _cardsPerCountry = 14;
        private bool _isrunning = true;
        private GameStateHandler _GameState;
        private Dictionary<Type, GameState> _gameStates;
      
        

  
        public void Start()
        {
            _GameState = new GameStateHandler();
            _gameStates = new Dictionary<Type, GameState>()
            {
                {typeof(DealState), new DealState(this)},
                {typeof(SwapState), new SwapState(this)},
                {typeof(EvaluationState), new EvaluationState(this)}
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

     

        public void DealHand()
        {
           
            Console.WriteLine("Dealing hand..");
            _hand = new Hand(_gameCards.Take(5).ToArray<Card>());
            _gameCards.RemoveRange(0, 5);
        }

        public void ShuffleDeck()
        {
            _gameCards.Shuffle();
        }

        public void SwitchCards(Card[] switchable)
        {
            List<Card> lst = new List<Card>();
            lst.AddRange(_hand.GetCards());
            foreach(Card c in switchable)
            {
                lst.Remove(c);
            }
            lst.AddRange(Draw(switchable.Length));
            _hand.SetCards(lst.ToArray());
        }

        public List<Card>Draw(int amount)
        {
            List<Card> drawedCards = new List<Card>();

            for(int i = 0; i < amount; i++)
            {
                Card drawed = _gameCards[i];
                _gameCards.Remove(drawed);
                drawedCards.Add(drawed);   
            }
            return drawedCards;
        }

    
    }
}