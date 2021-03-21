using NUnit.Framework;
using System;
using TestHelpers.Attributes;
using TestHelpers.Common;

namespace Tests1
{
    [TargetAssembly("Task1")]
    public class Task1Tests : TestFixtureBase<Task1Tests>
    {
        private Type subject;

        [SetUp]
        public void Setup()
        {
            subject = ReflectionHelper.FindType("DynamicArray`1");
        }

        [Test]
        [TestCase(TestName = "Тип 'DynamicArray<T>' существует в сборке 'Task1'")]
        public void DynamicArrayTypeExistsTest()
        {
            Assert.IsNotNull(subject, "Тип 'DynamicArray<T>' не найден в сборке 'Task1'");
        }
    }
}