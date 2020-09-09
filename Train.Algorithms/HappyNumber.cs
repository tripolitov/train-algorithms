using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Train.Algorithms
{
    /// <summary>
    /// https://leetcode.com/problems/happy-number/
    /// 
    /// Happy Number
    ///
    /// Write an algorithm to determine if a number n is "happy".
    /// 
    /// A happy number is a number defined by the following process:
    /// Starting with any positive integer, replace the number by the
    /// sum of the squares of its digits, and repeat the process until
    /// the number equals 1 (where it will stay), or it loops endlessly
    /// in a cycle which does not include 1. Those numbers for which this
    /// process ends in 1 are happy numbers.
    /// 
    /// Return True if n is a happy number, and False if not.
    /// 
    /// Example: 
    /// 
    /// Input: 19
    /// Output: true
    /// Explanation: 
    /// 12 + 92 = 82
    /// 82 + 22 = 68
    /// 62 + 82 = 100
    /// 12 + 02 + 02 = 1
    /// </summary>
    class HappyNumber
    {
        int sum_of_digits_squares(int number)
        {
            var result = 0;
            while (number > 0)
            {
                var digit = (number % 10);
                result += digit * digit;
                number /= 10;
            }

            return result;
        }

        [Test]
        [TestCaseSource(nameof(TestData))]
        public bool IsHappyHashSet(int n)
        {
            var hashset = new HashSet<int>();
            while (n != 1)
            {
                n = sum_of_digits_squares(n);
                if (hashset.Contains(n))
                    return false;

                hashset.Add(n);
            }

            return true;
        }

        [Test]
        [TestCaseSource(nameof(TestData))]
        public bool IsHappyFastSlow(int n)
        {
            var slow = n;
            var fast = n;
            do
            {
                slow = sum_of_digits_squares(slow);
                fast = sum_of_digits_squares(sum_of_digits_squares(fast));
            } while (fast != slow);

            return slow == 1;
        }

        static IEnumerable<TestCaseData> TestData
        {
            get
            {
                yield return new TestCaseData(1).Returns(true);
                yield return new TestCaseData(19).Returns(true);
                yield return new TestCaseData(22).Returns(false);
            }
        }
    }
}
