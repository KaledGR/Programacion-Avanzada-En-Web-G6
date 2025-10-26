using AP.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.Data.Repositories
{
    public interface IRepositorySource
    {
        Task<bool> UpsertAsync(Source entity, bool isUpdating);
        Task<bool> CreateAsync(Source entity);
        Task<bool> DeleteAsync(Source entity);
        Task<IEnumerable<Source>> ReadAsync();
        Task<Source> FindAsync(int id);
        Task<bool> UpdateAsync(Source entity);
        Task<bool> UpdateManyAsync(IEnumerable<Source> entities);
        Task<bool> ExistsAsync(Source entity);
        Task<bool> CheckBeforeSavingAsync(Source entity);
    }

    public class RepositorySource : RepositoryBase<Source>, IRepositorySource
    {
        public async Task<bool> CheckBeforeSavingAsync(Source entity)
        {
            var exists = await ExistsAsync(entity);
            return await UpsertAsync(entity, exists);
        }

        public async new Task<bool> ExistsAsync(Source entity)
        {
            return await DbContext.Sources.AnyAsync(x => x.Id == entity.Id);
        }
    }
}
