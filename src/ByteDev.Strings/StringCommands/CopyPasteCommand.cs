namespace ByteDev.Strings.StringCommands
{
    /// <summary>
    /// Represents a command that copies part of a value and pastes into
    /// the value at a certain position.
    /// </summary>
    public class CopyPasteCommand : StringCommand
    {
        public int CopyPosition { get; private set; }

        public int CopyLength { get; private set; }

        public int PastePosition { get; private set; }

        public CopyPasteCommand(int copyPosition, int copyLength, int pastePosition)
        {
            CopyPosition = copyPosition;
            CopyLength = copyLength;
            PastePosition = pastePosition;
        }

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