﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PlebWorld.Database.Models
{
	public class Inventory : NamedDBObject
	{
		public List<Item> Items { get; set; } = new List<Item>();

		public int Slots { get; set; }
	}
}