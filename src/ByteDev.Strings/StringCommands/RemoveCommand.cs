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
            if (string.IsNullOrEmpty(Value) || 
                string.IsNullOrEmpty(RemoveValue))
            {
                SetResult(Value);
                return;
            }

            var removeValue = Value.Replace(RemoveValue, string.Empty);

            SetResult(removeValue);
        }

        public override string ToString()
        {
            return $"{GetType().Name} ({RemoveValue})";
        }
    }
}
