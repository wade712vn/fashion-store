using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FashionStore.Core.Data
{
    public interface IRepository<T> where T : BaseEntity
    {
        T GetById(object id);
        void Insert(T[] entities);
        void Update(T[] entities);
        void Delete(T[] entities);
        IQueryable<T> Table { get; }
    }
}
