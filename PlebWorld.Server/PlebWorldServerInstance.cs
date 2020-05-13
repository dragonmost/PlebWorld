using Microsoft.EntityFrameworkCore;
using PlebWorld.Database.Data;
using PlebWorld.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlebWorld.Server
{
	public class PlebWorldServerInstance
	{
		private readonly PlebWorldDBContext dbContext;

		public PlebWorldServerInstance(PlebWorldDBContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public Item CreateItem(ItemType itemType, string name, int count = 1)
		{
			Item result = dbContext.Items.Add(new Item
			{
				ItemTypeID = itemType.ID,
				Name = name,
				Count = count
			}).Entity;
			dbContext.SaveChanges();

			return result;
		}

		public void UpdateInventory(Inventory inventory)
		{
			dbContext.Inventories.Update(inventory);
			dbContext.SaveChanges();
		}

		public bool TryRegisterPlayer(string name, out Player player)
		{
			if (dbContext.Players.Any(p => p.Name == name))
			{
				player = null;
				return false;
			}

			player = new Player
			{
				Name = name
			};

			InitializeInventory(player);

			dbContext.Players.Add(player);
			dbContext.SaveChanges();

			return true;
		}

		public Player GetPlayer(int id)
		{
			return dbContext.Players.Find(id);
		}

		public Player GetPlayer(string name)
		{
			return dbContext.Players.FirstOrDefault(p => p.Name == name);
		}

		public Inventory CreateInventory(int slots)
		{
			Inventory inventory = new Inventory
			{
				Slots = slots
			};

			dbContext.Inventories.Add(inventory);
			dbContext.SaveChanges();

			return inventory;
		}

		public Inventory GetInventory(int id)
		{
			return dbContext
				.Inventories
				.Include(i => i.Items)
				.FirstOrDefault(i => i.ID == id);
		}

		private void InitializeInventory(Player player)
		{
			Inventory backpack = CreateInventory(10);
			Inventory chest = CreateInventory(100);

			player.BackpackID = backpack.ID;
			player.ChestID = chest.ID;
		}
	}
}
