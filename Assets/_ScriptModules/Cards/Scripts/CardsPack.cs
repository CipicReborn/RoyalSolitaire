using Utils;

namespace Cards
{
    public class CardsPack
    {
        #region PUBLIC STATIC

        public static Pile GetNew52CardsPack()
        {
            var colors = EnumUtils.GetValues<eCardColor>();
            var values = EnumUtils.GetValues<eCardValue>();
            return GetNewCardsPack(colors, values);
        }

        public static Pile GetNew32CardsPack()
        {
            var colors = EnumUtils.GetValues<eCardColor>();
            var values = new eCardValue[8] { eCardValue.Ace, eCardValue.Seven, eCardValue.Eight, eCardValue.Nine, eCardValue.Ten, eCardValue.Jack, eCardValue.Queen, eCardValue.King };
            return GetNewCardsPack(colors, values);
        }

        #endregion


        #region PRIVATE STATIC

        private static Pile GetNewCardsPack(eCardColor[] colors, eCardValue[] values)
        {
            var pile = new Pile();

            for (int i = 0; i < colors.Length; i++)
            {
                for (int j = 0; j < values.Length; j++)
                {
                    var value = values[j];
                    var color = colors[i];
                    pile.Add(new Card(value, color));
                }
            }

            return pile;
        }
        #endregion
    }
}
