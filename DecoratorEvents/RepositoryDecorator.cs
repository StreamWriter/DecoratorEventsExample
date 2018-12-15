using System;
using System.Collections.Generic;
using System.Text;

namespace DecoratorEvents
{
    public class RepositoryDecorator<T> : IRepository<T> where T : DbItem, new()
    {
        private IRepository<T> _repository;
        public event EventHandler<DatabaseOperationEventArgs> DatabaseOperation;

        public RepositoryDecorator(IRepository<T> repository)
        {
            _repository = repository;
        }

        protected virtual void OnDatabaseOperation(DatabaseOperationEventArgs e)
        {
            DatabaseOperation?.Invoke(this, e);
        }

        public void Add(T item)
        {
            OnDatabaseOperation(new DatabaseOperationEventArgs() { OperationName = "Add", EntityType = typeof(T).Name.ToString(), AffectedEntityId = item.Id });
            _repository.Add(item);
        }

        public T Get(int id)
        {
            OnDatabaseOperation(new DatabaseOperationEventArgs() { OperationName = "Get", EntityType = typeof(T).Name.ToString(), AffectedEntityId = id });
            return _repository.Get(id);
        }
    }
}
