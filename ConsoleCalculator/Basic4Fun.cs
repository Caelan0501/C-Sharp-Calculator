using System;
using System.Collections.Generic;

public class Basic4Fun
{
    private List<String>? History;
    private int? Ihistory;

    //Constructor
    public Basic4Fun(bool enableHistory = false)
	{
		if (enableHistory)
		{
            History = new List<String>();
            Ihistory = 0;
        }
    }

	public override string ToString()
	{
		return "4 Function Calculator";
	}
	//History
	public void ClearHistory()
	{
		if(History != null) History.Clear();
	}
	/// <summary>
	/// Reads the Last entry, Multiple uses will iterate backwards
	/// </summary>
	/// <returns>"{a} {operator} {b} = {result} \n"</returns>
	public string ReadRecentHistory()
	{
        if (Ihistory == null) return "";
        if (History == null) return "";
        if (History.Count == Ihistory)
		{
			return "No Futher History";
		}
		string history = History[History.Count - Ihistory.GetValueOrDefault() - 1];
        Ihistory++;
        return history;
	}
    /// <summary>
    /// Reads all history from youngest to oldest
    /// </summary>
    /// <returns>"{a} {operator} {b} = {result} \n" {next entry} ...</returns>
    public string ReadAllHistory()
	{
		if (History == null) return "";

		Ihistory = 0;
		string result = "";
		foreach (string entry in History)
		{
			result = entry + "\n" + result;
		}
		result = result + "End of History";
		return result;
	}

	//Integer 5 function
	public int Add(int a, int b)
	{
		AddToHistory(a, '+', b, a + b);
        return a + b;
	}
	public int Subtract(int a, int b)
	{
        AddToHistory(a, '-', b, a - b);
        return a - b;
	}
	public int Multiply(int a, int b)
	{
        AddToHistory(a, '*', b, a * b);
        return a * b;
	}
	public int Divide(int a, int b)
	{
        AddToHistory(a, '/', b, a / b);
        return a / b;
	}
	public int Mod(int a, int b)
	{
        AddToHistory(a, '%', b, a % b);
        return a % b;
	}
	
	//Double 4 function
	public double Add(double a, double b)
	{
        AddToHistory(a, '+', b, a + b);
        return a + b;
	}
	public double Subtract(double a, double b)
	{
        AddToHistory(a, '-', b, a - b);
        return a - b;
	}
	public double Multiply(double a, double b)
	{
        AddToHistory(a, '*', b, a * b);
        return a * b;
	}
	public double Divide(double a, double b)
	{
        AddToHistory(a, '/', b, a / b);
        return a / b;
	}

	//float 4 function
	public float Add(float a, float b)
	{
        AddToHistory(a, '+', b, a + b);
        return a + b;
	}
	public float Subtract(float a, float b)
	{
        AddToHistory(a, '-', b, a - b);
        return a - b;
	}
	public float Multiply(float a, float b)
	{
        AddToHistory(a, '*', b, a * b);
        return a * b;
	}
	public float Divide(float a, float b)
	{
        AddToHistory(a, '/', b, a / b);
        return a / b;
	}

	//string 5 function
	//Impebedding convertion to doubles
	public double Add(string aS, string bS)
	{
        double a = Double.Parse(aS);
		double b = Double.Parse(bS);
        AddToHistory(a, '+', b, a + b);
        return a + b;
	}
    public double Subtract(string aS, string bS)
    {
        double a = Double.Parse(aS);
        double b = Double.Parse(bS);
        AddToHistory(a, '-', b, a - b);
        return a - b;
    }
    public double Multiply(string aS, string bS)
    {
        double a = Double.Parse(aS);
        double b = Double.Parse(bS);
        AddToHistory(a, '*', b, a * b);
        return a * b;
    }
    public double Divide(string aS, string bS)
    {
        double a = Double.Parse(aS);
        double b = Double.Parse(bS);
        AddToHistory(a, '/', b, a / b);
        return (a / b);
    }
	public int? Mod (string aS, string bS)
	{
		int a;
		int b;
		bool status = int.TryParse(aS, out a);
		if (status)
		{
            status = int.TryParse(bS, out b);
        }
		else
		{
			return null;
		}
		if (status)
		{
            AddToHistory(a, '%', b, a % b);
            return a % b;
        }
		return null;
	}

	protected void AddToHistory(int a, char op, int b, int result)
	{
		if (History != null)
		{
            Ihistory = 0;
            History.Add(a.ToString() + " " + op + " " + b.ToString() + " = " + result.ToString());
        }
	}
    protected void AddToHistory(double a, char op, double b, double result)
    {
        if (History != null)
        {
            Ihistory = 0;
            History.Add(a.ToString() + " " + op + " " + b.ToString() + " = " + result.ToString());
        }
    }
    protected void AddToHistory(float a, char op, float b, float result)
    {
        if (History != null)
        {
            Ihistory = 0;
            History.Add(a.ToString() + " " + op + " " + b.ToString() + " = " + result.ToString());
        }
    }
}
