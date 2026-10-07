using NUnit.Framework;
using DateTimeCheckerLib;

namespace DateTimeCheckerTests
{
    [TestFixture]
    public class DayInMonthTests
    {
        [SetUp]
        public void Setup()
        {
        }

        #region Parameterized Test Suite (DIM01 - DIM15)
        [TestCase(1, 2023, 31, TestName = "DIM01_Month1_Year2023_Returns31_Boundary")]
        [TestCase(4, 2023, 30, TestName = "DIM02_Month4_Year2023_Returns30_Normal")]
        [TestCase(2, 2023, 28, TestName = "DIM03_Month2_Year2023_Returns28_Normal")]
        [TestCase(2, 2024, 29, TestName = "DIM04_Month2_Year2024_Returns29_Boundary")]
        [TestCase(2, 2000, 29, TestName = "DIM05_Month2_Year2000_Returns29_Boundary")]
        [TestCase(2, 1900, 28, TestName = "DIM06_Month2_Year1900_Returns28_Boundary")]
        [TestCase(2, 2100, 28, TestName = "DIM07_Month2_Year2100_Returns28_Boundary")]
        [TestCase(2, 2400, 29, TestName = "DIM08_Month2_Year2400_Returns29_Boundary")]
        [TestCase(2, 2004, 29, TestName = "DIM09_Month2_Year2004_Returns29_Normal")]
        [TestCase(2, 2001, 28, TestName = "DIM10_Month2_Year2001_Returns28_Normal")]
        [TestCase(0, 2023, 0, TestName = "DIM11_Month0_Year2023_Returns0_Abnormal")]
        [TestCase(13, 2023, 0, TestName = "DIM12_Month13_Year2023_Returns0_Abnormal")]
        [TestCase(2, 1000, 28, TestName = "DIM13_Month2_Year1000_Returns28_Boundary")]
        [TestCase(2, 3000, 28, TestName = "DIM14_Month2_Year3000_Returns28_Boundary")]
        [TestCase(2, 65535, 28, TestName = "DIM15_Month2_Year65535_Returns28_Boundary")]
        public void DayInMonth_ParameterizedTest(int month, int year, int expected)
        {
            int actual = DateTimeChecker.DayInMonth(month, year);
            Assert.That(actual, Is.EqualTo(expected), $"DayInMonth({month}, {year}) should return {expected}.");
        }
        #endregion

        #region Explicit Individual Test Methods (DIM01 - DIM15)
        [Test]
        public void DIM01_January_NormalYear()
        {
            // Month 1, Year 2023 -> 31 days (Boundary case)
            int result = DateTimeChecker.DayInMonth(1, 2023);
            Assert.That(result, Is.EqualTo(31));
        }

        [Test]
        public void DIM02_April_NormalYear()
        {
            // Month 4, Year 2023 -> 30 days (Normal case)
            int result = DateTimeChecker.DayInMonth(4, 2023);
            Assert.That(result, Is.EqualTo(30));
        }

        [Test]
        public void DIM03_February_NonLeapYear()
        {
            // Month 2, Year 2023 -> 28 days (Normal case)
            int result = DateTimeChecker.DayInMonth(2, 2023);
            Assert.That(result, Is.EqualTo(28));
        }

        [Test]
        public void DIM04_February_LeapYear_DivisibleBy4()
        {
            // Month 2, Year 2024 -> 29 days (Boundary case)
            int result = DateTimeChecker.DayInMonth(2, 2024);
            Assert.That(result, Is.EqualTo(29));
        }

        [Test]
        public void DIM05_February_LeapYear_DivisibleBy400()
        {
            // Month 2, Year 2000 -> 29 days (Boundary case)
            int result = DateTimeChecker.DayInMonth(2, 2000);
            Assert.That(result, Is.EqualTo(29));
        }

        [Test]
        public void DIM06_February_NonLeapYear_DivisibleBy100()
        {
            // Month 2, Year 1900 -> 28 days (Boundary case)
            int result = DateTimeChecker.DayInMonth(2, 1900);
            Assert.That(result, Is.EqualTo(28));
        }

        [Test]
        public void DIM07_February_NonLeapYear_Century2100()
        {
            // Month 2, Year 2100 -> 28 days (Boundary case)
            int result = DateTimeChecker.DayInMonth(2, 2100);
            Assert.That(result, Is.EqualTo(28));
        }

        [Test]
        public void DIM08_February_LeapYear_Century2400()
        {
            // Month 2, Year 2400 -> 29 days (Boundary case)
            int result = DateTimeChecker.DayInMonth(2, 2400);
            Assert.That(result, Is.EqualTo(29));
        }

        [Test]
        public void DIM09_February_LeapYear_Year2004()
        {
            // Month 2, Year 2004 -> 29 days (Normal case)
            int result = DateTimeChecker.DayInMonth(2, 2004);
            Assert.That(result, Is.EqualTo(29));
        }

        [Test]
        public void DIM10_February_NonLeapYear_Year2001()
        {
            // Month 2, Year 2001 -> 28 days (Normal case)
            int result = DateTimeChecker.DayInMonth(2, 2001);
            Assert.That(result, Is.EqualTo(28));
        }

        [Test]
        public void DIM11_InvalidMonth_Zero()
        {
            // Month 0, Year 2023 -> 0 days (Abnormal case)
            int result = DateTimeChecker.DayInMonth(0, 2023);
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void DIM12_InvalidMonth_Thirteen()
        {
            // Month 13, Year 2023 -> 0 days (Abnormal case)
            int result = DateTimeChecker.DayInMonth(13, 2023);
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void DIM13_February_Year1000()
        {
            // Month 2, Year 1000 -> 28 days (Boundary case)
            int result = DateTimeChecker.DayInMonth(2, 1000);
            Assert.That(result, Is.EqualTo(28));
        }

        [Test]
        public void DIM14_February_Year3000()
        {
            // Month 2, Year 3000 -> 28 days (Boundary case)
            int result = DateTimeChecker.DayInMonth(2, 3000);
            Assert.That(result, Is.EqualTo(28));
        }

        [Test]
        public void DIM15_February_Year65535()
        {
            // Month 2, Year 65535 -> 28 days (Boundary case)
            int result = DateTimeChecker.DayInMonth(2, 65535);
            Assert.That(result, Is.EqualTo(28));
        }
        #endregion
    }
}
