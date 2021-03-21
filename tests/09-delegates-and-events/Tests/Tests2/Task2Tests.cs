using NUnit.Framework;
using System;
using TestHelpers.Attributes;
using TestHelpers.Common;

namespace Tests2
{
    [TargetAssembly("Task2")]
    public class Task2Tests : TestFixtureBase<Task2Tests>
    {
        private Type subject;

        [SetUp]
        public void Setup()
        {
            subject = ReflectionHelper.FindType("Program");
        }

        // TODO: Add tests
    }
}