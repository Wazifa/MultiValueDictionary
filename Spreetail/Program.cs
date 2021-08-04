using System;

namespace Spreetail
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary dictionary = new Dictionary();

            while(true)
            {
                Console.Write("> ");
                string input = Console.ReadLine();

                if (String.Equals(input, "exit"))
                    break;

                dictionary.Command(input);
            }

        }
    }
}
