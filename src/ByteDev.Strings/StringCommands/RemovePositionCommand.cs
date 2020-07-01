namespace ByteDev.Strings.StringCommands
{
    /// <summary>
    /// Represents a command that removes value from a start position
    /// to length.
    /// </summary>
    public class RemovePositionCommand : StringCommand
    {
        /// <summary>
        /// Start position to remove from.
        /// </summary>
        public int Position { get; private set; }

        /// <summary>
        /// Length of string to remove.
        /// </summary>
        public int Length { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ByteDev.Strings.StringCommands.RemovePositionCommand" /> class.
        /// </summary>
        /// <param name="position">Start position to remove from.</param>
        /// <param name="length">Length of string to remove.</param>
        public RemovePositionCommand(int position, int length)
        {
            Position = position;
            Length = length;
        }

        /// <summary>
        /// Execute the command.
        /// </summary>
        public override void Execute()
        {
            if (string.IsNullOrEmpty(Value) ||
                Position >= Value.Length ||
                Length < 1)
            {
                SetResult(Value);
                return;
            }

            if (Position < 0)
                Position = 0;

            if (Position + Length > Value.Length)
                Length = Value.Length - Position;

            var left = Value.Substring(0, Position);     
            var right = Value.Substring(Position + Length);

            SetResult(left + right);
        }

        public override string ToString()
        {
            return $"{GetType().Name} ({Position}, {Length})";
        }
    }
}
