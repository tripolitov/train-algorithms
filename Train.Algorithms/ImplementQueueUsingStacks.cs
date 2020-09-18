using System.Collections.Generic;
using NUnit.Framework;

namespace Train.Algorithms
{
    /// <summary>
    /// Implement Queue using Stacks
    ///
    /// Implement the following operations of a queue using stacks.
    ///
    /// push(x) -- Push element x to the back of queue.
    /// pop() -- Removes the element from in front of queue.
    /// peek() -- Get the front element.
    /// empty() -- Return whether the queue is empty.
    /// 
    /// Example:
    ///
    /// MyQueue queue = new MyQueue();
    ///
    /// queue.push(1);
    /// queue.push(2);  
    /// queue.peek();  // returns 1
    /// queue.pop();   // returns 1
    /// queue.empty(); // returns false
    /// Notes:
    ///
    /// You must use only standard operations of a stack -- which means only push to top, peek/pop from top, size, and is empty operations are valid.
    /// Depending on your language, stack may not be supported natively. You may simulate a stack by using a list or deque (double-ended queue), as long as you use only standard operations of a stack.
    ///     You may assume that all operations are valid (for example, no pop or peek operations will be called on an empty queue).
    /// </summary>
    public class ImplementQueueUsingStacks
    {
        public class MyQueue
        {

            Stack<int> _stack = new Stack<int>();

            /** Initialize your data structure here. */
            public MyQueue()
            {

            }

            /** Push element x to the back of queue. */
            public void Push(int x)
            {
                var temp = new Stack<int>();

                while (_stack.Count > 0)
                {
                    temp.Push(_stack.Pop());
                }

                _stack.Push(x);

                while (temp.Count > 0)
                {
                    _stack.Push(temp.Pop());
                }
            }

            /** Removes the element from in front of queue and returns that element. */
            public int Pop()
            {
                return _stack.Pop();
            }

            /** Get the front element. */
            public int Peek()
            {
                return _stack.Peek();
            }

            /** Returns whether the queue is empty. */
            public bool Empty()
            {
                return _stack.Count == 0;
            }
        }

        [Test]
        public void Test()
        {
            var sut = new MyQueue();
            sut.Push(1);
            sut.Push(2);
            Assert.AreEqual(1, sut.Peek());
            Assert.AreEqual(1, sut.Pop());
            Assert.IsFalse(sut.Empty());
        }
    }
}