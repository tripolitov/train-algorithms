using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Train.Algorithms
{
    /// <summary>
    /// https://leetcode.com/problems/min-stack/
    /// 
    /// Min Stack
    ///
    /// Design a stack that supports push, pop, top,
    /// and retrieving the minimum element in constant time.
    /// 
    /// push(x) -- Push element x onto stack.
    /// pop() -- Removes the element on top of the stack.
    /// top() -- Get the top element.
    /// getMin() -- Retrieve the minimum element in the stack.
    /// 
    /// Example 1:
    /// 
    /// Input
    /// ["MinStack", "push", "push", "push", "getMin", "pop", "top", "getMin"]
    /// [[], [-2], [0], [-3], [], [], [], []]
    /// 
    /// Output
    /// [null, null, null, null, -3, null, 0, -2]
    /// 
    /// Explanation
    /// MinStack minStack = new MinStack();
    /// minStack.push(-2);
    /// minStack.push(0);
    /// minStack.push(-3);
    /// minStack.getMin(); // return -3
    /// minStack.pop();
    /// minStack.top();    // return 0
    /// minStack.getMin(); // return -2
    ///
    /// Constraints:
    /// Methods pop, top and getMin operations will always be called on non-empty stacks.
    /// </summary>
    class MinStackProblem
    {
        [Test]
        public void Test()
        {
            var sut = new MinStack();
            sut.Push(-2);
            sut.Push(0);
            sut.Push(-3);
            Assert.AreEqual(-3, sut.GetMin());
            sut.Pop();
            Assert.AreEqual(-2, sut.GetMin());
            Assert.AreEqual(0, sut.Top());
        }

        public class MinStack
        {
            class Node
            {
                public int val;
                public int min;
                public Node next;
            }


            Node head = null;
            public MinStack()
            {
                
            }

            public void Push(int x)
            {
                head = new Node()
                {
                    val = x,
                    min = head == null ? x : x < head.min ? x : head.min, 
                    next = head
                };
            }

            public void Pop()
            {
                head = head.next;
            }

            public int Top()
            {
                return head.val;
            }

            public int GetMin()
            {
                return head.min;
            }
        }
    }
}
