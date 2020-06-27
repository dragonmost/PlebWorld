using System;
using System.Collections.Generic;

namespace PlebWorld.Server.Data
{
	internal class DBInventory : NamedDBObject
	{
		public int Slots { get; set; }

		public List<Guid> ItemIDs { get; set; } = new List<Guid>();
	}
}
