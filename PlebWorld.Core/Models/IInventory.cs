using System;
using System.Collections.Generic;
using System.Text;

namespace PlebWorld.Models
{
	public interface IInventory: IID, IName
	{
		IEnumerable<IItem> Items { get; }

		int Slots { get; set; }

		IItem GetItem(int slot);

		bool SetItem(int slot, IItem item);
	}
}
