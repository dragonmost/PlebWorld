using PlebWorld.Database;
using System;
using System.Collections.Generic;
using System.Text;
using Vildmark.DependencyServices;

namespace PlebWorld.Server.ViewModels
{
	internal abstract class BaseViewModel<TModel> : IID
		where TModel : IID, new()
	{
		private readonly IDatabase database;
		private readonly IDatabaseCollection<TModel> collection;

		private TModel model;

		public Guid ID
		{
			get => model.ID;
			set => model.ID = value;
		}

		protected BaseViewModel(Guid id)
		{
			database = DependencyService.Global.Get<IDatabase>();
			collection = database.GetCollection<TModel>();

			model = id == Guid.Empty ? collection.Create() : collection.Get(id);
		}

		protected void RefreshModel()
		{
			model = collection.Get(model.ID);
		}

		protected void UpdateModel()
		{
			collection.Update(model);
		}

		protected void SetValue(Action<TModel> action)
		{
			action(model);
			UpdateModel();
		}

		protected T GetValue<T>(Func<TModel, T> func)
		{
			RefreshModel();
			return func(model);
		}
	}
}
