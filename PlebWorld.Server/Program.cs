using PlebWorld.Database;
using PlebWorld.Database.LiteDB;
using PlebWorld.Models;
using System;
using System.Linq;
using Vildmark.DependencyServices;

namespace PlebWorld.Server
{
	class Program
	{
		static void Main(string[] args)
		{
			DependencyService dependencyService = new DependencyService();
			CascadingDependencyServiceTypeRegistrer registrer = new CascadingDependencyServiceTypeRegistrer(dependencyService, new AttributeDependencyServiceTypeProvider(new AppDomainDependencyServiceAssemblyProvider()));
			registrer.RegisterServices();

			IDatabase database = new LiteDBDatabase("plebworld.db");

			dependencyService.Register(database);

			PlebWorldServerInstance instance = dependencyService.CreateInstance<PlebWorldServerInstance>();

			instance.TryRegisterPlayer("Phyyl", out Player phyyl);

			Inventory chest = instance.GetInventory(phyyl.ChestID);
			chest.Items.Clear();
			Item spearItem = instance.CreateItem(ItemType.Spear, "Master Pleb Spear", 42069);

			chest.Items.Add(spearItem);
			instance.UpdateInventory(chest);

			PrintInventory(instance, phyyl);

			Console.ReadLine();
		}

		static void PrintInventory(PlebWorldServerInstance instance, Player player)
		{
			Inventory chest = instance.GetInventory(player.ChestID);

			Console.WriteLine("Chest items: ");

			foreach (var item in chest.Items)
			{
				Console.WriteLine($"  {item.Name} ({item.Count})");
			}
		}
	}
}
