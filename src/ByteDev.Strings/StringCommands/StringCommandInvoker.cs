using System;
using System.Collections.Generic;

namespace ByteDev.Strings.StringCommands
{
    /// <summary>
    /// Represents an invoker of string commands.
    /// </summary>
    public class StringCommandInvoker : IStringCommandInvoker
    {
        private readonly IList<StringCommand> _commands;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ByteDev.Strings.StringCommands.StringCommandInvoker" /> class.
        /// </summary>
        public StringCommandInvoker()
        {
            _commands = new List<StringCommand>();
        }

        /// <summary>
        /// Set the command(s) to be invoked.
        /// </summary>
        /// <param name="commands">Commands to invoke.</param>
        public StringCommandInvoker SetCommands(params StringCommand[] commands)
        {
            if (commands == null)
                throw new ArgumentNullException(nameof(commands));

            _commands.Clear();

            foreach (var command in commands)
            {
                _commands.Add(command);
            }

            return this;
        }
        
        /// <summary>
        /// Invoke the command(s).
        /// </summary>
        public void Invoke()
        {
            foreach (var command in _commands)
            {
                command.Execute();
            }
        }
    }
}