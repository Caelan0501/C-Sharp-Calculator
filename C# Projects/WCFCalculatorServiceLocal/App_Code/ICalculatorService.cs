using System.ServiceModel;

[ServiceContract]
public interface IWCFCalculatorServiceLocal
{
	[OperationContract]
	double Add(string a, string b);
	[OperationContract]
	double Subtract(string a, string b);
	[OperationContract]
	double Multiply(string a, string b);
	[OperationContract]
	double Divide(string a, string b);
	[OperationContract]
	double Mod(string a, string b);
	[OperationContract]
	double Power(string a, string b);
	[OperationContract]
	double Root(string a, string b);
	[OperationContract]
	double SolveArithmetic (string equation);
}