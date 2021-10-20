using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializationLib
{
	public class PropertyDescriptor:IPropertyDescriptor
	{
		public string Name
		{
			get;
			set;
		}
		public string Value
		{
			get;
			set;
		}
	}
}
