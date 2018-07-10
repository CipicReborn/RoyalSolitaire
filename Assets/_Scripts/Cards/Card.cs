namespace Cards
{
    public class Card {

        #region PUBLIC

        public eCardValue Value { get { return mValue; } }
        public eCardColor Color { get { return mColor; } }
        public eCardSide VisibleSide { get { return mVisibleSide; } }

        public Card (eCardValue value, eCardColor color, eCardSide side = eCardSide.Front)
        {
            mValue = value;
            mColor = color;
            mVisibleSide = side;
        }

        public void SwitchSide()
        {
            if (mVisibleSide == eCardSide.Front) PutBackfaceVisible();
            else PutFrontfaceVisible();
        }
        public void PutBackfaceVisible()
        {
            mVisibleSide = eCardSide.Back;
        }

        public void PutFrontfaceVisible()
        {
            mVisibleSide = eCardSide.Front;
        }

        public override string ToString()
        {
            return mValue + " of " + mColor + " (" + mVisibleSide + "face visible)";
        }
        #endregion

        #region PRIVATE

        private eCardValue mValue;
        private eCardColor mColor;
        private eCardSide mVisibleSide;
        
        #endregion
    }
}
