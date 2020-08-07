using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Train.Algorithms
{
    /// <summary>
    /// https://leetcode.com/problems/merge-two-sorted-lists/
    /// 
    /// Merge two sorted linked lists and return it as a new sorted list.
    /// The new list should be made by splicing together the nodes of the
    /// first two lists.
    ///
    /// Example:
    ///
    /// Input: 1->2->4, 1->3->4
    /// Output: 1->1->2->3->4->4
    /// </summary>
    class MergeTwoSortedLists
    {
        [Test]
        [TestCaseSource(nameof(TestData))]
        public ListNode Recursive(ListNode l1, ListNode l2)
        {
            if (l1 == null) return l2;
            if (l2 == null) return l1;

            return l1.val <= l2.val 
                ? new ListNode(l1.val, Recursive(l1.next, l2)) 
                : new ListNode(l2.val, Recursive(l1, l2.next));
        }

        [Test]
        [TestCaseSource(nameof(TestData))]
        public ListNode Iterative(ListNode l1, ListNode l2)
        {
            ListNode result = new ListNode();
            ListNode head = result;
            while (l1 != null && l2 != null)
            {
                if (l1.val <= l2.val)
                {
                    head.next = new ListNode(l1.val);
                    head = head.next;
                    l1 = l1.next;
                }
                else
                {
                    head.next = new ListNode(l2.val);
                    head = head.next;
                    l2 = l2.next;
                }
            }

            if (l1 == null)
                head.next = l2;
            if (l2 == null)
                head.next = l1;

            return result.next;
        }


        public static IEnumerable<TestCaseData> TestData
        {
            get
            {
                yield return new TestCaseData(
                    new ListNode(1, new ListNode(2, new ListNode(4))),
                    new ListNode(1, new ListNode(3, new ListNode(4)))
                ).Returns(new ListNode(1, new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(4)))))));

                yield return new TestCaseData(
                    new ListNode(1, new ListNode(2, new ListNode(3))),
                    new ListNode(4, new ListNode(5, new ListNode(6)))
                ).Returns(new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5, new ListNode(6)))))));

                yield return new TestCaseData(
                    new ListNode(4, new ListNode(5, new ListNode(6))),
                    new ListNode(1, new ListNode(2, new ListNode(3)))
                ).Returns(new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5, new ListNode(6)))))));
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
                return Equals((ListNode) obj);
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
