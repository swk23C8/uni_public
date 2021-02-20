using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameObjects
{
  
    public class CardPile
    {
        public int Count;
        List<Card> _pile;
        public Random _numberGenerator;
        public CardPile(bool status = false)
        {
            _pile = new List<Card>();
            _numberGenerator = new Random();

            if(status)
            {
                for (Suit suit = Suit.Clubs; suit <= Suit.Spades; ++suit)
                {
                    
                    for (FaceValue facevalue = FaceValue.Ace; facevalue <= FaceValue.King; ++facevalue)
                    {
                        _pile.Add(new Card(suit, facevalue));
                    }
                }                
            }

            Count = _pile.Count;
        }

        public void ShufflePile()
        {
            int n = _pile.Count;

            while (n > 1)
            {
                n--;
                int k = _numberGenerator.Next(n + 1);
                Card value = _pile[k];
                _pile[k] = _pile[n];
                _pile[n] = value;
            }
     
        }
        
        public Card DealOneCard()
        {
            Card card = _pile.First();
            _pile.Remove(card);
            return card;
        }
        public List<Card> DealCards(int index)
        {
            List<Card> cards = _pile.GetRange(0, index);
            _pile.RemoveRange(0, index);
            return cards;
        }
        
        public void AddCard(Card card)
        {
            _pile.Add(card);
            Count = _pile.Count;
        }
        public Card GetLastCardInPile()
        {
            return _pile.Last();
        }
        public int GetCount()
        {
            return Count;
        }
    }
}
