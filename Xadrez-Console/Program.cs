using System;
using board;


namespace Xadrez_Console {
    class Program {
        static void Main(string[] args) {
            Position p = new Position(5, 3);
            Console.WriteLine(p);

            Board b = new Board(9, 9);
            Console.WriteLine(b.Lines.ToString() + ", " + b.Columns.ToString()); ;

        }
    }
}