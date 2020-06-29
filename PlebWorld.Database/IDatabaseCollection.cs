using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace PlebWorld.Database
{
	public interface IDatabaseCollection<T> where T : IID, new()
	{
		T Create();
		T Get(Guid id);
		void Add(T value);
		bool Update(T value);
		bool Upsert(T value);
		bool Remove(Guid id);

		IEnumerable<T> GetAll();

		T Get(Expression<Func<T, bool>> predicate);
		IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate);
	}
}
