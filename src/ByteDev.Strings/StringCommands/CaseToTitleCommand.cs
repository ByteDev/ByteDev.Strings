namespace ByteDev.Strings.StringCommands
{
    /// <summary>
    /// Represents a command that converts a value to title case.
    /// </summary>
    public class CaseToTitleCommand : StringCommand
    {
        /// <summary>
        /// Execute the command.
        /// </summary>
        public override void Execute()
        {
            SetResult(Value?.ToTitleCase());
        }

        public override string ToString()
        {
            return GetType().Name;
        }
    }
}