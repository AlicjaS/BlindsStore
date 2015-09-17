using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Blinds02.Models
{
    public class Repository<T> where T : class
    {
        private Blinds02Context context = new Blinds02Context();

        protected DbSet<T> DbSet { get; set; }

        public Repository()
        {
            DbSet = context.Set<T>();
        }

        public List<X> GetOtherDbSet<X>() where X : class
        {
            DbSet<X> newList = context.Set<X>();
            return newList.ToList();
        }

        public virtual List<T> GetAll()
        {
            return DbSet.ToList();
        }

        public virtual T Get(int? id)
        {
            return DbSet.Find(id);
        }

        public virtual void Add(T entity)
        {
            DbSet.Add(entity);
        }
        public virtual void Modify(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Remove(T entity)
        {
            DbSet.Remove(entity);
        }

        public virtual void SaveChanges()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}