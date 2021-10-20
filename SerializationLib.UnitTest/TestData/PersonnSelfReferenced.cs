using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializationLib.UnitTest.TestData
{
	public class PersonnSelfReferenced
	{
		public string Name
		{
			get;
			set;
		}
		public byte Age
		{
			get;
			set;
		}
		public PersonnSelfReferenced Parent
		{
			get;
			set;
		}

		public override int GetHashCode()
		{
			return Age;
		}

	}
}
