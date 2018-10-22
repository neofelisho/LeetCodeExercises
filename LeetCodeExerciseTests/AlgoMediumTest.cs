using FluentAssertions;
using LeetCodeExercises;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Text;

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

        [DataTestMethod]
        [DataRow(700, 7, 707)]
        [DataRow(7, 700000001, 700000008)]
        [DataRow(5, 5, 10)]
        public void TestFor_AddTwoNumbers(int var1, int var2, int sum)
        {
            var l1 = ConvertToListNode(var1);
            var l2 = ConvertToListNode(var2);
            var expected = ConvertToListNode(sum);

            var actual = _algo.AddTwoNumbers(l1, l2);
            actual.Should().BeEquivalentTo(expected);
        }

        private ListNode ConvertToListNode(int value)
        {
            int quotient = value;
            ListNode result = null;
            ListNode pointer = null;
            do
            {
                var remainder = new ListNode(quotient % 10);
                quotient = quotient / 10;
                if (result == null)
                {
                    result = remainder;
                    pointer = result;
                }
                else
                {
                    pointer.next = remainder;
                    pointer = pointer.next;
                }

            } while (quotient > 0);

            return result;
        }

        [DataTestMethod]
        [DataRow("abcabcbb", 3)]
        [DataRow("bbbbb", 1)]
        [DataRow("pwwkew", 3)]
        [DataRow("abcdeffabcdegh", 8)]
        public void TestFor_LengthOfLongestSubstring(string s, int expected)
        {
            var actual = _algo.LengthOfLongestSubstring(s);
            actual.Should().Be(expected);
        }

        [DataTestMethod]
        [DataRow("12345", 2, "1235")]
        [DataRow("123", 0, "123")]
        [DataRow("12", 1, "1")]
        [DataRow("12", 2, "2")]
        [DataRow("1", 1, "")]
        public void TestFor_RemoveNthFromEnd(string given, int n, string expected)
        {
            ListNode head =null, tail=null;
            while(true)
            {
                var digit = int.Parse(given.Substring(0, 1));
                var node = ConvertToListNode(digit);
                if (head == null)
                {
                    head = node;
                    tail = head;
                }
                else
                {
                    tail.next = node;
                    tail = tail.next;
                }

                if (given.Length == 1) break;
                given = given.Substring(1);
            }

            var result = _algo.RemoveNthFromEnd(head, n);
            var sb = new StringBuilder();
            while (result != null)
            {
                sb.Append(result.val);
                result = result.next;
            }

            sb.ToString().Should().Be(expected);
        }

        [DataTestMethod]
        [DataRow(0, "")]
        [DataRow(1, "()" )]
        [DataRow(2, "(())|()()")]
        [DataRow(3, "((()))|(()())|(())()|()(())|()()()")]
        public void TestFor_GenerateParenthesis(int n, string expected)
        {
            var results = _algo.GenerateParenthesis(n);
            results.ToArray().Should().BeEquivalentTo(expected.Split('|'));
        }
    }
}
