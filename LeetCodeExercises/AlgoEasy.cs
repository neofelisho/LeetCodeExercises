using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExercises
{
    public class AlgoEasy
    {
        public int[] TwoSum(int[] nums, int target)
        {
            var dic = new Dictionary<int, int>();
            for (var i = 0; i < nums.Length; i++)
            {
                var current = nums[i];
                var complement = target - current;
                if (dic.Values.Contains(current))
                    return new[] {i, dic.Where(p => p.Value == current).Select(p => p.Key).Single()};
                dic.Add(i, complement);
            }

            return new int[] { };
        }

        public int Reverse(int x)
        {
            var isNegative = x < 0;
            if (isNegative) x *= -1;
            var chars = x.ToString().ToCharArray().Reverse().ToArray();
            var s = new string(chars);
            return int.TryParse(s, out var r) ? r * (isNegative ? -1 : 1) : 0;
        }

        public bool IsPalindrome(int x)
        {
            if (x < 0 || x % 10 == 0 && x != 0)
                return false;

            var revertedNumber = 0;
            while (x > revertedNumber)
            {
                revertedNumber = revertedNumber * 10 + x % 10;
                x /= 10;
            }

            return x == revertedNumber || x == revertedNumber / 10;
        }

        /// <summary>
        ///     LeetCode 234
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public bool IsPalindrome(ListNode head)
        {
            var middle = FindMiddle(head);
            var reverse = ReverseList(middle);
            while (reverse != null)
            {
                if (reverse.val != head.val) return false;
                reverse = reverse.next;
                head = head.next;
            }

            return true;
        }

        private static ListNode FindMiddle(ListNode head)
        {
            var slow = head;
            var fast = head;
            while (fast?.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }

            return slow;
        }

        /// <summary>
        ///     LeetCode 206
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode ReverseList(ListNode head)
        {
            if (head?.next == null) return head;
            ListNode reverse = null;
            var current = head;
            while (current != null)
            {
                var temp = current;
                current = current.next;
                temp.next = reverse;
                reverse = temp;
            }

            return reverse;
        }

        /// <summary>
        ///     LeetCode 292 Nim Game
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public bool CanWinNim(int n)
        {
            return n % 4 != 0;
        }

        /// <summary>
        ///     LeetCode 70 Climbing Stairs
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int ClimbStairs(int n)
        {
            if (n == 1) return 1;

            var a = 1;
            var b = 2;
            for (var i = 2; i < n; i++)
            {
                var c = a + b;
                a = b;
                b = c;
            }

            return b;
            //var dp = new int[n + 1];
            //dp[1] = 1;
            //dp[2] = 2;
            //for (var i = 3; i <= n; i++) dp[i] = dp[i - 1] + dp[i - 2];
            //return dp[n];
        }


        /// <summary>
        ///     LeetCode 278 First Bad Version
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int FirstBadVersion(int n)
        {
            return BinaryVersionTest(1, n);
        }

        private static int BinaryVersionTest(int begin, int end)
        {
            if (end < begin) return int.MinValue;
            while (true)
            {
                if (IsBadVersion(begin)) return begin;
                if (!IsBadVersion(end)) return int.MinValue;
                var mid = begin + (end - begin) / 2;
                if (IsBadVersion(mid))
                {
                    begin += +1;
                    end = mid;
                    continue;
                }

                begin = mid + 1;
            }
        }

        private static bool IsBadVersion(int version)
        {
            return version >= 987;
        }

        /// <summary>
        ///     LeetCode 35 Search Insert Position
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int SearchInsert(int[] nums, int target)
        {
            var begin = 0;
            var end = nums.Length - 1;

            while (true)
            {
                if (nums[begin] >= target) return begin;
                if (nums[end] < target) return end + 1;
                var mid = begin + (end - begin) / 2;
                if (nums[mid] >= target)
                {
                    begin += 1;
                    end = mid;
                    continue;
                }

                begin = mid + 1;
            }
        }

        /// <summary>
        ///     LeetCode 189 Rotate Array
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        public void RotateBruteForce(int[] nums, int k)
        {
            k = k % nums.Length;
            for (var i = 0; i < k; i++)
            {
                var prev = nums[nums.Length - 1];
                for (var j = 0; j < nums.Length; j++)
                {
                    var temp = nums[j];
                    nums[j] = prev;
                    prev = temp;
                }
            }
        }

        public void RotateCycleReplace(int[] nums, int k)
        {
            k = k % nums.Length;
            var count = 0;
            for (var start = 0; count < nums.Length; start++)
            {
                var current = start;
                var prev = nums[start];
                do
                {
                    var next = (current + k) % nums.Length;
                    var temp = nums[next];
                    nums[next] = prev;
                    prev = temp;
                    current = next;
                    count++;
                } while (start != current);
            }
        }

        /// <summary>
        ///     LeetCode 14 Longest Common Prefix
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public string LongestCommonPrefix(string[] strs)
        {
            while (true)
                switch (strs.Length)
                {
                    case 0:
                        return string.Empty;
                    case 1:
                        return strs[0];
                    case 2:
                        var minLength = Math.Min(strs[0].Length, strs[1].Length);
                        var leftChars = strs[0].ToCharArray();
                        var rightChars = strs[1].ToCharArray();
                        for (var i = 0; i < minLength; i++)
                            if (leftChars[i] != rightChars[i])
                                return strs[0].Substring(0, i);

                        return strs[0].Substring(0, minLength);
                    default:
                        var leftLength = strs.Length / 2;
                        var leftStrs = new string[leftLength];
                        Array.Copy(strs, 0, leftStrs, 0, leftLength);
                        var rightLength = strs.Length - leftLength;
                        var rightStrs = new string[rightLength];
                        Array.Copy(strs, leftLength, rightStrs, 0, rightLength);
                        strs = new[] {LongestCommonPrefix(leftStrs), LongestCommonPrefix(rightStrs)};
                        continue;
                }
        }

        /// <summary>
        ///     LeetCode 21 Merge Two Sorted Lists
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            if (l1 == null) return l2;
            if (l2 == null) return l1;
            if (l1.val < l2.val)
            {
                l1.next = MergeTwoLists(l1.next, l2);
                return l1;
            }

            l2.next = MergeTwoLists(l1, l2.next);
            return l2;
        }

        /// <summary>
        ///     LeetCode 26. Remove Duplicates from Sorted Array
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int RemoveDuplicates(int[] nums)
        {
            if (nums.Length == 0) return 0;
            var index = 0;
            for (var i = 1; i < nums.Length; i++)
                if (nums[i] != nums[index])
                    nums[++index] = nums[i];

            return ++index;
        }

        /// <summary>
        ///     LeetCode 27. Remove Element
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public int RemoveElement(int[] nums, int val)
        {
            var index = 0;
            for (var i = 0; i < nums.Length; i++)
                if (nums[i] != val)
                    nums[index++] = nums[i];

            return index;
        }

        /// <summary>
        ///     LeetCode 83. Remove Duplicates from Sorted List
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode DeleteDuplicates(ListNode head)
        {
            if (head == null) return null;
            var tail = head;
            var current = head.next;
            while (current != null)
            {
                if (current.val == tail.val)
                    tail.next = current.next;
                else
                    tail = current;
                current = current.next;
            }

            tail.next = null;
            return head;
        }

        /// <summary>
        ///     LeetCode 101. Symmetric Tree
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public bool IsSymmetric(TreeNode root)
        {
            return root == null || IsMirror(root.left, root.right);
        }

        private static bool IsMirror(TreeNode left, TreeNode right)
        {
            if (left == null && right == null) return true;
            if (left == null || right == null) return false;
            return left.val == right.val && IsMirror(left.right, right.left) && IsMirror(left.left, right.right);
        }

        /// <summary>
        ///     LeetCode 118. Pascal's Triangle
        /// </summary>
        /// <param name="numRows"></param>
        /// <returns></returns>
        public IList<IList<int>> Generate(int numRows)
        {
            var result = new List<IList<int>>();
            if (numRows == 0) return result;
            result.Add(new List<int> {1});
            for (var i = 1; i < numRows; i++)
            {
                var previousList = result[i - 1];
                var currentList = new List<int>();
                for (var j = 0; j <= i; j++)
                {
                    var value = (j - 1 < 0 ? 0 : previousList[j - 1]) + (j >= previousList.Count ? 0 : previousList[j]);
                    currentList.Add(value);
                }

                result.Add(currentList);
            }

            return result;
        }

        /// <summary>
        ///     LeetCode 119. Pascal's Triangle II
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <returns></returns>
        public IList<int> GetRow(int rowIndex)
        {
            var list = new int[rowIndex + 1];
            list[0] = 1;
            for (var i = 1; i < rowIndex + 1; i++)
            for (var j = i; j > 0; j--)
                list[j] += list[j - 1];

            return list;
        }

        /// <summary>
        ///     LeetCode 121 Best Time to Buy and Sell Stock
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        public int MaxProfit(int[] prices)
        {
            var minPrice = int.MaxValue;
            var maxProfit = 0;
            foreach (var price in prices)
            {
                if (price < minPrice)
                    minPrice = price;
                if (price - minPrice > maxProfit)
                    maxProfit = price - minPrice;
            }

            return maxProfit;
        }

        /// <summary>
        ///     LeetCode 122. Best Time to Buy and Sell Stock II
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        public int MaxProfit2(int[] prices)
        {
            if (prices.Length == 0) return 0;
            var maxProfit = 0;
            for (var i = 1; i < prices.Length; i++)
                if (prices[i] > prices[i - 1])
                    maxProfit += prices[i] - prices[i - 1];

            return maxProfit;
        }

        /// <summary>
        ///     LeetCode 136. Single Number
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int SingleNumber(int[] nums)
        {
            return nums.Distinct().Sum() * 2 - nums.Sum();
        }

        /// <summary>
        ///     LeetCode 141. Linked List Cycle
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public bool HasCycle(ListNode head)
        {
            if (head?.next == null) return false;
            var slow = head;
            var fast = head.next;
            while (slow != fast)
            {
                if (fast?.next == null) return false;
                slow = slow.next;
                fast = fast.next.next;
            }

            return true;
        }

        /// <summary>
        ///     LeetCode 160. Intersection of Two Linked Lists
        /// </summary>
        /// <param name="headA"></param>
        /// <param name="headB"></param>
        /// <returns></returns>
        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            if (headA == null || headB == null) return null;
            var pointA = headA;
            var pointB = headB;
            ListNode tailA = null, tailB = null;
            while (pointA != pointB)
            {
                if (pointA.next == null)
                {
                    tailA = pointA;
                    pointA = headB;
                }
                else
                {
                    pointA = pointA.next;

                }

                if (pointB.next == null)
                {
                    tailB = pointB;
                    pointB = headA;
                }
                else
                {
                    pointB = pointB.next;
                }

                if (tailA != null && tailB != null && tailA != tailB) return null;
            }

            return pointA;
        }

        /// <summary>
        ///     LeetCode 198. House Robber
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int Rob(int[] nums)
        {
            switch (nums.Length)
            {
                case 0:
                    return 0;
                case 1:
                    return nums[0];
                default:
                    var dp = new int[nums.Length];
                    dp[0] = nums[0];
                    dp[1] = Math.Max(nums[0], nums[1]);
                    for (var i = 2; i < nums.Length; i++) dp[i] = Math.Max(nums[i] + dp[i - 2], dp[i - 1]);

                    return dp[nums.Length - 1];
            }
        }

        /// <summary>
        ///     LeetCode 374 Guess Number Higher or Lower
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int GuessNumber(int n)
        {
            return BinarySearch(1, n);
        }

        private static int BinarySearch(int begin, int end)
        {
            if (end < begin)
                return int.MinValue;
            while (true)
            {
                if (Guess(begin) == 0) return begin;
                if (Guess(end) == 0) return end;
                var mid = begin + (end - begin) / 2;
                var result = Guess(mid);
                switch (result)
                {
                    case 1:
                        begin = begin + 1;
                        end = mid - 1;
                        break;
                    case -1:
                        begin = mid + 1;
                        end = end - 1;
                        break;
                    case 0:
                        return mid;
                    default:
                        return int.MinValue;
                }
            }
        }

        private static int Guess(int num)
        {
            const int answer = 987;
            return num == answer ? 0 : num < answer ? -1 : 1;
        }
    }

    // ReSharper disable InconsistentNaming
    public class ListNode
    {
        public ListNode next;
        public int val;

        public ListNode(int x)
        {
            val = x;
        }
    }

    public class TreeNode
    {
        public TreeNode left;
        public TreeNode right;
        public int val;

        public TreeNode(int x)
        {
            val = x;
        }
    }
}