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
            if (mTable.StockPile.CardsCount == 0)
            {
                MoveDiscardedToPool();
            }

            var card = MoveTopToTop(mTable.StockPile, mTable.WastePile);
            card.PutFrontfaceVisible();
            return card;
        }
        #endregion

        
        #region PRIVATE


        private CardsTable mTable;

        private void DealNewDeck()
        {
            var pile = CardsPack.GetNew52CardsPack();
            pile.Shuffle();
            mTable.StockPile = pile;
        }

        private void SetDiscardPile()
        {
            mTable.WastePile = new Pile();
        }


        private void DealColumns(int columnsCount)
        {
            var columns = new List<Pile>();
            for (int i = 0; i < columnsCount; i++)
            {
                columns.Add(new Pile());
            }

            for (int startColumn = 0; startColumn < columnsCount; startColumn++)
            {
                for (int i = startColumn; i < columnsCount; i++)
                {
                    var card = MoveTopToTop(mTable.StockPile, columns[i]);
                    if (i == startColumn)
                    {   
                        card.PutFrontfaceVisible();
                    }
                }
            }
            mTable.SetColumns(columns);
        }

        private Card MoveTopToTop(Pile originDeck, Pile destinationDeck)
        {
            var card = originDeck.Unstack();
            destinationDeck.Stack(card);
            return card;
        }

        private void MoveDiscardedToPool()
        {
            while(mTable.WastePile.CardsCount > 0)
            {
                mTable.WastePile.PutUpsideDown();
                mTable.StockPile = mTable.WastePile;
                mTable.WastePile = new Pile();
            }
        }
        #endregion
    }
}
