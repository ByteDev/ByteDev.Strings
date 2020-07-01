using System;
using ByteDev.Strings.StringCommands;
using NUnit.Framework;

namespace ByteDev.Strings.UnitTests.StringCommands
{
    [TestFixture]
    public class StringCommandInvokerTests
    {
        [TestFixture]
        public class SetCommands
        {
            [Test]
            public void WhenCommandsIsNull_ThenThrowException()
            {
                Assert.Throws<ArgumentNullException>(() => new StringCommandInvoker().SetCommands(null));
            }
        }

        [TestFixture]
        public class Invoke
        {
            private StringCommandInvoker _sut;

            [SetUp]
            public void SetUp()
            {
                _sut = new StringCommandInvoker();
            }

            [Test]
            public void WhenCommandHasNotBeenSet_ThenDoNothing()
            {
                Assert.DoesNotThrow(() => _sut.Invoke());
            }

            [Test]
            public void WhenCommandSet_ThenExecuteCommand()
            {
                var command = new CaseToLowerCommand().SetValue("John Smith");

                _sut.SetCommands(command);
                _sut.Invoke();

                Assert.That(command.Result, Is.EqualTo("john smith"));
            }

            [Test]
            public void WhenCommandsSet_ThenExecuteCommands()
            {                
                var c1 = new CaseToLowerCommand().SetValue("John Smith");
                var c2 = new CopyPasteCommand(0, 4, 0).SetValue("John Smith");

                _sut.SetCommands(c1, c2);
                _sut.Invoke();

                Assert.That(c1.Result, Is.EqualTo("john smith"));
                Assert.That(c2.Result, Is.EqualTo("JohnJohn Smith"));
            }
        }
    }
}