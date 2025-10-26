using AP.Architecture;
using AP.Architecture.Providers;
using AP.Models.DTOs;
using AP.ServiceLocator.Services.Contracts;

namespace AP.ServiceLocator.Services
{
    public interface ISourceItemService
    {
        Task<IEnumerable<SourceItemDTO>> GetDataAsync();
    }

    public class SourceItemService(IRestProvider restProvider, IConfiguration configuration) : IService<SourceItemDTO>, ISourceItemService
    {
        public async Task<IEnumerable<SourceItemDTO>> GetDataAsync()
        {
            var url = configuration.GetStringFromAppSettings("APIS", "SourceItem");
            var response = await restProvider.GetAsync(url, null);
            return await JsonProvider.DeserializeAsync<IEnumerable<SourceItemDTO>>(response);
        }

    }
}
