using Cards;
using System.Collections.Generic;
using UnityEngine;

namespace SolitaireGame
{
    public class Dealer
    {
        #region PUBLIC

        public CardsTable Table
        {
            get { return mTable; }
            set { mTable = value; }
        }

        public void DealNewGame(int columnsCount)
        {
            if (mTable == null)
            {
                throw new System.Exception("A Table must be assigned to a Dealer before Dealing A New Game");
            }

            DealNewDeck();
            SetDiscardPile();
            DealColumns(columnsCount);
        }

        public Card DrawCard()
        {
            if (mTable.CardsStack.CardsCount == 0)
            {
                MoveDiscardedToPool();
            }

            var card = MoveTopToTop(mTable.CardsStack, mTable.DiscardsStack);
            card.PutFrontfaceVisible();
            return card;
        }
        #endregion

        
        #region PRIVATE


        private CardsTable mTable;

        private void DealNewDeck()
        {
            var newDeck = Deck.GetNew(eDeckType.FiftyTwo);
            newDeck.Shuffle();
            mTable.CardsStack = newDeck;
        }

        private void SetDiscardPile()
        {
            mTable.DiscardsStack = new Deck();
        }


        private void DealColumns(int columnsCount)
        {
            var columns = new List<Deck>();
            for (int i = 0; i < columnsCount; i++)
            {
                columns.Add(new Deck());
            }

            for (int startColumn = 0; startColumn < columnsCount; startColumn++)
            {
                for (int i = startColumn; i < columnsCount; i++)
                {
                    var card = MoveTopToTop(mTable.CardsStack, columns[i]);
                    if (i == startColumn)
                    {   
                        card.PutFrontfaceVisible();
                    }
                }
            }
            mTable.SetColumns(columns);
        }

        private Card MoveTopToTop(Deck originDeck, Deck destinationDeck)
        {
            var card = originDeck.Unstack();
            destinationDeck.Stack(card);
            return card;
        }

        private void MoveDiscardedToPool()
        {
            while(mTable.DiscardsStack.CardsCount > 0)
            {
                mTable.DiscardsStack.PutUpsideDown();
                mTable.CardsStack = mTable.DiscardsStack;
                mTable.DiscardsStack = new Deck();
            }
        }
        #endregion
    }
}
