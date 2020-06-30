using ByteDev.Strings.StringCommands.BaseCommands;

namespace ByteDev.Strings.StringCommands
{
    /// <summary>
    /// Represents a command that cuts part of a value and pastes into
    /// the value at a certain position.
    /// </summary>
    public class CutPasteCommand : CutCopyPasteCommand
    {
        public CutPasteCommand(int copyPosition, int copyLength, int pastePosition) :
            base(copyPosition, copyLength, pastePosition)
        {
        }

        public override void Execute()
        {
            if (Value == null)
            {
                SetResult(null);
                return;
            }

            ValidateParameters();

            var copyValue = Copy(Value);
            
            Value = Paste(Value, copyValue);

            SetResult(Cut(Value));
        }
        
        public override string ToString()
        {
            return $"{GetType().Name} ({CopyPosition}, {CopyLength}, {PastePosition})";
        }
    }
}