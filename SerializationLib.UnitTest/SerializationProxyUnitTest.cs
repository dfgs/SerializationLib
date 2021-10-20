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
		public void ShouldGetObject()
		{
			Personn data;
			SerializationProxy proxy;

			data = new Personn();
			data.Name = "Homer";
			data.Age = 40;

			proxy = new SerializationProxy();
			Assert.AreEqual(0, proxy.Objects.Count());
			proxy.AddObject(data);
			Assert.AreEqual(1, proxy.Objects.Count());
			Assert.AreEqual(40, proxy.Objects.ElementAt(0).Ref);
			Assert.AreEqual(3, proxy.Objects.ElementAt(0).Properties.Count());

			Assert.AreEqual(proxy.Objects.ElementAt(0), proxy.GetObject(40));
			Assert.AreEqual(null, proxy.GetObject(4));


		}

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
		public void ShouldAddBasicObject()
		{
			Personn data;
			SerializationProxy proxy;
			IPropertyDescriptor pd;
			int id;

			data = new Personn();
			data.Name = "Homer";
			data.Age = 40;

			proxy = new SerializationProxy();
			Assert.AreEqual(0, proxy.Objects.Count());
			id = proxy.AddObject(data);
			Assert.AreEqual(40, id);
			Assert.AreEqual(1, proxy.Objects.Count());
			Assert.AreEqual(40, proxy.Objects.ElementAt(0).Ref);
			Assert.AreEqual(3, proxy.Objects.ElementAt(0).Properties.Count());

			pd = proxy.Objects.ElementAt(0).GetProperty("Name");
			Assert.AreEqual("Homer", pd.Value);

			pd = proxy.Objects.ElementAt(0).GetProperty("Job");
			Assert.AreEqual(null, pd.Value);

		}
		[TestMethod]
		public void ShouldAddObjectWithNullRefs()
		{
			PersonnEx data;
			SerializationProxy proxy;
			IPropertyDescriptor pd;
			int id;

			data = new PersonnEx();
			data.Name = "Homer";
			data.Age = 40;

			proxy = new SerializationProxy();
			Assert.AreEqual(0, proxy.Objects.Count());
			id=proxy.AddObject(data);

			Assert.AreEqual(40, id);
			Assert.AreEqual(1, proxy.Objects.Count());
			Assert.AreEqual(40, proxy.Objects.ElementAt(0).Ref);
			Assert.AreEqual(3, proxy.Objects.ElementAt(0).Properties.Count());

			pd = proxy.Objects.ElementAt(0).GetProperty("Name");
			Assert.AreEqual("Homer", pd.Value);

			pd = proxy.Objects.ElementAt(0).GetProperty("Job");
			Assert.AreEqual(null, pd.Value);

		}
		[TestMethod]
		public void ShouldAddObjectWithRefs()
		{
			PersonnEx data;
			SerializationProxy proxy;
			IPropertyDescriptor pd;
			int id;

			data = new PersonnEx();
			data.Name = "Homer";
			data.Age = 40;
			data.Job = new Job() { Name = "Supervisor",Ref=1234 };

			proxy = new SerializationProxy();
			Assert.AreEqual(0, proxy.Objects.Count());
			id=proxy.AddObject(data);

			Assert.AreEqual(40, id);
			Assert.AreEqual(2, proxy.Objects.Count());
			
			Assert.AreEqual(40, proxy.Objects.ElementAt(0).Ref);
			Assert.AreEqual(3, proxy.Objects.ElementAt(0).Properties.Count());

			Assert.AreEqual(1234, proxy.Objects.ElementAt(1).Ref);
			Assert.AreEqual(2, proxy.Objects.ElementAt(1).Properties.Count());


			pd = proxy.Objects.ElementAt(0).GetProperty("Name");
			Assert.AreEqual("Homer", pd.Value);

			pd = proxy.Objects.ElementAt(0).GetProperty("Job");
			Assert.AreEqual("1234", pd.Value);

			pd = proxy.Objects.ElementAt(1).GetProperty("Name");
			Assert.AreEqual("Supervisor", pd.Value);



		}
		[TestMethod]
		public void ShouldAddTwoObjectWithSameRefs()
		{
			Job job;
			PersonnEx data1,data2;
			SerializationProxy proxy;
			int id;

			job= new Job() { Name = "Supervisor", Ref = 1234 };

			data1 = new PersonnEx();
			data1.Name = "Homer";
			data1.Age = 40;
			data1.Job = job;

			data2 = new PersonnEx();
			data2.Name = "Lenny";
			data2.Age = 41;
			data2.Job = job;

			proxy = new SerializationProxy();
			Assert.AreEqual(0, proxy.Objects.Count());

			id = proxy.AddObject(data1);
			Assert.AreEqual(40, id);
			Assert.AreEqual(2, proxy.Objects.Count());

			id = proxy.AddObject(data2);
			Assert.AreEqual(41, id);
			Assert.AreEqual(3, proxy.Objects.Count());


			Assert.AreEqual("1234", proxy.GetObject(40).GetProperty("Job").Value);
			Assert.AreEqual("1234", proxy.GetObject(41).GetProperty("Job").Value);

		}

		[TestMethod]
		public void ShouldAddSelfReferencedObject()
		{
			PersonnSelfReferenced data;
			SerializationProxy proxy;
			int id;


			data = new PersonnSelfReferenced();
			data.Name = "Homer";
			data.Age = 40;
			data.Parent = data;


			proxy = new SerializationProxy();
			Assert.AreEqual(0, proxy.Objects.Count());

			id = proxy.AddObject(data);
			Assert.AreEqual(40, id);
			Assert.AreEqual(1, proxy.Objects.Count());

			Assert.AreEqual("40", proxy.GetObject(40).GetProperty("Parent").Value);

		}

	}
}
