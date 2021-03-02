using System;
using NUnit.Framework;
using TestHelpers;
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
        public void UserConstractorShouldCreateCorrectly()
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

            Assert.AreEqual(name.Value, ReflectionHelper.GetValueUsingGetter(user, name.DataName));
            Assert.AreEqual(lastName.Value, ReflectionHelper.GetValueUsingGetter(user, lastName.DataName));
            Assert.AreEqual(patronymic.Value, ReflectionHelper.GetValueUsingGetter(user, patronymic.DataName));
            Assert.AreEqual(age.Value, ReflectionHelper.GetValueUsingGetter(user, age.DataName));
        }
    }
}