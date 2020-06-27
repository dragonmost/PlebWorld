using System;
using System.Collections.Generic;
using System.Text;

namespace PlebWorld.Models
{
	public interface IItem: IID, IName
	{
		IItemType ItemType { get; set; }

		int Count { get; set; }
	}
}
