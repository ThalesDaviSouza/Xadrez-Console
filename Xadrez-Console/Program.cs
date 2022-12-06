using System;
using board;
using Chess;


namespace Chess_Console {
    class Program {
        static void Main(string[] args) {
            ChessPosition p = new ChessPosition('a', 2);
            Console.WriteLine(p);
            Console.WriteLine(p.toPosition());
        }
    }
}