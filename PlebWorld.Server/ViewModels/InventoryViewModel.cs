using PlebWorld.Database;
using PlebWorld.Models;
using PlebWorld.Server.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlebWorld.Server.ViewModels
{
	internal class InventoryViewModel : BaseViewModel<DBInventory>, IInventory
	{
		public InventoryViewModel(Guid id = default)
			: base(id)
		{

		}

		public IEnumerable<IItem> Items => GetValue(m => m.ItemIDs).Select(id => new ItemViewModel(id)).ToArray();

		public int Slots
		{
			get => GetValue(m => m.Slots);
			set => SetValue(m => m.Slots = value);
		}

		public string Name
		{
			get => GetValue(m => m.Name);
			set => SetValue(m => m.Name = value);
		}
		 
		public IItem GetItem(int slot)
		{
			throw new NotImplementedException();
		}

		public bool SetItem(int slot, IItem item)
		{
			throw new NotImplementedException();
		}
	}
}
