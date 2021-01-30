using System;

namespace MyRoot
{
    public class Logger
    {
        public static void Yellow(string texto)// Do ROBO
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(texto);
            Console.ResetColor();
        }
        public static void Red(string texto) // Error
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(texto);
            Console.ResetColor();
        }
        public static void Blue(string texto) //Cabeçalho
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(texto);
            Console.ResetColor();
        }
        public static void Green(string texto)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(texto);
            Console.ResetColor();
        }
    }
}
