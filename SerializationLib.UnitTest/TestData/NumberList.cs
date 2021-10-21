using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializationLib.UnitTest.TestData
{
	public class NumberList:List<int>
	{
		public override int GetHashCode()
		{
			return 40;
		}
	}
}
