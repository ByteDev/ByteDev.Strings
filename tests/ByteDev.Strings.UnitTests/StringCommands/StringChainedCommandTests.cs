using System;
using System.Collections.Generic;
using ByteDev.Strings.StringCommands;
using NUnit.Framework;

namespace ByteDev.Strings.UnitTests.StringCommands
{
    [TestFixture]
    public class StringChainedCommandTests
    {
        [TestFixture]
        public class Constructor
        {
            [Test]
            public void WhenCommandsIsNull_ThenThrowException()
            {
                Assert.Throws<ArgumentNullException>(() => new StringChainedCommand(null));
            }
        }

        [TestFixture]
        public class Execute
        {
            private const string Value = "John Smith";

            [Test]
            public void WhenCommandsIsEmpty_ThenSetResultToValue()
            {
                var commands = new List<StringCommand>();

                var sut = new StringChainedCommand(commands);

                sut.SetValue(Value);
                sut.Execute();

                Assert.That(sut.Result, Is.EqualTo(Value));
            }

            [Test]
            public void WhenMultipleCommands_ThenSetValue()
            {
                var commands = new List<StringCommand>
                {
                    new CaseToLowerCommand(),
                    new InsertCommand(100, " lives in England."),
                    new CutPasteCommand(5, 5, 0)
                };

                var sut = new StringChainedCommand(commands);

                sut.SetValue(Value);
                sut.Execute();

                Assert.That(sut.Result, Is.EqualTo("smithjohn  lives in England."));
            }
        }
    }
}