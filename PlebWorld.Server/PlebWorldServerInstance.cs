using PlebWorld.Database;
using PlebWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vildmark.DependencyServices;

namespace PlebWorld.Server
{
	public class PlebWorldServerInstance
	{
		private readonly IDatabase database;

		public IDependencyService DependencyService { get; }

		public IEnumerable<Player> Players => database.GetCollection<Player>().GetAll();

		public PlebWorldServerInstance(IDependencyService dependencyService, IDatabase database)
		{
			DependencyService = dependencyService;
			this.database = database;
		}

		public bool RenamePlayer(Player player, string newName)
		{
			if (GetPlayer(newName) is { })
			{
				return false;
			}

			player.Name = newName;

			database.GetCollection<Player>().Update(player);

			return true;
		}

		public Item CreateItem(ItemType itemType, string name, int count = 1)
		{
			Item item = new Item
			{
				ItemTypeID = itemType.ID,
				Name = name,
				Count = count
			};

			database.GetCollection<Item>().Add(item);

			return item;
		}

		public void UpdateInventory(Inventory inventory)
		{
			database.GetCollection<Inventory>().Update(inventory);
		}

		public bool TryRegisterPlayer(string name, out Player player)
		{
			if (database.GetCollection<Player>().Get(p => p.Name == name) is Player existingPlayer)
			{
				player = existingPlayer;
				return false;
			}

			player = new Player
			{
				Name = name
			};

			InitializeInventory(player);

			database.GetCollection<Player>().Add(player);

			return true;
		}

		public Player GetPlayer(Guid id)
		{
			return database.GetCollection<Player>().Get(id);
		}

		public Player GetPlayer(string name)
		{
			return database.GetCollection<Player>().Get(p => p.Name == name);
		}

		public Inventory CreateInventory(int slots)
		{
			Inventory inventory = new Inventory
			{
				Slots = slots
			};

			database.GetCollection<Inventory>().Add(inventory);

			return inventory;
		}

		public Inventory GetInventory(Guid id)
		{
			return database.GetCollection<Inventory>().Get(id);
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
