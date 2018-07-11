using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using Cards;

namespace Cards3D
{
    public class Layout {

        public Layout () { }
        public void ApplyTopToBottom(Vector3 startPosition, Vector3 offset) { }
        public void ApplyBottomToTop(Vector3 startPosition, Vector3 offset) { }
        //private Deck mDeck;
    }
}

namespace TestCards3D
{
    public class TestCards3DLayout
    {

        [Test]
        public void Test3DLayout()
        {
            var startPosition = new Vector3(5, 10, -2);
            var offset = new Vector3(0.1f, 0.2f, -0.1f);
            //var layout = new Cards3D.Layout(mDeck3D);

            //layout.ApplyTopToBottom(startPosition, offset);

            //Assert
            
        }
    }

    public class TestCards3DCreation
    {
        [Test]
        public void TestCards3D()
        {
            var deck = new Deck();
            var layout = new Cards3D.Layout(mDeck3D);
        }
    }
}