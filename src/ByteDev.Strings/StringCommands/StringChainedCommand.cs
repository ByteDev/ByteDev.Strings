using System;
using System.Collections.Generic;

namespace ByteDev.Strings.StringCommands
{
    /// <summary>
    /// Represents a command of chained commands. The result from one
    /// will feed as the value for the next.
    /// </summary>
    public class StringChainedCommand : StringCommand
    {
        private readonly IEnumerable<StringCommand> _commands;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ByteDev.Strings.StringCommands.StringChainedCommand" /> class.
        /// </summary>
        /// <param name="commands">Collection of commands.</param>
        public StringChainedCommand(IEnumerable<StringCommand> commands)
        {
            _commands = commands ?? throw new ArgumentNullException(nameof(commands));
        }

        /// <summary>
        /// Execute the command.
        /// </summary>
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