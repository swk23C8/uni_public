using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameObjects
{
    public enum Suit { Clubs, Diamonds, Hearts, Spades }

    public enum FaceValue { Ace, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King }
    public class Card : IEquatable<Card>, IComparable<Card>
    {
        public FaceValue FaceValue { set; get; }
        public Suit Suit { set; get; }

        public Card(Suit suit, FaceValue faceValue)
        {
            FaceValue = faceValue;
            Suit = suit;
        }

        public bool Equals(Card card)
        {
            if (card.FaceValue.Equals(FaceValue) && card.Suit.Equals(Suit))
                return true;
            return false;
        }

        public int CompareTo(Card card)
        {
            if (Equals(card))
                return 0;
            else if (Suit < card.Suit)
            {
                return -1;
            }
            else if (Suit == card.Suit)
            {
                if(FaceValue < card.FaceValue)
                return -1;
            }

            return 1;
        }

        public override string ToString()
        {
           switch(FaceValue)
            {
                case FaceValue.Ace:
                    return string.Format("A{0}", Suit.ToString().Substring(0, 1));
                case FaceValue.Jack:
                    return string.Format("J{0}", Suit.ToString().Substring(0, 1));
                case FaceValue.Queen:
                    return string.Format("Q{0}", Suit.ToString().Substring(0, 1));
                case FaceValue.King:
                    return string.Format("K{0}", Suit.ToString().Substring(0, 1));
                default:
                    int index = Array.IndexOf(Enum.GetValues(FaceValue.GetType()), FaceValue) + 1;
                    return string.Format("{0}{1}", index.ToString(), Suit.ToString().Substring(0, 1));
            }
        }
    }
}
