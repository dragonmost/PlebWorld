using PlebWorld.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlebWorld.Core.Services
{
	public interface INamedDBObjectRegister
	{
		T Register<T>(T value) where T : NamedDBObject;
	}
}
