namespace ByteDev.Strings.StringCommands
{
    /// <summary>
    /// Represents a command that replaces an old value with a
    /// new value within a string value.
    /// </summary>
    public class ReplaceCommand : StringCommand
    {
        public string OldValue { get; }

        public string NewValue { get; }

        public ReplaceCommand(string oldValue, string newValue)
        {
            OldValue = oldValue;
            NewValue = newValue;
        }

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
