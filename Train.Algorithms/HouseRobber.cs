using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Train.Algorithms
{
    /// <summary>
    /// https://leetcode.com/problems/house-robber/
    ///
    /// House Robber
    ///
    /// You are a professional robber planning to rob houses along a street.
    /// Each house has a certain amount of money stashed, the only constraint
    /// stopping you from robbing each of them is that adjacent houses have
    /// security system connected and it will automatically contact the police
    /// if two adjacent houses were broken into on the same night.
    /// 
    /// Given a list of non-negative integers representing the amount of money
    /// of each house, determine the maximum amount of money you can rob tonight
    /// without alerting the police.
    /// 
    /// Example 1:
    /// 
    /// Input: nums = [1,2,3,1]
    /// Output: 4
    /// Explanation: Rob house 1 (money = 1) and then rob house 3 (money = 3).
    /// Total amount you can rob = 1 + 3 = 4.
    ///
    /// Example 2:
    /// 
    /// Input: nums = [2,7,9,3,1]
    /// Output: 12
    /// Explanation: Rob house 1 (money = 2), rob house 3 (money = 9) and rob house 5 (money = 1).
    /// Total amount you can rob = 2 + 9 + 1 = 12.
    /// </summary>
    class HouseRobber
    {
        [Test]
        [TestCaseSource(nameof(TestData))]
        public int Rob(int[] nums)
        {
            int rob(IDictionary<int, int> memo, int[] hs, int i)
            {
                if (i < 0) return 0;
                if (memo.ContainsKey(i)) return memo[i];

                var a = hs[i] + rob(memo, hs, i - 2);
                var b = rob(memo, hs, i - 1);

                memo[i] = Math.Max(a, b);
                return memo[i];
            }

            return rob(new Dictionary<int, int>(nums.Length), nums, nums.Length - 1);
        }

        [Test]
        [TestCaseSource(nameof(TestData))]
        public int RobIterative(int[] nums)
        {
            var robbedPrev = 0;
            var notRobbedPrev = 0;

            foreach (var num in nums)
            {
                var robbedCurrent = notRobbedPrev + num;
                var notRobbedCurrent = Math.Max(robbedPrev, notRobbedPrev);

                robbedPrev = robbedCurrent;
                notRobbedPrev = notRobbedCurrent;
            }

            return Math.Max(robbedPrev, notRobbedPrev);
        }

        static IEnumerable<TestCaseData> TestData
        {
            get
            {
                yield return new TestCaseData(new int[] { 1, 1 }).Returns(1);
                yield return new TestCaseData(new int[] { 2, 1 }).Returns(2);
                yield return new TestCaseData(new int[] { 1, 2 }).Returns(2);
                yield return new TestCaseData(new int[] { 1, 1, 1 }).Returns(2);
                yield return new TestCaseData(new int[] { 9, 0, 0, 9 }).Returns(18);
                yield return new TestCaseData(new int[] { 1, 2, 3, 1 }).Returns(4);
                yield return new TestCaseData(new int[] { 2, 7, 9, 3, 1 }).Returns(12);
                yield return new TestCaseData(new int[] { 114, 117, 207, 117, 235, 82, 90, 67, 143, 146, 53, 108, 200, 91, 80, 223, 58, 170, 110, 236, 81, 90, 222, 160, 165, 195, 187, 199, 114, 235, 197, 187, 69, 129, 64, 214, 228, 78, 188, 67, 205, 94, 205, 169, 241, 202, 144, 240 }).Returns(4173);
                yield return new TestCaseData(new int[100]).Returns(0);
            }
        }
    }
}
