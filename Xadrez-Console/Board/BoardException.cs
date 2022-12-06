using System;

namespace board {
    internal class BoardException : Exception{
        public BoardException(string message) : base(message) { }
    }
}
