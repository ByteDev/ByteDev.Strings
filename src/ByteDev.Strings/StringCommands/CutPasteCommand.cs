namespace ByteDev.Strings.StringCommands
{
    /// <summary>
    /// Represents a command that cuts part of a value and pastes into
    /// the value at a certain position.
    /// </summary>
    public class CutPasteCommand : StringCommand
    {
        public int CutPosition { get; private set; }

        public int CutLength { get; private set; }

        public int PastePosition { get; private set; }

        public CutPasteCommand(int cutPosition, int cutLength, int pastePosition)
        {
            CutPosition = cutPosition;
            CutLength = cutLength;
            PastePosition = pastePosition;
        }

        public override void Execute()
        {
            if (Value == null ||
                CutLength < 1 || 
                CutPosition == Value.Length)
            {
                SetResult(Value);
                return;
            }

            ValidateParameters();

            if (CutPosition == 0 && CutLength >= Value.Length)
            {
                SetResult(string.Empty);
                return;
            }

            var copyValue = Copy(Value);
            
            var cutValue = Cut(Value);

            if (PastePosition > cutValue.Length)
                PastePosition = cutValue.Length;

            var pasteValue = Paste(cutValue, copyValue);

            SetResult(pasteValue);
        }
        
        public override string ToString()
        {
            return $"{GetType().Name} ({CutPosition}, {CutLength}, {PastePosition})";
        }

        protected void ValidateParameters()
        {
            if (CutPosition < 0)
                CutPosition = 0;
            else if (CutPosition > Value.Length)
                CutPosition = Value.Length;

            if (PastePosition < 0)
                PastePosition = 0;

            if (CutLength < 0)
                CutLength = 0;
            else if (CutPosition + CutLength > Value.Length)
                CutLength = Value.Length - CutPosition;
        }

        protected string Cut(string value)
        {
            return value.Remove(CutPosition, CutLength);
        }

        protected string Copy(string value)
        {
            return value.Substring(CutPosition, CutLength);
        }

        protected string Paste(string value, string textToPaste)
        {
            return value.Insert(PastePosition, textToPaste);
        }

    }
}