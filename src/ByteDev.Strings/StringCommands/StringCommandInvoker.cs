using System;
using System.Collections.Generic;

namespace ByteDev.Strings.StringCommands
{
    public class StringCommandInvoker
    {
        private readonly IList<StringCommand> _commands;

        public StringCommandInvoker()
        {
            _commands = new List<StringCommand>();
        }

        public void SetCommands(params StringCommand[] commands)
        {
            if (commands == null)
                throw new ArgumentNullException(nameof(commands));

            _commands.Clear();

            foreach (var command in commands)
            {
                _commands.Add(command);
            }
        }
        
        public void Invoke()
        {
            foreach (var command in _commands)
            {
                command.Execute();
            }
        }
    }
}