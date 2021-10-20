using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializationLib
{
	public interface ISerializationProxy
	{
		IEnumerable<IObjectDescriptor> Objects
		{
			get;
		}

		int AddObject(object Object);

		IObjectDescriptor GetObject(int Ref);
	}
}
