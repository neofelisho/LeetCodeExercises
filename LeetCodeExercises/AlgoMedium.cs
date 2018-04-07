namespace LeetCodeExercises
{
    public class AlgoMedium
    {
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