using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace PlebWorld.Database.LiteDB
{
	internal class LiteDBDatabaseCollection<T> : IDatabaseCollection<T> where T : IID, new()
	{
		private readonly ILiteCollection<T> liteCollection;

		internal LiteDBDatabaseCollection(ILiteCollection<T> liteCollection)
		{
			this.liteCollection = liteCollection;
		}

		public void Add(T value)
		{
			liteCollection.Insert(value);
		}

		public T Create()
		{
			T value = new T();

			Add(value);

			return value;
		}

		public T Get(Guid id)
		{
			return liteCollection.FindById(id);
		}

		public IEnumerable<T> GetAll()
		{
			return liteCollection.FindAll();
		}

		public bool Remove(Guid id)
		{
			return liteCollection.Delete(id);
		}

		public bool Update(T value)
		{
			return liteCollection.Update(value);
		}

		public bool Upsert(T value)
		{
			return liteCollection.Upsert(value);
		}

		public IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate)
		{
			return liteCollection.Find(predicate);
		}

		public T Get(Expression<Func<T, bool>> predicate)
		{
			return liteCollection.Find(predicate, limit: 1).FirstOrDefault();
		}
	}
}
