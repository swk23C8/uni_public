using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameObjects
{
    public class Hand : IEnumerable
    {
        public List<Card> _hand;
        public int Count;
        public Hand()
        {
            _hand = new List<Card>();
        }
        public Hand(List<Card> cards)
        {
            _hand = cards;
            Count = _hand.Count;
        }
        public IEnumerator GetEnumerator()
        {
            return _hand.GetEnumerator();
        }

        public Card GetCard(int index)
        {
            return _hand.ElementAt(index);
        }

        public void AddCard(Card card)
        {
            _hand.Add(card);
            Count = _hand.Count;
        }

        public bool ContainsCard(Card card)
        {
           return _hand.Contains(card);
        }

        public bool RemoveCard(Card card)
        {
            return _hand.Remove(card);
        }

        public bool RemoveCardAt(int index)
        {
            Card card = GetCard(index);
            if (card == null)
                return false;

            return RemoveCard(card);
        }

        public int GetCount()
        {
            Count = _hand.Count;
            return Count;
        }

        public void SortHand()
        {
            _hand.Sort((a, b) => a.CompareTo(b));
        }
    }
}
