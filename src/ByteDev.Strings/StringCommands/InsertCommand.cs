namespace ByteDev.Strings.StringCommands
{
    /// <summary>
    /// Represents a command that inserts a string at a certain position.
    /// </summary>
    public class InsertCommand : StringCommand
    {
        /// <summary>
        /// Position to insert value.
        /// </summary>
        public int Position { get; private set; }

        /// <summary>
        /// String to insert.
        /// </summary>
        public string InsertValue { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ByteDev.Strings.StringCommands.InsertCommand" /> class.
        /// </summary>
        /// <param name="position">Position to insert value.</param>
        /// <param name="insertValue">String to insert.</param>
        public InsertCommand(int position, string insertValue)
        {
            Position = position;
            InsertValue = insertValue;
        }

        /// <summary>
        /// Execute the command.
        /// </summary>
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
