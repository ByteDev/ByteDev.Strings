using ByteDev.Strings.StringCommands.BaseCommands;

namespace ByteDev.Strings.StringCommands
{
    /// <summary>
    /// Represents a command that inserts a string at a certain position.
    /// </summary>
    public class InsertCommand : StringCommand
    {
        public int Position { get; }

        public string InsertValue { get; }

        public InsertCommand(int position, string insertValue)
        {
            Position = position;
            InsertValue = insertValue;
        }

        public override void Execute()
        {
            if (Position < 0)											
			{
                SetResult(InsertValue + Value);
			}
			else if (Position <= Value.Length)
			{
                SetResult(Value.Insert(Position, InsertValue));
			}
			else
			{
                SetResult(Value + InsertValue);
			}
        }

        public override string ToString()
        {
            return $"{GetType().Name} ({Position}, {InsertValue})";
        }
    }
}
