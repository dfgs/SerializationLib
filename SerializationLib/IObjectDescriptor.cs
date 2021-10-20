using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializationLib
{
	public interface IObjectDescriptor
	{
		int Ref
		{
			get;
		}
		
		IEnumerable<IPropertyDescriptor> Properties
		{
			get;
		}

		void AddProperty(string Name, string Value);

		IPropertyDescriptor GetProperty(string Name);
	}
}
