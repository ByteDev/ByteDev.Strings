using ByteDev.Strings.StringCommands.BaseCommands;

namespace ByteDev.Strings.StringCommands
{
    /// <summary>
    /// Represents a command that removes value from a start position
    /// to length.
    /// </summary>
    public class RemovePositionCommand : StringCommand
    {
        public int Position { get; }

        public int Length { get; }

        public RemovePositionCommand(int position, int length)
        {
            Position = position;
			Length = length;
        }

        public override void Execute()
        {
			if(Length < 1)
			{
				SetResult(Value);
				return;
			}

            var startPos = Position;

            if (startPos < 0)
            {
                startPos = 0;
            }
            else if (startPos > Value.Length)
            {
                SetResult(Value);
            	return;
            }

            var left = Value.Substring(0, startPos);     
            var right = Value.Substring(startPos + Length);

            SetResult(left + right + Value);
        }

        public override string ToString()
        {
            return $"{GetType().Name} ({Position}, {Length})";
        }
    }
}
