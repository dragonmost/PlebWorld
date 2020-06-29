using PlebWorld.Models;
using PlebWorld.Server.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlebWorld.Server.ViewModels
{
	internal class ItemTypeViewModel : BaseViewModel<DBItemType>, IItemType
	{
		public ItemTypeViewModel(Guid id)
			: base(id)
		{
		}

		public string Name
		{
			get => GetValue(m => m.Name);
			set => SetValue(m => m.Name = value);
		}
	}
}
