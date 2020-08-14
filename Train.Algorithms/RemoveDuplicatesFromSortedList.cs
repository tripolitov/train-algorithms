using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Train.Algorithms
{
    /// <summary>
    /// Given a sorted linked list, delete all
    /// duplicates such that each element appear
    /// only once.

    /// Example 1: 
    /// Input: 1->1->2
    /// Output: 1->2
    /// 
    /// Example 2: 
    /// Input: 1->1->2->3->3
    /// Output: 1->2->3
    /// 
    /// </summary>
    class RemoveDuplicatesFromSortedList
    {
        [Test]
        [TestCaseSource(nameof(TestData))]
        public ListNode RemoveDuplicatesIterative(ListNode head)
        {
            var result = head;
            while (head != null && head.next != null)
            {
                if (head.val == head.next.val)
                    head.next = head.next.next;
                else 
                    head = head.next;
            }

            return result;
        }

        [Test]
        [TestCaseSource(nameof(TestData))]
        public ListNode RemoveDuplicatesRecursive(ListNode head)
        {
            if (head == null || head.next == null)
                return head;

            head.next = RemoveDuplicatesRecursive(head.next);

            return head.val != head.next.val
                ? head
                : head.next;
        }

        public static IEnumerable<TestCaseData> TestData
        {
            get
            {
                yield return new TestCaseData(null)
                    .Returns(null);

                yield return new TestCaseData(new ListNode(1))
                    .Returns(new ListNode(1));

                yield return new TestCaseData(new ListNode(1, new ListNode(1, new ListNode(1))))
                    .Returns(new ListNode(1));

                yield return new TestCaseData(new ListNode(1, new ListNode(1, new ListNode(2))))
                    .Returns(new ListNode(1, new ListNode(2)));

                yield return new TestCaseData(new ListNode(1, new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(3))))))
                    .Returns(new ListNode(1, new ListNode(2, new ListNode(3))));
            }

        }


        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }

            public override string ToString()
            {
                return next != null ? $"{val} -> {next}" : val.ToString();
            }

            protected bool Equals(ListNode other)
            {
                return val == other.val && Equals(next, other.next);
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                if (obj.GetType() != this.GetType()) return false;
                return Equals((ListNode)obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    return (val * 397) ^ (next != null ? next.GetHashCode() : 0);
                }
            }
        }
    }
}
