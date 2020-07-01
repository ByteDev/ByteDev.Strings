using System;
using System.Collections.Generic;

namespace ByteDev.Strings.StringCommands
{
    /// <summary>
    /// Represents a command of chained commands.
    /// </summary>
    public class StringChainedCommand : StringCommand
    {
        private readonly IList<StringCommand> _commands;

        public StringChainedCommand(IList<StringCommand> commands)
        {
            _commands = commands ?? throw new ArgumentNullException(nameof(commands));
        }

        public override void Execute()
        {
            string last = Value;

            foreach (var command in _commands)
            {
                command.SetValue(last);
                command.Execute();

                last = command.Result;
            }

            SetResult(last);
        }
    }
}