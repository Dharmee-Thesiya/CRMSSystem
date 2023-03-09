using CRMSSystem.Core.Models;
using System.Linq;

namespace CRMSSystem.Core.Context
{
    public interface IMRepository<T> where T : BaseEntity
    {
        IQueryable<T> Collection();
        void Commit();
        void Delete(string Id);
        T Find(string Id);
        void Insert(T t);
        void Update(T t);
    }
}