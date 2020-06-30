using System;

namespace ByteDev.Strings.StringCommands.BaseCommands
{
    public abstract class CutCopyPasteCommand : StringCommand
    {
        public int CopyPosition { get; protected set; }

        public int CopyLength { get; protected set; }

        public int PastePosition { get; protected set; }

        protected CutCopyPasteCommand(int copyPosition, int copyLength, int pastePosition)
        {
            CopyPosition = copyPosition;
            CopyLength = copyLength;
            PastePosition = pastePosition;      
        }

        protected void ValidateParameters()
        {
            if (CopyPosition < 0)
                CopyPosition = 0;

            if (CopyLength < 1)
                throw new ArgumentException("Copy length must be 1 or greater");

            if (CopyLength > Value.Length)
                throw new ArgumentException($"Copy length must be equal to or less than {Value.Length}");

            if (PastePosition > Value.Length)
                PastePosition = Value.Length;									// position is off the end so just append to end
        }

        protected string Copy(string value)
        {
            return value.Substring(CopyPosition, CopyLength);
        }

        protected string Paste(string value, string textToPaste)
        {
            return value.Insert(PastePosition, textToPaste);
        }

        protected string Cut(string value)
        {
            return value.Remove(CopyPosition, CopyLength);
        }
    }
}
