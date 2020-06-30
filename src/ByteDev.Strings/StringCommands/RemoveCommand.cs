using ByteDev.Strings.StringCommands.BaseCommands;

namespace ByteDev.Strings.StringCommands
{
    /// <summary>
    /// Represents a command that removes all given values.
    /// </summary>
    public class RemoveCommand : StringCommand
    {
        public string RemoveValue { get; }

        public RemoveCommand(string removeValue)
        {
            RemoveValue = removeValue;
        }

        public override void Execute()
        {
			if(string.IsNullOrEmpty(RemoveValue))
			{
				SetResult(Value);
				return;
			}

            SetResult(Value.Replace(RemoveValue, string.Empty));
        }

        public override string ToString()
        {
            return $"{GetType().Name} ({RemoveValue})";
        }
    }
}
