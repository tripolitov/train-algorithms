using System.Collections.Generic;
using NUnit.Framework;

namespace Train.Algorithms
{
    public class FizzBuzzSolution
    {
        [Test][TestCaseSource(nameof(TestData))]
        public IList<string> FizzBuzz(int n) {
            var result = new List<string>();
            for(var i = 1; i <= n; i++) {
                if (i % 3 == 0 && i % 5 == 0) result.Add("FizzBuzz");
                else if(i % 3 == 0) result.Add("Fizz");
                else if(i % 5 == 0) result.Add("Buzz");
                else result.Add(i.ToString());
            }
            return result;
        }

        static IEnumerable<TestCaseData> TestData
        {
            get
            {
                yield return new TestCaseData(0).Returns(new string[0]);
                yield return new TestCaseData(1).Returns(new []{"1"});
                yield return new TestCaseData(2).Returns(new []{"1","2"});
                yield return new TestCaseData(3).Returns(new []{"1","2", "Fizz"});
                yield return new TestCaseData(4).Returns(new []{"1","2", "Fizz", "4"});
                yield return new TestCaseData(5).Returns(new []{"1","2", "Fizz", "4", "Buzz"});
                yield return new TestCaseData(6).Returns(new []{"1","2", "Fizz", "4", "Buzz", "Fizz"});
                yield return new TestCaseData(7).Returns(new []{"1","2", "Fizz", "4", "Buzz", "Fizz", "7"});
                yield return new TestCaseData(8).Returns(new []{"1","2", "Fizz", "4", "Buzz", "Fizz", "7", "8"});
                yield return new TestCaseData(9).Returns(new []{"1","2", "Fizz", "4", "Buzz", "Fizz", "7", "8", "Fizz"});
                yield return new TestCaseData(10).Returns(new []{"1","2", "Fizz", "4", "Buzz", "Fizz", "7", "8", "Fizz", "Buzz"});
                yield return new TestCaseData(11).Returns(new []{"1","2", "Fizz", "4", "Buzz", "Fizz", "7", "8", "Fizz", "Buzz", "11"});
                yield return new TestCaseData(12).Returns(new []{"1","2", "Fizz", "4", "Buzz", "Fizz", "7", "8", "Fizz", "Buzz", "11", "Fizz"});
                yield return new TestCaseData(13).Returns(new []{"1","2", "Fizz", "4", "Buzz", "Fizz", "7", "8", "Fizz", "Buzz", "11", "Fizz", "13"});
                yield return new TestCaseData(14).Returns(new []{"1","2", "Fizz", "4", "Buzz", "Fizz", "7", "8", "Fizz", "Buzz", "11", "Fizz", "13", "14"});
                yield return new TestCaseData(15).Returns(new []{"1","2", "Fizz", "4", "Buzz", "Fizz", "7", "8", "Fizz", "Buzz", "11", "Fizz", "13", "14", "FizzBuzz"});
            }
        }
    }
}