using System.Collections.Generic;
using Cards;

namespace SolitaireGame
{
    public class CardsTable
    {
        public Pile StockPile;
        public Pile WastePile;
        private List<Pile> mTableau = new List<Pile>();
        //private List<Deck> mFoundations = new List<Deck>();
        

        public Pile GetColumn(int index)
        {
            return mTableau[index - 1];
        }

        public void SetColumns(List<Pile> columns)
        {
            mTableau = columns;
        }
    }
}
