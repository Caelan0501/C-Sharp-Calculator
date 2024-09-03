using System;
using System.Collections.Generic;

public class History
{
    private List<String> history;
    private bool enabled;
    private bool isChanged;

    public History(bool enabled = true)
    {
        history = new List<String>();
        this.enabled = enabled;
        isChanged = true;
    }
    public void Clear()
    {
        history.Clear();
        enabled = true;
    }
    public void Resume()
    {
        enabled = true;
    }
    public void Pause()
    {
        enabled = false;
    }
    public bool IsEnabled()
    {
        return enabled;
    }
    public void AddEntry(string entry)
    {
        if (enabled)
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

