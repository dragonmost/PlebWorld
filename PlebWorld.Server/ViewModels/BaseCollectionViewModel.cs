using PlebWorld.Database;
using PlebWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using Vildmark.DependencyServices;

namespace PlebWorld.Server.ViewModels
{
	internal abstract class BaseCollectionViewModel<TModel, TViewModel>
		where TModel : IID, new()
		where TViewModel : BaseViewModel<TModel>
	{
		protected IDatabase Database { get; }
		protected IDatabaseCollection<TModel> Collection { get; }

		protected BaseCollectionViewModel()
		{
			Database = DependencyService.Global.Get<IDatabase>();
			Collection = Database.GetCollection<TModel>();
		}
	}
}
