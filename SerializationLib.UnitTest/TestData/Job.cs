using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializationLib.UnitTest.TestData
{
	public class Job
	{
		public string Name
		{
			get;
			set;
		}

		public int Ref
		{
			get;
			set;
		}

		public override int GetHashCode()
		{
			return Ref;
		}

	}
}
