using System;

namespace ByteDev.Strings.StringCommands
{
    [Serializable]
    public abstract class StringCommand
    {
        protected string Value;

        public string Result { get; private set; }

        public abstract void Execute();
        
        public void SetValue(string value)
        {
            Value = value;
        }

        protected void SetResult(string result)
        {
            Result = result;
        }
    }
}
