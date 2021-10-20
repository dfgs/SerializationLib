using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializationLib
{
	public class SerializationProxy:ISerializationProxy
	{
		private List<IObjectDescriptor> objects;
		public IEnumerable<IObjectDescriptor> Objects
		{
			get => objects;
		}

		public SerializationProxy()
		{
			objects = new List<IObjectDescriptor>();
		}

	}
}
