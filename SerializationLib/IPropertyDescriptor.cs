using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializationLib
{
	public interface IPropertyDescriptor
	{
		string Name
		{
			get;
		}
		string Value
		{
			get;
		}
	}
}
