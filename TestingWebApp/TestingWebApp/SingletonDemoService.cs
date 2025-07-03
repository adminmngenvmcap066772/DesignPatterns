public class SingletonDemoService : ILifetimeDemoService
{
    private readonly Guid _operationId = Guid.NewGuid();
    public Guid GetOperationId() => _operationId;
}