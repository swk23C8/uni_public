using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Games;
using GameObjects;
using System.Reflection;

/*
 * The unit tests described in this file will test your CrazyEights code from the
 * Games project.
 * 
 * Running the tests will help you determine whether you have implemented the
 * CrazyEights logic correctly. The tests may be used to guide the marking
 * of your submission.
 * 
 * NOTE: The tests will not run until you have completed the method headers
 *       in the CrazyEights class as described by the UML diagram.
 * 
 * If there are any errors present in this file, it may be because:
 *     - You have not written all the necessary method headers in CrazyEights
 *       as specified by the UML diagram
 *     - You have written the method headers, but they are incorrect in some way
 *       (e.g. misspelled a method name, missing parameters, incorrect access 
 *       modifier etc.)
 *     - You are missing return statements in value-returning methods
 * 
 * At the bottom of this file is the class Scenarios, which can start CrazyEights
 * scenarios which otherwise occur rarely during normal play.
 * 
 */

namespace CrazyEightsTests {

    /// <summary>
    /// This test suite relates to the state of CrazyEights before the 
    /// StartGame method has been called.
    /// </summary>
    [TestClass()]
    public class C1_CrazyEightsBeforeGameStartsTests {
        [TestMethod()]
        public void CannotSortHandException() {
            try {
                CrazyEights.SortUserHand();
            } catch {
                return;
            }
            Assert.Fail();
        }

        [TestMethod()]
        public void TestIsPlayingIsFalse() {
            Assert.IsFalse(CrazyEights.IsPlaying);
        }

        [TestMethod()]
        public void ComputerCannotActException() {
            try {
                CrazyEights.ComputerAction();
            } catch {
                return;
            }
            Assert.Fail();
        }

        [TestMethod()]
        public void UserCannotPlayCardException() {
            try {
                CrazyEights.UserPlayCard(0);
            } catch {
                return;
            }
            Assert.Fail();
        }

        [TestMethod()]
        public void UserCannotDrawCardException() {
            try {
                CrazyEights.UserDrawCard();
            } catch {
                return;
            }
            Assert.Fail();
        }

        [TestMethod()]
        public void TestTopDiscardIsNull() {
            try {
                Card card = CrazyEights.TopDiscard;
            } catch (NullReferenceException) {
                return;
            }

            if (CrazyEights.TopDiscard == null) {
                return;
            }

            Assert.Fail("TopDiscard must not be defined before a game starts!");
        }
    }

    /// <summary>
    /// This test suite relates to the state of Crazy Eights after the
    /// StartGame method has been called.
    /// </summary>
    [TestClass()]
    public class C2_CrazyEightsAfterGameStartsTests {
        const int NUM_STARTING_CARDS = 8;

        [TestMethod()]
        public void TestStartGameRunsWithoutErrors() {
            CrazyEights.StartGame();
        }

        [TestMethod(), Timeout(5000)]
        public void TestSortUserHand() {
            bool sortedHand = false;
            do {
                CrazyEights.StartGame();
                sortedHand = Utility.HandIsSorted(CrazyEights.UserHand);
            } while (sortedHand);
            CrazyEights.SortUserHand();
            Assert.IsTrue(Utility.HandIsSorted(CrazyEights.UserHand));
        }

        [TestMethod(), Timeout(5000)]
        public void UserHandIsNotNecessarilyInOrder() {
            bool sortedHand = true;
            do {
                CrazyEights.StartGame();
                sortedHand = Utility.HandIsSorted(CrazyEights.UserHand);
            } while (sortedHand);
        }

        [TestMethod(), Timeout(5000)]
        public void ComputerHandIsNotNecessarilyInOrder() {
            bool sortedHand = true;
            do {
                CrazyEights.StartGame();
                sortedHand = Utility.HandIsSorted(CrazyEights.ComputerHand);
            } while (sortedHand);
        }

        [TestMethod()]
        public void ComputerHandCountIsEight() {
            CrazyEights.StartGame();
            Assert.AreEqual(NUM_STARTING_CARDS, CrazyEights.ComputerHand.Count);
        }

        [TestMethod()]
        public void UserHandCountIsEight() {
            CrazyEights.StartGame();
            Assert.AreEqual(NUM_STARTING_CARDS, CrazyEights.UserHand.Count);
        }

        [TestMethod()]
        public void TestIsUserTurnIsTrue() {
            CrazyEights.StartGame();
            Assert.IsTrue(CrazyEights.IsUserTurn);
        }

        [TestMethod()]
        public void TestIsPlayingIsTrue() {
            CrazyEights.StartGame();
            Assert.IsTrue(CrazyEights.IsPlaying);
        }

        [TestMethod()]
        public void TestIsDrawPileEmptyIsFalse() {
            CrazyEights.StartGame();
            Assert.IsFalse(CrazyEights.IsDrawPileEmpty);
        }

        [TestMethod()]
        public void TestTopDiscardIsNotNull() {
            CrazyEights.StartGame();
            Assert.IsNotNull(CrazyEights.TopDiscard);
        }

        [TestMethod()]
        public void ComputerCannotGoFirstException() {
            CrazyEights.StartGame();
            try {
                CrazyEights.ComputerAction();
            } catch {
                return;
            }
            Assert.Fail();
        }

        [TestMethod()]
        public void TestStartGameWithParameters() {
            Hand userHand = new Hand (new List<Card>() {
                new Card(Suit.Clubs, FaceValue.Ace)
            });
            Hand computerHand = new Hand (new List<Card>() {
                new Card(Suit.Clubs, FaceValue.Two),
            });

            CardPile discardPile = new CardPile();
            discardPile.AddCard(new Card(Suit.Clubs, FaceValue.Three));

            CardPile drawPile = new CardPile(true);

            CrazyEights.StartGame(
                userHand: userHand,
                computerHand: computerHand,
                discardPile: discardPile,
                drawPile: drawPile
            );

            CollectionAssert.AreEqual(Utility.HandToList(userHand), Utility.HandToList(CrazyEights.UserHand));
            CollectionAssert.AreEqual(Utility.HandToList(computerHand), Utility.HandToList(CrazyEights.ComputerHand));
            Assert.AreEqual(true, CrazyEights.IsPlaying);
            Assert.AreEqual(true, CrazyEights.IsUserTurn);
            Assert.AreEqual(false, CrazyEights.IsDrawPileEmpty);
        }
    }

    /// <summary>
    /// This test suite tests the user draw functionality in Crazy Eights.
    /// </summary>
    [TestClass()]
    public class C3_CrazyEightsUserDrawCardTests {
        const int NUM_CARDS_IN_DECK = 52;

        [TestMethod()]
        public void UserCannotDrawBecauseSuitMatches() {
            Hand computerHand = new Hand(new List<Card>() {
                    new Card(Suit.Hearts, FaceValue.Ace)
            });

            Hand userHand = new Hand(new List<Card>() {
                new Card(Suit.Clubs, FaceValue.Ace),
            });
            int originalNumCardsUser = userHand.Count;

            CardPile discardPile = new CardPile();
            discardPile.AddCard(new Card(Suit.Clubs, FaceValue.Ten));

            CardPile drawPile = new CardPile(true);

            CrazyEights.StartGame(
                userHand: userHand,
                computerHand: computerHand,
                discardPile: discardPile,
                drawPile: drawPile
            );

            Assert.AreEqual(
                CrazyEights.ActionResult.CannotDraw,
                CrazyEights.UserDrawCard()
            );

            Assert.AreEqual(originalNumCardsUser, CrazyEights.UserHand.Count);
            Assert.AreEqual(NUM_CARDS_IN_DECK, drawPile.Count);
            Assert.IsTrue(CrazyEights.IsUserTurn);
            Assert.IsTrue(CrazyEights.IsPlaying);
        }

        [TestMethod()]
        public void UserCannotDrawBecauseFaceValueMatches() {
            Hand computerHand = new Hand(new List<Card>() {
                    new Card(Suit.Hearts, FaceValue.Ace)
            });

            Hand userHand = new Hand(new List<Card>() { 
                new Card(Suit.Clubs, FaceValue.Ace),
            });
            int originalNumCardsUser = userHand.Count;

            CardPile discardPile = new CardPile();
            discardPile.AddCard(new Card(Suit.Hearts, FaceValue.Ace));

            CardPile drawPile = new CardPile(true);

            CrazyEights.StartGame(
                userHand: userHand,
                computerHand: computerHand,
                discardPile: discardPile,
                drawPile: drawPile
            );

            Assert.AreEqual(
                CrazyEights.ActionResult.CannotDraw,
                CrazyEights.UserDrawCard()
            );

            Assert.AreEqual(originalNumCardsUser, CrazyEights.UserHand.Count);
            Assert.AreEqual(NUM_CARDS_IN_DECK, drawPile.Count);
            Assert.IsTrue(CrazyEights.IsUserTurn);
            Assert.IsTrue(CrazyEights.IsPlaying);
        }

        [TestMethod()]
        public void UserCannotDrawBecauseEightIsFirstCard() {
            Hand computerHand = new Hand(new List<Card>() {
                new Card(Suit.Hearts, FaceValue.Ace)
            });

            Hand userHand = new Hand(new List<Card>() { 
                new Card(Suit.Clubs, FaceValue.Ace),
            });
            int originalNumCardsUser = userHand.Count;

            CardPile discardPile = new CardPile();
            discardPile.AddCard(new Card(Suit.Hearts, FaceValue.Eight));

            CardPile drawPile = new CardPile(true);

            CrazyEights.StartGame(
                 userHand: userHand,
                 computerHand: computerHand,
                 discardPile: discardPile,
                 drawPile: drawPile
             );

            Assert.AreEqual(
                CrazyEights.ActionResult.CannotDraw,
                CrazyEights.UserDrawCard()
            );

            Assert.AreEqual(originalNumCardsUser, CrazyEights.UserHand.Count);
            Assert.AreEqual(NUM_CARDS_IN_DECK, drawPile.Count);
            Assert.IsTrue(CrazyEights.IsUserTurn);
            Assert.IsTrue(CrazyEights.IsPlaying);
        }

        [TestMethod()]
        public void UserDrawsAndHasNoPossibleMoves() {

            Hand computerHand = new Hand(new List<Card>() {
                new Card(Suit.Hearts, FaceValue.Ace)
            });

            Hand userHand = new Hand(new List<Card>() { 
                new Card(Suit.Diamonds, FaceValue.Two),
                new Card(Suit.Diamonds, FaceValue.Three),
                new Card(Suit.Diamonds, FaceValue.Four),
                new Card(Suit.Diamonds, FaceValue.Five),
                new Card(Suit.Diamonds, FaceValue.Six),
                new Card(Suit.Diamonds, FaceValue.Seven),
                new Card(Suit.Diamonds, FaceValue.Nine),
                new Card(Suit.Diamonds, FaceValue.Ten),
                new Card(Suit.Diamonds, FaceValue.Jack),
                new Card(Suit.Diamonds, FaceValue.Queen),
                new Card(Suit.Diamonds, FaceValue.King),
                new Card(Suit.Spades, FaceValue.Two)
            });
            

            CardPile discardPile = new CardPile(false);
            discardPile.AddCard(new Card(Suit.Clubs, FaceValue.Ace));

            List<Card> drawCards = Utility.CardPileCreateFullDeck();
            Utility.RemoveFromHand(drawCards, userHand);
            drawCards.Add(new Card(Suit.Hearts, FaceValue.Two));
            drawCards.Reverse();
            CardPile drawPile = Utility.CardPileCreate(drawCards);

            int originalNumCardsUser = userHand.Count;
            int originalNumCardsDrawPile = drawPile.Count;

            CrazyEights.StartGame(
                userHand: userHand,
                computerHand: computerHand,
                drawPile: drawPile,
                discardPile: discardPile
            );

            Assert.AreEqual(
                CrazyEights.ActionResult.DrewAndNoMovePossible,
                CrazyEights.UserDrawCard()
            );

            Assert.AreEqual(originalNumCardsUser + 1, CrazyEights.UserHand.Count);
            Assert.AreEqual(originalNumCardsDrawPile - 1, drawPile.Count);
            Assert.IsFalse(CrazyEights.IsUserTurn);
            Assert.IsTrue(CrazyEights.IsPlaying);
        }

        [TestMethod()]
        public void UserDrawsAndNobodyCanPlaySoPilesAreResetForComputer() {
            Hand computerHand = new Hand(new List<Card>() {
                new Card(Suit.Spades, FaceValue.Two),
                new Card(Suit.Spades, FaceValue.Three),
                new Card(Suit.Spades, FaceValue.Four),
                new Card(Suit.Spades, FaceValue.Five),
                new Card(Suit.Spades, FaceValue.Six),
                new Card(Suit.Spades, FaceValue.Seven),
                new Card(Suit.Spades, FaceValue.Nine),
                new Card(Suit.Spades, FaceValue.Ten),
                new Card(Suit.Spades, FaceValue.Jack),
                new Card(Suit.Spades, FaceValue.Queen),
                new Card(Suit.Spades, FaceValue.King),
                new Card(Suit.Hearts, FaceValue.Two),
                new Card(Suit.Hearts, FaceValue.Three)
            });

            Hand userHand = new Hand(new List<Card>() {
                new Card(Suit.Hearts, FaceValue.Four),
                new Card(Suit.Hearts, FaceValue.Five),
                new Card(Suit.Hearts, FaceValue.Six),
                new Card(Suit.Hearts, FaceValue.Seven),
                new Card(Suit.Hearts, FaceValue.Nine),
                new Card(Suit.Hearts, FaceValue.Ten),
                new Card(Suit.Hearts, FaceValue.Jack),
                new Card(Suit.Hearts, FaceValue.Queen),
                new Card(Suit.Hearts, FaceValue.King),
                new Card(Suit.Diamonds, FaceValue.Two),
                new Card(Suit.Diamonds, FaceValue.Three),
                new Card(Suit.Diamonds, FaceValue.Four)
            });

            CardPile discardPile = new CardPile();
            discardPile.AddCard(new Card(Suit.Clubs, FaceValue.Ace));

            List<Card> drawCards = Utility.CardPileCreateFullDeck();
            Utility.RemoveFromHand(drawCards, userHand);
            Utility.RemoveFromHand(drawCards, computerHand);
            drawCards.Remove(discardPile.GetLastCardInPile());
            drawCards.Remove(new Card(Suit.Diamonds, FaceValue.Five));
            drawCards.Add(new Card(Suit.Diamonds, FaceValue.Five));
            drawCards.Reverse();
            CardPile drawPile = Utility.CardPileCreate(drawCards);

            int originalNumCardsUser = userHand.Count;
            int originalNumCardsDrawPile = drawPile.Count;
            int originalNumCardsDiscardPile = discardPile.Count;

            CrazyEights.StartGame(
                userHand, 
                computerHand, 
                discardPile, 
                drawPile
            );

            Assert.AreEqual(
                CrazyEights.ActionResult.DrewAndResetPiles,
                CrazyEights.UserDrawCard()
            );

            Assert.AreEqual(originalNumCardsUser + 1, CrazyEights.UserHand.Count);
            Assert.AreEqual(originalNumCardsDrawPile + originalNumCardsDiscardPile - 2, drawPile.Count);
            Assert.AreEqual(1, discardPile.Count);
            Assert.IsFalse(CrazyEights.IsUserTurn);
            Assert.IsTrue(CrazyEights.IsPlaying);
        }

        [TestMethod()]
        public void UserDrawsUnplayableCard() {
            Hand userHand = new Hand(new List<Card>() { 
                new Card(Suit.Diamonds, FaceValue.Two)
            });
            int originalNumCardsUser = userHand.Count;

            Hand computerHand = new Hand(new List<Card>() { 
                new Card(Suit.Clubs, FaceValue.Ace)
            });

            CardPile discardPile = new CardPile(false);
            discardPile.AddCard(new Card(Suit.Clubs, FaceValue.Ace));

            List<Card> drawCards = Utility.CardPileCreateFullDeck();
            Utility.RemoveFromHand(drawCards, userHand);
            Utility.RemoveFromHand(drawCards, computerHand);
            drawCards.Remove(new Card(Suit.Hearts, FaceValue.Two));
            drawCards.Add(new Card(Suit.Hearts, FaceValue.Two));
            drawCards.Reverse();
            CardPile drawPile = Utility.CardPileCreate(drawCards);
            int originalNumCardsDrawPile = drawPile.Count;

            CrazyEights.StartGame(
                userHand: userHand,
                computerHand: computerHand,
                drawPile: drawPile,
                discardPile: discardPile
            );

            Assert.AreEqual(
                CrazyEights.ActionResult.DrewUnplayableCard,
                CrazyEights.UserDrawCard()
            );

            Assert.AreEqual(originalNumCardsUser + 1, CrazyEights.UserHand.Count);
            Assert.AreEqual(originalNumCardsDrawPile - 1, drawPile.Count);
            Assert.IsTrue(CrazyEights.IsUserTurn);
            Assert.IsTrue(CrazyEights.IsPlaying);
        }

        [TestMethod()]
        public void UserDrawsPlayableCard() {
            Hand userHand = new Hand(new List<Card>() {
                new Card(Suit.Diamonds, FaceValue.Two)
            });
            int originalNumCardsUser = userHand.Count;

            Hand computerHand = new Hand(new List<Card>() {
                new Card(Suit.Clubs, FaceValue.Ace)
            });

            CardPile discardPile = new CardPile(false);
            discardPile.AddCard(new Card(Suit.Hearts, FaceValue.Ace));

            List<Card> drawCards = Utility.CardPileCreateFullDeck();
            Utility.RemoveFromHand(drawCards, userHand);
            Utility.RemoveFromHand(drawCards, computerHand);
            drawCards.Remove(new Card(Suit.Hearts, FaceValue.Two));
            drawCards.Add(new Card(Suit.Hearts, FaceValue.Two));
            drawCards.Reverse();
            CardPile drawPile = Utility.CardPileCreate(drawCards);
            int originalNumCardsDrawPile = drawPile.Count;

            CrazyEights.StartGame(
                userHand: userHand,
                computerHand: computerHand,
                drawPile: drawPile,
                discardPile: discardPile
            );

            Assert.AreEqual(
                CrazyEights.ActionResult.DrewPlayableCard,
                CrazyEights.UserDrawCard()
            );

            Assert.AreEqual(originalNumCardsUser + 1, CrazyEights.UserHand.Count);
            Assert.AreEqual(originalNumCardsDrawPile - 1, drawPile.Count);
            Assert.IsTrue(CrazyEights.IsUserTurn);
            Assert.IsTrue(CrazyEights.IsPlaying);
        }

        [TestMethod()]
        public void UserFlipsDeckWhenDrawPileEmpty() {
            Hand userHand = new Hand(new List<Card>() {
                new Card(Suit.Diamonds, FaceValue.Three)
            });
            int originalNumCardsUser = userHand.Count;

            Hand computerHand = new Hand(new List<Card>() {
                new Card(Suit.Diamonds, FaceValue.Four)
            });

            List<Card> discardCards = Utility.CardPileCreateFullDeck();
            discardCards.Remove(new Card(Suit.Clubs, FaceValue.Ace));
            discardCards.Add(new Card(Suit.Clubs, FaceValue.Ace));
            discardCards.Reverse();
            discardCards.Remove(new Card(Suit.Clubs, FaceValue.Five));
            discardCards.Add(new Card(Suit.Clubs, FaceValue.Five));
            CardPile discardPile = Utility.CardPileCreate(discardCards);

            CardPile drawPile = new CardPile(false);

            CrazyEights.StartGame(
                userHand: userHand,
                computerHand: computerHand,
                discardPile: discardPile,
                drawPile: drawPile
            );

            Assert.AreEqual(
                CrazyEights.ActionResult.FlippedDeck,
                CrazyEights.UserDrawCard()
            );

            Assert.AreEqual(originalNumCardsUser, CrazyEights.UserHand.Count);
            Assert.AreEqual(NUM_CARDS_IN_DECK - 1, drawPile.Count);
            Assert.AreEqual(1, discardPile.Count);
            Assert.IsTrue(discardPile.GetLastCardInPile().Equals(new Card(Suit.Clubs, FaceValue.Ace)));
            Assert.IsTrue(CrazyEights.IsUserTurn);
            Assert.IsTrue(CrazyEights.IsPlaying);
        }
    }

    /// <summary>
    /// This test suite tests the computer draw functionality in Crazy Eights.
    /// </summary>
    [TestClass()]
    public class C5_CrazyEightsComputerDrawCardTests {

        [TestMethod()]
        public void ComputerFlipsDeckWhenDrawPileEmpty() {
            Hand computerHand = new Hand(new List<Card>() { 
                new Card(Suit.Diamonds, FaceValue.Three)
            });

            Hand userHand = new Hand(new List<Card>() { 
                new Card(Suit.Clubs, FaceValue.Two),
                new Card(Suit.Diamonds, FaceValue.Four)
            });

            List<Card> discardCards = Utility.CardPileCreateFullDeck();
            Utility.RemoveFromHand(discardCards, userHand);
            Utility.RemoveFromHand(discardCards, computerHand);
            discardCards.Remove(new Card(Suit.Hearts, FaceValue.Nine));
            discardCards.Add(new Card(Suit.Hearts, FaceValue.Nine));
            discardCards.Reverse();
            discardCards.Remove(new Card(Suit.Clubs, FaceValue.Ace));
            discardCards.Add(new Card(Suit.Clubs, FaceValue.Ace));
            CardPile discardPile = Utility.CardPileCreate(discardCards);

            CardPile drawPile = new CardPile(false);

            int originalNumCardsComputer = computerHand.Count;
            int originalNumCardsDiscardPile = discardPile.Count;

            CrazyEights.StartGame(
                userHand: userHand,
                computerHand: computerHand,
                discardPile: discardPile,
                drawPile: drawPile
            );

            CrazyEights.UserPlayCard(0);

            Assert.AreEqual(
                CrazyEights.ActionResult.FlippedDeck,
                CrazyEights.ComputerAction()
            );

            Assert.IsTrue(CrazyEights.TopDiscard.Equals(new Card(Suit.Hearts, FaceValue.Nine)));
            Assert.AreEqual(originalNumCardsComputer, computerHand.Count);
            Assert.AreEqual(originalNumCardsDiscardPile, drawPile.Count);
            Assert.AreEqual(1, discardPile.Count);
            Assert.IsTrue(CrazyEights.IsPlaying);
            Assert.IsFalse(CrazyEights.IsUserTurn);
        }

        [TestMethod()]
        public void ComputerDrawsPlayableCard() {
            Hand computerHand = new Hand(new List<Card>() {
                new Card(Suit.Hearts, FaceValue.Two)
            });

            Hand userHand = new Hand(new List<Card>() {
                new Card(Suit.Clubs, FaceValue.Nine),
                new Card(Suit.Spades, FaceValue.Ten)
            });

            CardPile discardPile = new CardPile();
            discardPile.AddCard(new Card(Suit.Clubs, FaceValue.Ten));

            CardPile drawPile = new CardPile();
            drawPile.AddCard(new Card(Suit.Clubs, FaceValue.Two));

            int originalNumCardsComputer = computerHand.Count;
            int originalNumCardsDrawPile = drawPile.Count;

            CrazyEights.StartGame(
                userHand: userHand,
                computerHand: computerHand,
                drawPile: drawPile,
                discardPile: discardPile
            );

            CrazyEights.UserPlayCard(0);

            Assert.AreEqual(
                CrazyEights.ActionResult.DrewPlayableCard,
                CrazyEights.ComputerAction()
            );

            Assert.AreEqual(originalNumCardsComputer + 1, computerHand.Count);
            Assert.AreEqual(originalNumCardsDrawPile - 1, drawPile.Count);
            Assert.IsTrue(CrazyEights.IsPlaying);
            Assert.IsFalse(CrazyEights.IsUserTurn);
        }

        [TestMethod()]
        public void ComputerDrawsUnplayableCard() {
            Hand computerHand = new Hand(new List<Card>() {
                new Card(Suit.Hearts, FaceValue.Two)
            });

            Hand userHand = new Hand(new List<Card>() {
                new Card(Suit.Clubs, FaceValue.Nine),
                new Card(Suit.Spades, FaceValue.Ten)
            });

            CardPile discardPile = new CardPile();
            discardPile.AddCard(new Card(Suit.Clubs, FaceValue.Ten));

            CardPile drawPile = new CardPile();
            drawPile.AddCard(new Card(Suit.Hearts, FaceValue.Three));

            int originalNumCardsComputer = computerHand.Count;
            int originalNumCardsDrawPile = drawPile.Count;

            CrazyEights.StartGame(
                userHand: userHand,
                computerHand: computerHand,
                drawPile: drawPile,
                discardPile: discardPile
            );

            CrazyEights.UserPlayCard(0);

            Assert.AreEqual(
                CrazyEights.ActionResult.DrewUnplayableCard,
                CrazyEights.ComputerAction()
            );

            Assert.AreEqual(originalNumCardsComputer + 1, computerHand.Count);
            Assert.AreEqual(originalNumCardsDrawPile - 1, drawPile.Count);
            Assert.IsTrue(CrazyEights.IsPlaying);
            Assert.IsFalse(CrazyEights.IsUserTurn);
        }

        [TestMethod()]
        public void ComputerDrawsAndHasNoMovePossible() {
            Hand computerHand = new Hand(new List<Card>() {
                new Card(Suit.Diamonds, FaceValue.Two),
                new Card(Suit.Diamonds, FaceValue.Three),
                new Card(Suit.Diamonds, FaceValue.Four),
                new Card(Suit.Diamonds, FaceValue.Five),
                new Card(Suit.Diamonds, FaceValue.Six),
                new Card(Suit.Diamonds, FaceValue.Seven),
                new Card(Suit.Diamonds, FaceValue.Nine),
                new Card(Suit.Diamonds, FaceValue.Ten),
                new Card(Suit.Diamonds, FaceValue.Jack),
                new Card(Suit.Diamonds, FaceValue.Queen),
                new Card(Suit.Diamonds, FaceValue.King),
                new Card(Suit.Spades, FaceValue.Two)
            });

            Hand userHand = new Hand(new List<Card>() {
                new Card(Suit.Hearts, FaceValue.Ace),
                new Card(Suit.Spades, FaceValue.King)
            });

            CardPile discardPile = new CardPile(false);
            discardPile.AddCard(new Card(Suit.Clubs, FaceValue.Ace));

            List<Card> drawCards = Utility.CardPileCreateFullDeck();
            Utility.RemoveFromHand(drawCards, computerHand);
            drawCards.Add(new Card(Suit.Spades, FaceValue.Three));
            drawCards.Add(new Card(Suit.Spades, FaceValue.Four));
            drawCards.Reverse();
            CardPile drawPile = Utility.CardPileCreate(drawCards);

            int originalNumCardsComputer = computerHand.Count;
            int originalNumCardsDrawPile = drawPile.Count;

            CrazyEights.StartGame(
                userHand: userHand,
                computerHand: computerHand,
                drawPile: drawPile,
                discardPile: discardPile
            );

            CrazyEights.UserPlayCard(0);

            Assert.AreEqual(
                CrazyEights.ActionResult.DrewAndNoMovePossible,
                CrazyEights.ComputerAction()
            );

            Assert.AreEqual(originalNumCardsComputer + 1, computerHand.Count);
            Assert.AreEqual(originalNumCardsDrawPile - 1, drawPile.Count);
            Assert.IsTrue(CrazyEights.IsPlaying);
            Assert.IsTrue(CrazyEights.IsUserTurn);
        }

        [TestMethod()]
        public void ComputerDrawsAndNobodyCanPlaySoPilesAreResetForUser() {
            Hand computerHand = new Hand(new List<Card>() {
                new Card(Suit.Hearts, FaceValue.Four),
                new Card(Suit.Hearts, FaceValue.Five),
                new Card(Suit.Hearts, FaceValue.Six),
                new Card(Suit.Hearts, FaceValue.Seven),
                new Card(Suit.Hearts, FaceValue.Nine),
                new Card(Suit.Hearts, FaceValue.Ten),
                new Card(Suit.Hearts, FaceValue.Jack),
                new Card(Suit.Hearts, FaceValue.Queen),
                new Card(Suit.Hearts, FaceValue.King),
                new Card(Suit.Diamonds, FaceValue.Two),
                new Card(Suit.Diamonds, FaceValue.Three),
                new Card(Suit.Diamonds, FaceValue.Four)
            });
            Hand userHand = new Hand(new List<Card>() {
                new Card(Suit.Spades, FaceValue.Two),
                new Card(Suit.Spades, FaceValue.Three),
                new Card(Suit.Spades, FaceValue.Four),
                new Card(Suit.Spades, FaceValue.Five),
                new Card(Suit.Spades, FaceValue.Six),
                new Card(Suit.Spades, FaceValue.Seven),
                new Card(Suit.Spades, FaceValue.Nine),
                new Card(Suit.Spades, FaceValue.Ten),
                new Card(Suit.Spades, FaceValue.Jack),
                new Card(Suit.Spades, FaceValue.Queen),
                new Card(Suit.Spades, FaceValue.King),
                new Card(Suit.Hearts, FaceValue.Two)
            });

            CardPile discardPile = new CardPile();
            discardPile.AddCard(new Card(Suit.Clubs, FaceValue.Ace));

            List<Card> drawCards = Utility.CardPileCreateFullDeck();
            Utility.RemoveFromHand(drawCards, userHand);
            Utility.RemoveFromHand(drawCards, computerHand);
            drawCards.Remove(discardPile.GetLastCardInPile());
            drawCards.Remove(new Card(Suit.Diamonds, FaceValue.Five));
            drawCards.Add(new Card(Suit.Diamonds, FaceValue.Five));
            drawCards.Remove(new Card(Suit.Hearts, FaceValue.Three));
            drawCards.Add(new Card(Suit.Hearts, FaceValue.Three));
            drawCards.Reverse();
            CardPile drawPile = Utility.CardPileCreate(drawCards);

            CrazyEights.StartGame(
                userHand,
                computerHand,
                discardPile,
                drawPile
            );

            CrazyEights.UserDrawCard();

            int originalNumCardsComputer = computerHand.Count;
            int originalNumCardsDrawPile = drawPile.Count;
            int originalNumCardsDiscardPile = discardPile.Count;

            Assert.AreEqual(
                CrazyEights.ActionResult.DrewAndResetPiles,
                CrazyEights.ComputerAction()
            );

            Assert.AreEqual(originalNumCardsComputer + 1, computerHand.Count);
            Assert.AreEqual(originalNumCardsDrawPile + originalNumCardsDiscardPile - 2, drawPile.Count);
            Assert.AreEqual(1, discardPile.Count);
            Assert.IsTrue(CrazyEights.IsUserTurn);
            Assert.IsTrue(CrazyEights.IsPlaying);
        }

    }

    /// <summary>
    /// This test suite tests the functionality of playing cards as the user 
    /// in Crazy Eights.
    /// </summary>
    [TestClass()]
    public class C4_CrazyEightsUserPlayCardTests {
        [TestMethod()]
        public void UserPlaysEightAndSuitRequired() {
            Hand userHand = new Hand(new List<Card>() {
                new Card(Suit.Clubs, FaceValue.Eight),
            });

            Hand computerHand = new Hand(new List<Card>() {
                new Card(Suit.Clubs, FaceValue.Ace)
            });

            CardPile discardPile = new CardPile();
            discardPile.AddCard(new Card(Suit.Clubs, FaceValue.Ten));

            CardPile drawPile = new CardPile(true);

            int originalNumCardsUser = userHand.Count;
            int originalNumCardsDiscardPile = discardPile.Count;

            CrazyEights.StartGame(
                userHand: userHand,
                computerHand: computerHand,
                drawPile: drawPile,
                discardPile: discardPile
            );

            Assert.AreEqual(
                CrazyEights.ActionResult.SuitRequired,
                CrazyEights.UserPlayCard(0)
            );

            Assert.IsTrue(CrazyEights.IsPlaying);
            Assert.IsTrue(CrazyEights.IsUserTurn);
            Assert.AreEqual(originalNumCardsUser, userHand.Count);
            Assert.AreEqual(originalNumCardsDiscardPile, discardPile.Count);
        }

        [TestMethod()]
        public void UserPlaysAndTheirTurnEnds() {
            CardPile discardPile = new CardPile(false);
            discardPile.AddCard(new Card(Suit.Clubs, FaceValue.Ace));

            Hand computerHand = new Hand(new List<Card>() {
                new Card(Suit.Diamonds, FaceValue.Two),
            });

            Hand userHand = new Hand(new List<Card>() {
                new Card(Suit.Hearts, FaceValue.Two),
                new Card(Suit.Hearts, FaceValue.Ace)
            });

            CardPile drawPile = new CardPile(true);

            CrazyEights.StartGame(
                userHand: userHand,
                computerHand: computerHand,
                drawPile: drawPile,
                discardPile: discardPile
            );

            CrazyEights.UserPlayCard(1);

            Assert.IsFalse(CrazyEights.IsUserTurn);
        }

        [TestMethod()]
        public void UserPlaysEightWithSuit() {
            Hand computerHand = new Hand(new List<Card>() {
                new Card(Suit.Clubs, FaceValue.Ace)
            });

            Hand userHand = new Hand(new List<Card>() {
                new Card(Suit.Clubs, FaceValue.Eight),
                new Card(Suit.Clubs, FaceValue.Nine),
            });

            CardPile discardPile = new CardPile();
            discardPile.AddCard(new Card(Suit.Clubs, FaceValue.Ten));

            CardPile drawPile = new CardPile(true);

            int originalNumCardsUser = userHand.Count;
            int originalNumCardsDiscardPile = discardPile.Count;

            CrazyEights.StartGame(
                userHand: userHand,
                computerHand: computerHand,
                drawPile: drawPile,
                discardPile: discardPile
            );

            Assert.AreEqual(
                CrazyEights.ActionResult.ValidPlay,
                CrazyEights.UserPlayCard(0, Suit.Hearts)
            );

            Assert.IsTrue(CrazyEights.IsPlaying);
            Assert.IsFalse(CrazyEights.IsUserTurn);
            Assert.AreEqual(originalNumCardsUser - 1, userHand.Count);
            Assert.AreEqual(originalNumCardsDiscardPile + 1, discardPile.Count);
            Assert.IsTrue(CrazyEights.TopDiscard.Equals(new Card(Suit.Hearts, FaceValue.Eight)));
        }

        [TestMethod()]
        public void UserPlaysValidCardWithMatchingSuit() {
            Hand userHand = new Hand(new List<Card>() {
                new Card(Suit.Clubs, FaceValue.Seven),
                new Card(Suit.Spades, FaceValue.Six)
            });

            Hand computerHand = new Hand(new List<Card>() {
                new Card(Suit.Clubs, FaceValue.Ace)
            });

            CardPile discardPile = new CardPile();
            discardPile.AddCard(new Card(Suit.Clubs, FaceValue.Ten));

            CardPile drawPile = new CardPile(true);

            int originalNumCardsUser = userHand.Count;
            int originalNumCardsDiscardPile = discardPile.Count;

            CrazyEights.StartGame(
                userHand: userHand,
                computerHand: computerHand,
                drawPile: drawPile,
                discardPile: discardPile
            );

            Assert.AreEqual(
                CrazyEights.ActionResult.ValidPlay,
                CrazyEights.UserPlayCard(0)
            );

            Assert.IsTrue(CrazyEights.IsPlaying);
            Assert.IsFalse(CrazyEights.IsUserTurn);
            Assert.AreEqual(originalNumCardsUser - 1, userHand.Count);
            Assert.AreEqual(originalNumCardsDiscardPile + 1, discardPile.Count);
            Assert.IsTrue(CrazyEights.TopDiscard.Equals(new Card(Suit.Clubs, FaceValue.Seven)));
        }

        [TestMethod()]
        public void UserPlaysAndWins() {
            Hand userHand = new Hand(new List<Card>() { 
                new Card(Suit.Clubs, FaceValue.Nine)
            });
            Hand computerHand = new Hand(new List<Card>() {
                new Card(Suit.Clubs, FaceValue.Ace)
            });

            CardPile discardPile = new CardPile();
            discardPile.AddCard(new Card(Suit.Clubs, FaceValue.Ten));

            CardPile drawPile = new CardPile(true);

            int originalNumCardsUser = userHand.Count;
            int originalNumCardsDiscardPile = discardPile.Count;

            CrazyEights.StartGame(
                userHand: userHand,
                computerHand: computerHand,
                drawPile: drawPile,
                discardPile: discardPile
            );

            Assert.AreEqual(
                CrazyEights.ActionResult.WinningPlay,
                CrazyEights.UserPlayCard(0)
            );

            Assert.IsFalse(CrazyEights.IsPlaying);
            Assert.AreEqual(0, userHand.Count);
            Assert.AreEqual(originalNumCardsDiscardPile + 1, discardPile.Count);
            Assert.IsTrue(CrazyEights.TopDiscard.Equals(new Card(Suit.Clubs, FaceValue.Nine)));
        }

        [TestMethod()]
        public void UserPlaysAndGetsExtraTurn() {
            Hand computerHand = new Hand(new List<Card>() {
                new Card(Suit.Diamonds, FaceValue.Two),
                new Card(Suit.Diamonds, FaceValue.Three),
                new Card(Suit.Diamonds, FaceValue.Four),
                new Card(Suit.Diamonds, FaceValue.Five),
                new Card(Suit.Diamonds, FaceValue.Six),
                new Card(Suit.Diamonds, FaceValue.Seven),
                new Card(Suit.Diamonds, FaceValue.Nine),
                new Card(Suit.Diamonds, FaceValue.Ten),
                new Card(Suit.Diamonds, FaceValue.Jack),
                new Card(Suit.Diamonds, FaceValue.Queen),
                new Card(Suit.Diamonds, FaceValue.King),
                new Card(Suit.Spades, FaceValue.Two),
                new Card(Suit.Spades, FaceValue.Three)
            });

            Hand userHand = new Hand(new List<Card>() {
                new Card(Suit.Hearts, FaceValue.Ace),
                new Card(Suit.Hearts, FaceValue.Two)
            });

            CardPile discardPile = new CardPile(false);
            discardPile.AddCard(new Card(Suit.Clubs, FaceValue.Ace));

            List<Card> drawCards = Utility.CardPileCreateFullDeck();
            drawCards.Remove(new Card(Suit.Spades, FaceValue.Four));
            drawCards.Add(new Card(Suit.Spades, FaceValue.Four));
            drawCards.Remove(new Card(Suit.Spades, FaceValue.Four));
            drawCards.Add(new Card(Suit.Spades, FaceValue.Five));
            Utility.RemoveFromHand(drawCards, userHand);
            Utility.RemoveFromHand(drawCards, computerHand);
            drawCards.Reverse();
            CardPile drawPile = Utility.CardPileCreate(drawCards);

            int originalNumCardsUser = userHand.Count;
            int originalNumCardsComputer = computerHand.Count;
            int originalNumCardsDiscardPile = discardPile.Count;

            CrazyEights.StartGame(
                userHand: userHand,
                computerHand: computerHand,
                drawPile: drawPile,
                discardPile: discardPile
            );

            Assert.AreEqual(
                CrazyEights.ActionResult.ValidPlayAndExtraTurn,
                CrazyEights.UserPlayCard(0)
            );

            Assert.IsTrue(CrazyEights.IsPlaying);
            Assert.IsTrue(CrazyEights.IsUserTurn);
            Assert.AreEqual(originalNumCardsComputer, computerHand.Count);
            Assert.AreEqual(originalNumCardsUser - 1, userHand.Count);
            Assert.AreEqual(originalNumCardsDiscardPile + 1, discardPile.Count);
            Assert.IsTrue(CrazyEights.TopDiscard.Equals(new Card(Suit.Hearts, FaceValue.Ace)));

        }

        [TestMethod()]
        public void UserPlaysInvalidCardButMustDraw() {
            CardPile discardPile = new CardPile(false);
            discardPile.AddCard(new Card(Suit.Clubs, FaceValue.Ace));

            Hand computerHand = new Hand(new List<Card>() {
                new Card(Suit.Diamonds, FaceValue.Two),
            });

            Hand userHand = new Hand(new List<Card>() {
                new Card(Suit.Hearts, FaceValue.Two),
                new Card(Suit.Hearts, FaceValue.Three)
            });

            CardPile drawPile = new CardPile(true);

            int originalNumCardsUser = userHand.Count;
            int originalNumCardsDiscardPile = discardPile.Count;

            CrazyEights.StartGame(
                userHand: userHand,
                computerHand: computerHand,
                drawPile: drawPile,
                discardPile: discardPile
            );

            Assert.AreEqual(
                CrazyEights.ActionResult.InvalidPlayAndMustDraw,
                CrazyEights.UserPlayCard(0)
            );
            
            Assert.AreEqual(originalNumCardsUser, userHand.Count);
            Assert.AreEqual(originalNumCardsDiscardPile, discardPile.Count);
            Assert.IsTrue(CrazyEights.IsUserTurn);
            Assert.IsTrue(CrazyEights.IsPlaying);
            Assert.IsTrue(CrazyEights.TopDiscard.Equals(new Card(Suit.Clubs, FaceValue.Ace)));

        }

        [TestMethod()]
        public void UserPlaysInvalidCardAndMustChooseAnother() {
            CardPile discardPile = new CardPile(false);
            discardPile.AddCard(new Card(Suit.Clubs, FaceValue.Ace));

            Hand computerHand = new Hand(new List<Card>() {
                new Card(Suit.Diamonds, FaceValue.Two),
            });

            Hand userHand = new Hand(new List<Card>() {
                new Card(Suit.Hearts, FaceValue.Two),
                new Card(Suit.Hearts, FaceValue.Ace)
            });

            CardPile drawPile = new CardPile(true);

            int originalNumCardsUser = userHand.Count;
            int originalNumCardsDiscardPile = discardPile.Count;

            CrazyEights.StartGame(
                userHand: userHand,
                computerHand: computerHand,
                drawPile: drawPile,
                discardPile: discardPile
            );

            Assert.AreEqual(
                CrazyEights.ActionResult.InvalidPlay,
                CrazyEights.UserPlayCard(0)
            );

            Assert.AreEqual(originalNumCardsUser, userHand.Count);
            Assert.AreEqual(originalNumCardsDiscardPile, discardPile.Count);
            Assert.IsTrue(CrazyEights.IsUserTurn);
            Assert.IsTrue(CrazyEights.IsPlaying);
            Assert.IsTrue(CrazyEights.TopDiscard.Equals(new Card(Suit.Clubs, FaceValue.Ace)));
        }

        [TestMethod()]
        public void UserPlaysValidCardWithMatchingFaceValue() {
            CardPile discardPile = new CardPile(false);
            discardPile.AddCard(new Card(Suit.Clubs, FaceValue.Ace));

            Hand computerHand = new Hand(new List<Card>() {
                new Card(Suit.Diamonds, FaceValue.Two),
            });

            Hand userHand = new Hand(new List<Card>() {
                new Card(Suit.Hearts, FaceValue.Two),
                new Card(Suit.Hearts, FaceValue.Ace)
            });

            CardPile drawPile = new CardPile(true);

            int originalNumCardsUser = userHand.Count;
            int originalNumCardsDiscardPile = discardPile.Count;

            CrazyEights.StartGame(
                userHand: userHand,
                computerHand: computerHand,
                drawPile: drawPile,
                discardPile: discardPile
            );

            Assert.AreEqual(
                CrazyEights.ActionResult.ValidPlay,
                CrazyEights.UserPlayCard(1)
            );

            Assert.AreEqual(originalNumCardsUser - 1, userHand.Count);
            Assert.AreEqual(originalNumCardsDiscardPile + 1, discardPile.Count);
            Assert.IsFalse(CrazyEights.IsUserTurn);
            Assert.IsTrue(CrazyEights.IsPlaying);
            Assert.IsTrue(CrazyEights.TopDiscard.Equals(new Card(Suit.Hearts, FaceValue.Ace)));
        }

        [TestMethod()]
        public void UserPlaysValidCardBecauseFirstDiscardIsEight() {
            CardPile discardPile = new CardPile(false);
            discardPile.AddCard(new Card(Suit.Clubs, FaceValue.Eight));

            Hand computerHand = new Hand(new List<Card>() {
                new Card(Suit.Diamonds, FaceValue.Two),
            });

            Hand userHand = new Hand(new List<Card>() {
                new Card(Suit.Hearts, FaceValue.Two),
                new Card(Suit.Hearts, FaceValue.Ace)
            });

            CardPile drawPile = new CardPile(true);

            int originalNumCardsUser = userHand.Count;
            int originalNumCardsComputer = computerHand.Count;
            int originalNumCardsDrawPile = drawPile.Count;
            int originalNumCardsDiscardPile = discardPile.Count;

            CrazyEights.StartGame(
                userHand: userHand,
                computerHand: computerHand,
                drawPile: drawPile,
                discardPile: discardPile
            );

            Assert.AreEqual(
                CrazyEights.ActionResult.ValidPlay,
                CrazyEights.UserPlayCard(0)
            );

            Assert.AreEqual(originalNumCardsUser - 1, userHand.Count);
            Assert.AreEqual(originalNumCardsDiscardPile + 1, discardPile.Count);
            Assert.IsFalse(CrazyEights.IsUserTurn);
            Assert.IsTrue(CrazyEights.IsPlaying);
            Assert.IsTrue(CrazyEights.TopDiscard.Equals(new Card(Suit.Hearts, FaceValue.Two)));
        }
    }

    /// <summary>
    /// This test suite tests the functionality of playing cards as the 
    /// computer in Crazy Eights.
    /// </summary>
    [TestClass()]
    public class C6_CrazyEightsComputerPlayCardTests {
        [TestMethod()]
        public void ComputerPlaysMatchingFaceValueFirst() {
            Hand userHand = new Hand(new List<Card>() { 
                new Card(Suit.Hearts, FaceValue.Four),
                new Card(Suit.Clubs, FaceValue.Two)
            });

            Hand computerHand = new Hand(new List<Card>() {
                new Card(Suit.Hearts, FaceValue.Eight),
                new Card(Suit.Clubs, FaceValue.Seven),
                new Card(Suit.Diamonds, FaceValue.Four),
                new Card(Suit.Hearts, FaceValue.Nine),
            });

            CardPile discardPile = new CardPile();
            discardPile.AddCard(new Card(Suit.Hearts, FaceValue.Ace));

            CardPile drawPile = new CardPile(true);

            CrazyEights.StartGame(
                userHand: userHand,
                computerHand: computerHand,
                discardPile: discardPile,
                drawPile: drawPile
            );

            CrazyEights.UserPlayCard(0);

            int originalNumCardsComputer = computerHand.Count;
            int originalNumCardsDiscardPile = discardPile.Count;

            Assert.AreEqual(
                CrazyEights.ActionResult.ValidPlay,
                CrazyEights.ComputerAction()
            );

            Assert.IsTrue(CrazyEights.TopDiscard.Equals(new Card(Suit.Diamonds, FaceValue.Four)));
            Assert.AreEqual(originalNumCardsComputer - 1, computerHand.Count);
            Assert.AreEqual(originalNumCardsDiscardPile + 1, discardPile.Count);
            Assert.IsTrue(CrazyEights.IsUserTurn);
            Assert.IsTrue(CrazyEights.IsPlaying);

        }

        [TestMethod()]
        public void ComputerPlaysMatchingSuitsSecond() {
            Hand userHand = new Hand(new List<Card>() { 
                new Card(Suit.Hearts, FaceValue.Four),
                new Card(Suit.Clubs, FaceValue.Two)
            });

            Hand computerHand = new Hand(new List<Card>() { 
                new Card(Suit.Hearts, FaceValue.Eight),
                new Card(Suit.Clubs, FaceValue.Seven),
                new Card(Suit.Diamonds, FaceValue.Five),
                new Card(Suit.Hearts, FaceValue.Nine),
            });

            CardPile discardPile = new CardPile();
            discardPile.AddCard(new Card(Suit.Hearts, FaceValue.Ace));

            CardPile drawPile = new CardPile(true);

            CrazyEights.StartGame(
                userHand: userHand,
                computerHand: computerHand,
                discardPile: discardPile,
                drawPile: drawPile
            );

            CrazyEights.UserPlayCard(0);

            int originalNumCardsComputer = computerHand.Count;
            int originalNumCardsDiscardPile = discardPile.Count;

            Assert.AreEqual(
                CrazyEights.ActionResult.ValidPlay,
                CrazyEights.ComputerAction()
            );

            Assert.IsTrue(CrazyEights.TopDiscard.Equals(new Card(Suit.Hearts, FaceValue.Nine)));

            Assert.AreEqual(originalNumCardsComputer - 1, computerHand.Count);
            Assert.AreEqual(originalNumCardsDiscardPile + 1, discardPile.Count);

            Assert.IsTrue(CrazyEights.IsUserTurn);
            Assert.IsTrue(CrazyEights.IsPlaying);
        }

        [TestMethod()]
        public void ComputerPlaysEightsLast() {
            Hand userHand = new Hand(new List<Card>() { 
                new Card(Suit.Hearts, FaceValue.Four),
                new Card(Suit.Clubs, FaceValue.Two)
            });

            Hand computerHand = new Hand(new List<Card>() { 
                new Card(Suit.Hearts, FaceValue.Eight),
                new Card(Suit.Clubs, FaceValue.Seven),
                new Card(Suit.Diamonds, FaceValue.Five),
                new Card(Suit.Clubs, FaceValue.Nine),
            });

            CardPile discardPile = new CardPile();
            discardPile.AddCard(new Card(Suit.Hearts, FaceValue.Ace));

            CardPile drawPile = new CardPile(true);

            CrazyEights.StartGame(
                userHand: userHand,
                computerHand: computerHand,
                discardPile: discardPile,
                drawPile: drawPile
            );

            CrazyEights.UserPlayCard(0);

            int originalNumCardsComputer = computerHand.Count;
            int originalNumCardsDiscardPile = discardPile.Count;

            Assert.AreEqual(
                CrazyEights.ActionResult.ValidPlay,
                CrazyEights.ComputerAction()
            );

            Assert.IsTrue(CrazyEights.TopDiscard.Equals(new Card(Suit.Hearts, FaceValue.Eight)));

            Assert.AreEqual(originalNumCardsComputer - 1, computerHand.Count);
            Assert.AreEqual(originalNumCardsDiscardPile + 1, discardPile.Count);

            Assert.IsTrue(CrazyEights.IsUserTurn);
            Assert.IsTrue(CrazyEights.IsPlaying);
        }

        [TestMethod()]
        public void ComputerPlaysAnyCardWhenFirstDiscardIsEight() {
            Hand computerHand = new Hand(new List<Card>() { 
                new Card(Suit.Diamonds, FaceValue.Three),
                new Card(Suit.Diamonds, FaceValue.Four)
            });

            Hand userHand = new Hand(new List<Card>() {
                new Card(Suit.Clubs, FaceValue.Two),
                new Card(Suit.Diamonds, FaceValue.Four)
            });

            CardPile discardPile = new CardPile(false);
            discardPile.AddCard(new Card(Suit.Clubs, FaceValue.Eight));
            discardPile.AddCard(new Card(Suit.Clubs, FaceValue.Ace));

            CardPile drawPile = new CardPile(false);

            int originalNumCardsComputer = computerHand.Count;

            CrazyEights.StartGame(
                userHand: userHand,
                computerHand: computerHand,
                discardPile: discardPile,
                drawPile: drawPile
            );

            // user plays Two of Clubs
            CrazyEights.UserPlayCard(0);

            // computer flips deck - new top card is Eight of Clubs
            CrazyEights.ComputerAction();
            Assert.IsTrue(CrazyEights.TopDiscard.Equals(new Card(Suit.Clubs, FaceValue.Eight)));

            // computer has no matching cards, but should still be able to play
            // because the discard pile ONLY contains an Eight
            int originalNumCardsDiscardPile = discardPile.Count;
            Assert.AreEqual(
                CrazyEights.ActionResult.ValidPlay,
                CrazyEights.ComputerAction()
            );

            // computer has played a card
            Assert.AreEqual(originalNumCardsComputer - 1, computerHand.Count);
            Assert.AreEqual(originalNumCardsDiscardPile + 1, discardPile.Count);
            
            // user's turn - game is still in play
            Assert.IsTrue(CrazyEights.IsUserTurn);
            Assert.IsTrue(CrazyEights.IsPlaying);
        }

        [TestMethod()]
        public void ComputerPlaysAndWins() {
            Hand computerHand = new Hand(new List<Card>() {
                new Card(Suit.Clubs, FaceValue.Nine),
            });
            Hand userHand = new Hand(new List<Card>() {
                new Card(Suit.Clubs, FaceValue.Seven),
                new Card(Suit.Clubs, FaceValue.Six),
            });

            CardPile discardPile = new CardPile();
            discardPile.AddCard(new Card(Suit.Clubs, FaceValue.Ten));

            CardPile drawPile = new CardPile(true);

            CrazyEights.StartGame(
                userHand: userHand,
                computerHand: computerHand,
                discardPile: discardPile,
                drawPile: drawPile
            );

            CrazyEights.UserPlayCard(0);

            int originalNumCardsComputer = computerHand.Count;
            int originalNumCardsUser = userHand.Count;
            int originalNumCardsDiscardPile = discardPile.Count;
            int originalNumCardsDrawPile = drawPile.Count;

            Assert.AreEqual(
                CrazyEights.ActionResult.WinningPlay,
                CrazyEights.ComputerAction()
            );

            Assert.AreEqual(0, computerHand.Count);
            Assert.AreEqual(originalNumCardsDiscardPile + 1, discardPile.Count);

            Assert.IsFalse(CrazyEights.IsPlaying);
        }

        [TestMethod()]
        public void ComputerPlaysAndGetsExtraTurn() {
            Hand userHand = new Hand(new List<Card>() {
                new Card(Suit.Diamonds, FaceValue.Two),
                new Card(Suit.Diamonds, FaceValue.Three),
                new Card(Suit.Diamonds, FaceValue.Four),
                new Card(Suit.Diamonds, FaceValue.Five),
                new Card(Suit.Diamonds, FaceValue.Six),
                new Card(Suit.Diamonds, FaceValue.Seven),
                new Card(Suit.Diamonds, FaceValue.Nine),
                new Card(Suit.Diamonds, FaceValue.Ten),
                new Card(Suit.Diamonds, FaceValue.Jack),
                new Card(Suit.Diamonds, FaceValue.Queen),
                new Card(Suit.Diamonds, FaceValue.King),
                new Card(Suit.Hearts, FaceValue.Two)
            });

            Hand computerHand = new Hand(new List<Card>() {
                new Card(Suit.Spades, FaceValue.Ace),
                new Card(Suit.Spades, FaceValue.Four),
                new Card(Suit.Hearts, FaceValue.Five)
            });

            CardPile discardPile = new CardPile(false);
            discardPile.AddCard(new Card(Suit.Clubs, FaceValue.Ace));

            List<Card> drawCards = Utility.CardPileCreateFullDeck();
            drawCards.Remove(new Card(Suit.Hearts, FaceValue.Three));
            drawCards.Add(new Card(Suit.Hearts, FaceValue.Three));
            Utility.RemoveFromHand(drawCards, userHand);
            Utility.RemoveFromHand(drawCards, computerHand);
            drawCards.Reverse();
            CardPile drawPile = Utility.CardPileCreate(drawCards);

            CrazyEights.StartGame(
                userHand: userHand,
                computerHand: computerHand,
                drawPile: drawPile,
                discardPile: discardPile
            );

            Assert.AreEqual(
                CrazyEights.ActionResult.DrewAndNoMovePossible,
                CrazyEights.UserDrawCard()
            );

            Assert.IsFalse(CrazyEights.IsUserTurn);

            Assert.AreEqual(
                CrazyEights.ActionResult.ValidPlayAndExtraTurn,
                CrazyEights.ComputerAction()
            );

            Assert.IsFalse(CrazyEights.IsUserTurn);

            Assert.AreEqual(
                CrazyEights.ActionResult.ValidPlay,
                CrazyEights.ComputerAction()
            );

            Assert.IsTrue(CrazyEights.IsUserTurn);
            Assert.IsTrue(CrazyEights.IsPlaying);
        }
    }

    /// <summary>
    /// These methods are necessary for some of the above unit tests.
    /// </summary>
    public static class Utility {
        public static bool HandIsSorted(Hand hand) {
            for (int i = 0; i < hand.Count - 1; i++) {
                if ((int)hand.GetCard(i).Suit > (int)hand.GetCard(i + 1).Suit) {
                    return false;
                } else if (hand.GetCard(i).Suit == hand.GetCard(i + 1).Suit &&
                          (int)hand.GetCard(i).FaceValue > (int)hand.GetCard(i + 1).FaceValue) {
                    return false;
                }
            }
            return true;
        }
        public static List<Card> HandToList(Hand hand) {
            List<Card> cards = new List<Card>();
            foreach (Card card in hand) {
                cards.Add(card);
            }
            return cards;
        }
        public static CardPile CardPileCreate(List<Card> cards) {
            CardPile cardPile = new CardPile();
            foreach (Card card in cards) {
                cardPile.AddCard(card);
            }
            return cardPile;
        }
        public static List<Card> CardPileCreateFullDeck() {
            CardPile cardPile = new CardPile(true);
            List<Card> allCards = cardPile.DealCards(cardPile.Count);
            allCards.Reverse();
            return allCards;
        }
        public static void RemoveFromHand(List<Card> cards, Hand hand) {
            foreach (Card card in hand) {
                cards.Remove(card);
            }
        }
    }

    /// <summary>
    /// This class contains logic to start games of Crazy Eights in 
    /// particular scenarios. 
    /// 
    /// The methods are useful because they create scenarios which may
    /// only occur rarely during normal play.
    /// </summary>
    public static class Scenarios {
        /// <summary>
        /// Starts a demonstration game of Crazy Eights where the user will inevitably lose
        /// </summary>
        public static void StartUserLoseDemo() {
            Hand userHand = new Hand(new List<Card>() { 
                new Card(Suit.Clubs, FaceValue.Ace),
                new Card(Suit.Spades, FaceValue.Six),
                new Card(Suit.Diamonds, FaceValue.Seven)
            });
            Hand computerHand = new Hand(new List<Card>() {
                new Card(Suit.Spades, FaceValue.Ace),
            });

            CardPile drawPile = new CardPile(true);
            drawPile.ShufflePile();

            CardPile discardPile = new CardPile();
            discardPile.AddCard(new Card(Suit.Clubs, FaceValue.Ten));

            CrazyEights.StartGame(userHand, computerHand, discardPile, drawPile);
        }

        /// <summary>
        /// Starts a demonstration game of Crazy Eights where the user will inevitably win
        /// </summary>
        public static void StartUserWinDemo() {
            Hand computerHand = new Hand(new List<Card>() { 
                new Card(Suit.Spades, FaceValue.Ace),
                new Card(Suit.Spades, FaceValue.Six),
                new Card(Suit.Diamonds, FaceValue.Seven)
            });
            Hand userHand = new Hand(new List<Card>() { 
                new Card(Suit.Clubs, FaceValue.Ace),
            });

            CardPile drawPile = new CardPile(true);
            drawPile.ShufflePile();


            CardPile discardPile = new CardPile();
            discardPile.AddCard(new Card(Suit.Clubs, FaceValue.Ten));

            CrazyEights.StartGame(userHand, computerHand, discardPile, drawPile);
        }

        /// <summary>
        /// Starts a demonstration game of Crazy Eights where the user will reach a full hand
        /// </summary>
        public static void StartNoUserMovesDemo() {
            Hand userHand = new Hand(new List<Card>() {
                new Card(Suit.Spades, FaceValue.Ace),
                new Card(Suit.Spades, FaceValue.Two),
                new Card(Suit.Spades, FaceValue.Three),
                new Card(Suit.Spades, FaceValue.Four),
                new Card(Suit.Spades, FaceValue.Five),
                new Card(Suit.Spades, FaceValue.Six),
                new Card(Suit.Hearts, FaceValue.Seven),
                new Card(Suit.Diamonds, FaceValue.Seven),
                new Card(Suit.Hearts, FaceValue.Nine),
                new Card(Suit.Hearts, FaceValue.Ten),
                new Card(Suit.Hearts, FaceValue.Jack),
                new Card(Suit.Diamonds, FaceValue.Jack)
            });

            Hand computerHand = new Hand(new List<Card>() {
                new Card(Suit.Clubs, FaceValue.Jack),
                new Card(Suit.Spades, FaceValue.Six),
                new Card(Suit.Diamonds, FaceValue.Seven)
            });

            CardPile discardPile = new CardPile();
            discardPile.AddCard(new Card(Suit.Clubs, FaceValue.Queen));

            List<Card> drawCards = Utility.CardPileCreateFullDeck();
            Utility.RemoveFromHand(drawCards, userHand);
            Utility.RemoveFromHand(drawCards, computerHand);
            drawCards.Remove(new Card(Suit.Clubs, FaceValue.Queen));
            drawCards.Remove(new Card(Suit.Diamonds, FaceValue.King));
            drawCards.Add(new Card(Suit.Diamonds, FaceValue.King));
            drawCards.Reverse();
            CardPile drawPile = Utility.CardPileCreate(drawCards);

            CrazyEights.StartGame(userHand, computerHand, discardPile, drawPile);
        }

        /// <summary>
        /// Starts a demonstration game of Crazy Eights where the computer will reach a full hand
        /// </summary>
        public static void StartNoComputerMovesDemo() {
            Hand computerHand = new Hand(new List<Card>() {
                new Card(Suit.Spades, FaceValue.Ace),
                new Card(Suit.Spades, FaceValue.Two),
                new Card(Suit.Spades, FaceValue.Three),
                new Card(Suit.Spades, FaceValue.Four),
                new Card(Suit.Spades, FaceValue.Five),
                new Card(Suit.Spades, FaceValue.Six),
                new Card(Suit.Hearts, FaceValue.Seven),
                new Card(Suit.Diamonds, FaceValue.Seven),
                new Card(Suit.Hearts, FaceValue.Nine),
                new Card(Suit.Hearts, FaceValue.Ten),
                new Card(Suit.Hearts, FaceValue.Jack),
                new Card(Suit.Diamonds, FaceValue.Jack)
            });
            Hand userHand = new Hand(new List<Card>() {
                new Card(Suit.Clubs, FaceValue.Queen),
                new Card(Suit.Spades, FaceValue.Six),
                new Card(Suit.Diamonds, FaceValue.Seven)
            });

            CardPile discardPile = new CardPile();
            discardPile.AddCard(new Card(Suit.Clubs, FaceValue.Ace));

            List<Card> drawCards = Utility.CardPileCreateFullDeck();
            Utility.RemoveFromHand(drawCards, userHand);
            Utility.RemoveFromHand(drawCards, computerHand);
            drawCards.Remove(discardPile.GetLastCardInPile());
            drawCards.Remove(new Card(Suit.Spades, FaceValue.Nine));
            drawCards.Add(new Card(Suit.Spades, FaceValue.Nine));
            drawCards.Reverse();
            CardPile drawPile = Utility.CardPileCreate(drawCards);

            CrazyEights.StartGame(userHand, computerHand, discardPile, drawPile);
        }

        /// <summary>
        /// Starts a demonstration game of Crazy Eights where both players reach a full List<Card> 
        /// during the user's turn, so the decks must be shuffled and reset
        /// </summary>
        public static void StartNobodyCanPlayAfterUserDrawsDemo() {
            Hand computerHand = new Hand(new List<Card>() {
                new Card(Suit.Spades, FaceValue.Two),
                new Card(Suit.Spades, FaceValue.Three),
                new Card(Suit.Spades, FaceValue.Four),
                new Card(Suit.Spades, FaceValue.Five),
                new Card(Suit.Spades, FaceValue.Six),
                new Card(Suit.Spades, FaceValue.Seven),
                new Card(Suit.Spades, FaceValue.Nine),
                new Card(Suit.Spades, FaceValue.Ten),
                new Card(Suit.Spades, FaceValue.Jack),
                new Card(Suit.Spades, FaceValue.Queen),
                new Card(Suit.Spades, FaceValue.King),
                new Card(Suit.Hearts, FaceValue.Two),
                new Card(Suit.Hearts, FaceValue.Three)
            });
            Hand userHand = new Hand(new List<Card>() {
                new Card(Suit.Hearts, FaceValue.Four),
                new Card(Suit.Hearts, FaceValue.Five),
                new Card(Suit.Hearts, FaceValue.Six),
                new Card(Suit.Hearts, FaceValue.Seven),
                new Card(Suit.Hearts, FaceValue.Nine),
                new Card(Suit.Hearts, FaceValue.Ten),
                new Card(Suit.Hearts, FaceValue.Jack),
                new Card(Suit.Hearts, FaceValue.Queen),
                new Card(Suit.Hearts, FaceValue.King),
                new Card(Suit.Diamonds, FaceValue.Two),
                new Card(Suit.Diamonds, FaceValue.Three),
                new Card(Suit.Diamonds, FaceValue.Four)
            });

            CardPile discardPile = new CardPile();
            discardPile.AddCard(new Card(Suit.Clubs, FaceValue.Ace));

            List<Card> drawCards = Utility.CardPileCreateFullDeck();
            Utility.RemoveFromHand(drawCards, userHand);
            Utility.RemoveFromHand(drawCards, computerHand);
            drawCards.Remove(discardPile.GetLastCardInPile());
            drawCards.Remove(new Card(Suit.Diamonds, FaceValue.Five));
            drawCards.Add(new Card(Suit.Diamonds, FaceValue.Five));
            drawCards.Reverse();
            CardPile drawPile = Utility.CardPileCreate(drawCards);

            CrazyEights.StartGame(userHand, computerHand, discardPile, drawPile);
        }

        /// <summary>
        /// Starts a demonstration game of Crazy Eights where both players reach a full hand
        /// during the computer's turn, so the decks must be shuffled and reset
        /// </summary>
        public static void StartNobodyCanPlayAfterComputerDrawsDemo() {
            Hand computerHand = new Hand(new List<Card>() {
                new Card(Suit.Hearts, FaceValue.Four),
                new Card(Suit.Hearts, FaceValue.Five),
                new Card(Suit.Hearts, FaceValue.Six),
                new Card(Suit.Hearts, FaceValue.Seven),
                new Card(Suit.Hearts, FaceValue.Nine),
                new Card(Suit.Hearts, FaceValue.Ten),
                new Card(Suit.Hearts, FaceValue.Jack),
                new Card(Suit.Hearts, FaceValue.Queen),
                new Card(Suit.Hearts, FaceValue.King),
                new Card(Suit.Diamonds, FaceValue.Two),
                new Card(Suit.Diamonds, FaceValue.Three),
                new Card(Suit.Diamonds, FaceValue.Four)
            });
            Hand userHand = new Hand(new List<Card>() {
                new Card(Suit.Spades, FaceValue.Two),
                new Card(Suit.Spades, FaceValue.Three),
                new Card(Suit.Spades, FaceValue.Four),
                new Card(Suit.Spades, FaceValue.Five),
                new Card(Suit.Spades, FaceValue.Six),
                new Card(Suit.Spades, FaceValue.Seven),
                new Card(Suit.Spades, FaceValue.Nine),
                new Card(Suit.Spades, FaceValue.Ten),
                new Card(Suit.Spades, FaceValue.Jack),
                new Card(Suit.Spades, FaceValue.Queen),
                new Card(Suit.Spades, FaceValue.King),
                new Card(Suit.Hearts, FaceValue.Two)
            });

            CardPile discardPile = new CardPile();
            discardPile.AddCard(new Card(Suit.Clubs, FaceValue.Ace));

            List<Card> drawCards = Utility.CardPileCreateFullDeck();
            Utility.RemoveFromHand(drawCards, userHand);
            Utility.RemoveFromHand(drawCards, computerHand);
            drawCards.Remove(discardPile.GetLastCardInPile());
            drawCards.Remove(new Card(Suit.Diamonds, FaceValue.Five));
            drawCards.Add(new Card(Suit.Diamonds, FaceValue.Five));
            drawCards.Remove(new Card(Suit.Hearts, FaceValue.Three));
            drawCards.Add(new Card(Suit.Hearts, FaceValue.Three));
            drawCards.Reverse();
            CardPile drawPile = Utility.CardPileCreate(drawCards);

            CrazyEights.StartGame(userHand, computerHand, discardPile, drawPile);
        }

        /// <summary>
        /// Starts a demonstration game of Crazy Eights where the draw pile will become empty 
        /// during the user's turn
        /// </summary>
        public static void StartUserFlipDeckDemo() {
            Hand userHand = new Hand(new List<Card>() {
                new Card(Suit.Diamonds, FaceValue.Nine),
                new Card(Suit.Hearts, FaceValue.Seven),
            });
            Hand computerHand = new Hand(new List<Card>() {
                new Card(Suit.Diamonds, FaceValue.Two),
                new Card(Suit.Hearts, FaceValue.Three),
            });

            CardPile drawPile = new CardPile();
            drawPile.AddCard(new Card(Suit.Clubs, FaceValue.Five));

            List<Card> discardCards = Utility.CardPileCreateFullDeck();
            Utility.RemoveFromHand(discardCards, computerHand);
            Utility.RemoveFromHand(discardCards, userHand);
            discardCards.Remove(new Card(Suit.Spades, FaceValue.Two));
            discardCards.Add(new Card(Suit.Spades, FaceValue.Two));
            CardPile discardPile = Utility.CardPileCreate(discardCards);

            CrazyEights.StartGame(userHand, computerHand, discardPile, drawPile);
        }

        /// <summary>
        /// Starts a demonstration game of Crazy Eights where the draw pile will become empty 
        /// during the user's turn - the user flips to reveal an Eight and then may play
        /// any card.
        /// </summary>
        public static void StartOneEightAfterUserFlipsDeckDemo() {
            Hand userHand = new Hand(new List<Card>() {
                new Card(Suit.Diamonds, FaceValue.Nine),
                new Card(Suit.Hearts, FaceValue.Seven),
            });
            Hand computerHand = new Hand(new List<Card>() {
                new Card(Suit.Clubs, FaceValue.Two),
                new Card(Suit.Hearts, FaceValue.Three),
            });

            CardPile drawPile = Utility.CardPileCreate(new List<Card> {
                new Card(Suit.Diamonds, FaceValue.Ten)
            });

            List<Card> discardCards = Utility.CardPileCreateFullDeck();
            Utility.RemoveFromHand(discardCards, computerHand);
            Utility.RemoveFromHand(discardCards, userHand);
            discardCards.Remove(new Card(Suit.Spades, FaceValue.Eight));
            discardCards.Add(new Card(Suit.Spades, FaceValue.Eight));
            discardCards.Reverse();
            discardCards.Remove(new Card(Suit.Spades, FaceValue.Two));
            discardCards.Add(new Card(Suit.Spades, FaceValue.Two));
            CardPile discardPile = Utility.CardPileCreate(discardCards);

            CrazyEights.StartGame(userHand, computerHand, discardPile, drawPile);
        }

        /// <summary>
        /// Starts a demonstration game of Crazy Eights where the draw pile will become empty 
        /// during the computer's turn
        /// </summary>
        public static void StartComputerFlipDeckDemo() {
            Hand computerHand = new Hand(new List<Card>() {
                new Card(Suit.Diamonds, FaceValue.Nine),
                new Card(Suit.Hearts, FaceValue.Seven),
            });
            Hand userHand = new Hand(new List<Card>() {
                new Card(Suit.Clubs, FaceValue.Two),
                new Card(Suit.Hearts, FaceValue.Three),
            });

            CardPile drawPile = Utility.CardPileCreate(new List<Card> {
                new Card(Suit.Diamonds, FaceValue.Ten)
            });

            List<Card> discardCards = Utility.CardPileCreateFullDeck();
            Utility.RemoveFromHand(discardCards, computerHand);
            Utility.RemoveFromHand(discardCards, userHand);
            discardCards.Remove(new Card(Suit.Spades, FaceValue.Two));
            discardCards.Add(new Card(Suit.Spades, FaceValue.Two));
            CardPile discardPile = Utility.CardPileCreate(discardCards);

            CrazyEights.StartGame(userHand, computerHand, discardPile, drawPile);
        }

        /// <summary>
        /// Starts a demonstration game of Crazy Eights where the draw pile will become empty 
        /// during the computer's turn - the computer flips to reveal an Eight and then may play
        /// any card.
        /// </summary>
        public static void StartOneEightAfterComputerFlipsDeckDemo() {
            Hand computerHand = new Hand(new List<Card>() {
                new Card(Suit.Diamonds, FaceValue.Nine),
                new Card(Suit.Hearts, FaceValue.Seven),
            });
            Hand userHand = new Hand(new List<Card>() {
                new Card(Suit.Clubs, FaceValue.Two),
                new Card(Suit.Hearts, FaceValue.Three),
            });

            CardPile drawPile = Utility.CardPileCreate(new List<Card> {
                new Card(Suit.Diamonds, FaceValue.Ten)
            });

            List<Card> discardCards = Utility.CardPileCreateFullDeck();
            Utility.RemoveFromHand(discardCards, computerHand);
            Utility.RemoveFromHand(discardCards, userHand);
            discardCards.Remove(new Card(Suit.Spades, FaceValue.Eight));
            discardCards.Add(new Card(Suit.Spades, FaceValue.Eight));
            discardCards.Reverse();
            discardCards.Remove(new Card(Suit.Spades, FaceValue.Two));
            discardCards.Add(new Card(Suit.Spades, FaceValue.Two));
            CardPile discardPile = Utility.CardPileCreate(discardCards);

            CrazyEights.StartGame(userHand, computerHand, discardPile, drawPile);
        }

        /// <summary>
        /// Starts a demonstrationg ame of Crazy Eights where there is one Eight in the discard pile
        /// </summary>
        public static void StartOneEightInDiscardDemo() {
            CardPile drawPile = new CardPile(true);
            drawPile.ShufflePile();

            Hand userHand = new Hand(drawPile.DealCards(8));
            Hand computerHand = new Hand(drawPile.DealCards(8));

            CardPile discardPile = new CardPile();
            discardPile.AddCard(new Card(Suit.Clubs, FaceValue.Eight));

            CrazyEights.StartGame(userHand, computerHand, discardPile, drawPile);
        }
    }

}