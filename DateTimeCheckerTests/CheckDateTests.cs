using NUnit.Framework;
using DateTimeCheckerLib;

namespace DateTimeCheckerTests
{
    [TestFixture]
    public class CheckDateTests
    {
        [SetUp]
        public void Setup()
        {
        }

        #region Parameterized Test Suite (CD01 - CD15)
        [TestCase(31, 1, 2023, true, TestName = "CD01_Day31_Month1_Year2023_Valid_Boundary")]
        [TestCase(31, 4, 2023, false, TestName = "CD02_Day31_Month4_Year2023_Invalid_Boundary")]
        [TestCase(29, 2, 2024, true, TestName = "CD03_Day29_Month2_Year2024_ValidLeap_Boundary")]
        [TestCase(29, 2, 2023, false, TestName = "CD04_Day29_Month2_Year2023_InvalidNonLeap_Boundary")]
        [TestCase(29, 2, 2000, true, TestName = "CD05_Day29_Month2_Year2000_ValidLeap400_Boundary")]
        [TestCase(29, 2, 1900, false, TestName = "CD06_Day29_Month2_Year1900_InvalidCentury_Boundary")]
        [TestCase(29, 2, 2100, false, TestName = "CD07_Day29_Month2_Year2100_InvalidCentury_Boundary")]
        [TestCase(29, 2, 2400, true, TestName = "CD08_Day29_Month2_Year2400_ValidLeap400_Boundary")]
        [TestCase(29, 4, 2023, true, TestName = "CD09_Day29_Month4_Year2023_Valid_Normal")]
        [TestCase(29, 0, 2023, false, TestName = "CD10_Day29_Month0_Year2023_InvalidMonth_Abnormal")]
        [TestCase(0, 2, 2023, false, TestName = "CD11_Day0_Month2_Year2023_InvalidDay_Abnormal")]
        [TestCase(0, 1, 2024, false, TestName = "CD12_Day0_Month1_Year2024_InvalidDay_Abnormal")]
        [TestCase(29, 2, 1000, false, TestName = "CD13_Day29_Month2_Year1000_InvalidNonLeap_Boundary")]
        [TestCase(29, 2, 3000, false, TestName = "CD14_Day29_Month2_Year3000_InvalidNonLeap_Boundary")]
        [TestCase(31, 1, 2024, true, TestName = "CD15_Day31_Month1_Year2024_Valid_Normal")]
        public void CheckDate_ParameterizedTest(int day, int month, int year, bool expected)
        {
            bool actual = DateTimeChecker.CheckDate(day, month, year);
            Assert.That(actual, Is.EqualTo(expected), $"CheckDate({day}, {month}, {year}) should return {expected}.");
        }
        #endregion

        #region Explicit Individual Test Methods (CD01 - CD15)
        [Test]
        public void CD01_Day31_January_Valid()
        {
            // Day 31, Month 1, Year 2023 -> True (Boundary case)
            bool result = DateTimeChecker.CheckDate(31, 1, 2023);
            Assert.That(result, Is.True);
        }

        [Test]
        public void CD02_Day31_April_Invalid()
        {
            // Day 31, Month 4, Year 2023 -> False (April has only 30 days - Boundary case)
            bool result = DateTimeChecker.CheckDate(31, 4, 2023);
            Assert.That(result, Is.False);
        }

        [Test]
        public void CD03_Day29_Feb_LeapYear2024_Valid()
        {
            // Day 29, Month 2, Year 2024 -> True (Leap year div by 4 - Boundary case)
            bool result = DateTimeChecker.CheckDate(29, 2, 2024);
            Assert.That(result, Is.True);
        }

        [Test]
        public void CD04_Day29_Feb_NonLeapYear2023_Invalid()
        {
            // Day 29, Month 2, Year 2023 -> False (Non-leap year - Boundary case)
            bool result = DateTimeChecker.CheckDate(29, 2, 2023);
            Assert.That(result, Is.False);
        }

        [Test]
        public void CD05_Day29_Feb_LeapYear2000_Valid()
        {
            // Day 29, Month 2, Year 2000 -> True (Leap year div by 400 - Boundary case)
            bool result = DateTimeChecker.CheckDate(29, 2, 2000);
            Assert.That(result, Is.True);
        }

        [Test]
        public void CD06_Day29_Feb_NonLeapYear1900_Invalid()
        {
            // Day 29, Month 2, Year 1900 -> False (Century year div by 100 but not 400 - Boundary case)
            bool result = DateTimeChecker.CheckDate(29, 2, 1900);
            Assert.That(result, Is.False);
        }

        [Test]
        public void CD07_Day29_Feb_NonLeapYear2100_Invalid()
        {
            // Day 29, Month 2, Year 2100 -> False (Century year div by 100 but not 400 - Boundary case)
            bool result = DateTimeChecker.CheckDate(29, 2, 2100);
            Assert.That(result, Is.False);
        }

        [Test]
        public void CD08_Day29_Feb_LeapYear2400_Valid()
        {
            // Day 29, Month 2, Year 2400 -> True (Leap year div by 400 - Boundary case)
            bool result = DateTimeChecker.CheckDate(29, 2, 2400);
            Assert.That(result, Is.True);
        }

        [Test]
        public void CD09_Day29_April_Valid()
        {
            // Day 29, Month 4, Year 2023 -> True (Normal case)
            bool result = DateTimeChecker.CheckDate(29, 4, 2023);
            Assert.That(result, Is.True);
        }

        [Test]
        public void CD10_Day29_Month0_Invalid()
        {
            // Day 29, Month 0, Year 2023 -> False (Invalid month - Abnormal case)
            bool result = DateTimeChecker.CheckDate(29, 0, 2023);
            Assert.That(result, Is.False);
        }

        [Test]
        public void CD11_Day0_Month2_Invalid()
        {
            // Day 0, Month 2, Year 2023 -> False (Invalid day 0 - Abnormal case)
            bool result = DateTimeChecker.CheckDate(0, 2, 2023);
            Assert.That(result, Is.False);
        }

        [Test]
        public void CD12_Day0_Month1_Invalid()
        {
            // Day 0, Month 1, Year 2024 -> False (Invalid day 0 - Abnormal case)
            bool result = DateTimeChecker.CheckDate(0, 1, 2024);
            Assert.That(result, Is.False);
        }

        [Test]
        public void CD13_Day29_Feb_Year1000_Invalid()
        {
            // Day 29, Month 2, Year 1000 -> False (Year 1000 non-leap - Boundary case)
            bool result = DateTimeChecker.CheckDate(29, 2, 1000);
            Assert.That(result, Is.False);
        }

        [Test]
        public void CD14_Day29_Feb_Year3000_Invalid()
        {
            // Day 29, Month 2, Year 3000 -> False (Year 3000 non-leap - Boundary case)
            bool result = DateTimeChecker.CheckDate(29, 2, 3000);
            Assert.That(result, Is.False);
        }

        [Test]
        public void CD15_Day31_January_LeapYear2024_Valid()
        {
            // Day 31, Month 1, Year 2024 -> True (Normal case)
            bool result = DateTimeChecker.CheckDate(31, 1, 2024);
            Assert.That(result, Is.True);
        }
        #endregion
    }
}
