using System.Collections.Generic;
using Cards;

namespace SolitaireGame
{
    public class CardsTable
    {
        public Deck StockPile;
        public Deck WastePile;
        private List<Deck> mTableau = new List<Deck>();
        //private List<Deck> mFoundations = new List<Deck>();
        

        public Deck GetColumn(int index)
        {
            return mTableau[index - 1];
        }

        public void SetColumns(List<Deck> columns)
        {
            mTableau = columns;
        }
    }
}
