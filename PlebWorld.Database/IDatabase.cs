using System;
using System.Collections.Generic;
using System.Text;

namespace PlebWorld.Database
{
	public interface IDatabase
	{
		IDatabaseCollection<T> GetCollection<T>() where T : IID, new();
	}
}
