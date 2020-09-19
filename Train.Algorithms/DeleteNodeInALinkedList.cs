using System.Collections.Generic;
using NUnit.Framework;

namespace Train.Algorithms
{
    /// <summary>
    /// https://leetcode.com/problems/delete-node-in-a-linked-list/
    /// 
    /// Delete Node in a Linked List
    ///
    /// Write a function to delete a node in a singly-linked list. You will not be given access to the head of the list, instead you will be given access to the node to be deleted directly.
    /// 
    /// It is guaranteed that the node to be deleted is not a tail node in the list.
    /// 
    /// 
    /// 
    /// Example 1:
    /// 
    /// 
    /// Input: head = [4,5,1,9], node = 5
    /// Output: [4,1,9]
    /// Explanation: You are given the second node with value 5, the linked list should become 4 -> 1 -> 9 after calling your function.
    /// Example 2:
    /// 
    /// 
    /// Input: head = [4,5,1,9], node = 1
    /// Output: [4,5,9]
    /// Explanation: You are given the third node with value 1, the linked list should become 4 -> 5 -> 9 after calling your function.
    /// Example 3:
    /// 
    /// Input: head = [1,2,3,4], node = 3
    /// Output: [1,2,4]
    /// Example 4:
    /// 
    /// Input: head = [0,1], node = 0
    /// Output: [1]
    /// Example 5:
    /// 
    /// Input: head = [-3,5,-99], node = -3
    /// Output: [5,-99]
    /// </summary>
    public class DeleteNodeInALinkedList
    {
        public void DeleteNode(ListNode node)
        {
            node.val = node.next.val;
            node.next = node.next.next;
        }
        
        [Test][TestCaseSource(nameof(TestData))]
        public ListNode Test(ListNode root, ListNode node) {
            DeleteNode(node);
            return root;
        }

        static IEnumerable<TestCaseData> TestData
        {
            get
            {
                ListNode head, tail;
                
                tail = new ListNode(5, new ListNode(1, new ListNode(9)));
                head = new ListNode(4, tail);
                yield return new TestCaseData(head, tail)
                    .Returns(new ListNode(4, new ListNode(1, new ListNode(9))));
                
                tail = new ListNode(1, new ListNode(9));
                head = new ListNode(4, new ListNode(5, tail));
                yield return new TestCaseData(head, tail)
                    .Returns(new ListNode(4, new ListNode(5, new ListNode(9))));
                
                tail = new ListNode(3, new ListNode(4));
                head = new ListNode(1, new ListNode(2, tail));
                yield return new TestCaseData(head, tail)
                    .Returns(new ListNode(1, new ListNode(2, new ListNode(4))));
                
                tail = new ListNode(1);
                head = new ListNode(0, tail);
                yield return new TestCaseData(head, head)
                    .Returns(new ListNode(1));
                
                tail = new ListNode(5, new ListNode(-99));
                head = new ListNode(-3, tail);
                yield return new TestCaseData(head, head)
                    .Returns(new ListNode(5, new ListNode(-99)));
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