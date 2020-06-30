using System.Collections.Generic;
using ByteDev.Strings.StringCommands.BaseCommands;

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
            _commands = commands;
        }

        public override void Execute()
        {
            string lastValue = null;

            foreach (var command in _commands)
            {
                if (lastValue != null)
                    command.SetValue(lastValue);

                command.Execute();
                lastValue = command.Result;
            }
        }
    }
}