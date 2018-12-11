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
        public void should_return_foo_Bar_Qix_in_Order_when_input_contains_3_5(string number, string expected)
        {
            var computed = new FooBarQix().Compute(number);
            Assert.That(computed, Is.EqualTo(expected));
        }
        [TestCase("10", "Bar*")]
        public void should_return_string_that_contains_Bar_then_asterisk_when_input_is_divisible_by_5_and_contains_0(string number, string expected)
        {
            var computed = new FooBarQix().Compute(number);
            Assert.That(computed, Is.EqualTo(expected));
        }
        [TestCase("303", "FooFoo*Foo")]
        public void should_return_string_that_contains_Foo_and_asterisk_when_input_is_divisible_by_3_and_contains_3_and_0(string number, string expected)
        {
            var computed = new FooBarQix().Compute(number);
            Assert.That(computed, Is.EqualTo(expected));
        }
        [TestCase("1050", "FooBarQix*Bar*")]
        [TestCase("10101", "FooQix**")]
        public void should_return_string_that_contains_Foo_Bar_Qix_and_asterisk_when_input_is_divisible_by_3_5_7_and_contains_0(string number, string expected)
        {
            var computed = new FooBarQix().Compute(number);
            Assert.That(computed, Is.EqualTo(expected));
        }
        [TestCase("101", "1*1")]
        [TestCase("202", "2*2")]
        [TestCase("802", "8*2")]
        public void should_return_string_that_contains_numbers_and_asterisk_when_input_contains_0_and_regular_numbers(string number, string expected)
        {
            var computed = new FooBarQix().Compute(number);
            Assert.That(computed, Is.EqualTo(expected));
        }
        [TestCase("21", "FooQix")]
        [TestCase("51", "FooBar")]
        [TestCase("15", "FooBarBar")]
        public void should_return_string_that_contains_Foo_Bar_Qix_in_order_of_division_when_input_is_divisible_by_3_5_and_7(string number, string expected)
        {
            var computed = new FooBarQix().Compute(number);
            Assert.That(computed, Is.EqualTo(expected));
        }
   
        public void should_return_value_using_foo_bar_qix_rules(string number, string expected)
        {
            var computed = new FooBarQix().Compute(number);
            Assert.That(computed, Is.EqualTo(expected));
        }
    }
}
