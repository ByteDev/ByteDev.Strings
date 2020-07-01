namespace ByteDev.Strings.StringCommands
{
    /// <summary>
    /// Represents a command that removes value from a start position
    /// to length.
    /// </summary>
    public class RemovePositionCommand : StringCommand
    {
        public int Position { get; private set; }

        public int Length { get; private set; }

        public RemovePositionCommand(int position, int length)
        {
            Position = position;
            Length = length;
        }

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
