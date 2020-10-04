using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using NUnit.Framework;

namespace Train.Algorithms
{
    /// <summary>
    /// https://leetcode.com/problems/binary-watch/
    /// 
    /// Binary Watch
    ///
    /// A binary watch has 4 LEDs on the top which represent the hours (0-11), and the 6 LEDs on the bottom represent
    /// the minutes (0-59).
    /// 
    /// Each LED represents a zero or one, with the least significant bit on the right.
    /// 
    /// For example, the above binary watch reads "3:25".
    /// 
    /// Given a non-negative integer n which represents the number of LEDs that are currently on, return all possible
    /// times the watch could represent.
    /// 
    /// Example:
    /// 
    /// Input: n = 1
    /// Return: ["1:00", "2:00", "4:00", "8:00", "0:01", "0:02", "0:04", "0:08", "0:16", "0:32"]
    /// Note:
    /// The order of output does not matter.
    /// The hour must not contain a leading zero, for example "01:00" is not valid, it should be "1:00".
    /// The minute must be consist of two digits and may contain a leading zero, for example "10:2" is not valid, it
    /// should be "10:02".
    /// </summary>
    public class BinaryWatch
    {
        private IList<string> ReadBinaryWatch(int num)
        {
            var hoursLeds = new int[] {8, 4, 2, 1};
            var minutesLeds = new int[] {32, 16, 8, 4, 2, 1};

            var result = new List<string>();
            for (var i = 0; i <= num; i++)
            {
                var hours = generate(hoursLeds, i);
                var minutes = generate(minutesLeds, num - i);

                foreach (var hour in hours)
                {
                    if (hour > 11) continue;
                    foreach (var minute in minutes)
                    {
                        if (minute > 59) continue;

                        result.Add($"{hour}:{minute:00}");
                    }

                }
            }

            return result;
        }

        IList<int> generate(IList<int> leds, int n)
        {
            void rec(IList<int> list, int count, int pos, int sum, IList<int> results)
            {
                if (count == 0)
                {
                    results.Add(sum);
                    return;
                }

                for (var i = pos; i < list.Count; i++)
                {
                    rec(list, count - 1, i + 1, sum + list[i], results);
                }
            }

            IList<int> result = new Collection<int>();
            rec(leds, n, 0, 0, result);
            return result;
        }

        [Test]
        [TestCaseSource(nameof(TestData))]
        public void ReadBinaryWatchTest(int n, IList<string> expected)
        {
            var actual = ReadBinaryWatch(n);
            CollectionAssert.AreEquivalent(expected, actual);
        }

        private IList<string> ReadBinaryWatchBits(int num)
        {
            var result = new List<string>();
            for (byte h = 0; h < 12; h++)
            for (byte m = 0; m < 60; m++)
                if (CountBits((ushort) (h << 8 | m)) == num)
                    result.Add($"{h}:{m:00}");

            return result;
        }

        private static int CountBits(ushort n)
        {
            var count = 0;
            for (; n > 0; n >>= 1)
                count += n & 1;
            return count;
        }

        [Test]
        [TestCaseSource(nameof(TestData))]
        public void ReadBinaryWatchBitsTest(int n, IList<string> expected)
        {
            var actual = ReadBinaryWatchBits(n);
            CollectionAssert.AreEquivalent(expected, actual);
        }
        

        static IEnumerable<TestCaseData> TestData
        {
            get
            {
                yield return new TestCaseData(0, new string[] {"0:00"});
                yield return new TestCaseData(1,
                    new[] {"1:00", "2:00", "4:00", "8:00", "0:01", "0:02", "0:04", "0:08", "0:16", "0:32"});
            }
        }
    }
}