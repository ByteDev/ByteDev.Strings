namespace ByteDev.Strings.StringCommands
{
    /// <summary>
    /// Represents a command that replaces an old value with a
    /// new value within a string value.
    /// </summary>
    public class ReplaceCommand : StringCommand
    {
        /// <summary>
        /// Old string value to replace.
        /// </summary>
        public string OldValue { get; }

        /// <summary>
        /// New string value to replace with.
        /// </summary>
        public string NewValue { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ByteDev.Strings.StringCommands.ReplaceCommand" /> class.
        /// </summary>
        /// <param name="oldValue">Old string value to replace.</param>
        /// <param name="newValue">New string value to replace with.</param>
        public ReplaceCommand(string oldValue, string newValue)
        {
            OldValue = oldValue;
            NewValue = newValue;
        }

        /// <summary>
        /// Execute the command.
        /// </summary>
        public override void Execute()
        {
			if(string.IsNullOrEmpty(Value) ||
               string.IsNullOrEmpty(OldValue))
			{
				SetResult(Value);
                return;
            }

            var replaceValue = Value.Replace(OldValue, NewValue);

            SetResult(replaceValue);
        }

        public override string ToString()
        {
            return $"{GetType().Name} ({OldValue}, {NewValue})";
        }
    }
}
