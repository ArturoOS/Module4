using System;

namespace Task1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
			try
			{
				Console.Write("Input character:");
				string input = Console.ReadLine();
				if (!string.IsNullOrEmpty(input))
					Console.WriteLine($"Output character: {input}");
				else
					throw new Exception("Invalid input.");
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
        }
    }
}