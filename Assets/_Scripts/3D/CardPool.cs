using System.Collections.Generic;
using UnityEngine;
using Cards;
using Utils;

public class CardPool : MonoBehaviour {

    public Transform TargetContainer;
    public GameObject CardPrefab;

    private const string mPrefix = "PlayingCards_";
    private Dictionary<eCardColor, Dictionary<eCardValue, GameObject>> mCards;

    private Dictionary<eCardColor, string> colorNames = new Dictionary<eCardColor, string>()
    {
        { eCardColor.Clubs, "Club"},
        { eCardColor.Diamonds, "Diamond"},
        { eCardColor.Hearts, "Heart"},
        { eCardColor.Spades, "Spades"}
    };
    private Dictionary<eCardValue, string> valueNames = new Dictionary<eCardValue, string>()
    {
        { eCardValue.Ace, "A"},
        { eCardValue.Two, "2"},
        { eCardValue.Three, "3"},
        { eCardValue.Four, "4"},
        { eCardValue.Five, "5"},
        { eCardValue.Six, "6"},
        { eCardValue.Seven, "7"},
        { eCardValue.Eight, "8"},
        { eCardValue.Nine, "9"},
        { eCardValue.Ten, "10"},
        { eCardValue.Jack, "J"},
        { eCardValue.Queen, "Q"},
        { eCardValue.King, "K"}
    };

    private eCardColor[] mColors = EnumUtils.GetValues<eCardColor>();
    private eCardValue[] mValues = EnumUtils.GetValues<eCardValue>();

    public Dictionary<eCardColor, Dictionary<eCardValue, GameObject>> GenerateNewDeck()
    {
        mCards = new Dictionary<eCardColor, Dictionary<eCardValue, GameObject>>();
        var y = 1;
        for (int i = 0; i < mColors.Length; i++)
        {
            var color = mColors[i];
            mCards[color] = new Dictionary<eCardValue, GameObject>();

            for (int j = 0; j < mValues.Length; j++)
            {
                var value = mValues[j];
                var cardImagePrefab = transform.Find(mPrefix + valueNames[value] + colorNames[color]);
                var cardPosition = new Vector3(-0.6f, 0.04f + y * 0.02f, 0.1f);
                y++;
                var card = Instantiate(CardPrefab, cardPosition, Quaternion.identity, TargetContainer);
                var image = Instantiate(cardImagePrefab.gameObject, card.transform);
                image.transform.localScale = new Vector3(14, 11, 1);
                image.transform.localPosition = new Vector3(0, 0.51f, 0);
                image.transform.rotation = Quaternion.Euler(-90f, 0f, 0f);
                mCards[color][value] = card;
            }
        }
        return mCards;
    }
}
