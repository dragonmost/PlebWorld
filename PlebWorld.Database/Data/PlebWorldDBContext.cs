using Microsoft.EntityFrameworkCore;
using PlebWorld.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlebWorld.Database.Data
{
	public class PlebWorldDBContext : DbContext
	{
		public DbSet<Item> Items { get; set; }

		public DbSet<ItemType> ItemTypes { get; set; }

		public DbSet<Inventory> Inventories { get; set; }

		public DbSet<Player> Players { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
			optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=PlebWorld;Trusted_Connection=True;ConnectRetryCount=0");

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			foreach (var item in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
			{
				item.DeleteBehavior = DeleteBehavior.NoAction;
			}

			foreach (var prop in typeof(ItemTypes).GetFields())
			{
				if (prop.GetValue(null) is ItemType itemType)
				{
					modelBuilder.Entity<ItemType>().HasData(itemType);
				}
			}
		}
	}
}
