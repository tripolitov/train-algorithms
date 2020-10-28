using System.Collections.Generic;
using NUnit.Framework;

namespace Train.Algorithms
{
    /// <summary>
    /// https://leetcode.com/problems/next-greater-element-i/
    /// 
    /// Next Greater Element I
    ///
    /// You are given two arrays (without duplicates) nums1 and nums2 where nums1’s elements are subset of nums2. Find all the next greater numbers for nums1's elements in the corresponding places of nums2.

    /// The Next Greater Number of a number x in nums1 is the first greater number to its right in nums2. If it does not exist, output -1 for this number.
    /// 
    /// Example 1:
    /// Input: nums1 = [4,1,2], nums2 = [1,3,4,2].
    /// Output: [-1,3,-1]
    /// Explanation:
    /// For number 4 in the first array, you cannot find the next greater number for it in the second array, so output -1.
    /// For number 1 in the first array, the next greater number for it in the second array is 3.
    /// For number 2 in the first array, there is no next greater number for it in the second array, so output -1.
    ///
    /// Example 2:
    /// Input: nums1 = [2,4], nums2 = [1,2,3,4].
    /// Output: [3,-1]
    /// Explanation:
    /// For number 2 in the first array, the next greater number for it in the second array is 3.
    /// For number 4 in the first array, there is no next greater number for it in the second array, so output -1.
    ///
    /// Note:
    /// All elements in nums1 and nums2 are unique.
    /// The length of both nums1 and nums2 would not exceed 1000.
    /// </summary>
    public class NextGreaterElementI
    {
        [Test][TestCaseSource(nameof(TestData))]
        public int[] NextGreaterElement(int[] nums1, int[] nums2) {
            var result = new int[nums1.Length];
            var map = new Dictionary<int, int>();
        
            for(var i = 0; i < nums2.Length; i+=1) {
                map[nums2[i]] = i; 
            }
        
            for(var i = 0; i < nums1.Length; i +=1) {
                result[i] = -1;
                for(var j = map[nums1[i]] + 1; j < nums2.Length; j += 1) {
                    if(nums1[i] < nums2[j]) {
                        result[i] = nums2[j];
                        break;
                    }
                }
            }
            return result;
        }

        [Test]
        [TestCaseSource(nameof(TestData))]
        public int[] NextGreaterElement_Stack(int[] nums1, int[] nums2)
        {
            var result = new int[nums1.Length];
            var map = new Dictionary<int, int>();

            foreach (var n in nums1) map[n] = -1;

            var stack = new Stack<int>();
            foreach (var n in nums2)
            {
                while (stack.Count > 0 && stack.Peek() < n)
                {
                    map[stack.Pop()] = n;
                }

                if(map.ContainsKey(n)) stack.Push(n);
            }

            for (var i = 0; i < nums1.Length; i += 1) result[i] = map[nums1[i]];

            return result;
        }

        static IEnumerable<TestCaseData> TestData
        {
            get
            {
                yield return new TestCaseData(new int[] {1}, new int[] {1,2,3,4}).Returns(new int[] {2});
                yield return new TestCaseData(new int[] {2}, new int[] {1,2,3,4}).Returns(new int[] {3});
                yield return new TestCaseData(new int[] {4}, new int[] {1,2,3,4}).Returns(new int[] {-1});
                yield return new TestCaseData(new int[] {1,2}, new int[] {1,2,3,4}).Returns(new int[] {2,3});
                yield return new TestCaseData(new int[] {1,3}, new int[] {1,2,3,4}).Returns(new int[] {2,4});
                yield return new TestCaseData(new int[] {2,3}, new int[] {1,2,3,4}).Returns(new int[] {3,4});
                yield return new TestCaseData(new int[] {2,4}, new int[] {1,2,3,4}).Returns(new int[] {3,-1});
                yield return new TestCaseData(new int[] {4, 1, 2}, new int[] {1, 3, 4, 2}).Returns(new int[] {-1, 3, -1});
                yield return new TestCaseData(new int[] {1, 2, 3}, new int[] {4, 3, 2, 1}).Returns(new int[] {-1, -1, -1});
            }
        }
    }
}