namespace ByteDev.Strings.StringCommands
{
    public interface IStringCommandInvoker
    {
        /// <summary>
        /// Set the command(s) to be invoked.
        /// </summary>
        /// <param name="commands">Commands to invoke.</param>
        StringCommandInvoker SetCommands(params StringCommand[] commands);

        /// <summary>
        /// Invoke the command(s).
        /// </summary>
        void Invoke();
    }
}