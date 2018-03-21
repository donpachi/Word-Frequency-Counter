using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Word_Frequency_Counter
{
    class InputHandler
    {
        HashSet<string> supportedFileTypes = new HashSet<string>() {"txt"};
        public string PromptUserFileName()
        {
            string str = null;
            do
            {
                Console.Write("Enter filename: ");
                str = Console.ReadLine();
                str.Trim();
                while (!IsStringValid(str))
                {
                    Console.Write("Invalid filename entered, please enter a valid filename: ");
                    str = Console.ReadLine();
                }
                while (!IsFileTypeSupported(str))
                {
                    Console.Write("Filetype not supported, supported types are: ");
                    foreach (string s in supportedFileTypes) Console.Write(s);
                    Console.WriteLine();
                }
                return str;

            }
            while (string.IsNullOrWhiteSpace(str));
        }

        private bool IsStringValid(string s)
        {
            if (s.Split('.').Length == 1) { return false; }
            return true;
        }

        private bool IsFileTypeSupported(string s)
        {
            return supportedFileTypes.Contains(s.Split('.').Last());
        }
    }
}
