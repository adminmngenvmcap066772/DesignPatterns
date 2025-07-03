public class ScopedDemoService : ILifetimeDemoService
{
    private readonly Guid _operationId = Guid.NewGuid();
    public Guid GetOperationId() => _operationId;
}