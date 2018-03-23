using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Word_Frequency_Counter
{
    class FileManager
    {
        private StreamReader fileStream;
        public StreamReader FileStream { get { return fileStream;}}
        public FileManager(string fileName)
        {
            fileStream = OpenFile(fileName);
        }

        public Boolean FileFound()
        {
            return fileStream != null ? true : false;
        }

        internal string MapToFile(IReadOnlyDictionary<string, int> readOnlyDictionary)
        {
            string path = @"./output.txt";
            using (StreamWriter file = new StreamWriter(path))
            {
                foreach (KeyValuePair<string, int> entry in readOnlyDictionary)
                {
                    file.WriteLine("Word: {0} \t\t\t\t Count: {1}", entry.Key, entry.Value);
                }
            }
            return path;
        }

        public void CloseStream()
        {
            try
            {
                fileStream.Dispose();
            } catch (Exception e)
            {
                Console.WriteLine("Stream already closed");
            }
        }

        private StreamReader OpenFile(string filename)
        {
            string winDir = System.Environment.GetEnvironmentVariable("windir");
            try
            {
                StreamReader reader = new StreamReader(filename);
                return reader;
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
                CloseStream();
                return null;
            }
        }
    }
}
