using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.DataAccess.Common.Interfaces
{
    public interface IBaseRepository <T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetEntityByEntityId(int entityId);
        Task InsertEntityAsync(T entity);
    }
}
