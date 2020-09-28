using System.Collections.Generic;
using NUnit.Framework;

namespace Train.Algorithms
{
    /// <summary>
    /// https://leetcode.com/problems/valid-perfect-square/
    /// 
    /// Valid Perfect Square
    ///
    /// Given a positive integer num, write a function which returns True if num is a perfect square else False.
    ///
    /// Follow up: Do not use any built-in library function such as sqrt.
    /// </summary>
    public class ValidPerfectSquare
    {
        [Test][TestCaseSource(nameof(TestData))]
        public bool IsPerfectSquare(int num) {
            if(num == 1) return true;
        
            long left = 1, right = num;
            while(left <= right) {
                var mid = left + (right - left) / 2;
            
                var candidate = mid * mid;            
                if(candidate > num) right = mid - 1;
                if(candidate < num) left = mid + 1;
                if(candidate == num) return true;
            }
            return false;
        }

        static IEnumerable<TestCaseData> TestData
        {
            get
            {
                yield return new TestCaseData(1).Returns(true);
                yield return new TestCaseData(3).Returns(false);
                yield return new TestCaseData(4).Returns(true);
                yield return new TestCaseData(14).Returns(false);
                yield return new TestCaseData(16).Returns(true);
                yield return new TestCaseData(64).Returns(true);
                yield return new TestCaseData(81).Returns(true);
                yield return new TestCaseData(100).Returns(true);
                yield return new TestCaseData(121).Returns(true);
                yield return new TestCaseData(256).Returns(true);
                yield return new TestCaseData(257).Returns(false);
                yield return new TestCaseData(500).Returns(false);
                yield return new TestCaseData(525).Returns(false);
                yield return new TestCaseData(808201).Returns(true);
                yield return new TestCaseData(2147483647).Returns(false);
            }
        }
    }
}