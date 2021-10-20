using Microsoft.VisualStudio.TestTools.UnitTesting;
using SerializationLib.UnitTest.TestData;
using System;
using System.Linq;

namespace SerializationLib.UnitTest
{
	[TestClass]
	public class SerializationProxyUnitTest
	{
		[TestMethod]
		public void ShouldNotAddValueTypeObject()
		{
			SerializationProxy proxy;

			proxy = new SerializationProxy();
			Assert.AreEqual(0, proxy.Objects.Count());
			Assert.ThrowsException<ArgumentException>(() => proxy.AddObject("test"));
			Assert.ThrowsException<ArgumentException>(() => proxy.AddObject(42));
		}
		[TestMethod]
		public void ShouldNotAddNullObject()
		{
			SerializationProxy proxy;

			proxy = new SerializationProxy();
			Assert.AreEqual(0, proxy.Objects.Count());
			Assert.ThrowsException<ArgumentNullException>(() => proxy.AddObject(null));
		}
		[TestMethod]
		public void ShouldAddObject()
		{
			Personn data;
			SerializationProxy proxy;
			IPropertyDescriptor pd;

			data = new Personn();
			data.Name = "Homer";
			data.Age = 40;

			proxy = new SerializationProxy();
			Assert.AreEqual(0, proxy.Objects.Count());
			proxy.AddObject(data);
			Assert.AreEqual(1, proxy.Objects.Count());
			Assert.AreEqual(40, proxy.Objects.ElementAt(0).Ref);
			Assert.AreEqual(3, proxy.Objects.ElementAt(0).Properties.Count());

			pd = proxy.Objects.ElementAt(0).GetProperty("Name");
			Assert.AreEqual("Homer", pd.Value);

			pd = proxy.Objects.ElementAt(0).GetProperty("Job");
			Assert.AreEqual(null, pd.Value);

		}
	}
}
