using PlebWorld.Database;
using PlebWorld.Database.LiteDB;
using PlebWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Vildmark.DependencyServices;

namespace PlebWorld.Server
{
	class Program
	{
		static void Main(string[] args)
		{
			InitializeDependencyService();
			InitializeDatabase();

			IGame game = new PlebWorldServer();

			IPlayer[] players = game.Players.GetAll().ToArray();

			Console.WriteLine(players.Length);
			Console.WriteLine(string.Join(Environment.NewLine, players.Select(p => p.Name)));
			Console.ReadLine();
		}

		private static void InitializeDatabase()
		{
			IDatabase database = new LiteDBDatabase("plebworld.db");
			DependencyService.Global.Register(database);
		}

		private static void InitializeDependencyService()
		{
			CascadingDependencyServiceTypeRegistrer registrer = new CascadingDependencyServiceTypeRegistrer(DependencyService.Global, new AttributeDependencyServiceTypeProvider(new AppDomainDependencyServiceAssemblyProvider()));
			registrer.RegisterServices();
		}
	}
}
