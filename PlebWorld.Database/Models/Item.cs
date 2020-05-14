using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PlebWorld.Database.Models
{
	public class Item : NamedDBObject
	{
		public int ItemTypeID { get; set; }

		public int Count { get; set; }
	}
}
