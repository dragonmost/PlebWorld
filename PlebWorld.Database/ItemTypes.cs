using PlebWorld.Database.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace PlebWorld.Database
{
	public static class ItemTypes
	{
		private static volatile int lastID = 0;

		public static readonly ItemType Sword = Register(nameof(Sword));
		public static readonly ItemType Spear = Register(nameof(Spear));

		private static ItemType Register(string name) => new ItemType
		{
			ID = Interlocked.Increment(ref lastID),
			Name = name
		};
	}
}
