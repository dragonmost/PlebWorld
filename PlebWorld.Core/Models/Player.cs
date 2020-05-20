using System;
using System.Collections.Generic;
using System.Text;

namespace PlebWorld.Models
{
	public class Player : NamedDBObject
	{
		public Guid BackpackID { get; set; }

		public Guid ChestID { get; set; }
	}
}
