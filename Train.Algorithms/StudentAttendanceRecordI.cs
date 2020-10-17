using System.Collections.Generic;
using NUnit.Framework;

namespace Train.Algorithms
{
    /// <summary>
    /// https://leetcode.com/problems/student-attendance-record-i/
    /// 
    /// Student Attendance Record I
    ///
    /// You are given a string representing an attendance record for a student.
    /// The record only contains the following three characters:
    /// 'A' : Absent.
    /// 'L' : Late.
    /// 'P' : Present.
    /// A student could be rewarded if his attendance record doesn't contain
    /// more than one 'A' (absent) or more than two continuous 'L' (late).
    /// 
    /// You need to return whether the student could be rewarded according to his attendance record.
    /// 
    /// Example 1:
    /// Input: "PPALLP"
    /// Output: True
    /// 
    /// Example 2:
    /// Input: "PPALLL"
    /// Output: False
    /// </summary>
    public class StudentAttendanceRecordI
    {
        [Test][TestCaseSource(nameof(TestData))]
        public bool CheckRecord(string s)
        {
            int a = 0, l = 0, ml = 0;
            foreach (var c in s)
            {
                if (c == 'L')
                {
                    l += 1;
                    ml = ml > l ? ml : l;
                }
                else
                {
                    l = 0;
                    if (c == 'A') a += 1;
                }
            }

            return a <= 1 && ml <= 2;
        }

        [Test]
        [TestCaseSource(nameof(TestData))]
        public bool CheckRecordSimplified(string s)
        {
            int a = 0, l = 0;
            foreach (var c in s)
            {
                if (c == 'A') a += 1;
                if (c == 'L') l += 1;
                else l = 0;

                if (a > 1 || l > 2) return false;
            }

            return true;
        }

        static IEnumerable<TestCaseData> TestData
        {
            get
            {
                yield return new TestCaseData("PPPP").Returns(true);
                yield return new TestCaseData("PPPPA").Returns(true);
                yield return new TestCaseData("APPPP").Returns(true);
                yield return new TestCaseData("PPAPP").Returns(true);
                yield return new TestCaseData("A").Returns(true);
                yield return new TestCaseData("AA").Returns(false);
                yield return new TestCaseData("PAAP").Returns(false);
                yield return new TestCaseData("PAPA").Returns(false);
                yield return new TestCaseData("PPAA").Returns(false);
                yield return new TestCaseData("PPAAPP").Returns(false);
                yield return new TestCaseData("PPAPPAPP").Returns(false);
                yield return new TestCaseData("APPPPPPA").Returns(false);
                yield return new TestCaseData("PAPLLP").Returns(true);
                yield return new TestCaseData("PALLP").Returns(true);
                yield return new TestCaseData("PLLAP").Returns(true);
                yield return new TestCaseData("LLA").Returns(true);
                yield return new TestCaseData("ALL").Returns(true);
                yield return new TestCaseData("PLALP").Returns(true);
                yield return new TestCaseData("PALPL").Returns(true);
                yield return new TestCaseData("PALPLL").Returns(true);
                yield return new TestCaseData("PALLPLL").Returns(true);
                yield return new TestCaseData("PLLPLLP").Returns(true);
                yield return new TestCaseData("LLPLLPLL").Returns(true);
                yield return new TestCaseData("LLLPLL").Returns(false);
                yield return new TestCaseData("LLPLLL").Returns(false);
                yield return new TestCaseData("PLLPLLL").Returns(false);
                yield return new TestCaseData("PLLPLLLP").Returns(false);
                yield return new TestCaseData("PPLLLPP").Returns(false);
                yield return new TestCaseData("PPLLLL").Returns(false);
                yield return new TestCaseData("PPPLLL").Returns(false);
                yield return new TestCaseData("LLLPPP").Returns(false);
                yield return new TestCaseData("LLPPLLPPLLL").Returns(false);
            }
        }
    }
}