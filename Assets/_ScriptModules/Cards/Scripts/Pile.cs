﻿using System;
using System.Collections.Generic;
using UnityEngine;

namespace Cards
{
    public class Pile
    {

        #region PUBLIC

        public int CardsCount { get { return mStack.Count; } }

        public void Add(Card card)
        {
            mStack.Add(card);
        }

        public void Stack (Card card)
        {
            mStack.Insert(0, card);
        }

        public Card Unstack()
        {
            var topCard = mStack[0];
            mStack.RemoveAt(0);
            return topCard;
        }

        public Card ReadCard(int index)
        {
            if (index < 1 || index > mStack.Count)
            {
                throw new Exception("index <" + index + "> is out of range for a deck of " + mStack.Count + " cards.");
            }
            else
            {
                return mStack[index - 1];
            }
        }

        public void Shuffle()
        {
            var shuffled = new List<Card>();
            var intialCount = mStack.Count;
            for (int i = 0; i < intialCount; i++)
            {
                var pick = mStack[UnityEngine.Random.Range(0, mStack.Count)];
                mStack.Remove(pick);
                pick.PutBackfaceVisible();
                shuffled.Add(pick);
            }
            mStack = shuffled;
        }

        public void PutUpsideDown()
        {
            var upsideDown = new List<Card>();
            var intialCount = mStack.Count;
            for (int i = 0; i < intialCount; i++)
            {
                var pick = mStack[mStack.Count-1];
                mStack.Remove(pick);
                pick.SwitchSide();
                upsideDown.Add(pick);
            }
            mStack = upsideDown;
        }

        #endregion


        #region PRIVATE

        private List<Card> mStack = new List<Card>();

        #endregion
    }
}
