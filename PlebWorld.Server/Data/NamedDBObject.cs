using System;
using System.Collections.Generic;
using System.Text;

namespace PlebWorld.Server.Data
{
	internal abstract class NamedDBObject : DBObject, IName
	{
		public string Name { get; set; }
	}
}
