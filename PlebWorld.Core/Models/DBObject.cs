using System;
using System.Collections.Generic;
using System.Text;

namespace PlebWorld.Models
{
	public abstract class DBObject : IID
	{
		public Guid ID { get; set; }
	}
}
