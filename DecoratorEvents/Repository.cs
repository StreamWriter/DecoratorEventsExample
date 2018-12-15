using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace DecoratorEvents
{
    public interface IRepository<T>
    {
        void Add(T item);
        T Get(int id);
    }

    public class Repository<T> : IRepository<T> where T : DbItem, new()
    {
        private IList<T> items = new List<T>();

        public void Add(T item)
        {
            items.Add(item);
        }

        public T Get(int id)
        {
            DbItem anon = new T() { Id = id };
            return items.SingleOrDefault(i => i.Equals(anon));
        }
    }
}
