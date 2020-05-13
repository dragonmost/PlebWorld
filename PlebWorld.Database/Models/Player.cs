using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PlebWorld.Database.Models
{
	public class Player : DBObject
	{
		public string Name { get; set; }

		public int BackpackID { get; set; }

		public int ChestID { get; set; }
	}
}
