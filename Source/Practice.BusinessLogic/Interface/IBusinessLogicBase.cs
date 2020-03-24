using Practice.Domain.Model.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Practice.BusinessLogic.Interface
{
    public interface IBusinessLogicBase<T> where T : class, IEntityBase
    {
        Task<IList<T>> GetList();
        Task<T> GetById(int internalId);
        Task<T> Update(T item);
        Task<T> Save(T item);
        void Delete(int internalId);
    }
}
