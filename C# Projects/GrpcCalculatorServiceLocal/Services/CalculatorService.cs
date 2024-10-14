using Grpc.Core;
using GrpcCalculatorServiceLocal;
using Calculator;
using Google.Protobuf.WellKnownTypes;

namespace GrpcCalculatorServiceLocal.Services
{
    public class CalculatorService : Calculator.CalculatorBase
    {
        private readonly ILogger<GreeterService> _logger;
        public CalculatorService(ILogger<GreeterService> logger)
        {
            _logger = logger;
        }

        public override Task<Response> Add(Nums request, ServerCallContext context)
        {
            double n1 = request.N1;
            double n2 = request.N2;
            Response result = new Response();
            result.Result = Function.Add(n1, n2);
            return Task.FromResult(result);
        }
        public override Task<Response> Subtract(Nums request, ServerCallContext context)
        {
            double n1 = request.N1;
            double n2 = request.N2;
            Response result = new Response();
            result.Result = Function.Subtract(n1, n2);
            return Task.FromResult(result);
        }
        public override Task<Response> Multiply(Nums request, ServerCallContext context)
        {
            double n1 = request.N1;
            double n2 = request.N2;
            Response result = new Response();
            result.Result = Function.Subtract(n1, n2);
            return Task.FromResult(result);
        }
        public override Task<Response> Divide(Nums request, ServerCallContext context)
        {
            double n1 = request.N1;
            double n2 = request.N2;
            Response result = new Response();
            result.Result = Function.Divide(n1, n2);
            return Task.FromResult(result);
        }
        public override Task<Response> Mod(Ints request, ServerCallContext context)
        {
            int n1 = request.N1;
            int n2 = request.N2;
            Response result = new Response();
            result.Result = Function.Mod(n1, n2);
            return Task.FromResult(result);
        }
        public override Task<Response> Power(Nums request, ServerCallContext context)
        {
            double n1 = request.N1;
            double n2 = request.N2;
            Response result = new Response();
            result.Result = Function.Power(n1, n2);
            return Task.FromResult(result);
        }
        public override Task<Response> Root(Nums request, ServerCallContext context)
        {
            double n1 = request.N1;
            double n2 = request.N2;
            Response result = new Response();
            result.Result = Function.Root(n1, n2);
            return Task.FromResult(result);
        }
        public override Task<Response> Abs(Num request, ServerCallContext context)
        {
            double n = request.N;
            Response result = new Response();
            result.Result = Function.Abs(n);
            return Task.FromResult(result);
        }
        public override Task<Response> Sin(Angle request, ServerCallContext context)
        {
            double a = request.A;
            bool degrees = request.Degrees;
            Response result = new Response();
            result.Result = Function.Sin(a, degrees);
            return Task.FromResult(result);
        }
        public override Task<Response> Cos(Angle request, ServerCallContext context)
        {
            double a = request.A;
            bool degrees = request.Degrees;
            Response result = new Response();
            result.Result = Function.Cos(a, degrees);
            return Task.FromResult(result);
        }
        public override Task<Response> Tan(Angle request, ServerCallContext context)
        {
            double a = request.A;
            bool degrees = request.Degrees;
            Response result = new Response();
            result.Result = Function.Tan(a, degrees);
            return Task.FromResult(result);
        }
        public override Task<Response> Sinh(Angle request, ServerCallContext context)
        {
            double a = request.A;
            bool degrees = request.Degrees;
            Response result = new Response();
            result.Result = Function.Sinh(a, degrees);
            return Task.FromResult(result);
        }
        public override Task<Response> Cosh(Angle request, ServerCallContext context)
        {
            double a = request.A;
            bool degrees = request.Degrees;
            Response result = new Response();
            result.Result = Function.Cosh(a, degrees);
            return Task.FromResult(result);

        }
        public override Task<Response> Tanh(Angle request, ServerCallContext context)
        {
            double a = request.A;
            bool degrees = request.Degrees;
            Response result = new Response();
            result.Result = Function.Tanh(a, degrees);
            return Task.FromResult(result);
        }
        public override Task<Response> Asin(Angle request, ServerCallContext context)
        {
            double a = request.A;
            bool degrees = request.Degrees;
            Response result = new Response();
            result.Result = Function.Asin(a, degrees);
            return Task.FromResult(result);
        }
        public override Task<Response> Acos(Angle request, ServerCallContext context)
        {
            double a = request.A;
            bool degrees = request.Degrees;
            Response result = new Response();
            result.Result = Function.Acos(a, degrees);
            return Task.FromResult(result);
        }
        public override Task<Response> Atan(Angle request, ServerCallContext context)
        {
            double a = request.A;
            bool degrees = request.Degrees;
            Response result = new Response();
            result.Result = Function.Atan(a, degrees);
            return Task.FromResult(result);
        }
        public override Task<Response> Asinh(Angle request, ServerCallContext context)
        {
            double a = request.A;
            bool degrees = request.Degrees;
            Response result = new Response();
            result.Result = Function.Asinh(a, degrees);
            return Task.FromResult(result);
        }
        public override Task<Response> Acosh(Angle request, ServerCallContext context)
        {
            double a = request.A;
            bool degrees = request.Degrees;
            Response result = new Response();
            result.Result = Function.Acosh(a, degrees);
            return Task.FromResult(result);

        }
        public override Task<Response> Atanh(Angle request, ServerCallContext context)
        {
            double a = request.A;
            bool degrees = request.Degrees;
            Response result = new Response();
            result.Result = Function.Atanh(a, degrees);
            return Task.FromResult(result);
        }
        public override Task<Response> Ln(Num request, ServerCallContext context)
        {
            double n = request.N;
            Response result = new Response();
            result.Result = Function.Ln(n);
            return Task.FromResult(result);
        }
        public override Task<Response> Log(Nums request, ServerCallContext context)
        {
            double n1 = request.N1;
            double n2 = request.N2;
            Response result = new Response();
            result.Result = Function.Log(n1, n2);
            return Task.FromResult(result);
        }

        public override Task<Response> Pythagorean(PythagoreanRequest request, ServerCallContext context) 
        {
            double? a = request.A;
            double? b = request.B;
            double? c = request.C;
            Response result = new Response();
            result.Result = Formula.Pythagorean(a, b, c);
            return Task.FromResult(result);
        }
        public override Task<Response> Sum(NumList request, ServerCallContext context)
        {
            double[] a = request.A.ToArray<double>();
            Response result = new Response();
            result.Result = Formula.Sum(a);
            return Task.FromResult(result);
        }
        public override Task<Response> Mean(NumList request, ServerCallContext context)
        {
            double[] a = request.A.ToArray<double>();
            Response result = new Response();
            result.Result = Formula.Mean(a);
            return Task.FromResult(result);
        }

        public override Task<Response> Aritmetic(Equation request, ServerCallContext context)
        {
            string e = request.E;
            Response result = new Response();
            result.Result = Arithmetic.Solve(e);
            return Task.FromResult(result);
        }
    }
}
