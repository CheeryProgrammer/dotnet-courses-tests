using NUnit.Framework;
using System;
using TestHelpers.Attributes;
using TestHelpers.Common;

namespace Tests3
{
    [TargetAssembly("Task3")]
    public class Task3Tests : TestFixtureBase<Task3Tests>
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