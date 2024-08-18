using System;

namespace RPG
{
    public class RpgException : Exception
    {
        public RpgException(string message) : base(message) { }
    }
}
