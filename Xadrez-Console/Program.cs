using System;
using board;
using Xadrez;


namespace Xadrez_Console {
    class Program {
        static void Main(string[] args) {
            XadrezPosition p = new XadrezPosition('a', 2);
            Console.WriteLine(p);
            Console.WriteLine(p.toPosition());
        }
    }
}