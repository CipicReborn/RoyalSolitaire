using UnityEngine;
using NUnit.Framework;
using Cards;

namespace TestCards
{
    public class TestCardsAndDecks
    {
        [Test]
        public void WhatIsACard()
        {
            var card = new Card(eCardValue.Ace, eCardColor.Spades);

            Assert.AreEqual(eCardValue.Ace, card.Value, "The card should be an Ace");
            Assert.AreEqual(eCardColor.Spades, card.Color, "The card should be a Spade");
            Assert.AreEqual(eCardSide.Front, card.VisibleSide, "The card front side should be visible");

            card.PutBackfaceVisible();
            Assert.AreEqual(eCardSide.Back, card.VisibleSide, "The card back side should be visible");
            card.PutFrontfaceVisible();
            Assert.AreEqual(eCardSide.Front, card.VisibleSide, "The card front side should be visible");

        }

        [Test]
        public void WhatIsA_52CardsDeck()
        {
            var deck = Deck.GetNew52CardsPack();

            var aceOfSpades = deck.ReadCard(1);
            var sevenOfDiamonds = deck.ReadCard(20);
            var queenOfHearts = deck.ReadCard(38);
            var kingOfClubs = deck.ReadCard(52);

            Assert.AreEqual(52, deck.CardsCount);

            Assert.AreEqual(eCardValue.Ace, aceOfSpades.Value, "The 1st card should be an Ace of Spades");
            Assert.AreEqual(eCardColor.Spades, aceOfSpades.Color, "The 1st card should be an Ace of Spades");
            Assert.AreEqual(eCardSide.Front, aceOfSpades.VisibleSide, "The 1st card should be an Ace of Spades");
            Assert.AreEqual(eCardValue.Seven, sevenOfDiamonds.Value, "The 20th card should be an Seven of Diamonds");
            Assert.AreEqual(eCardColor.Diamonds, sevenOfDiamonds.Color, "The 20th card should be an Seven of Diamonds");
            Assert.AreEqual(eCardSide.Front, sevenOfDiamonds.VisibleSide, "The 20th card should be an Seven of Diamonds");
            Assert.AreEqual(eCardValue.Queen, queenOfHearts.Value, "The 38th card should be an Queen of Hearts");
            Assert.AreEqual(eCardColor.Hearts, queenOfHearts.Color, "The 38th card should be an Queen of Hearts");
            Assert.AreEqual(eCardSide.Front, queenOfHearts.VisibleSide, "The 38th card should be an Queen of Hearts");
            Assert.AreEqual(eCardValue.King, kingOfClubs.Value, "The 52nd card should be an King of Clubs");
            Assert.AreEqual(eCardColor.Clubs, kingOfClubs.Color, "The 52nd card should be an King of Clubs");
            Assert.AreEqual(eCardSide.Front, kingOfClubs.VisibleSide, "The 52nd card should be an King of Clubs");
        }

        [Test]
        public void WhatIsA_32CardsDeck()
        {
            var deck = Deck.GetNew32CardsPack();

            var aceOfSpades = deck.ReadCard(1);
            var tenOfDiamonds = deck.ReadCard(13);
            var queenOfHearts = deck.ReadCard(23);
            var kingOfClubs = deck.ReadCard(32);

            Assert.AreEqual(32, deck.CardsCount);

            Assert.AreEqual(eCardValue.Ace, aceOfSpades.Value, "The 1st card should be an Ace of Spades");
            Assert.AreEqual(eCardColor.Spades, aceOfSpades.Color, "The 1st card should be an Ace of Spades");
            Assert.AreEqual(eCardSide.Front, aceOfSpades.VisibleSide, "The 1st card should be an Ace of Spades");
            Assert.AreEqual(eCardValue.Ten, tenOfDiamonds.Value, "The 20th card should be an Seven of Diamonds");
            Assert.AreEqual(eCardColor.Diamonds, tenOfDiamonds.Color, "The 20th card should be an Seven of Diamonds");
            Assert.AreEqual(eCardSide.Front, tenOfDiamonds.VisibleSide, "The 20th card should be an Seven of Diamonds");
            Assert.AreEqual(eCardValue.Queen, queenOfHearts.Value, "The 38th card should be an Queen of Hearts");
            Assert.AreEqual(eCardColor.Hearts, queenOfHearts.Color, "The 38th card should be an Queen of Hearts");
            Assert.AreEqual(eCardSide.Front, queenOfHearts.VisibleSide, "The 38th card should be an Queen of Hearts");
            Assert.AreEqual(eCardValue.King, kingOfClubs.Value, "The 52nd card should be an King of Clubs");
            Assert.AreEqual(eCardColor.Clubs, kingOfClubs.Color, "The 52nd card should be an King of Clubs");
            Assert.AreEqual(eCardSide.Front, kingOfClubs.VisibleSide, "The 52nd card should be an King of Clubs");
        }

        [Test]
        public void ADeckCanBeShuffled()
        {

            var deck = Deck.GetNew52CardsPack();
            deck.Shuffle();
            var randomCard = deck.ReadCard(1);
            Debug.Log("First Card is now a " + randomCard);

            Assert.AreEqual(52, deck.CardsCount, "A deck shuffle should not change the cards count");
            Assert.AreEqual(eCardSide.Back, randomCard.VisibleSide, "After shuffle, the cards should be Backface on top");
        }

        [Test]
        public void AShuffledDeckIsFullBackface()
        {

            var deck = Deck.GetNew52CardsPack();
            deck.Shuffle();
            
            for (int i = 1; i < 53; i++)
            {
                Assert.AreEqual(52, deck.CardsCount);
                Assert.AreEqual(eCardSide.Back, deck.ReadCard(i).VisibleSide, "After shuffle, all cards should be Backface on top");
            }
        }

        [Test]
        public void ACardCanBeStackedOnADeck()
        {
            var deck = new Deck();
            deck.Stack(new Card(eCardValue.Ace, eCardColor.Clubs, eCardSide.Back));
            deck.Stack(new Card(eCardValue.Two, eCardColor.Clubs, eCardSide.Front));

            Assert.AreEqual(2, deck.CardsCount);
            Assert.AreEqual(eCardValue.Two, deck.ReadCard(1).Value);
            Assert.AreEqual(eCardValue.Ace, deck.ReadCard(2).Value);
        }

        [Test]
        public void ACardCanBeUnstackedFromADeck()
        {
            var deck = new Deck();
            deck.Stack(new Card(eCardValue.Ace, eCardColor.Clubs, eCardSide.Back));
            deck.Stack(new Card(eCardValue.Two, eCardColor.Clubs, eCardSide.Front));
            deck.Stack(new Card(eCardValue.Queen, eCardColor.Hearts, eCardSide.Front));

            Assert.AreEqual(3, deck.CardsCount);

            var topCard = deck.Unstack();

            Assert.AreEqual(2, deck.CardsCount);
            Assert.AreEqual(eCardValue.Queen, topCard.Value);
            Assert.AreEqual(eCardColor.Hearts, topCard.Color);
            Assert.AreEqual(eCardValue.Two, deck.ReadCard(1).Value);
            Assert.AreEqual(eCardColor.Clubs, deck.ReadCard(1).Color);
        }

        [Test]
        public void ADeckCanBePutUpsideDown()
        {
            var deck1 = Deck.GetNew32CardsPack();
            var deck2 = Deck.GetNew32CardsPack();

            deck2.PutUpsideDown();
            Assert.AreEqual(32, deck2.CardsCount);

            for (int i = 1; i < 33; i++)
            {
                var c1 = deck1.ReadCard(i);
                var c2 = deck2.ReadCard(33 - i);
                Assert.AreEqual(c1.Value, c2.Value);
                Assert.AreEqual(c1.Color, c2.Color);
                Assert.AreNotEqual(c1.VisibleSide, c2.VisibleSide);
            }
        }
    }
}