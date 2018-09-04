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

        [DataTestMethod]
        [DataRow(new int[] { }, -1)]
        [DataRow(new[] { 5, 0 }, -1)]
        [DataRow(new[] { 3, 2, 4 }, 1)]
        [DataRow(new[] { 0, 1, 3, -2, 0, 1, 0, -3, 2, 3 }, 4)]
        [DataRow(new[] { 0, 1, 3, 3, 3, 3, 3, 3, 3, 4 }, -1)]
        [DataRow(new[] { 0, -2, -5, -1, -4, 3 }, 4)]
        [DataRow(new[] { 0, -5, -1, 4, 6, 3, 1, -2 }, 5)]
        public void TestFor_FindDeepestPit(int[] values, int expected)
        {
            var actual = _algo.FindDeepestPit(values);
            actual.Should().Be(expected);
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
