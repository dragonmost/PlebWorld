using System;
using System.Collections.Generic;
using System.Text;

namespace PlebWorld.Models
{
	public interface ICollection<T> where T : IID
	{
		IEnumerable<T> GetAll();
		T Get(Guid id);
		T Create();
		bool Delete(Guid id);
	}
}
