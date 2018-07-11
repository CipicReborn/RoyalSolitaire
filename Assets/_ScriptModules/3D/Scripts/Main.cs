using Cards;
using SolitaireGame;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class Main : MonoBehaviour {

    public CardPool Pool;

    private Dictionary<eCardColor, Dictionary<eCardValue, GameObject>> mCards;
    private eCardColor[] mColors = EnumUtils.GetValues<eCardColor>();
    private eCardValue[] mValues = EnumUtils.GetValues<eCardValue>();

    private Dealer mDealer;
    private CardsTable mTable;

    private Quaternion FaceUp = Quaternion.identity;
    private Quaternion FaceDown = Quaternion.Euler(0, 0, 180);

    void Start () {
        mCards = Pool.GenerateNewDeck();
        mDealer = new Dealer();
        mTable = new CardsTable();
        mDealer.Table = mTable;
        mDealer.DealNewGame(7);
        Layout();
    }

    public void SpreadLayout()
    {
        for (int i = 0; i < mColors.Length; i++)
        {
            var color = mColors[i];
            for (int j = 0; j < mValues.Length; j++)
            {
                var value = mValues[j];
                var card = mCards[color][value];

                card.transform.position = new Vector3(-0.6f + j * 0.1f, 0.04f, 0.1f - i * 0.15f);
            }
        }
    }

    public void Layout()
    {

        StackAt(mTable.StockPile, new Vector3(-0.35f, 0.04f, -0.1f), 0.04f);

        for (int col = 1; col < 8; col++)
        {
            var column = mTable.GetColumn(col);
            Debug.Log("Colonne " + col + " : ");
            StackAt(column, new Vector3(-0.35f + col * 0.1f, 0.04f, -0.3f), 0.08f, -0.01f);
        }
    }

    private void StackAt (Pile deck, Vector3 position, float yOffset, float zOffset = 0)
    {
        for (int i = 0; i < deck.CardsCount; i++)
        {
            var card = deck.ReadCard(deck.CardsCount - i);
            Debug.Log(card);
            var transform = mCards[card.Color][card.Value].transform;

            transform.localPosition = new Vector3(position.x, position.y + yOffset * i, position.z + zOffset * i);
            transform.rotation = card.VisibleSide == eCardSide.Front ? FaceUp : FaceDown;
        }
    }

}
