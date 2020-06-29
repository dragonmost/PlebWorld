using PlebWorld.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlebWorld.Server.Data
{
	internal class DBItem : NamedDBObject
	{
		public Guid ItemTypeID { get; set; }
		public int Count { get; set; }
	}
}
