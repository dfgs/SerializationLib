using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializationLib.UnitTest.TestData
{
	public class JobList:List<Job>
	{
		public override int GetHashCode()
		{
			return 40;
		}
	}
}
