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

        [XmlIgnore]
        IEnumerable<IItemDescriptor> IObjectDescriptor.Items
        {
            get => items;
        }

        private List<PropertyDescriptor> properties;
        public List<PropertyDescriptor> Properties
        {
            get => properties;
            set => properties = value;
        }

        private List<ItemDescriptor> items;
        public List<ItemDescriptor> Items
        {
            get => items;
            set => items = value;
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
            items = new List<ItemDescriptor>();
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
        public void AddItem(string Value)
        {
            ItemDescriptor id;


            id = new ItemDescriptor();
            id.Value = Value;

            items.Add(id);
        }
        public IItemDescriptor GetItem(int Index)
        {
            if ((Index < 0) || (Index >= items.Count)) return null;
            return items[Index];
        }

    }
}
