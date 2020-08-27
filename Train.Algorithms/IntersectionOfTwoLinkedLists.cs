using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Train.Algorithms
{
    /// <summary>
    /// https://leetcode.com/problems/intersection-of-two-linked-lists/
    ///
    /// Intersection of Two Linked Lists
    /// 
    /// Write a program to find the node at which the intersection of two singly linked lists begins.
    /// </summary>
    class IntersectionOfTwoLinkedLists
    {
        [Test]
        [TestCaseSource(nameof(TestData))]
        public ListNode GetIntersectionNode_Stack(ListNode headA, ListNode headB)
        {
            Stack<ListNode> f(ListNode n)
            {
                var stack = new Stack<ListNode>();
                while (n != null)
                {
                    stack.Push(n);
                    n = n.next;
                }

                return stack;
            }

            var stackA = f(headA);
            var stackB = f(headB);

            ListNode result = null;
            while (stackA.Count > 0 && stackB.Count > 0)
            {
                var a = stackA.Pop();
                var b = stackB.Pop();
                if (a != b) return result;

                result = a;
            }

            return result;
        }

        [Test]
        [TestCaseSource(nameof(TestData))]
        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            ListNode a = headA, b = headB;

            while (a != b)
            {
                a = a == null ? headB : a.next;
                b = b == null ? headA : b.next;
            }

            return a;
        }

        public static IEnumerable<TestCaseData> TestData
        {
            get
            {
                var i1 = new ListNode(8, new ListNode(4, new ListNode(5)));
                var a1 = new ListNode(4, new ListNode(1, i1));
                var b1 = new ListNode(5, new ListNode(6, new ListNode(1, i1)));
                yield return new TestCaseData(a1, b1).Returns(i1);

                var i2 = new ListNode(2, new ListNode(4));
                
                var a2 = new ListNode(1, new ListNode(9, new ListNode(1, i2)));
                var b2 = new ListNode(3, i2);
                yield return new TestCaseData(a2, b2).Returns(i2);

                var a3 = new ListNode(2, new ListNode(6, new ListNode(4)));
                var b3 = new ListNode(1, new ListNode(5));
                yield return new TestCaseData(a3, b3).Returns(null);
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
        }

    }
}
