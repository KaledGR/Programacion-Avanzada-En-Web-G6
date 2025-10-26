using AP.Models.DTOs;
using AP.ServiceLocator.Services.Contracts;


namespace AP.ServiceLocator.Helper;

public interface IServiceMapper
{
    Task<IService<T>> GetServiceAsync<T>(string name);
}

public class ServiceMapper : IServiceMapper
{
    private readonly IServiceProvider serviceProvider;

    public ServiceMapper(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
    }

    public Task<IService<T>> GetServiceAsync<T>(string name)
    {
        var service = name.ToLower() switch
        {

            "sourceItem" => (IService<T>)serviceProvider.GetRequiredService<IService<SourceItemDTO>>(),
            "task" => (IService<T>)serviceProvider.GetRequiredService<IService<TaskDTO>>(),
            "source" => (IService<T>)serviceProvider.GetRequiredService<IService<SourceDTO>>(),
            _ => throw new ArgumentException($"Service not found for '{name}'")
        };

        return Task.FromResult(service);
    }

}

