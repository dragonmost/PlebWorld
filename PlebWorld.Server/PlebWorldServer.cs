using PlebWorld.Models;
using PlebWorld.Server.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlebWorld.Server
{
	public class PlebWorldServer : IGame
	{
		public Models.ICollection<IPlayer> Players { get; } = new PlayerCollectionViewModel();

		public PlebWorldServer()
		{

		}
	}
}
