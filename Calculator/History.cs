using System;
using System.Collections.Generic;

namespace Calculator
{
    public class History
    {
        private record Entry
        {
            public required string solution {get; set;}
            public List<string>? subhistory;
            public override string ToString()
            {
                string result = solution;
                if (subhistory == null) return result;
                foreach (string s in subhistory)
                {
                    result += "\n"+ "---" + s;
                }
                return result;
            }
        };
        
        private List<Entry> history;
        private bool paused;

        public History()
        {
            paused = false;
            history = new List<Entry>();
        }
        
        public void Start() { paused = false; }
        public void Pause() { paused = true; }
        public void Clear() { history.Clear(); }

        public void AddEntry(string solution)
        {
            if (paused) return;
            history.Add(new Entry { solution = solution });
        }

        public void AddEntry(string solution, List<string> subHistory)
        {
            if (paused) return;
            history.Add(new Entry { solution = solution , subhistory = subHistory});
        }

        /// <summary>
        /// Reads all history from youngest to oldest
        /// </summary>
        /// <returns>"{a} {operator} {b} = {result} \n" {next entry} ...</returns>
        public string ReadAll()
        {
            string result = "";
            foreach (Entry entry in history)
            {
                result += "-----------------------\n";
                result = entry.ToString() + "\n" + result;
                result += "-----------------------\n";
            }
            result = result + "End of History";
            return result;
        }
    }


}
