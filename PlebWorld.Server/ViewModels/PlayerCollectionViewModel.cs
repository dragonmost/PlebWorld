using PlebWorld.Models;
using PlebWorld.Server.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlebWorld.Server.ViewModels
{
	internal class PlayerCollectionViewModel : BaseCollectionViewModel<DBPlayer, PlayerViewModel>, Models.ICollection<IPlayer>
	{
		public IPlayer Create()
		{
			return Get(Collection.Create().ID);
		}

		public bool Delete(Guid id)
		{
			return Collection.Remove(id);
		}

		public IPlayer Get(Guid id)
		{
			return new PlayerViewModel(id);
		}

		public IEnumerable<IPlayer> GetAll()
		{
			return Collection.GetAll().Select(m => Get(m.ID));
		}
	}
}
