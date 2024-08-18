using System;

namespace RPG
{
    public class MissingReferenceException : Exception
    {
        public MissingReferenceException(string message) : base(message) { }
    }
}
