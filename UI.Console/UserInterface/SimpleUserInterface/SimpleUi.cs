using System;

namespace UserInterface.SimpleUserInterface
{
    /// <summary>
    /// This class is a way to output to the user at first glance.
    /// </summary>
    public class SimpleUi
    {
        public string Print(string text)
        {
            Console.WriteLine(text);
            return text;
        }

        public string PrintWithUserFullfillment(string text)
        {
            Console.Write(text);
            return text;
        }

        public string PrintWithColor(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.White;
            return text;
        }

        public string PrintWithTimestamp(string text)
        {
            string output = $"[{DateTime.Now}] {text}";
            Console.WriteLine(output);
            return output;
        }

        public string PrintWithTimestampAndColor(string text, ConsoleColor color)
        {
            string output = $"[{DateTime.Now}] {text}";
            Console.ForegroundColor = color;
            Console.WriteLine(output);
            Console.ForegroundColor = ConsoleColor.White;
            return output;
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public bool ParseYesNo(string text)
        {
            text = text.ToLower();
            if (text.Equals("y") || text.Equals("yes"))
            {
                return true;
            }

            if (text.Equals("n") || text.Equals("no"))
            {
                return false;
            }

            throw new InvalidOperationException("Enter either 'yes'/'y' or 'no'/'n' (not case sensitive).");
        }
    }
}