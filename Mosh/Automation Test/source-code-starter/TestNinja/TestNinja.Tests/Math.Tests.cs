/**
* @Project Name: $projectname$ ： Math
* @Project Desc:
*
* @Machine Name: IVAN_ZHANG
* @Namespace Name: TestNinja.Tests
* @Creation Time:  3/13/2018 8:59:27 PM
* @Author Ivan
* @Email  yf.eva.yifan@gmail.com
*
* @Change Log
*
* Version       Change Date               Changed By                  Changes
* ───────────────────────────────────────────────────────────────────────────────
* V0.01          3/13/2018 8:59:27 PM                    Ivan                  Initial
*
* Copyright (c) @ Yifan Zhang 2018.  All rights reserved.
*
*/
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.Tests
{
    [TestFixture]
    class MathTests
    {
        private Math _math;
        [SetUp]
        public void SetUP()
        {
            _math = new Math();
        }
        [Test]
        [TestCase(5, new int[] { 1, 3, 5 })]
        public void GetOddNumbers_LimitIsGreaterThanZero_ReturnOddNumbersUpToLimit(int limit, int[] array)
        {
            var result = _math.GetOddNumbers(limit);

            Assert.That(result, Is.EquivalentTo(array));
        }

        [Test]
        [TestCase(-5, new int[] { })]
        public void GetOddNumbers_LimitIsLessThanZero_ReturnOddNumbersUpToLimit(int limit, int[] array)
        {
            var result = _math.GetOddNumbers(limit);

            Assert.That(result, Is.EquivalentTo(array));
        }

        [Test]
        [TestCase(0, new int[] { })]
        public void GetOddNumbers_LimitIsEqualToZero_ReturnOddNumbersUpToLimit(int limit, int[] array)
        {
            var result = _math.GetOddNumbers(limit);

            Assert.That(result, Is.EquivalentTo(array));
        }
    }
}
