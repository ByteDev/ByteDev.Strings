namespace ByteDev.Strings.StringCommands
{
    /// <summary>
    /// Represents a command that safely removes part of a string from a start position to the end.
    /// </summary>
    public class RemoveToEndCommand : StringCommand
    {
        /// <summary>
        /// Start position to remove from.
        /// </summary>
        public int Position { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ByteDev.Strings.StringCommands.RemoveToEndCommand" /> class.
        /// </summary>
        /// <param name="position">Start position to remove from.</param>
        public RemoveToEndCommand(int position)
        {
            Position = position;
        }

        /// <summary>
        /// Execute the command.
        /// </summary>
        public override void Execute()
        {
            if (string.IsNullOrEmpty(Value))
            {
                SetResult(Value);
                return;
            }

            SetResult(Value.SafeSubstring(0, Position));
        }
    }
}