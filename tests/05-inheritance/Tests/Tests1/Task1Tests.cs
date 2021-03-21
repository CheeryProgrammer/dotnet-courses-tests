using NUnit.Framework;
using System;
using TestHelpers.Attributes;
using TestHelpers.Common;

namespace Tests1
{
    [TargetAssembly("Task1")]
    public class Task1Tests : TestFixtureBase<Task1Tests>
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
