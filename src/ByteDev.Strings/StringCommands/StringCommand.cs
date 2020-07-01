using System;

namespace ByteDev.Strings.StringCommands
{
    /// <summary>
    /// Represents an abstract string command.
    /// </summary>
    [Serializable]
    public abstract class StringCommand
    {
        protected string Value;

        /// <summary>
        /// Result from the command after it's been executed.
        /// </summary>
        public string Result { get; private set; }

        /// <summary>
        /// Execute the command.
        /// </summary>
        public abstract void Execute();
        
        /// <summary>
        /// Set the initial string value that the command will act on.
        /// </summary>
        /// <param name="value">String value.</param>
        /// <returns>Current command instance.</returns>
        public StringCommand SetValue(string value)
        {
            Value = value;
            return this;
        }

        protected StringCommand SetResult(string result)
        {
            Result = result;
            return this;
        }
    }
}
