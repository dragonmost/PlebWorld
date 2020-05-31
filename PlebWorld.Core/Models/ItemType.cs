using System;
using System.Collections.Generic;
using System.Text;

namespace PlebWorld.Models
{
	public class ItemType : NamedDBObject
	{
		public static ItemType Sword { get; } = new ItemType();
		public static ItemType Spear { get; } = new ItemType();
	}
}
