namespace ByteDev.Strings.StringCommands
{
    /// <summary>
    /// Represents a command that inserts a string at a certain position.
    /// </summary>
    public class InsertCommand : StringCommand
    {
        public int Position { get; private set; }

        public string InsertValue { get; }

        public InsertCommand(int position, string insertValue)
        {
            Position = position;
            InsertValue = insertValue;
        }

        public override void Execute()
        {
            if (string.IsNullOrEmpty(Value))
            {
                SetResult(InsertValue);
                return;
            }

            if (string.IsNullOrEmpty(InsertValue))
            {
                SetResult(Value);
                return;
            }

            if (Position < 0)
                Position = 0;
            else if (Position > Value.Length)
                Position = Value.Length;

            var insertValue = Value.Insert(Position, InsertValue);

            SetResult(insertValue);
        }

        public override string ToString()
        {
            return $"{GetType().Name} ({Position}, {InsertValue})";
        }
    }
}
