namespace ByteDev.Strings.StringCommands
{
    /// <summary>
    /// Represents a command that removes all given values.
    /// </summary>
    public class RemoveCommand : StringCommand
    {
        /// <summary>
        /// String value to remove.
        /// </summary>
        public string RemoveValue { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ByteDev.Strings.StringCommands.RemoveCommand" /> class.
        /// </summary>
        /// <param name="removeValue">String value to remove.</param>
        public RemoveCommand(string removeValue)
        {
            RemoveValue = removeValue;
        }

        /// <summary>
        /// Execute the command.
        /// </summary>
        public override void Execute()
        {
            if (string.IsNullOrEmpty(Value) || 
                string.IsNullOrEmpty(RemoveValue))
            {
                SetResult(Value);
                return;
            }

            var removeValue = Value.Replace(RemoveValue, string.Empty);

            SetResult(removeValue);
        }

        public override string ToString()
        {
            return $"{GetType().Name} ({RemoveValue})";
        }
    }
}
