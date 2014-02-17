using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FashionStore.Core;
using FashionStore.Core.Data;

namespace FashionStore.EFData
{
    public class EfRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly IDbContext _context;
        private IDbSet<T> _entities;

        public EfRepository(IDbContext context)
        {
            _context = context;
        }

        public T GetById(object id)
        {
            try
            {
                return Entities.Find(id);
            }
            catch (DbEntityValidationException dbex)
            {
                
                throw;
            }
        }

        public void Insert(T[] entities)
        {
            try
            {
                foreach (var entity in entities)
                {
                    Entities.Add(entity);
                }
                _context.SaveChanges();
            }
            catch (DbEntityValidationException dbex)
            {
                
                throw;
            }
        }

        public void Update(T[] entities)
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException dbex)
            {
                
                throw;
            }
        }

        public void Delete(T[] entities)
        {
            try
            {
                foreach (var entity in entities)
                {
                    Entities.Remove(entity);
                }
                _context.SaveChanges();
            }
            catch (DbEntityValidationException dbex)
            {
                
                throw;
            }
        }

        public IQueryable<T> Table
        {
            get
            {
                return Entities;
            }
        }

        private IDbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                {
                    _entities = _context.Set<T>();
                }
                return _entities;
            }
        }
    }
}
