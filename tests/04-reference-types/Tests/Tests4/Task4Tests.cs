using System;
using NUnit.Framework;
using TestHelpers.Attributes;
using TestHelpers.Common;
using TestHelpers.Data;

namespace Tests4
{
    [TargetAssembly("Task4")]
    public class Task4Tests : TestFixtureBase<Task4Tests>
    {
        private Type _subjectType;

        [SetUp]
        public void SetUp()
        {
            _subjectType = ReflectionHelper.FindType("MyString");
        }

        [Test]
        public void MyStringShouldCreateCorrectString()
        {
            var chars = new ClassData { DataName = "ToString" };
            var expectedString = string.Empty;

            var myString = ReflectionHelper.ExecuteConstructorWithCorrectParametersOrder(_subjectType);
            var actualString = ReflectionHelper.ExecuteNonStaticMethod(myString, chars.DataName);

            Assert.AreEqual(expectedString, actualString, GetErrorMessage(chars.DataName, chars.Value, actualString));
        }

        [Test]
        public void MyStringShouldCreateCorrectStringWithCharArray()
        {
            var chars = new ClassData { DataName = "ToString", Value = new[] { 'h', 'e', 'l', 'l', 'o' } };
            var expectedString = "hello";

            var myString = ReflectionHelper.ExecuteConstructorWithCorrectParametersOrder(_subjectType, chars);
            var actualString = ReflectionHelper.ExecuteNonStaticMethod(myString, chars.DataName);

            Assert.AreEqual(expectedString, actualString, GetErrorMessage(chars.DataName, expectedString, actualString));
        }

        [Test]
        public void MyStringShouldCreateCorrectStringWithCharString()
        {
            var expectedString = new ClassData { DataName = "ToString", Value = "hello" };

            var myString = ReflectionHelper.ExecuteConstructorWithCorrectParametersOrder(_subjectType, expectedString);
            var actualString = ReflectionHelper.ExecuteNonStaticMethod(myString, expectedString.DataName);

            Assert.AreEqual(expectedString.Value, actualString, GetErrorMessage(expectedString.DataName, expectedString, actualString));
        }

        [TestCase(" world", "hello world", "op_Addition")]
        [TestCase("ello", "h", "op_Subtraction")]
        [TestCase("hello", true, "op_Equality")]
        [TestCase(" hello", false, "op_Equality")]
        public void MyStringShouldOverrideOperatorsCorrectly(string secondValue, object expected, string operatorName)
        {
            var expectedString1 = new ClassData { DataName = "ToString", Value = "hello" };
            var myString1 = ReflectionHelper.ExecuteConstructorWithCorrectParametersOrder(_subjectType, expectedString1);
            var expectedString2 = new ClassData { DataName = "ToString", Value = secondValue };
            var myString2 = ReflectionHelper.ExecuteConstructorWithCorrectParametersOrder(_subjectType, expectedString2);

            var actual = ReflectionHelper.ExecuteCustomOperator(myString1, myString2, operatorName);

            if (expected is string expectedString)
            {
                Assert.AreEqual(expectedString, actual.ToString());
            }
            else
            {
                Assert.AreEqual(expected, actual);
            }
        }

        private string GetErrorMessage<T>(string property, T expected, object actual)
        {
            return $"{Environment.NewLine}Некорректное значение {property} после инициализации через конструктор" +
                   $"{Environment.NewLine}Ожидалось: {expected}" +
                   $"{Environment.NewLine}Было: {actual}";
        }

        private string GetErrorMessageForOperator<TExpected, TActual>(string operatorName, TExpected expected,
            TActual actual)
        {
            return $"{Environment.NewLine}Некорректное значение после использования оператора {operatorName}" +
                   $"{Environment.NewLine}Ожидалось: {expected}" +
                   $"{Environment.NewLine}Было: {actual}";
        }
    }
}