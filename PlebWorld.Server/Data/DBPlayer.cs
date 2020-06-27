using System;
using System.Collections.Generic;
using System.Text;

namespace PlebWorld.Server.Data
{
	internal class DBPlayer : NamedDBObject
	{
		public Guid ChestID { get; set; }
		public Guid BackpackID { get; set; }
	}
}
