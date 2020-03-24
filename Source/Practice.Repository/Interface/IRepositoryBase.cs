using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Repository.Interface
{
    public interface IRepositoryBase<T>
    {
        Task<IList<T>> GetList();
        Task<T> GetById(int internalId);
        Task<T> Update(T item);
        Task<T> Save(T item);
        void Delete(int internalId);
    }
}
