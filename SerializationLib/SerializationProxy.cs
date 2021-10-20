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

		public void AddObject(object Object)
		{
			ObjectDescriptor od;
			System.Reflection.PropertyInfo[] pis;

			if (Object == null) throw new ArgumentNullException(nameof(Object));

			if (Object.GetType()==typeof(string)) throw new ArgumentException("Cannot add value type objects");
			if (Object.GetType().IsValueType) throw new ArgumentException("Cannot add value type objects");

			od = new ObjectDescriptor();
			od.Ref = Object.GetHashCode();

			pis= Object.GetType().GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
			foreach(System.Reflection.PropertyInfo pi in pis)
			{
				od.AddProperty(pi.Name, pi.GetValue(Object)?.ToString());
			}

			objects.Add(od);
		}

	}
}
