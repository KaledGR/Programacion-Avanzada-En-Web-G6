using AP.Data.Models;
using AP.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace AP.Core.BusinessLogic
{
    public interface ISourceItemBusiness
    {
        Task<IEnumerable<SourceItem>> GetSourceItem(int? id);
        Task<bool> SaveSourceItemAsync(SourceItem SourceItem);
        Task<bool> DeleteSourceItemAsync(int id);
    }

    public class SourceItemBusiness(IRepositorySourceItem repositorySourceItem) : ISourceItemBusiness
    {
        public async Task<IEnumerable<SourceItem>> GetSourceItem(int? id)
        {
            return (IEnumerable<SourceItem>)(id == null
                ? await repositorySourceItem.ReadAsync()
                : [await repositorySourceItem.FindAsync((int)id)]);
        }

        public async Task<bool> SaveSourceItemAsync(SourceItem SourceItem)
        {

            return await repositorySourceItem.UpdateAsync(SourceItem);
        }

        public async Task<bool> DeleteSourceItemAsync(int id)
        {
            var SourceItem = await repositorySourceItem.FindAsync(id);
            return await repositorySourceItem.DeleteAsync(SourceItem);
        }
    }
}
