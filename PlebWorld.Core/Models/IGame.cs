﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PlebWorld.Models
{
	public interface IGame
	{
		ICollection<IPlayer> Players { get; }
	}
}
