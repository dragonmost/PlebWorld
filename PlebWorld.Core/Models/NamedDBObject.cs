using System;
using System.Collections.Generic;
using System.Text;

namespace PlebWorld.Models
{
	public abstract class NamedDBObject : DBObject
	{
		public string Name { get; set; }
	}
}
