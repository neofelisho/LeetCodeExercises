using System.Collections.Generic;
using FluentAssertions;
using LeetCodeExercises;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCodeExerciseTests
{
    [TestClass]
    public class AlgoEasyTest
    {
        private readonly AlgoEasy _algo;

        public AlgoEasyTest()
        {
            _algo = new AlgoEasy();
        }

        [DataTestMethod]
        [DataRow(new[] {3, 2, 4}, 6, new[] {1, 2})]
        [DataRow(new[] {2, 7, 11, 5}, 9, new[] {0, 1})]
        public void TestFor_TwoSum(int[] nums, int target, int[] expected)
        {
            var actual = _algo.TwoSum(nums, target);
            actual.Should().BeEquivalentTo(expected);
        }

        [DataTestMethod]
        [DataRow(-91235, -53219)]
        [DataRow(12340, 4321)]
        [DataRow(1534236469, 0)]
        public void TestFor_Reverse(int value, int expected)
        {
            var actual = _algo.Reverse(value);
            actual.Should().Be(expected);
        }

        [DataTestMethod]
        [DataRow(12321, true)]
        [DataRow(-123, false)]
        [DataRow(987789, true)]
        [DataRow(25520, false)]
        [DataRow(2147483647, false)]
        [DataRow(-2147483648, false)]
        public void TestFor_IsPalindrome(int value, bool expected)
        {
            var actual = _algo.IsPalindrome(value);
            actual.Should().Be(expected);
        }

        [TestMethod]
        public void TestFor_IsPalindromeLinkedList()
        {
            var head = new ListNode(1) {next = new ListNode(2) {next = new ListNode(3)}};
            _algo.IsPalindrome(head).Should().BeFalse();

            head = new ListNode(1) {next = new ListNode(2) {next = new ListNode(1)}};
            _algo.IsPalindrome(head).Should().BeTrue();

            head = new ListNode(1) {next = new ListNode(2) {next = new ListNode(2) {next = new ListNode(1)}}};
            _algo.IsPalindrome(head).Should().BeTrue();

            head = new ListNode(1) {next = new ListNode(2) {next = new ListNode(2) {next = new ListNode(2)}}};
            _algo.IsPalindrome(head).Should().BeFalse();
        }

        [TestMethod]
        public void TestFor_ReverseList()
        {
            var head = new ListNode(1) {next = new ListNode(2) {next = new ListNode(3) {next = new ListNode(4)}}};
            var expected = new ListNode(4) {next = new ListNode(3) {next = new ListNode(2) {next = new ListNode(1)}}};
            var actual = _algo.ReverseList(head);
            actual.Should().BeEquivalentTo(expected);

            head = new ListNode(1) {next = new ListNode(2) {next = new ListNode(3) {next = new ListNode(4)}}};
            expected = new ListNode(4) {next = new ListNode(2) {next = new ListNode(3) {next = new ListNode(1)}}};
            actual = _algo.ReverseList(head);
            while (actual != null)
            {
                if (actual.val == 1 || actual.val == 4)
                    actual.val.Should().Be(expected.val);
                else
                    actual.val.Should().NotBe(expected.val);
                actual = actual.next;
                expected = expected.next;
            }
        }

        [DataTestMethod]
        [DataRow(1, true)]
        [DataRow(4, false)]
        [DataRow(32, false)]
        [DataRow(35, true)]
        public void TestFor_CanWinNim(int value, bool expected)
        {
            var actual = _algo.CanWinNim(value);
            actual.Should().Be(expected);
        }

        [DataTestMethod]
        [DataRow(1, 1)]
        [DataRow(2, 2)]
        [DataRow(3, 3)]
        [DataRow(4, 5)]
        [DataRow(5, 8)]
        [DataRow(10, 89)]
        public void TestFor_ClimbStairs(int value, int expected)
        {
            var actual = _algo.ClimbStairs(value);
            actual.Should().Be(expected);
        }

        [DataTestMethod]
        [DataRow(new[] {3, 2, 4}, 2)]
        [DataRow(new[] {3, 7, 11, 5, 3}, 8)]
        [DataRow(new[] {3, 7, 11, 5, 2, 11}, 9)]
        public void TestFor_MaxProfit(int[] prices, int expected)
        {
            var actual = _algo.MaxProfit(prices);
            actual.Should().Be(expected);
        }

        [DataTestMethod]
        [DataRow(new[] {7}, 7)]
        [DataRow(new[] {3, 2, 4}, 7)]
        [DataRow(new[] {3, 7, 11, 5, 3}, 17)]
        [DataRow(new[] {3, 7, 11, 5, 2, 11}, 25)]
        public void TestFor_Rob(int[] nums, int expected)
        {
            var actual = _algo.Rob(nums);
            actual.Should().Be(expected);
        }

        [DataTestMethod]
        [DataRow(int.MaxValue, 987)]
        [DataRow(int.MinValue, int.MinValue)]
        [DataRow(0, int.MinValue)]
        [DataRow(-1, int.MinValue)]
        [DataRow(12345, 987)]
        public void TestFor_GuessNumber(int value, int expected)
        {
            var actual = _algo.GuessNumber(value);
            actual.Should().Be(expected);
        }

        [DataTestMethod]
        [DataRow(int.MaxValue, 987)]
        [DataRow(int.MinValue, int.MinValue)]
        [DataRow(0, int.MinValue)]
        [DataRow(-1, int.MinValue)]
        [DataRow(12345, 987)]
        public void TestFor_FirstBadVersion(int value, int expected)
        {
            var actual = _algo.FirstBadVersion(value);
            actual.Should().Be(expected);
        }

        [DataTestMethod]
        [DataRow(new[] {7}, 7, 0)]
        [DataRow(new[] {2, 3, 4}, 7, 3)]
        [DataRow(new[] {3, 7, 11, 15, 23}, 17, 4)]
        [DataRow(new[] {3, 7, 11, 15, 23, 24}, 2, 0)]
        public void TestFor_SearchInsert(int[] nums, int target, int expected)
        {
            var actual = _algo.SearchInsert(nums, target);
            actual.Should().Be(expected);
        }

        [DataTestMethod]
        [DataRow(new[] {2, 3, 4}, 1, new[] {4, 2, 3})]
        [DataRow(new[] {3, 7, 11, 15, 23}, 2, new[] {15, 23, 3, 7, 11})]
        public void TestFor_Rotate(int[] actual, int k, int[] expected)
        {
            _algo.RotateCycleReplace(actual, k);
            actual.Should().BeEquivalentTo(expected);
        }

        [DataTestMethod]
        [DataRow(new[] {"abc", "abcde", "abdef"}, "ab")]
        public void TestFor_LongestCommonPrefix(string[] strs, string expected)
        {
            var actual = _algo.LongestCommonPrefix(strs);
            actual.Should().Be(expected);
        }

        [TestMethod]
        public void TestFor_MergeTwoLists()
        {
            var l1 = new ListNode(1) {next = new ListNode(1) {next = new ListNode(2) {next = new ListNode(3)}}};
            var l2 = new ListNode(1) {next = new ListNode(2) {next = new ListNode(3) {next = new ListNode(4)}}};
            var expected = new ListNode(1)
            {
                next = new ListNode(1)
                {
                    next = new ListNode(1)
                    {
                        next = new ListNode(2)
                        {
                            next = new ListNode(2)
                            {
                                next = new ListNode(3) {next = new ListNode(3) {next = new ListNode(4)}}
                            }
                        }
                    }
                }
            };

            var actual = _algo.MergeTwoLists(l1, l2);
            actual.Should().BeEquivalentTo(expected);
        }

        [DataTestMethod]
        [DataRow(new[] {1}, 1)]
        [DataRow(new int[] { }, 0)]
        [DataRow(new[] {1, 1, 2, 3, 3}, 3)]
        [DataRow(new[] {1, 2, 3, 4, 4}, 4)]
        public void TestFor_RemoveDuplicates(int[] nums, int expected)
        {
            var actual = _algo.RemoveDuplicates(nums);
            actual.Should().Be(expected);
        }

        [DataTestMethod]
        [DataRow(new[] {1}, 1, 0)]
        [DataRow(new[] {1}, 2, 1)]
        [DataRow(new int[] { }, 0, 0)]
        [DataRow(new[] {1, 1, 2, 3, 3}, 3, 3)]
        [DataRow(new[] {1, 2, 3, 4, 4}, 4, 3)]
        public void TestFor_RemoveElement(int[] nums, int val, int expected)
        {
            var actual = _algo.RemoveElement(nums, val);
            actual.Should().Be(expected);
        }

        [TestMethod]
        public void TestFor_DeleteDuplicates()
        {
            var head = new ListNode(1) {next = new ListNode(3) {next = new ListNode(3) {next = new ListNode(4)}}};
            var expected = new ListNode(1) {next = new ListNode(3) {next = new ListNode(4)}};
            var actual = _algo.DeleteDuplicates(head);
            actual.Should().BeEquivalentTo(expected);

            head = new ListNode(1) {next = new ListNode(1) {next = new ListNode(1) {next = new ListNode(1)}}};
            expected = new ListNode(1);
            actual = _algo.DeleteDuplicates(head);
            actual.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void TestFor_IsSymmetric()
        {
            var root = new TreeNode(1)
            {
                left = new TreeNode(2)
                {
                    left = new TreeNode(3),
                    right = new TreeNode(4)
                },
                right = new TreeNode(2)
                {
                    left = new TreeNode(4),
                    right = new TreeNode(3)
                }
            };
            var actual = _algo.IsSymmetric(root);
            actual.Should().BeTrue();

            root = new TreeNode(1)
            {
                left = new TreeNode(2)
                {
                    left = new TreeNode(3),
                    right = new TreeNode(4)
                },
                right = new TreeNode(2)
                {
                    left = new TreeNode(3),
                    right = new TreeNode(4)
                }
            };
            actual = _algo.IsSymmetric(root);
            actual.Should().BeFalse();

            actual = _algo.IsSymmetric(null);
            actual.Should().BeTrue();
        }

        [TestMethod]
        public void TestFor_Generate()
        {
            var expected = new List<List<int>>
            {
                new List<int> {1},
                new List<int> {1, 1},
                new List<int> {1, 2, 1},
                new List<int> {1, 3, 3, 1},
                new List<int> {1, 4, 6, 4, 1}
            };

            var actual = _algo.Generate(5);
            actual.Should().BeEquivalentTo(expected);
        }

        [DataTestMethod]
        [DataRow(0, new[] {1})]
        [DataRow(1, new[] {1, 1})]
        [DataRow(5, new[] {1, 5, 10, 10, 5, 1})]
        public void TestFor_GetRow(int rowIndex, int[] expected)
        {
            var actual = _algo.GetRow(rowIndex);
            actual.Should().BeEquivalentTo(expected);
        }

        [DataTestMethod]
        [DataRow(new[] {1, 2}, 1)]
        [DataRow(new[] {1, 2, 4}, 3)]
        [DataRow(new[] {1, 4, 2}, 3)]
        [DataRow(new[] {1, 2, 1, 2, 1}, 2)]
        public void TestFor_MaxProfit2(int[] prices, int expected)
        {
            var actual = _algo.MaxProfit2(prices);
            actual.Should().Be(expected);
        }

        [DataTestMethod]
        [DataRow(new[] {1}, 1)]
        [DataRow(new[] {1, 1}, 0)]
        [DataRow(new[] {1, 1, 2}, 2)]
        [DataRow(new[] {1, 2, 1, 2, 3}, 3)]
        public void TestFor_SingleNumber(int[] nums, int expected)
        {
            var actual = _algo.SingleNumber(nums);
            actual.Should().Be(expected);
        }

        [TestMethod]
        public void TestFor_HasCycle()
        {
            var head = new ListNode(1) {next = new ListNode(2)};
            var actual = _algo.HasCycle(head);
            actual.Should().BeFalse();

            head = new ListNode(1);
            var tail = new ListNode(2);
            head.next = tail;
            tail.next = head;
            actual = _algo.HasCycle(head);
            actual.Should().BeTrue();
        }

        [TestMethod]
        public void TestFor_GetIntersectionNode()
        {
            var headA = new ListNode(1) { next = new ListNode(2) };
            var headB = new ListNode(3) { next = new ListNode(4) {next = new ListNode(5){next = new ListNode(6)}}};
            var actual = _algo.GetIntersectionNode(headA, headB);
            actual.Should().BeNull();

            headA=new ListNode(1){next = new ListNode(3){next = new ListNode(5){next = new ListNode(7){next = new ListNode(9)}}}};
            headB=new ListNode(2);
            actual = _algo.GetIntersectionNode(headA, headB);
            actual.Should().BeNull();

            var headC=new ListNode(7){next = new ListNode(8)};
            headA = new ListNode(1) { next = new ListNode(2) {next = headC}};
            headB = new ListNode(3) { next = new ListNode(4) { next = new ListNode(5) { next = new ListNode(6){next = headC} } } };
            actual = _algo.GetIntersectionNode(headA, headB);
            actual.Should().BeEquivalentTo(headC);
        }
    }
}