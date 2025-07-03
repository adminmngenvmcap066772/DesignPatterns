public class TransientDemoService : ILifetimeDemoService
{
    private readonly Guid _operationId = Guid.NewGuid();
    public Guid GetOperationId() => _operationId;
}