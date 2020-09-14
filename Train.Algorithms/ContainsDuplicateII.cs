using System.Collections.Generic;
using NUnit.Framework;

namespace Train.Algorithms
{
    /// <summary>
    /// Contains Duplicate II
    ///
    /// https://leetcode.com/problems/contains-duplicate-ii/
    ///
    /// Given an array of integers and an integer k, find out whether
    /// there are two distinct indices i and j in the array such
    /// that nums[i] = nums[j] and the absolute difference
    /// between i and j is at most k.
    /// 
    /// Example 1:
    /// 
    /// Input: nums = [1,2,3,1], k = 3
    /// Output: true
    /// 
    /// Example 2:
    /// 
    /// Input: nums = [1,0,1,1], k = 1
    /// Output: true
    /// 
    /// Example 3:
    /// 
    /// Input: nums = [1,2,3,1,2,3], k = 2
    /// Output: false
    /// </summary>
    public class ContainsDuplicateII
    {
        [Test][TestCaseSource(nameof(TestData))]
        public bool ContainsNearbyDuplicate(int[] nums, int k)
        {
            var map = new Dictionary<int, int>();

            for (var i = 0; i < nums.Length; i++)
            {
                if (map.ContainsKey(nums[i]) 
                    && i - map[nums[i]] <= k)
                {
                    return true;
                }

                map[nums[i]] = i;
            }

            return false;
        }

        static IEnumerable<TestCaseData> TestData
        {
            get
            {
                yield return new TestCaseData(new int[] {1,2,3,1}, 3).Returns(true);
                yield return new TestCaseData(new int[] {1,0,1,1}, 1).Returns(true);
                yield return new TestCaseData(new int[] {1,2,3,1,2,3}, 2).Returns(false);
            }
        }
    }
}