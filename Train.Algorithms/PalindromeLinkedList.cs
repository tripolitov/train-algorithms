using System.Collections.Generic;
using NUnit.Framework;

namespace Train.Algorithms
{
    public class PalindromeLinkedList
    {
        static Stack<ListNode> BuildStack(ListNode head)
        {
            var result = new Stack<ListNode>();
            while (head != null)
            {
                result.Push(head);
                head = head.next;
            }

            return result;
        }

        [Test]
        [TestCaseSource(nameof(TestData))]
        public bool IsPalindrome(ListNode head)
        {
            var stack = BuildStack(head);
            while (head != null)
            {
                if (head.val != stack.Pop().val)
                    return false;
                head = head.next;
            }

            return true;
        }

        static IEnumerable<TestCaseData> TestData
        {
            get
            {
                yield return new TestCaseData(new ListNode(1))
                    .Returns(true);
                yield return new TestCaseData(new ListNode(1, new ListNode(2)))
                    .Returns(false);
                yield return new TestCaseData(new ListNode(1, new ListNode(2, new ListNode(1))))
                    .Returns(true);
                yield return new TestCaseData(new ListNode(1, new ListNode(2, new ListNode(2))))
                    .Returns(false);
                yield return new TestCaseData(new ListNode(1, new ListNode(2, new ListNode(2, new ListNode(1)))))
                    .Returns(true);
            }
        }
        
        public class ListNode
        {
            public int val;
            public ListNode next;

            public ListNode(int x)
            {
                val = x;
                next = null;
            }

            public ListNode(int x, ListNode next)
            {
                val = x;
                this.next = next;
            }

            public override string ToString()
            {
                return $"{val}" + (next != null ? $"->{next}" : "");
            }
        }

    }
}