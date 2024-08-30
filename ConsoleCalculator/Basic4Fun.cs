using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;

public class Basic4Fun
{
	//Constructor
	public Basic4Fun()
	{
        History = new List<String>();
		Ihistory = 0;
    }
	public string ToString()
	{
		return "4 Function Calculator";
	}
	//History
	List<String> History;
	int Ihistory;
	public void ClearHistory()
	{
		History.Clear();
	}
	/// <summary>
	/// Reads the Last entry, Multiple uses will iterate backwards
	/// </summary>
	/// <returns>"{a} {operator} {b} = {result} \n"</returns>
	public string ReadRecentHistory()
	{
		if (History.Count == Ihistory)
		{
			return "No Futher History";
		}
		string history = History[History.Count - Ihistory - 1];
        Ihistory++;
        return history;
	}
    /// <summary>
    /// Reads all history from youngest to oldest
    /// </summary>
    /// <returns>"{a} {operator} {b} = {result} \n" {next entry} ...</returns>
    public string ReadAllHistory()
	{
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
        Ihistory = 0;
        History.Add(a.ToString() + " + " + b.ToString() + " = " + (a + b).ToString());
		return a + b;
	}
	public int Subtract(int a, int b)
	{
        Ihistory = 0;
        History.Add(a.ToString() + " - " + b.ToString() + " = " + (a + b).ToString());
        return a - b;
	}
	public int Multiply(int a, int b)
	{
        Ihistory = 0;
        History.Add(a.ToString() + " * " + b.ToString() + " = " + (a + b).ToString());
        return a * b;
	}
	public int Divide(int a, int b)
	{
        Ihistory = 0;
        History.Add(a.ToString() + " / " + b.ToString() + " = " + (a + b).ToString());
        return a / b;
	}
	public int Mod(int a, int b)
	{
        Ihistory = 0;
        History.Add(a.ToString() + " % " + b.ToString() + " = " + (a + b).ToString());
        return a % b;
	}
	
	//Double 4 function
	public double Add(double a, double b)
	{
        Ihistory = 0;
        History.Add(a.ToString() + " + " + b.ToString() + " = " + (a + b).ToString());
        return a + b;
	}
	public double Subtract(double a, double b)
	{
        Ihistory = 0;
        History.Add(a.ToString() + " - " + b.ToString() + " = " + (a - b).ToString());
        return a - b;
	}
	public double Multiply(double a, double b)
	{
        Ihistory = 0;
        History.Add(a.ToString() + " * " + b.ToString() + " = " + (a * b).ToString());
        return a * b;
	}
	public double Divide(double a, double b)
	{
        Ihistory = 0;
        History.Add(a.ToString() + " / " + b.ToString() + " = " + (a / b).ToString());
        return a / b;
	}

	//float 4 function
	public float Add(float a, float b)
	{
        Ihistory = 0;
        History.Add(a.ToString() + " + " + b.ToString() + " = " + (a + b).ToString());
        return a + b;
	}
	public float Subtract(float a, float b)
	{
        Ihistory = 0;
        History.Add(a.ToString() + " - " + b.ToString() + " = " + (a - b).ToString());
        return a - b;
	}
	public float Multiply(float a, float b)
	{
        Ihistory = 0;
        History.Add(a.ToString() + " * " + b.ToString() + " = " + (a * b).ToString());
        return a * b;
	}
	public float Divide(float a, float b)
	{
        Ihistory = 0;
        History.Add(a.ToString() + " / " + b.ToString() + " = " + (a / b).ToString());
        return a / b;
	}

	//string 5 function
	//Impebedding convertion to doubles
	public double Add(string aS, string bS)
	{
		Ihistory = 0;
		double a = Double.Parse(aS);
		double b = Double.Parse(bS);
        History.Add(a.ToString() + " + " + b.ToString() + " = " + (a + b).ToString());
        return a + b;
	}
    public double Subtract(string aS, string bS)
    {
        Ihistory = 0;
        double a = Double.Parse(aS);
        double b = Double.Parse(bS);
        History.Add(a.ToString() + " - " + b.ToString() + " = " + (a - b).ToString());
        return a - b;
    }
    public double Multiply(string aS, string bS)
    {
        Ihistory = 0;
        double a = Double.Parse(aS);
        double b = Double.Parse(bS);
        History.Add(a.ToString() + " * " + b.ToString() + " = " + (a * b).ToString());
        return a * b;
    }
    public double Divide(string aS, string bS)
    {
        Ihistory = 0;
        double a = Double.Parse(aS);
        double b = Double.Parse(bS);
        History.Add(a.ToString() + " / " + b.ToString() + " = " + (a / b).ToString());
        return (a / b);
    }
	public int? Mod (string aS, string bS)
	{
		Ihistory = 0;
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
            History.Add(a.ToString() + " % " + b.ToString() + " = " + (a % b).ToString());
            return a % b;
        }
		return null;
	}
}
