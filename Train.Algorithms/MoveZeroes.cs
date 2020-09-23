using System.Collections.Generic;
using NUnit.Framework;

namespace Train.Algorithms
{
    /// <summary>
    /// https://leetcode.com/problems/move-zeroes/
    /// 
    /// Move Zeroes
    ///
    /// Given an array nums, write a function to move all 0's to the end of it while maintaining the relative order of the non-zero elements.
    /// 
    /// Example:
    /// 
    /// Input: [0,1,0,3,12]
    /// Output: [1,3,12,0,0]
    /// Note:
    /// 
    /// You must do this in-place without making a copy of the array.
    /// Minimize the total number of operations.
    /// </summary>
    public class MoveZeroes
    {
        [Test][TestCaseSource(nameof(TestData))]
        public int[] Move(int[] nums)
        {
            int i = 0, j = 1;
            int N = nums.Length;

            while (j < N)
            {
                if (nums[i] != 0) {
                    i += 1;
                    j += 1;
                    continue;
                    
                }

                if (nums[j] == 0)
                {
                    j += 1;
                    continue;
                }

                nums[i] = nums[j];
                nums[j] = 0;
                i += 1;
                j += 1;
            }

            return nums;
        }

        static IEnumerable<TestCaseData> TestData {
            get
            {
                yield return new TestCaseData(new int[] {0}).Returns(new int[] {0});
                yield return new TestCaseData(new int[] {0,0}).Returns(new int[] {0,0});
                yield return new TestCaseData(new int[] {0,1}).Returns(new int[] {1,0});
                yield return new TestCaseData(new int[] {0,0,1}).Returns(new int[] {1,0,0});
                yield return new TestCaseData(new int[] {0,0,0,1}).Returns(new int[] {1,0,0,0});
                yield return new TestCaseData(new int[] {0,1,0,3,12}).Returns(new int[] {1,3,12,0,0});
            }
        }
    }
}