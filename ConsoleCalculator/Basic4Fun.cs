using System;
using System.Collections.Generic;

public class Basic4Fun
{
    //Constructor
    protected History history;
    public Basic4Fun(bool enabledHistory = true)
	{
        history = new History(enabled:enabledHistory);
    }

	public override string ToString()
	{
		return "4 Function Calculator";
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
        history.AddEntry(a.ToString() + " " + op + " " + b.ToString() + " = " + result.ToString());
	}
    protected void AddToHistory(double a, char op, double b, double result)
    {
        history.AddEntry(a.ToString() + " " + op + " " + b.ToString() + " = " + result.ToString());
    }
    protected void AddToHistory(float a, char op, float b, float result)
    {
        history.AddEntry(a.ToString() + " " + op + " " + b.ToString() + " = " + result.ToString());
    }

	public string GetAllHistory()
	{
		return history.ReadAll();
	}
	public string GetRecentHistory()
	{
		return history.ReadRecent();
	}

	public void ClearHistory()
	{
		history.Clear();
	}
	public void PauseHistory()
	{
		history.Pause();
	}
	public void ResumeHistory()
	{
		history.Resume();
	}
}
