using PlebWorld.Database;
using PlebWorld.Database.Data;
using PlebWorld.Database.Models;
using System.Linq;

namespace PlebWorld.Server
{
	class Program
	{
		static void Main(string[] args)
		{
			PlebWorldServerInstance instance = new PlebWorldServerInstance(new PlebWorldDBContext());

			Player player = instance.GetPlayer("Phyyl");
			Inventory chest = instance.GetInventory(player.ChestID);
			Item spearItem = instance.CreateItem(ItemTypes.Spear, "Master Pleb Spear", 42069);

			chest.Items.Add(spearItem);
			instance.UpdateInventory(chest);

			chest = instance.GetInventory(player.ChestID);
		}
	}
}
