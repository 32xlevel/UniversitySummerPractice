using System;    

namespace Utilities
{
    public static class Utilities
    {
        public static int ReadInt(string message)
        {
            Console.Write(message);
            return int.TryParse(Console.ReadLine(), out var result) ? result : ReadInt(message);
        }
        
        public static double ReadDouble(string message)
        {
            Console.Write(message);
            return double.TryParse(Console.ReadLine(), out var result) ? result : ReadDouble(message);
        }
    }
}