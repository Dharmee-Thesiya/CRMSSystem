 using CRMSSystem.Core.Models;
using System;
using System.Linq;

namespace CRMSSystem.Core.Contracts
{
    //interface for main repository, we can use it also as generic//
    public interface IMRepository<T> where T : BaseEntity
    {
        IQueryable<T> Collection();
        void Commit();
        
        void Delete(Guid Id);
        T Find(Guid Id);
        void Insert(T t);
        void Update(T t);
       
    }
}