namespace ByteDev.Strings.StringCommands
{
    /// <summary>
    /// Represents a command that copies part of a value and pastes into
    /// the value at a certain position.
    /// </summary>
    public class CopyPasteCommand : StringCommand
    {
        /// <summary>
        /// Copy segment start position.
        /// </summary>
        public int CopyPosition { get; private set; }

        /// <summary>
        /// Copy segment length.
        /// </summary>
        public int CopyLength { get; private set; }

        /// <summary>
        /// Paste position for segment.
        /// </summary>
        public int PastePosition { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ByteDev.Strings.StringCommands.CopyPasteCommand" /> class.
        /// </summary>
        /// <param name="copyPosition">Copy segment start position.</param>
        /// <param name="copyLength">Copy segment length.</param>
        /// <param name="pastePosition">Paste position for segment.</param>
        public CopyPasteCommand(int copyPosition, int copyLength, int pastePosition)
        {
            CopyPosition = copyPosition;
            CopyLength = copyLength;
            PastePosition = pastePosition;
        }

        /// <summary>
        /// Execute the command.
        /// </summary>
        public override void Execute()
        {
            if (Value == null ||
                CopyLength < 1 || 
                CopyPosition == Value.Length)
            {
                SetResult(Value);
                return;
            }

            ValidateParameters();

            var copyValue = Copy(Value);
            
            var pasteValue = Paste(Value, copyValue);

            SetResult(pasteValue);
        }

        public override string ToString()
        {
            return $"{GetType().Name} ({CopyPosition}, {CopyLength}, {PastePosition})";
        }

        private void ValidateParameters()
        {
            if (CopyPosition < 0)
                CopyPosition = 0;
            else if (CopyPosition > Value.Length)
                CopyPosition = Value.Length;

            if (PastePosition < 0)
                PastePosition = 0;
            else if (PastePosition > Value.Length)
                PastePosition = Value.Length;

            if (CopyLength < 0)
                CopyLength = 0;
            else if (CopyPosition + CopyLength > Value.Length)
                CopyLength = Value.Length - CopyPosition;
        }

        private string Copy(string value)
        {
            return value.Substring(CopyPosition, CopyLength);
        }

        private string Paste(string value, string textToPaste)
        {
            return value.Insert(PastePosition, textToPaste);
        }
    }
}