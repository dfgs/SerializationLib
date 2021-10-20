﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SerializationLib
{
	public class PropertyDescriptor:IPropertyDescriptor
	{
		[XmlAttribute]
		public string Name
		{
			get;
			set;
		}
		[XmlAttribute]
		public string Value
		{
			get;
			set;
		}
	}
}
