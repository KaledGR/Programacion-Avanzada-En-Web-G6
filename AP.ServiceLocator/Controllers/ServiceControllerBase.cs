using AP.Models.DTOs;
using AP.ServiceLocator.Helper;
using Microsoft.AspNetCore.Mvc;

namespace AP.ServiceLocator.Controllers
{
    public class ServiceControllerBase : ControllerBase
    {
        protected readonly Dictionary<string, Func<Task<IEnumerable<object>>>> ServiceResolvers;
        protected ServiceControllerBase(IServiceMapper serviceMapper)
        {
            ServiceResolvers = new()
            {
                
                ["source"] = async () =>
                {
                    // defer resolution until invocation time
                    var service = await serviceMapper.GetServiceAsync<SourceDTO>("source");
                    var data = await service.GetDataAsync();
                    return data.Cast<object>();
                },
                ["task"] = async () =>
                {
                    // defer resolution until invocation time
                    var service = await serviceMapper.GetServiceAsync<TaskDTO>("task");
                    var data = await service.GetDataAsync();
                    return data.Cast<object>();
                },
                ["sourceItem"] = async () =>
                {
                    // defer resolution until invocation time
                    var service = await serviceMapper.GetServiceAsync<SourceItemDTO>("sourceItem");
                    var data = await service.GetDataAsync();
                    return data.Cast<object>();
                },

            };
        }
    }
}
