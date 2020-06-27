using System;
using System.Collections.Generic;
using System.Text;

namespace PlebWorld.Server.Data
{
	internal abstract class DBObject : IID
	{
		public Guid ID { get; set; }
	}
}
