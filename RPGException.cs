using System;

namespace RPG
{
    public class RPGException : Exception
    {
        public RPGException(string message) : base(message) { }
    }
}
