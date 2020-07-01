namespace ByteDev.Strings.StringCommands
{
    /// <summary>
    /// Represents a command that cuts part of a value and pastes into
    /// the value at a certain position.
    /// </summary>
    public class CutPasteCommand : StringCommand
    {
        /// <summary>
        /// Cut segment start position.
        /// </summary>
        public int CutPosition { get; private set; }

        /// <summary>
        /// Cut segment length.
        /// </summary>
        public int CutLength { get; private set; }

        /// <summary>
        /// Paste position for segment.
        /// </summary>
        public int PastePosition { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ByteDev.Strings.StringCommands.CutPasteCommand" /> class.
        /// </summary>
        /// <param name="cutPosition">Cut segment start position.</param>
        /// <param name="cutLength">Cut segment length.</param>
        /// <param name="pastePosition">Paste position for segment.</param>
        public CutPasteCommand(int cutPosition, int cutLength, int pastePosition)
        {
            CutPosition = cutPosition;
            CutLength = cutLength;
            PastePosition = pastePosition;
        }

        /// <summary>
        /// Execute the command.
        /// </summary>
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
                SetResult(Value);
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

        private void ValidateParameters()
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

        private string Cut(string value)
        {
            return value.Remove(CutPosition, CutLength);
        }

        private string Copy(string value)
        {
            return value.Substring(CutPosition, CutLength);
        }

        private string Paste(string value, string textToPaste)
        {
            return value.Insert(PastePosition, textToPaste);
        }
    }
}