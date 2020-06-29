using System;
using System.Collections.Generic;
using System.Text;

namespace PlebWorld.Models
{
	public interface IPlayer : IID, IName
	{
		IInventory Backpack { get; }
		IInventory Chest { get; }
	}
}
