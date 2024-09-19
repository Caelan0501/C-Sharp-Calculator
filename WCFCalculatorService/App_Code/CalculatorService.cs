using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Runtime;
using Calculator;

public class CalculatorService : ICalculatorService
{
	
    public double Add(string a, string b)
    {
        Basic4Fun calc = new Basic4Fun();
        return calc.Add(a, b);
    }


    public CompositeType GetDataUsingDataContract(CompositeType composite)
	{
		if (composite == null)
		{
			throw new ArgumentNullException("composite");
		}
		if (composite.BoolValue)
		{
			composite.StringValue += "Suffix";
		}
		return composite;
	}
}
