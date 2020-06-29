using PlebWorld.Models;
using PlebWorld.Server.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlebWorld.Server.ViewModels
{
	internal class ItemViewModel : BaseViewModel<DBItem>, IItem
	{
		public ItemViewModel(Guid id = default)
			: base(id)
		{
		}

		public IItemType ItemType
		{
			get => new ItemTypeViewModel(GetValue(m => m.ItemTypeID));
			set => SetValue(m => m.ItemTypeID = value.ID);
		}

		public int Count { get; set; }
		public string Name { get; set; }
	}
}
