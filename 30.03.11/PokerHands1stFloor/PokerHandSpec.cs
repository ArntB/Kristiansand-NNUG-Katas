using System;
using System.Diagnostics;
using NUnit.Framework;

namespace PokerHands
{
    [TestFixture]
    public class PokerHandSpec
    {
        [Test]
        public void It_should_identify_hand_is_pair()
        {
            PokerHand hand = new PokerHand("2H 4S 4C 5D KH");
            Assert.IsTrue(hand.IsPair());
        }

        [Test]
        public void It_should_identify_hand_is_not_pair()
        {
            Assert.IsFalse(new PokerHand("2H 5S 4C 3D KH").IsPair());
        }

        [Test]
        public void It_should_identify_hand_is_three_of_a_kind()
        {
            Assert.IsTrue(new PokerHand("2H 2S 2C 3D KH").IsThreeOfAKind());
        }

        [Test]
        public void It_should_identify_hand_is_not_three_of_a_kind()
        {
            Assert.IsFalse(new PokerHand("2H 2S AC 3D KH").IsThreeOfAKind());
        }

        [Test]
        public void It_should_identify_hand_is_four_of_a_kind()
        {
            PokerHand hand = new PokerHand("2H 2S 2C 2D KH");
            Assert.IsTrue(hand.IsFourOfAKind());
        }

        [Test]
        public void It_should_identify_hand_is_not_four_of_a_kind()
        {
            PokerHand hand = new PokerHand("2H 2S AC 3D KH");
            Assert.IsFalse(hand.IsFourOfAKind());
        }

        [Test]
        public void It_should_identify_hand_is_two_pair()
        {
            Assert.IsTrue(new PokerHand("2H 2S 3C 3D KH").IsDoublePair());
        }
        [Test]
        public void It_should_identify_hand_is_not_two_pair()
        {
            Assert.IsFalse(new PokerHand("2H 2S 2C 3D KH").IsDoublePair());
            Assert.IsFalse(new PokerHand("2H 2S 4C 3D KH").IsDoublePair());
        }
        
        [Test]
        public void It_should_identify_hand_is_straight()
        {
            Assert.IsTrue(new PokerHand("2H 3S 4C 5D 6H").IsStraight());
            Assert.IsTrue(new PokerHand("TH JS QC KD AH").IsStraight());
            // TODO :-)
            //Assert.IsTrue(new PokerHand("AH 2S 3C 4D 5H").IsStraight());
        }

        [Test]
        public void It_should_identify_hand_is_not_straight()
        {
            Assert.IsFalse(new PokerHand("2H 3S 4C 5D 4H").IsStraight());
        }

        [Test]
        public void It_should_identify_hand_is_flush()
        {
            Assert.IsTrue(new PokerHand("2H 3H 4H 5H 8H").IsFlush());
        }

        [Test]
        public void It_should_identify_hand_is_not_flush()
        {
            Assert.IsFalse(new PokerHand("2H 3H 4H 5H 8C").IsFlush());
        }

        [Test]
        public void It_should_identify_hand_is_full_house()
        {
            Assert.IsTrue(new PokerHand("2H 2H 2H 5H 5D").IsFullHouse());
            
        }

        [Test]
        public void It_should_identify_hand_is_not_full_house()
        {
            Assert.IsFalse(new PokerHand("2H 2H 3H 5H 5H").IsFullHouse());
            Assert.IsFalse(new PokerHand("2H 2H 2H 5H 6D").IsFullHouse());
        }

        [Test]
        public void It_should_sort_hand()
        {
            var unsortedHand = "2H 5S KH 4C 3D";
            string[] sortedHand = "2H 3D 4C 5S KH".Split(' ');
            PokerHand hand = new PokerHand(unsortedHand);
            Assert.AreEqual(sortedHand, hand.Hand);
        }

        [Test]
        public void It_should_sort_A_and_K()
        {
            var unsortedHand = "2H 5S KH AC 3D";
            string[] sortedHand = "2H 3D 5S KH AC".Split(' ');
            PokerHand hand = new PokerHand(unsortedHand);
            Assert.AreEqual(sortedHand, hand.Hand);
        }
    }
}