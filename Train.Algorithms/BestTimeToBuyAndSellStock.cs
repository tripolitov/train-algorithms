using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Train.Algorithms
{
    /// <summary>
    /// https://leetcode.com/problems/best-time-to-buy-and-sell-stock/
    ///
    /// Best Time to Buy and Sell Stock
    /// 
    /// Say you have an array for which the ith element
    /// is the price of a given stock on day i.
    /// If you were only permitted to complete at most
    /// one transaction(i.e., buy one and sell one share
    /// of the stock), design an algorithm to find the
    /// maximum profit.
    /// 
    /// Note that you cannot sell a stock before you buy one.
    /// 
    /// 
    /// Example 1:
    /// 
    /// 
    /// Input: [7,1,5,3,6,4]
    /// Output: 5
    /// Explanation: Buy on day 2 (price = 1) and sell on day 5 (price = 6), profit = 6-1 = 5.
    /// Not 7-1 = 6, as selling price needs to be larger than buying price.
    /// Example 2:
    /// 
    /// Input: [7,6,4,3,1]
    /// Output: 0
    /// Explanation: In this case, no transaction is done, i.e.max profit = 0.
    /// </summary>
    class BestTimeToBuyAndSellStock
    {
        [Test]
        [TestCaseSource(nameof(TestData))]
        public int MaxProfit(int[] prices)
        {
            int temp = 0, max = 0;
            for (var i = 1; i < prices.Length; i++)
            {
                temp = Math.Max(0, temp + prices[i] - prices[i - 1]);
                max = Math.Max(temp, max);
            }

            return max;
        }

        static IEnumerable<TestCaseData> TestData
        {
            get
            {
                yield return new TestCaseData(new[] { 7, 1, 5, 3, 6, 4 }).Returns(5);
                yield return new TestCaseData(new[] { 7, 6, 4, 3, 1 }).Returns(0);
            }
        }
    }
}
