using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using Cards;

namespace Cards3D
{
    public class LayoutAgent { }
}

namespace TestCards3D
{
    public class TestCards3DLayout
    {

        [Test]
        public void Test3DLayout()
        {
            var deck = Deck.GetNew52CardsPack();
            var startPosition = new Vector3(5, 10, -2);
            var offset = new Vector3(0.1f, 0.2f, -0.1f);
            var layoutAgent = new Cards3D.LayoutAgent(deck);

            layoutAgent.Layout(startPosition, offset, topToBottom = true);

            
        }
    }
}