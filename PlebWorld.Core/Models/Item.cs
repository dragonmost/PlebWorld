using System;
using System.Collections.Generic;
using System.Text;

namespace PlebWorld.Models
{
	public class Item : NamedDBObject
	{
		public Guid ItemTypeID { get; set; }

		public int Count { get; set; }
	}
}
