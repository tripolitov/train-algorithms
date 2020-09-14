using System.Collections.Generic;
using NUnit.Framework;

namespace Train.Algorithms
{
    /// <summary>
    /// Contains Duplicate
    ///
    /// https://leetcode.com/problems/contains-duplicate/
    ///
    /// Given an array of integers, find if the array contains any duplicates.
    /// 
    /// Your function should return true if any value appears at least twice in the array, and it should return false if every element is distinct.
    /// 
    /// Example 1:
    /// 
    /// Input: [1,2,3,1]
    /// Output: true
    /// 
    /// Example 2:
    /// 
    /// Input: [1,2,3,4]
    /// Output: false
    /// 
    /// Example 3:
    /// 
    /// Input: [1,1,1,3,3,4,3,2,4,2]
    /// Output: true
    /// </summary>
    public class ContainsDuplicate
    {
        [Test][TestCaseSource(nameof(TestData))]
        public bool ContainsDuplicateNumber(int[] nums) {
            var map = new HashSet<int>();
            foreach(var n in nums){
                if(map.Contains(n))
                    return true;
            
                map.Add(n);
            }
            return false;
        }

        static IEnumerable<TestCaseData> TestData
        {
            get
            {
                yield return new TestCaseData(new int[]{}).Returns(false);
                yield return new TestCaseData(new int[]{1}).Returns(false);
                yield return new TestCaseData(new int[]{1,2}).Returns(false);
                yield return new TestCaseData(new int[]{1,2,3}).Returns(false);
                yield return new TestCaseData(new int[]{1,2,3,4}).Returns(false);
                yield return new TestCaseData(new int[]{1,2,3,4,5}).Returns(false);
                yield return new TestCaseData(new int[]{1,1}).Returns(true);
                yield return new TestCaseData(new int[]{1,1,2}).Returns(true);
                yield return new TestCaseData(new int[]{1,2,2}).Returns(true);
                yield return new TestCaseData(new int[]{3,2,3,1}).Returns(true);
                yield return new TestCaseData(new int[]{1,2,3,3,4}).Returns(true);
                yield return new TestCaseData(new int[]{1,1,2,3,4,5}).Returns(true);
                yield return new TestCaseData(new int[]{1,2,3,1}).Returns(true);
                yield return new TestCaseData(new int[]{1,1,1,3,3,4,3,2,4,2}).Returns(true);
            }
        }

    }
}