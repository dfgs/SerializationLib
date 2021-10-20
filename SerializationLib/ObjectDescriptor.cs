using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SerializationLib
{
    public class ObjectDescriptor:IObjectDescriptor
    {
        [XmlIgnore]
        IEnumerable<IPropertyDescriptor> IObjectDescriptor.Properties
        {
            get => properties;
        }

        private List<PropertyDescriptor> properties;
        public List<PropertyDescriptor> Properties
        {
            get => properties;
            set => properties = value;
        }

        [XmlAttribute]
        public int Ref
		{
            get;
            set;
		}

        public ObjectDescriptor()
		{
            properties = new List<PropertyDescriptor>();
		}

        public void AddProperty(string Name, string Value)
		{
            PropertyDescriptor pd;

            if (Name == null) throw new ArgumentNullException(nameof(Name));

            pd = new PropertyDescriptor();
            pd.Name = Name;pd.Value = Value;

            properties.Add(pd);
		}
        public IPropertyDescriptor GetProperty(string Name)
		{
            if (Name == null) throw new ArgumentNullException(nameof(Name));

            return properties.FirstOrDefault(item => item.Name == Name);
		}


    }
}
