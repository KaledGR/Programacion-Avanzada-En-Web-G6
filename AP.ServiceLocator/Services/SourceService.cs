using AP.Architecture;
using AP.Architecture.Providers;
using AP.Models.DTOs;
using AP.ServiceLocator.Services.Contracts;

namespace AP.ServiceLocator.Services
{
   
        public interface ISourceService
        {
            Task<IEnumerable<SourceDTO>> GetDataAsync();
        }

        public class SourceService(IRestProvider restProvider, IConfiguration configuration) : IService<SourceDTO>, ISourceService
        {
            public async Task<IEnumerable<SourceDTO>> GetDataAsync()
            {
                var url = configuration.GetStringFromAppSettings("APIS", "Source");
                var response = await restProvider.GetAsync(url, null);
                return await JsonProvider.DeserializeAsync<IEnumerable<SourceDTO>>(response);
            }

        }
    
}
