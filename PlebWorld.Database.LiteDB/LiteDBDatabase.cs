using LiteDB;
using System;
using System.Collections.Generic;

namespace PlebWorld.Database.LiteDB
{
	public class LiteDBDatabase : IDatabase
	{
		private Dictionary<Type, object> collections = new Dictionary<Type, object>();

		private LiteDatabase liteDatabase;

		public LiteDBDatabase(string connectionString)
		{
			liteDatabase = new LiteDatabase(connectionString);
		}

		public IDatabaseCollection<T> GetCollection<T>() where T : IID, new()
		{
			if (collections.TryGetValue(typeof(T), out object value) && value is IDatabaseCollection<T> t)
			{
				return t;
			}

			ILiteCollection<T> collection = liteDatabase.GetCollection<T>();

			LiteDBDatabaseCollection<T> result = new LiteDBDatabaseCollection<T>(liteDatabase.GetCollection<T>());

			collections.Add(typeof(T), result);

			return result;
		}
	}
}
