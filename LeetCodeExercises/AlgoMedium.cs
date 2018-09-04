using System;

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
        ///     LeetCode 61 Rotate List
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
    }
}