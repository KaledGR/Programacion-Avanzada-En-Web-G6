using AP.Data.Models;
using AP.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.Core.BusinessLogic
{
    public interface ISourceBusiness
    {
        Task<IEnumerable<Source>> GetSource(int? id);
        Task<bool> SaveSourceAsync(Source Source);
        Task<bool> DeleteSourceAsync(int id);
    }

    public class SourceBusiness(IRepositorySource repositorySource) : ISourceBusiness
    {
        public async Task<IEnumerable<Source>> GetSource(int? id)
        {
            return (IEnumerable<Source>)(id == null
                ? await repositorySource.ReadAsync()
                : [await repositorySource.FindAsync((int)id)]);
        }

        public async Task<bool> SaveSourceAsync(Source Source)
        {

            return await repositorySource.UpdateAsync(Source);
        }

        public async Task<bool> DeleteSourceAsync(int id)
        {
            var Source = await repositorySource.FindAsync(id);
            return await repositorySource.DeleteAsync(Source);
        }
    }
}
