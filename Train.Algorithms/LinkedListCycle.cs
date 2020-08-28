using System.Collections.Generic;
using NUnit.Framework;

namespace Train.Algorithms
{

    /// <summary>
    /// https://leetcode.com/problems/linked-list-cycle/
    ///
    /// Linked List Cycle
    ///
    /// Given a linked list, determine if it has a cycle in it.
    /// 
    /// To represent a cycle in the given linked list, we use
    /// an integer pos which represents the position(0-indexed)
    /// in the linked list where tail connects to.If pos is -1,
    /// then there is no cycle in the linked list.
    /// </summary>
    class LinkedListCycle
    {
        [Test]
        [TestCaseSource(nameof(TestData))]
        public bool HasCycle(ListNode head)
        {
            if (head == null || head.next == null) return false;

            var a = head;
            var b = head.next;
            while (a != null && b != null && b.next != null)
            {
                a = a.next;
                b = b.next.next;

                if (a == b) return true;
            }

            return false;
        }

        static IEnumerable<TestCaseData> TestData 
        {
            get
            {
                yield return new TestCaseData(new ListNode(1)).Returns(false).SetName("Single Node");
                yield return new TestCaseData(new ListNode(1, new ListNode(2))).Returns(false).SetName("Two Nodes without cycle");
                {
                    ListNode l1 = new ListNode(3), l2 = new ListNode(2), l3 = new ListNode(0), l4 = new ListNode(4);
                    l1.next = l2;
                    l2.next = l3;
                    l3.next = l4;
                    l4.next = l2;

                    yield return new TestCaseData(l1).Returns(true).SetName("Four Nodes with cycle"); ;
                }
                {
                    ListNode l1 = new ListNode(3), l2 = new ListNode(2);
                    l1.next = l2;
                    l2.next = l1;

                    yield return new TestCaseData(l1).Returns(true).SetName("Two Nodes with cycle"); ;
                }
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
        }
    }
}
