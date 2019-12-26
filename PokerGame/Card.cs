using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public enum CardCountry{clubs, spades, hearts, diamonds}

namespace PokerGame
{
    public class Card : IComparable
    {
        private int _cardnumber;
        private CardCountry _country;

        public int CardNumber {get{return this._cardnumber;}}
        public CardCountry Country { get { return this._country; }}

        public Card(int number, CardCountry country)
        {
            this._cardnumber = number;
            this._country = country;
            
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            Card otherCard = obj as Card;
            if (otherCard != null)
                return this.CardNumber.CompareTo(otherCard.CardNumber);
            else
                throw new ArgumentException("Object is not a Temperature");
        }
    }
}
