using System;
using System.Reflection;
using NUnit.Framework;
using TestHelpers.Attributes;
using TestHelpers.Common;
using TestHelpers.Data;

namespace Tests2
{
    [TargetAssembly("Task2")]
    public class Task2Tests : TestFixtureBase<Task2Tests>
    {
        private Type _subjectType;

        [SetUp]
        public void SetUp()
        {
            _subjectType = ReflectionHelper.FindType("Round");
        }

        [Test]
        public void RoundShouldThrowExceptionWithIncorrectRadius()
        {
            var radius = new ClassData { DataName = "Radius", Value = -5 };
            var x = new ClassData { DataName = "X", Value = 10 };
            var y = new ClassData { DataName = "Y", Value = 5 };

            Assert.Throws<TargetInvocationException>(() => ReflectionHelper.ExecuteConstructorWithCorrectParametersOrder(_subjectType, radius, x, y),
                "При попытке создать объект класса Round с отрицательным радиусом должно выбрасываться исключение");
        }

        [Test]
        public void RoundConstructorShouldCreateCorrectly()
        {
            var radius = new ClassData { DataName = "Radius", Value = 5 };
            var x = new ClassData { DataName = "X", Value = 10 };
            var y = new ClassData { DataName = "Y", Value = 5 };

            var expectedCircumference = new ClassData { DataName = "Circumference", Value = 31.4};
            var expectedArea = new ClassData { DataName = "Area", Value = 78.5 };

            var round = ReflectionHelper.ExecuteConstructorWithCorrectParametersOrder(_subjectType, radius, x, y);

            AssertEquality(round, radius);
            AssertEquality(round, x);
            AssertEquality(round, y);

            AssertRoundedEquality(round, expectedCircumference);
            AssertRoundedEquality(round, expectedArea);
        }

        private void AssertEquality(object round, ClassData data)
        {
            AssertEquality(round, data, ReflectionHelper.GetValueUsingGetter(round, data.DataName));
        }

        private void AssertRoundedEquality(object round, ClassData data)
        {
            double actual = Math.Round((double)ReflectionHelper.GetValueUsingGetter(round, data.DataName), 1);

            AssertEquality(round, data, actual);
        }

        private void AssertEquality(object round, ClassData expected, object actual)
        {
            Assert.AreEqual(expected.Value, actual, GetErrorMessage(expected.DataName, expected.Value, actual));
        }

        private string GetErrorMessage<T>(string property, T expected, object actual)
        {
            return $"{Environment.NewLine}Некорректное значение свойства {property} после инициализации через конструктор" +
                   $"{Environment.NewLine}Ожидалось: {expected}" +
                   $"{Environment.NewLine}Было: {actual}";
        }
    }
}