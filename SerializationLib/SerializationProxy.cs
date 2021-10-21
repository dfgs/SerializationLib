using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SerializationLib
{
	public class SerializationProxy:ISerializationProxy
	{
		[XmlIgnore]
		IEnumerable<IObjectDescriptor> ISerializationProxy.Objects
		{
			get => objects;
		}

		private List<ObjectDescriptor> objects;
		public List<ObjectDescriptor> Objects
		{
			get => objects;
			set => objects = value;
		}

		public SerializationProxy()
		{
			objects = new List<ObjectDescriptor>();
		}

		public IObjectDescriptor GetObject(int Ref)
		{
			return objects.FirstOrDefault(item => item.Ref == Ref);
		}

		private int GetRef(object Object)
		{
			return Object.GetHashCode();
		}

		public int AddObject(object Object)
		{
			ObjectDescriptor od;
			System.Reflection.PropertyInfo[] pis;
			int childRef;
			object childObject;

			if (Object == null) throw new ArgumentNullException(nameof(Object));

			if (Object.GetType()==typeof(string)) throw new ArgumentException("Cannot add value type objects");
			if (Object.GetType().IsValueType) throw new ArgumentException("Cannot add value type objects");

			od = new ObjectDescriptor();
			od.Ref = GetRef(Object);
			objects.Add(od);

			pis = Object.GetType().GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
			foreach(System.Reflection.PropertyInfo pi in pis)
			{
				if (pi.GetIndexParameters().Length > 0) continue; // skip indexers

				if ((pi.PropertyType.IsValueType) || (pi.PropertyType == typeof(string)))
				{
					od.AddProperty(pi.Name, pi.GetValue(Object)?.ToString());
					continue;
				}

				childObject = pi.GetValue(Object);
				if (childObject==null)
				{
					od.AddProperty(pi.Name, null);
					continue;
				}

				childRef = GetRef(childObject);
				if (GetObject(childRef) == null) AddObject(childObject);
				od.AddProperty(pi.Name, childRef.ToString());
			}

			if (Object is System.Collections.IEnumerable enumerable)
			{
				foreach(object item in enumerable)
				{
					if (item==null)
					{
						od.AddItem(null);
						continue;
					}

					if ((item.GetType().IsValueType) || (item is string))
					{
						od.AddItem(item.ToString());
						continue;
					}

					childRef = GetRef(item);
					if (GetObject(childRef) == null) AddObject(item);
					od.AddItem(childRef.ToString());

				}
			}

			return od.Ref;
		}


	}
}
