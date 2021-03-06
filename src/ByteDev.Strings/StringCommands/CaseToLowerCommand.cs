﻿namespace ByteDev.Strings.StringCommands
{
    /// <summary>
    /// Represents a command that converts a value to lower case.
    /// </summary>
    public class CaseToLowerCommand : StringCommand
    {
        /// <summary>
        /// Execute the command.
        /// </summary>
        public override void Execute()
        {
            SetResult(Value?.ToLower());
        }

        public override string ToString()
        {
            return GetType().Name;
        }
    }
}
