using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializationLib
{
    public class ObjectDescriptor:IObjectDescriptor
    {
        private List<PropertyDescriptor> properties;
        public IEnumerable<IPropertyDescriptor> Properties
        {
            get => properties;
        }

        

        public ObjectDescriptor()
		{
            properties = new List<PropertyDescriptor>();
		}

        public void AddProperty(string Name, string Value)
		{
            PropertyDescriptor pd;

            pd = new PropertyDescriptor();
            pd.Name = Name;pd.Value = Value;

            properties.Add(pd);
		}


    }
}
