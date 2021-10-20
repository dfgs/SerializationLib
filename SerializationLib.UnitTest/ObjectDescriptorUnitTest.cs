using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace SerializationLib.UnitTest
{
	[TestClass]
	public class ObjectDescriptorUnitTest
	{
		[TestMethod]
		public void ShouldNotAddNullNamedProperty()
		{
			ObjectDescriptor od;

			od = new ObjectDescriptor();
			Assert.AreEqual(0, od.Properties.Count());
			Assert.ThrowsException<ArgumentNullException>(() => od.AddProperty(null, "value"));

		}
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

			od.AddProperty("Name", null);
			Assert.AreEqual(2, od.Properties.Count());
			Assert.AreEqual("Name", od.Properties.ElementAt(1).Name);
			Assert.AreEqual(null, od.Properties.ElementAt(1).Value);

		}


		[TestMethod]
		public void ShouldNotGetNullNamedProperty()
		{
			ObjectDescriptor od;

			od = new ObjectDescriptor();
			Assert.AreEqual(0, od.Properties.Count());
			Assert.ThrowsException<ArgumentNullException>(() => od.GetProperty(null));

		}
		[TestMethod]
		public void ShouldGetProperty()
		{
			ObjectDescriptor od;
			IPropertyDescriptor pd;

			od = new ObjectDescriptor();
			Assert.AreEqual(0, od.Properties.Count());
			od.AddProperty("Name", "Value");
			Assert.AreEqual(1, od.Properties.Count());
			pd = od.GetProperty("Name");
			Assert.AreEqual("Name", pd.Name);
			Assert.AreEqual("Value", pd.Value);
		}

	}
}
