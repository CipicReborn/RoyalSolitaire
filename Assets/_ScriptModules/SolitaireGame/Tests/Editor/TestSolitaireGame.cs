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

            var sevenColumns = 7;

            mDealer.DealNewGame(sevenColumns);

            Assert.AreEqual(24, mTable.StockPile.CardsCount);
            Assert.AreEqual(0, mTable.WastePile.CardsCount);

            for (int i = 1; i < 8; i++)
            {
                var column = mTable.GetColumn(i);
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
            Card topCard;
            var testDeck = Get3CardsDeck(out topCard);

            mTable.StockPile = testDeck;
            mTable.WastePile = new Pile();

            mDealer.DrawCard();

            Assert.AreEqual(2, mTable.StockPile.CardsCount);
            Assert.AreEqual(1, mTable.WastePile.CardsCount);
            Assert.AreSame(topCard, mTable.WastePile.ReadCard(1));
        }

        private Pile Get3CardsDeck (out Card topCard)
        {
            var deck = new Pile();
            deck.Stack(new Card(eCardValue.Ace, eCardColor.Clubs, eCardSide.Back));
            deck.Stack(new Card(eCardValue.Two, eCardColor.Clubs, eCardSide.Back));
            topCard = new Card(eCardValue.Three, eCardColor.Clubs, eCardSide.Back);
            deck.Stack(topCard);
            return deck;
        }

        
        [Test]
        public void TestDrawLastCard()
        {
            var oneCardDeckBackFace = new Pile();
            oneCardDeckBackFace.Stack(new Card(eCardValue.Ace, eCardColor.Clubs, eCardSide.Back));
            var twoCardsDeckFrontface = new Pile();
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