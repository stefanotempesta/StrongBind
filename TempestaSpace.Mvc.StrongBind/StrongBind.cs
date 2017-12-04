using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace TempestaSpace.Mvc.StrongBind
{
    internal class StrongBind<T> : IStrongBinder where T : class, new()
    {
        public Type ModelType { get; set; }

        public string Action { get; set; }

        public IEnumerable<string> Properties { get; set; }

        public StrongBind() : this(string.Empty, null)
        {
        }

        public StrongBind(string action) : this(action, null)
        {
        }

        public StrongBind(string action, dynamic properties)
        {
            ModelType = typeof(T);
            Action = action ?? string.Empty;
            Properties = properties ?? GetModelProperties();
        }

        public StrongBind<T> Include(Func<T, object> properties)
        {
            if (properties == null)
            {
                return this;
            }

            Properties = GetProperties(properties);
            return this;
        }

        public StrongBind<T> Exclude(Func<T, object> properties)
        {
            if (properties == null)
            {
                return this;
            }

            var allProperties = GetModelProperties();
            if (allProperties == null)
            {
                return this;
            }

            var exclude = GetProperties(properties);

            Properties = allProperties.Except(exclude).ToList();
            return this;
        }

        protected IEnumerable<string> GetModelProperties()
        {
            return typeof(T)
                .GetProperties()
                .Where(p => !Attribute.IsDefined(p, typeof(NotMappedAttribute)))
                .Select(p => p.Name)
                .ToList();
        }

        protected IEnumerable<string> GetProperties(Func<T, object> properties)
        {
            return properties(new T()).GetType()
                .GetProperties()
                .Select(p => p.Name)
                .ToList();
        }
    }
}
