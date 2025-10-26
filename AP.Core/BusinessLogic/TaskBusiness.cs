using AP.Data.Models;
using AP.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Task = AP.Data.Models.Task;

namespace AP.Core.BusinessLogic
{
    public interface ITaskBusiness
    {
        Task<IEnumerable<Task>> GetTask(int? id);
        Task<bool> SaveTaskAsync(Task task);
        Task<bool> DeleteTaskAsync(int id);
     
    }

    public class TaskBusiness(IRepositoryTask repositoryTask) : ITaskBusiness
    {
        public async Task<IEnumerable<Task>> GetTask(int? id)
        {
            return (IEnumerable<Task>)(id == null
                ? await repositoryTask.ReadAsync()
                : [await repositoryTask.FindAsync((int)id)]);
        }

        public async Task<bool> SaveTaskAsync(Task task)
        {

            return await repositoryTask.UpdateAsync(task);
        }

        public async Task<bool> DeleteTaskAsync(int id)
        {
            var task = await repositoryTask.FindAsync(id);
            return await repositoryTask.DeleteAsync(task);
        }

      
    }
}
