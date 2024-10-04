using Grpc.Core;
using GrpcCalculatorServiceLocal;
using Calculator;

namespace GrpcCalculatorServiceLocal.Services
{
    public class CalculatorService : Calculator.CalculatorBase
    {
        private readonly ILogger<GreeterService> _logger;
        public CalculatorService(ILogger<GreeterService> logger)
        {
            _logger = logger;
        }

        public override Task<Result> Add(Parameters request, ServerCallContext context)
        {
            Result result = new Result();
            result.Solution = Double.Parse(Function.Add(request.A, request.B));
            return Task.FromResult(result);
        }
    }
}
