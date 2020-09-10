using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Train.Algorithms
{
    /// <summary>
    ///https://leetcode.com/problems/remove-linked-list-elements/
    /// 
    /// Remove Linked List Elements
    ///
    /// Remove all elements from a linked list of integers that have value val.
    ///
    /// Example:
    /// 
    /// Input:  1->2->6->3->4->5->6, val = 6
    /// Output: 1->2->3->4->5
    /// </summary>
    class RemoveLinkedListElements
    {
        [Test]
        [TestCaseSource(nameof(TestData))]
        public ListNode RemoveElements(ListNode head, int val)
        {
            while (head != null && head.val == val)
            {
                head = head.next;
            }

            var current = head;

            while (current?.next != null)
            {
                if (current.next.val == val)
                    current.next = current.next.next;
                else
                    current = current.next;
            }

            return head;
        }

        [Test]
        [TestCaseSource(nameof(TestData))]
        public ListNode RemoveElementsRecursive(ListNode head, int val)
        {
            if (head == null) return null;
            head.next = RemoveElementsRecursive(head.next, val);
            return head.val == val
                ? head.next
                : head;

        }

        static IEnumerable<TestCaseData> TestData
        {
            get
            {
                yield return new TestCaseData(new ListNode(), 1).Returns(new ListNode());
                yield return new TestCaseData(new ListNode(1), 1).Returns(null);
                yield return new TestCaseData(new ListNode(1, new ListNode(1, new ListNode(1, new ListNode(2)))), 1).Returns(new ListNode(2));
                yield return new TestCaseData(new ListNode(1, new ListNode(2, new ListNode(1, new ListNode(1)))), 1).Returns(new ListNode(2));
                yield return new TestCaseData(new ListNode(2, new ListNode(1, new ListNode(1, new ListNode(1)))), 1).Returns(new ListNode(2));
                yield return new TestCaseData(new ListNode(1, new ListNode(2)), 1).Returns(new ListNode(2));
                yield return new TestCaseData(
                        new ListNode(1
                            , new ListNode(2
                                , new ListNode(3
                                    , new ListNode(4
                                        , new ListNode(5
                                            , new ListNode(6)))))), 6)
                    .Returns(new ListNode(1
                        , new ListNode(2
                            , new ListNode(3
                                , new ListNode(4
                                    , new ListNode(5))))));
                ;
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
                var sb = new StringBuilder(val.ToString());

                if (next != null)
                    sb.Append(" -> ").Append(next);
                        
                return sb.ToString();
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
                return HashCode.Combine(val, next);
            }
        }
    }
}
