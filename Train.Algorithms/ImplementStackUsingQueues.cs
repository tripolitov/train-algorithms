using System.Collections.Generic;
using NUnit.Framework;

namespace Train.Algorithms
{
    /// <summary>
    /// Implement Stack using Queues
    /// 
    /// https://leetcode.com/problems/implement-stack-using-queues/
    ///
    /// Implement the following operations of a stack using queues.
    /// 
    /// push(x) -- Push element x onto stack.
    /// pop() -- Removes the element on top of the stack.
    /// top() -- Get the top element.
    /// empty() -- Return whether the stack is empty.
    /// Example:
    /// 
    /// MyStack stack = new MyStack();
    /// 
    /// stack.push(1);
    /// stack.push(2);  
    /// stack.top();   // returns 2
    /// stack.pop();   // returns 2
    /// stack.empty(); // returns false
    /// Notes:
    /// 
    /// You must use only standard operations of a queue -- which means only push to back, peek/pop from front, size, and is empty operations are valid.
    /// Depending on your language, queue may not be supported natively. You may simulate a queue by using a list or deque (double-ended queue), as long as you use only standard operations of a queue.
    ///     You may assume that all operations are valid (for example, no pop or top operations will be called on an empty stack).
    /// </summary>
    public class ImplementStackUsingQueues
    {
        class MyStack
        {
            private Queue<int> _queue = new Queue<int>();
            public MyStack() {
        
            }
    
            /** Push element x onto stack. */
            public void Push(int x)
            {
                _queue.Enqueue(x);
                for(var i = 0; i < _queue.Count - 1; i++)
                    _queue.Enqueue(_queue.Dequeue());
            }
    
            /** Removes the element on top of the stack and returns that element. */
            public int Pop()
            {
                return _queue.Dequeue();
            }
    
            /** Get the top element. */
            public int Top()
            {
                return _queue.Peek();
            }
    
            /** Returns whether the stack is empty. */
            public bool Empty()
            {
                return _queue.Count == 0;
            }   
        }

        [Test]
        public void Test()
        {
            var sut = new MyStack();
            sut.Push(1);
            sut.Push(2);
            Assert.AreEqual(2, sut.Top());
            Assert.AreEqual(2, sut.Pop());
            Assert.IsFalse(sut.Empty());
        }
    }
}