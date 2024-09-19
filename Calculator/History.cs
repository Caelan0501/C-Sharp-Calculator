using System;
using System.Collections.Generic;

namespace Calculator
{
    public class History
    {
        private List<string>? history;
        private bool paused;
        private bool isChanged;

        public History(bool enabled = true)
        {
            paused = false;
            isChanged = true;
            if (enabled)
            {
                history = new List<string>();
            }
        }
        public void Clear()
        {
            if (history != null) history.Clear();
        }
        public void Resume()
        {
            paused = false;
        }
        public void Pause()
        {
            paused = true;
        }
        public bool IsEnabled()
        {
            return history == null;
        }
        public void AddEntry(string entry)
        {
            if (!(history == null) && !paused)
            {
                history.Add(entry);
                isChanged = true;
            }
        }

        /// <summary>
        /// Reads all history from youngest to oldest
        /// </summary>
        /// <returns>"{a} {operator} {b} = {result} \n" {next entry} ...</returns>
        public string ReadAll()
        {
            if (history == null) return "";
            string result = "";
            foreach (string entry in history)
            {
                result = entry + "\n" + result;
            }
            result = result + "End of History";
            return result;
        }

        int recentcyIndex = 0;
        public string ReadRecent()
        {
            if (history == null) return "";
            if (isChanged == true)
            {
                recentcyIndex = 0;
                isChanged = false;
            }
            if (recentcyIndex != history.Count)
            {
                string result = history[history.Count - recentcyIndex - 1];
                recentcyIndex++;
                return result;
            }
            return "No Further History";
        }
    }


}
