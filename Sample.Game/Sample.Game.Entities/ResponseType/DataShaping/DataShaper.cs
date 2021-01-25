using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;

namespace Sample.Game.Entities.ResponseType.DataShaping
{
    public class DataShaper<T>
    {
        private readonly List<PropertyInfo> RequiredProperties;

        public DataShaper(string fieldsString)
        {
            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            if (string.IsNullOrWhiteSpace(fieldsString))
            {
                RequiredProperties = properties.ToList();
            }
            else
            {
                var fields = fieldsString.Split(',', StringSplitOptions.RemoveEmptyEntries);
                foreach (var field in fields)
                {
                    var property = properties.FirstOrDefault(pi =>
                        pi.Name.Equals(field.Trim(), StringComparison.InvariantCultureIgnoreCase));
                    if (property == null)
                        continue;
                    RequiredProperties.Add(property);
                }
            }
        }

        public ExpandoObject FetchData(T sourceData)
        {
            var shapedObject = new ExpandoObject();

            foreach (var property in RequiredProperties)
            {
                var objectPropertyValue = property.GetValue(sourceData);
                shapedObject.TryAdd(property.Name, objectPropertyValue);
            }

            return shapedObject;
        }

        public IEnumerable<ExpandoObject> FetchData(IEnumerable<T> sourceData)
        {
            var shapedData = new List<ExpandoObject>();
            
            foreach (var item in sourceData)
            {
                var shapedObject = FetchData(item);
                shapedData.Add(shapedObject);
            }

            return shapedData;
        }

        
    }
}
