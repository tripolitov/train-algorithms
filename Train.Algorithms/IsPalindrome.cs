using System.Collections.Generic;
using NUnit.Framework;

namespace Train.Algorithms
{
    public class IsPalindrome
    {
        int reverse(int n)
        {
            int rn = 0;
            while (n > 0)
            {
                rn = rn * 10 + n % 10;
                n /= 10;
            }
            return rn; ;
        }

        [Test]
        [TestCaseSource("TestInput")]
        public bool solution_imperative(int n)
        {
            if (n < 0) return false;

            var r = reverse(n);
            while (n > 0)
            {
                if (n % 10 != r % 10) return false;

                n /= 10;
                r /= 10;
            }

            return true;
        }

        [Test]
        [TestCaseSource("TestInput")]
        public bool solution_recursive(int n)
        {
            bool f(int a, ref int b)
            {
                if (a >= 0 && a < 10)
                {
                    return a == b % 10;
                }

                if (!f(a / 10, ref b))
                    return false;

                b /= 10;
                return a % 10 == b % 10;
            }

            if (n < 0) return false;

            var r = n;
            return f(n, ref r);
        }

        public static IEnumerable<TestCaseData> TestInput
        {
            get
            {
                yield return new TestCaseData(-121).Returns(false);
                yield return new TestCaseData(12).Returns(false);
                yield return new TestCaseData(123).Returns(false);
                yield return new TestCaseData(121).Returns(true);
                yield return new TestCaseData(1221).Returns(true);
                yield return new TestCaseData(12321).Returns(true);
                yield return new TestCaseData(123321).Returns(true);
                yield return new TestCaseData(1235321).Returns(true);
                yield return new TestCaseData(12356321).Returns(false);
                
            }
        }
    }
}