using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Word_Frequency_Counter
{
    class TextProcessor
    {
        Dictionary<string, int> wordMap = new Dictionary<string, int>();
        public long WordLongCount { get { return wordCount; } }

        private string rawString;
        private long wordCount;
        public TextProcessor(string str)
        {
            rawString = str;
            ProcessString(rawString);
        }

        private void ProcessString(string rawString)
        {
            string[] tokens = rawString.Split(new char[] { ' ', '\n', });   //needs revision, preferably switch to regex?
            wordCount = tokens.LongLength;
            foreach (string s in tokens)
            {
                if (!wordMap.ContainsKey(s))
                {
                    wordMap.Add(s, 1);
                }
                else
                {
                    wordMap[s]++;
                }
            }
        }

        public IReadOnlyDictionary<string, int> GetWordMapping()
        {
            return wordMap;
        }
    }
}
