using AP.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace AP.Data.Repositories
{
    public interface IRepositorySourceItem
    {
        Task<bool> UpsertAsync(SourceItem entity, bool isUpdating);
        Task<bool> CreateAsync(SourceItem entity);
        Task<bool> DeleteAsync(SourceItem entity);
        Task<IEnumerable<SourceItem>> ReadAsync();
        Task<SourceItem> FindAsync(int id);
        Task<bool> UpdateAsync(SourceItem entity);
        Task<bool> UpdateManyAsync(IEnumerable<SourceItem> entities);
        Task<bool> ExistsAsync(SourceItem entity);
        Task<bool> CheckBeforeSavingAsync(SourceItem entity);
    }

    public class RepositorySourceItem : RepositoryBase<SourceItem>, IRepositorySourceItem
    {
        public async Task<bool> CheckBeforeSavingAsync(SourceItem entity)
        {
            var exists = await ExistsAsync(entity);
            return await UpsertAsync(entity, exists);
        }

        public async new Task<bool> ExistsAsync(SourceItem entity)
        {
            return await DbContext.SourceItems.AnyAsync(x => x.Id == entity.Id);
        }
    }
}
