package calculator;

import java.lang.String;
import java.util.ArrayList;
import java.util.List;


public class History 
{
	private record Entry(String solution, List<String> subhistory)
	{
		public String toString()
		{
		    String result = solution;
		    if (subhistory == null) return result;
		    for(String s : subhistory)
		    {
		        result += "\n---" + s;
		    }
		    return result;
		}
	};
	
	private List<Entry> history;
	private boolean paused;

	public History()
	{
	    paused = false;
	    history = new ArrayList<Entry>();
	}

	public void Start() { paused = false; }
	public void Pause() { paused = true; }
	public void Clear() { history.clear(); }

	public void AddEntry(String solution)
	{
	    if (paused) return;
	    history.add(new Entry (solution, null));
	}

	public void AddEntry(String solution, List<String> subHistory)
	{
	    if (paused) return;
	    history.add(new Entry(solution, subHistory));
	}

	/// <summary>
	/// Reads all history from youngest to oldest
	/// </summary>
	/// <returns>"{a} {operator} {b} = {result} \n" {next entry} ...</returns>
	public String ReadAll()
	{
	    String result = "";
	    for(Entry entry : history)
	    {
	        result += "-----------------------\n";
	        result = entry.toString() + "\n" + result;
	        result += "-----------------------\n";
	    }
	    result = result + "End of History";
	    return result;
	}
}
