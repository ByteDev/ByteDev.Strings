namespace ByteDev.Strings.StringCommands
{
    /// <summary>
    /// Represents a command that converts a value to upper case.
    /// </summary>
    public class CaseToUpperCommand : StringCommand
    {
        /// <summary>
        /// Execute the command.
        /// </summary>
        public override void Execute()
        {
            SetResult(Value?.ToUpper());
        }
        
        public override string ToString()
        {
            return GetType().Name;
        }
    }
}