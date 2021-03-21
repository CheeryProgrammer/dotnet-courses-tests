using NUnit.Framework;
using System;
using TestHelpers.Attributes;
using TestHelpers.Common;

namespace Tests4
{
    [TargetAssembly("Task4")]
    public class Task4Tests: TestFixtureBase<Task4Tests>
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