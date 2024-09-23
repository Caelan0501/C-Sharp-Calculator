using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Calculator;

[ServiceContract]
public interface ICalculatorService
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
	int Mod(string a, string b);
	[OperationContract]
	double Power(string a, string b);
	[OperationContract]
	double Root(string a, string b);
	[OperationContract]
	double SolveArithmetic (string equation);

	[OperationContract]
	int intergerAdd(int a, int b);
	[OperationContract]
	int integerSubtract(int a, int b);
	[OperationContract]
	int intergerMultiply(int a, int b);
	[OperationContract]
	int intergerDivide(int a, int b);
	[OperationContract]
	int integerMod(int a, int b);
	[OperationContract]
	int integerPower(int a, int b);
    [OperationContract]
    int integerRoot(int a, int b);

    [OperationContract]
	double doubleAdd(double a, double b);
	[OperationContract]
	double doubleSubtract(double a, double b);
	[OperationContract]
	double doubleMultiply(double a, double b);
	[OperationContract]
	double doubleDivide(double a, double b);
    [OperationContract]
    double doublePower(double a, double b);
    [OperationContract]
    double doubleRoot(double a, double b);

    [OperationContract]
	float floatAdd(float a, float b);
	[OperationContract]
	float floatSubtract(float a, float b);
	[OperationContract]
	float floatMultiply(float a, float b);
	[OperationContract]
	float floatDivide(float a, float b);
    [OperationContract]
    float floatPower(float a, float b);
    [OperationContract]
    float floatRoot(float a, float b);
}