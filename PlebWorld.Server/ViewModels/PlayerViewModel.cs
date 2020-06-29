using PlebWorld.Database;
using PlebWorld.Models;
using PlebWorld.Server.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlebWorld.Server.ViewModels
{
	internal class PlayerViewModel : BaseViewModel<DBPlayer>, IPlayer
	{
		public PlayerViewModel(Guid id = default)
			: base(id)
		{
		}

		public IInventory Backpack => new InventoryViewModel(GetValue(m => m.BackpackID));

		public IInventory Chest => new InventoryViewModel(GetValue(m => m.ChestID));

		public string Name
		{
			get => GetValue(m => m.Name);
			set => SetValue(m => m.Name = value);
		}
	}
}
