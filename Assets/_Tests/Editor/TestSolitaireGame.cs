using Cards;
using NUnit.Framework;
using SolitaireGame;

namespace TestsSolitaireGame
{
    public class TestSolitaireGame {

        private CardsTable mTable;
        private Dealer mDealer;

        [SetUp]
        public void Setup()
        {
            mTable = new CardsTable();
            mDealer = new Dealer()
            {
                Table = mTable
            };
        }

        [Test]
        public void TestDealNewGame() {

            mDealer.DealNewGame(7);

            var deckType = typeof(Deck);

            Assert.IsInstanceOf(deckType, mTable.CardsStack);
            Assert.IsInstanceOf(deckType, mTable.DiscardsStack);

            Assert.AreEqual(24, mTable.StockPile.CardsCount);
            Assert.AreEqual(0, mTable.WastePile.CardsCount);

            for (int i = 1; i < 8; i++)
            {
                var column = mTable.GetColumn(i);
                Assert.IsInstanceOf(deckType, column, "The column " + i + " should be a deck");
                Assert.AreEqual(i, column.CardsCount, "The column " + i + " should have " + i + "cards");
                Assert.AreEqual(eCardSide.Front, column.ReadCard(1).VisibleSide, "The top card of the column should be visible");
                for (int j = 2; j < i; j++)
                {
                    Assert.AreEqual(eCardSide.Back, column.ReadCard(j).VisibleSide, "The " + j + "th card of the " + i + "th column should NOT be visible");
                }
            }
        }

        [Test]
        public void TestDrawCard()
        {
            var testDeck = new Deck();
            testDeck.Stack(new Card(eCardValue.Ace, eCardColor.Clubs, eCardSide.Back));
            testDeck.Stack(new Card(eCardValue.Two, eCardColor.Clubs, eCardSide.Back));
            var topCard = new Card(eCardValue.Three, eCardColor.Clubs, eCardSide.Back);
            testDeck.Stack(topCard);

            mTable.StockPile = testDeck;
            mTable.WastePile = new Deck();

            mDealer.DrawCard();

            Assert.AreEqual(2, mTable.StockPile.CardsCount);
            Assert.AreEqual(1, mTable.WastePile.CardsCount);
            Assert.AreSame(topCard, mTable.WastePile.ReadCard(1));
        }

        [Test]
        public void TestDrawLastCard()
        {
            var oneCardDeckBackFace = new Deck();
            oneCardDeckBackFace.Stack(new Card(eCardValue.Ace, eCardColor.Clubs, eCardSide.Back));
            var twoCardsDeckFrontface = new Deck();
            twoCardsDeckFrontface.Stack(new Card(eCardValue.Two, eCardColor.Clubs, eCardSide.Front));
            twoCardsDeckFrontface.Stack(new Card(eCardValue.Three, eCardColor.Clubs, eCardSide.Front));

            mTable.StockPile = oneCardDeckBackFace;
            mTable.WastePile = twoCardsDeckFrontface;

            mDealer.DrawCard();

            Assert.AreEqual(0, mTable.StockPile.CardsCount);
            Assert.AreEqual(3, mTable.WastePile.CardsCount);

            mDealer.DrawCard();

            Assert.AreEqual(2, mTable.StockPile.CardsCount);
            Assert.AreEqual(1, mTable.WastePile.CardsCount);

            var topCardAfterDraw1 = mTable.StockPile.ReadCard(1);
            var topCardAfterDraw2 = mTable.WastePile.ReadCard(1);

            Assert.AreEqual(eCardValue.Three, topCardAfterDraw1.Value);
            Assert.AreEqual(eCardSide.Back, topCardAfterDraw1.VisibleSide);
            Assert.AreEqual(eCardValue.Two, topCardAfterDraw2.Value);
            Assert.AreEqual(eCardSide.Front, topCardAfterDraw2.VisibleSide);
        }
    }
}