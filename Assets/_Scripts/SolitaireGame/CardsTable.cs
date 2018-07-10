using System.Collections.Generic;
using Cards;

namespace SolitaireGame
{
    public class CardsTable
    {
        public Deck CardsStack;
        public Deck DiscardsStack;
        private List<Deck> mColumns = new List<Deck>();

        public Deck GetColumn(int index)
        {
            return mColumns[index - 1];
        }

        public void SetColumns(List<Deck> columns)
        {
            mColumns = columns;
        }
    }
}
