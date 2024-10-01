using Grpc.Core;
using gRPCCalculatorService;

namespace gRPCCalculatorService.Services;

public class GreeterService : Greeter.GreeterBase //Geeter.GreeterBase is auto-generated
{
    private readonly ILogger<GreeterService> _logger;
    public GreeterService(ILogger<GreeterService> logger)
    {
        _logger = logger;
    }

    public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
    {
        return Task.FromResult(new HelloReply
        {
            Message = "Hello " + request.Name
        });
    }
}
