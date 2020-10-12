using System.Collections.Generic;
using NUnit.Framework;

namespace Train.Algorithms
{
    /// <summary>
    /// https://leetcode.com/problems/find-all-numbers-disappeared-in-an-array/
    /// 
    /// Find All Numbers Disappeared in an Array
    ///
    /// Given an array of integers where 1 ≤ a[i] ≤ n (n = size of array), some elements appear twice and others appear once.
    ///
    /// Find all the elements of [1, n] inclusive that do not appear in this array.
    ///
    /// Could you do it without extra space and in O(n) runtime? You may assume the returned list does not count as extra space.
    ///
    /// Example:
    ///
    /// Input:
    /// [4,3,2,7,8,2,3,1]
    ///
    /// Output:
    /// [5,6]
    /// </summary>
    public class FindAllNumbersDisappearedInAnArray
    {
        [Test][TestCaseSource(nameof(TestData))]
        public IList<int> FindDisappearedNumbers(int[] nums)
        {
            var counts = new int[nums.Length + 1];

            for (var i = 0; i < nums.Length; i++)
            {
                counts[nums[i]] += 1;
            }

            var result = new List<int>();
            for (var i = 1; i < counts.Length; i++)
            {
                if (counts[i] == 0)
                    result.Add(i);
            }

            return result;
        }

        [Test]
        [TestCaseSource(nameof(TestData))]
        public IList<int> FindDisappearedNumbers_Linear(int[] nums)
        {
            foreach (var i in nums)
            {
                var j = (i > 0 ? i : -i) - 1;
                nums[j] = nums[j] > 0 ? -nums[j] : nums[j];
            }

            var result = new List<int>();
            for (var i = 0; i < nums.Length; i++)
                if (nums[i] > 0)
                    result.Add(i + 1);
            return result;
        }

        static IEnumerable<TestCaseData> TestData
        {
            get
            {
                yield return new TestCaseData(new int[] {1,2,3}).Returns(new int[0]);
                yield return new TestCaseData(new int[] {1,1,1}).Returns(new int[]{2,3});
                yield return new TestCaseData(new int[] {1,1,2}).Returns(new int[]{3});
                yield return new TestCaseData(new int[] {3,2,2}).Returns(new int[]{1});
                yield return new TestCaseData(new int[] {4, 3, 2, 7, 8, 2, 3, 1}).Returns(new int[]{5, 6});
            }
        }
    }
}