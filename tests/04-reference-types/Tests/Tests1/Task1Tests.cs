using System;
using NUnit.Framework;
using TestHelpers.Attributes;
using TestHelpers.Common;
using TestHelpers.Data;

namespace Tests1
{
    [TargetAssembly("Task1")]
    public class Task1Tests : TestFixtureBase<Task1Tests>
    {
        private Type _subjectType;

        [SetUp]
        public void SetUp()
        {
            _subjectType = ReflectionHelper.FindType("User");
        }

        [Test]
        public void UserConstructorShouldCreateCorrectly()
        {
            var age = new ClassData { DataName = "Age", Value = 20 };
            var birthDate = new ClassData { DataName = "BirthDate", Value = DateTime.Now.Date.AddYears(-(int)age.Value) };
            var name = new ClassData { DataName = "Name", Value = "Name" };
            var lastName = new ClassData { DataName = "LastName", Value = "LastName" };
            var patronymic = new ClassData { DataName = "Patronymic", Value = "Patronymic" };

            var user = ReflectionHelper.ExecuteConstructorWithCorrectParametersOrder(
                _subjectType,
                lastName,
                name,
                birthDate,
                patronymic);

            AssertEquality(user, name);
            AssertEquality(user, lastName);
            AssertEquality(user, patronymic);
            AssertEquality(user, age);
        }

        private void AssertEquality(object user, ClassData data)
        {
            var actual = ReflectionHelper.GetValueUsingGetter(user, data.DataName);

            Assert.AreEqual(data.Value, actual, GetErrorMessage(data.DataName, data.Value, actual));
        }

        private string GetErrorMessage<T>(string property, T expected, object actual)
        {
            return $"{Environment.NewLine}Некорректное значение свойства {property} после инициализации через конструктор" +
                   $"{Environment.NewLine}Ожидалось: {expected}" +
                   $"{Environment.NewLine}Было: {actual}";
        }
    }
}