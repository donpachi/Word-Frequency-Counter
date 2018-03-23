using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Word_Frequency_Counter
{
    class Program
    {
        static void Main(string[] args)
        {
            InputHandler input = new InputHandler();
            FileManager file = new FileManager(input.PromptUserFileName());
            if (file.FileFound())
            {
                TextProcessor textProcessor = new TextProcessor(file.FileStream.ReadToEnd());
                
                Console.Write("Word count: {0}", textProcessor.WordLongCount);
                Console.ReadLine();
                string path = file.MapToFile(textProcessor.GetWordMapping());
                Console.Write("Word mapping output to file " + path);
                Console.ReadLine();
                file.CloseStream();
            }
            else
            {
                Console.WriteLine("No file to process, press any key to exit");
                Console.ReadKey();
            }
        }


    }
}
