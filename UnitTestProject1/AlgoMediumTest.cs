using FluentAssertions;
using LeetCodeExercises;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCodeExerciseTests
{
    [TestClass]
    public class AlgoMediumTest
    {
        private readonly AlgoMedium _algo;

        public AlgoMediumTest()
        {
            _algo = new AlgoMedium();
        }

        [TestMethod]
        public void TestFor_RotateRight()
        {
            var head = new ListNode(1) { next = new ListNode(2) { next = new ListNode(3) { next = new ListNode(4) } } };
            var expected = new ListNode(3) { next = new ListNode(4) { next = new ListNode(1) { next = new ListNode(2) } } };
            var actual = _algo.RotateRight(head, 2);
            actual.Should().BeEquivalentTo(expected);
        }
    }
}
