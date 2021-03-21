using NUnit.Framework;
using System;
using TestHelpers.Attributes;
using TestHelpers.Common;

namespace Tests2
{
    [TargetAssembly("Task2")]
    public class Task2Tests : TestFixtureBase<Task2Tests>
    {
        private Type subjectType;

        [SetUp]
        public void Setup()
        {
            subjectType = ReflectionHelper.FindType("Program");
        }

        // TODO: Add tests
    }
}
