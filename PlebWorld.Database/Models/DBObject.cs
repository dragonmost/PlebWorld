using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PlebWorld.Database.Models
{
	public abstract class DBObject
	{
		[Key]
		public int ID { get; set; }
	}
}
