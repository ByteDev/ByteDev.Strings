namespace ByteDev.Strings.StringCommands
{
    public class StringCommandInvoker
    {
        private StringCommand _command;

        public void SetCommand(StringCommand command)
        {
            _command = command;
        }

        public void Invoke()
        {
            _command.Execute();
        }
    }
}