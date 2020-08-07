using System.Collections.Generic;
using NUnit.Framework;

namespace Train.Algorithms
{
    class RemoveDuplicatesFromSortedArray
    {
        [Test]
        [TestCaseSource(nameof(TestData))]
        public int RemoveDuplicates(int[] nums)
        {
            if (nums.Length == 0) return 0;

            int j = 1;

            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] != nums[j - 1])
                {
                    nums[j] = nums[i];
                    j++;
                }
            }

            return j;
        }

        public static IEnumerable<TestCaseData> TestData
        {
            get
            {
                yield return new TestCaseData(new int [0]).Returns(0);
                yield return new TestCaseData(new int [1]).Returns(1);
                yield return new TestCaseData(new int[] {1, 2, 3}).Returns(3);
                yield return new TestCaseData(new int[] {1, 1, 1}).Returns(1);
                yield return new TestCaseData(new int[] {1,1,3}).Returns(2);
                yield return new TestCaseData(new int[] {1,1,2,2,3,3}).Returns(3);
                yield return new TestCaseData(new int[] {0, 0, 1, 1, 1, 2, 2, 3, 3, 4}).Returns(5);
            }
        }

    }
}
