using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace SerializationLib.UnitTest
{
	[TestClass]
	public class ObjectDescriptorUnitTest
	{
		[TestMethod]
		public void ShouldAddProperty()
		{
			ObjectDescriptor od;

			od = new ObjectDescriptor();
			Assert.AreEqual(0, od.Properties.Count());
			od.AddProperty("Name", "Value");
			Assert.AreEqual(1, od.Properties.Count());
			Assert.AreEqual("Name", od.Properties.ElementAt(0).Name);
			Assert.AreEqual("Value", od.Properties.ElementAt(0).Value);

		}
	}
}
