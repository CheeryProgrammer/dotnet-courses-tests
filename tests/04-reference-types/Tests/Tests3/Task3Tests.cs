using System;
using System.Reflection;
using NUnit.Framework;
using TestHelpers.Attributes;
using TestHelpers.Common;
using TestHelpers.Data;

namespace Tests3
{
    [TargetAssembly("Task3")]
    public class Task3Tests : TestFixtureBase<Task3Tests>
    {
        private Type _subjectType;

        [SetUp]
        public void SetUp()
        {
            _subjectType = ReflectionHelper.FindType("Triangle");
        }

        [TestCase(-1, 2, 2, "сторона треугольника отрицательная")]
        [TestCase(2, -1, 2, "сторона треугольника отрицательная")]
        [TestCase(2, 2, -1, "сторона треугольника отрицательная")]
        [TestCase(1, 1, 3, "треугольник с заданными сторонами не существует")]
        public void TriangleShouldThrowExceptionWithIncorrectValues(int a, int b, int c, string message)
        {
            var aData = new ClassData { DataName = "A", Value = a };
            var bData = new ClassData { DataName = "A", Value = b };
            var cData = new ClassData { DataName = "A", Value = c };

            Assert.Throws<TargetInvocationException>(() => ReflectionHelper.ExecuteConstructorWithCorrectParametersOrder(_subjectType, aData, bData, cData),
                $"Должно выбрасываться исключение в случае, если {message}");
        }

        [Test]
        public void TriangleConstructorShouldCreateCorrectly()
        {
            var a = new ClassData { DataName = "A", Value = 3 };
            var b = new ClassData { DataName = "B", Value = 4 };
            var c = new ClassData { DataName = "C", Value = 5 };

            var expectedArea = new ClassData { DataName = "GetArea", Value = 6 };
            var expectedPerimeter = new ClassData { DataName = "GetPerimeter", Value = 12 };

            var triangle = ReflectionHelper.ExecuteConstructorWithCorrectParametersOrder(_subjectType, a, b, c);

            AssertEquality(triangle, a);
            AssertEquality(triangle, b);
            AssertEquality(triangle, c);
            AssertMethodResultEquality(triangle, expectedPerimeter);
            AssertMethodResultEquality(triangle, expectedArea);
        }

        private void AssertEquality(object triangle, ClassData data)
        {
            var actual = ReflectionHelper.GetValueUsingGetter(triangle, data.DataName);

            Assert.AreEqual(data.Value, actual, GetErrorMessage(data.DataName, data.Value, actual));
        }

        private void AssertMethodResultEquality(object triangle, ClassData data)
        {
            var actual = ReflectionHelper.ExecuteNonStaticMethod(triangle, data.DataName);

            Assert.AreEqual(data.Value, actual, GetErrorMessage(data.DataName, data.Value, actual));
        }

        private string GetErrorMessage<T>(string property, T expected, object actual)
        {
            return $"{Environment.NewLine}Некорректное значение {property} после инициализации через конструктор" +
                   $"{Environment.NewLine}Ожидалось: {expected}" +
                   $"{Environment.NewLine}Было: {actual}";
        }
    }
}