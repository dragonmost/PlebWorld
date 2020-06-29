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
		protected IDatabase Database { get; }
		protected IDatabaseCollection<TModel> Collection { get; }

		protected TModel Model { get; private set; }

		public Guid ID
		{
			get => Model.ID;
			set => Model.ID = value;
		}

		protected BaseViewModel(Guid id)
		{
			Database = DependencyService.Global.Get<IDatabase>();
			Collection = Database.GetCollection<TModel>();

			Model = id == Guid.Empty ? Collection.Create() : Collection.Get(id);
		}

		protected void RefreshModel()
		{
			Model = Collection.Get(Model.ID);
		}

		protected void UpdateModel()
		{
			Collection.Update(Model);
		}

		protected void SetValue(Action<TModel> action)
		{
			action(Model);
			UpdateModel();
			RefreshModel();
		}

		protected T GetValue<T>(Func<TModel, T> func)
		{
			RefreshModel();
			return func(Model);
		}
	}
}
