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
        public void should_return_empty_string_when_input_is_not_number(string number, string expected)
        {
            var computed = new FooBarQix().Compute(number);
            Assert.That(computed, Is.EqualTo(expected));
        }
        [TestCase("1", "1")]
        [TestCase("2", "2")]
        [TestCase("8", "8")]
        public void should_return_number_when_input_is_regular_number(string number, string expected)
        {
            var computed = new FooBarQix().Compute(number);
            Assert.That(computed, Is.EqualTo(expected));
        }    
        [TestCase("9", "Foo")]
        [TestCase("96", "Foo")]
        [TestCase("24", "Foo")]
        public void should_return_foo_when_input_is_divisible_by_3(string number, string expected)
        {
            var computed = new FooBarQix().Compute(number);
            Assert.That(computed, Is.EqualTo(expected));
        }
        [TestCase("13", "Foo")]
        [TestCase("32", "Foo")]
        public void should_return_foo_when_input_contains_3(string number, string expected)
        {
            var computed = new FooBarQix().Compute(number);
            Assert.That(computed, Is.EqualTo(expected));
        }
        [TestCase("3", "FooFoo")]
        [TestCase("33", "FooFooFoo")]
        public void should_return_foo_when_input_contains_3_and_is_divisisble_by_3(string number, string expected)
        {
            var computed = new FooBarQix().Compute(number);
            Assert.That(computed, Is.EqualTo(expected));
        }
        [TestCase("5", "BarBar")]
        [TestCase("25", "BarBar")]
        public void should_return_Bar_when_input_is_divisible_by_5_and_contains_5(string number, string expected)
        {
            var computed = new FooBarQix().Compute(number);
            Assert.That(computed, Is.EqualTo(expected));
        }
        [TestCase("52", "Bar")]
        public void should_return_Bar_when_input_contains_5(string number, string expected)
        {
            var computed = new FooBarQix().Compute(number);
            Assert.That(computed, Is.EqualTo(expected));
        }
        [TestCase("7", "QixQix")]
        [TestCase("77", "QixQixQix")]
        public void should_return_Qix_when_input_is_divisible_by_7_and_contains_7(string number, string expected)
        {
            var computed = new FooBarQix().Compute(number);
            Assert.That(computed, Is.EqualTo(expected));
        }
        [TestCase("28", "Qix")]
        public void should_return_Qix_when_input_is_divisible_by_7(string number, string expected)
        {
            var computed = new FooBarQix().Compute(number);
            Assert.That(computed, Is.EqualTo(expected));
        }
        [TestCase("17", "Qix")]
        [TestCase("47", "Qix")]
        public void should_return_foo_when_input_contains_7(string number, string expected)
        {
            var computed = new FooBarQix().Compute(number);
            Assert.That(computed, Is.EqualTo(expected));            
        }
        [TestCase("53", "BarFoo")]
        [TestCase("21", "FooQix")]
        [TestCase("51", "FooBar")]
        [TestCase("15", "FooBarBar")]     
        [TestCase("101", "1*1")]
        [TestCase("303", "FooFoo*Foo")]
        [TestCase("105", "FooBarQix*Bar")]
        [TestCase("10101", "FooQix**")]
        public void should_return_value_using_foo_bar_qix_rules(string number, string expected)
        {
            var computed = new FooBarQix().Compute(number);
            Assert.That(computed, Is.EqualTo(expected));
            // Assert.AreEqual(computed, strExpected);
        }
    }
}
