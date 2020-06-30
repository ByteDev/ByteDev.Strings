using ByteDev.Strings.StringCommands.BaseCommands;

namespace ByteDev.Strings.StringCommands
{
    /// <summary>
    /// Represents a command that converts a value to upper case.
    /// </summary>
    public class CaseToUpperCaseCommand : StringCommand
    {
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