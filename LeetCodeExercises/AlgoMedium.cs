using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeExercises
{
    public class AlgoMedium
    {
        public int FindDeepestPit(int[] A)
        {
            if (A.Length < 3) return -1;

            var decreasingAmount = 0;
            var increasingAmount = 0;
            int? deepestPit = null;
            bool isDecreasing = true;

            var index = 1;
            while (A[index] >= A[index - 1])
            {
                index++;
                if (index == A.Length)
                    break;
            }

            for (var i = index; i < A.Length; i++)
            {
                var currentAmount = A[i] - A[i - 1];

                if (currentAmount == 0)
                    continue;
                if (currentAmount < 0)
                {
                    if (isDecreasing)
                    {
                        decreasingAmount -= currentAmount;
                        continue;
                    }
                    deepestPit = GetPitValue(decreasingAmount, increasingAmount, deepestPit);
                    increasingAmount = 0;
                    decreasingAmount = -currentAmount;
                    isDecreasing = true;
                }
                else
                {
                    increasingAmount += currentAmount;
                    isDecreasing = false;
                }
            }
            if (!isDecreasing)
            {
                deepestPit = GetPitValue(decreasingAmount, increasingAmount, deepestPit);
            }
            return deepestPit == null ? -1 : deepestPit.Value;
        }

        private static int? GetPitValue(int decreasingAmount, int increasingAmount, int? deepestPit)
        {
            var currentPit = Math.Min(increasingAmount, decreasingAmount);
            deepestPit = deepestPit == null ? currentPit : Math.Max(deepestPit.Value, currentPit);
            return deepestPit;
        }

        /// <summary>
        ///     LeetCode #61 Rotate List
        /// </summary>
        /// <param name="head"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public ListNode RotateRight(ListNode head, int k)
        {
            if (head == null) return null;
            var length = 1;
            var tail = head;
            var newHead = head;
            while (tail.next != null)
            {
                tail = tail.next;
                length++;
            }

            k = k % length;
            if (k <= 0) return newHead;

            tail.next = newHead;
            for (var i = 0; i < length - k; i++)
            {
                tail = tail.next;
                newHead = newHead.next;
            }

            tail.next = null;
            return newHead;
        }

        /// <summary>
        ///     LeetCode #2 Add Two Numbers
        /// </summary>
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var h1 = l1;
            var h2 = l2;

            ListNode result = null;
            ListNode pointer = null;
            var carry = 0;
            while (h1 != null || h2 != null || carry > 0)
            {
                var sum = (h1 == null ? 0 : h1.val) + (h2 == null ? 0 : h2.val) + carry;
                carry = sum / 10;

                var temp = new ListNode(sum % 10);
                if (result == null)
                {
                    result = temp;
                    pointer = result;
                }
                else
                {
                    pointer.next = temp;
                    pointer = pointer.next;
                }

                if (h1 != null) h1 = h1.next;
                if (h2 != null) h2 = h2.next;
            }

            return result;
        }

        /// <summary>
        ///     LeetCode #3 Longest Substring Without Repeating Characters
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int LengthOfLongestSubstring(string s)
        {
            if (string.IsNullOrEmpty(s)) return 0;

            var result = 0;
            var max = 0;
            var set = new HashSet<char>();

            var j = 0;
            for(var i = 0; i < s.Length; i++)
            {
                var c = s[i];
                if (set.Contains(c))
                {
                    max = Math.Max(result, max);
                    var position = s.IndexOf(c, j);
                    foreach (var cc in s.Substring(j, position - j + 1))
                    {
                        set.Remove(cc);
                    }
                    result -= position - j;
                    j = position + 1;
                }
                else
                {
                    result++;
                }
                set.Add(c);
            }

            return Math.Max(result, max);
        }

        /// <summary>
        ///     LeetCode #19 Remove Nth Node From End of List
        /// </summary>
        /// <param name="head"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            var fp = head;
            if (fp == null) return head;
            if (n == 0) return head;
            for(var i = 0; i < n; i++)
            {
                fp = fp.next;
                if (fp == null) return head.next;
            }
            var sp = head;
            while (fp.next != null)
            {
                sp = sp.next;
                fp = fp.next;
            }
            sp.next = sp.next.next;
            return head;
        }

        /// <summary>
        ///     LeetCode #22 Generate Parentheses
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public IList<string> GenerateParenthesis(int n)
        {
            var results = new List<string>();

            GetPossible(n, n, string.Empty);

            return results;

            void GetPossible(int left, int right, string s)
            {
                if(s.Length == n*2)
                {
                    results.Add(s);
                    return;
                }

                if (left > 0)
                {
                    GetPossible(left - 1, right, s + "(");
                }

                if (left < right)
                {
                    GetPossible(left, right - 1, s + ")");
                }
            }
        }
    }
}