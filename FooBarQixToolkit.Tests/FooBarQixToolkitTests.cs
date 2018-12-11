/*
 * Title: FooBarQixToolkit.Tests
 * File: FooBarQixToolkitTests.cs
 * Description: The unit test class.
 * Author:Imene Khemiri
 * Copyright: Copyright (c) 2018
 * @version 1.0.0
 * */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FooBarQixToolkit;
namespace FooBarQixToolkit.Tests
{
    [TestFixture]
    public class FooBarQixToolkitTests
    {

        [TestCase("1Foo", "")]
        [TestCase("FooFoo", "")]
        [TestCase("QixFoo", "")]
        [TestCase("abc123", "")]
        public void should_return_empty_string_when_input_is_not_number(string strNumber, string strExpected)
        {
            var computed = new FooBarQix().Compute(strNumber);
            Assert.AreEqual(computed, strExpected);
        }
        [TestCase("1", "1")]
        [TestCase("2", "2")]
        [TestCase("8", "8")]
        public void should_return_number_when_input_is_regular_number(string strNumber, string strExpected)
        {
            var computed = new FooBarQix().Compute(strNumber);
            Assert.AreEqual(computed, strExpected);
        }
        [TestCase("3", "FooFoo")]
        public void should_return_foo_when_input_is_divisible_by_3_or_contains_3(string strNumber, string strExpected)
        {
            var computed = new FooBarQix().Compute(strNumber);
            Assert.AreEqual(computed, strExpected);
        }
        [TestCase("5", "BarBar")]
        public void should_return_foo_when_input_is_divisible_by_5_or_contains_5(string strNumber, string strExpected)
        {
            var computed = new FooBarQix().Compute(strNumber);
            Assert.AreEqual(computed, strExpected);
        }

        [TestCase("7", "QixQix")]
        public void should_return_foo_when_input_is_divisible_by_7_or_contains_7(string strNumber, string strExpected)
        {
            var computed = new FooBarQix().Compute(strNumber);
            Assert.AreEqual(computed, strExpected);
        }

        [TestCase("53", "BarFoo")]
        [TestCase("21", "FooQix")]
        [TestCase("51", "FooBar")]
        [TestCase("15", "FooBarBar")]
        [TestCase("33", "FooFooFoo")]
        [TestCase("13", "Foo")]
        [TestCase("101", "1*1")]
        [TestCase("303", "FooFoo*Foo")]
        [TestCase("105", "FooBarQix*Bar")]
        [TestCase("10101", "FooQix**")]
        public void should_return_value_using_foo_bar_qix_rules(string strNumber, string strExpected)
        {
            var computed = new FooBarQix().Compute(strNumber);
            Assert.AreEqual(computed, strExpected);
        }
    }
}
