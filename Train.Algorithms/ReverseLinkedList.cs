using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Train.Algorithms
{
    /// <summary>
    /// https://leetcode.com/problems/reverse-linked-list/
    ///
    /// Reverse Linked List
    /// 
    /// Reverse a singly linked list.
    ///
    /// Example:
    ///
    /// Input: 1->2->3->4->5->NULL
    /// Output: 5->4->3->2->1->NULL
    /// 
    /// Follow up:
    ///
    /// A linked list can be reversed either iteratively or recursively. Could you implement both?
    /// </summary>
    public class ReverseLinkedList
    {
        [Test]
        [TestCaseSource(nameof(TestData))]
        public ListNode Recursive(ListNode input)
        {
            ListNode rec(ListNode head, ListNode tail)
            {
                if (head == null) return tail;

                var next = head.next;
                head.next = tail;
                return rec(next, head);
            }

            return rec(input, null);
        }

        [Test]
        [TestCaseSource(nameof(TestData))]
        public ListNode Iterative(ListNode head)
        {
            ListNode tail = null;
            while (head != null)
            {
                var next = head.next;

                head.next = tail;
                tail = head;
                
                head = next;
            }

            return tail;
        }

        [Test]
        [TestCaseSource(nameof(TestData))]
        public ListNode Stack(ListNode head)
        {
            if (head == null) return null;
            
            var stack = new Stack<ListNode>();

            while (head != null)
            {
                stack.Push(head);
                head = head.next;
            }

            var result = stack.Pop();
            head = result;
            while (stack.Count > 0)
            {
                head.next = stack.Pop();
                head = head.next;
                head.next = null;
            }
             
            return result;
        }

        static IEnumerable<TestCaseData> TestData
        {
            get
            {
                yield return new TestCaseData(null).Returns(null);
                yield return new TestCaseData(new ListNode(1)).Returns(new ListNode(1));
                yield return new TestCaseData(new ListNode(1, new ListNode(2))).Returns(new ListNode(2,new ListNode(1)));
                yield return new TestCaseData(new ListNode(1, new ListNode(2, new ListNode(3))))
                    .Returns(new ListNode(3, new ListNode(2,new ListNode(1))));
                yield return new TestCaseData(new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4)))))
                    .Returns(new ListNode(4, new ListNode(3, new ListNode(2,new ListNode(1)))));
            }
        }

        public class ListNode {
             public int val;
             public ListNode next;
             public ListNode(int val=0, ListNode next=null) {
                 this.val = val;
                 this.next = next;
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

             public override string ToString()
             {
                 return $"{val} -> {next?.ToString() ?? "null"}";
             }
         }
    }
}