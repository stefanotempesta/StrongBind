using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace TempestaSpace.Core.StrongBind
{
    public abstract class StrongModelBinder : DefaultModelBinder
    {
        protected IList<IStrongBinder> Bindings = new List<IStrongBinder>();

        public virtual void Include<T>(string action, Func<T, dynamic> properties = null) where T : class, new()
        {
            Bindings.Add(new StrongBind<T>(action).Include(properties));
        }

        public virtual void Exclude<T>(string action, Func<T, dynamic> properties) where T : class, new()
        {
            Bindings.Add(new StrongBind<T>(action).Exclude(properties));
        }

        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            try
            {
                string action = controllerContext.RouteData.Values["action"] as string;

                // Binding properties for ModelType and Action
                var bindings = Bindings.FirstOrDefault(b => b.ModelType == bindingContext.ModelMetadata.ModelType && b.Action == action).Properties;

                // Filter out properties not in the binding properties
                bindingContext.PropertyFilter = s => bindings.Contains(s.PropertyName);
            }
            catch
            {
                // If something goes wrong, revert to the base (default) model binder
            }

            return base.BindModel(controllerContext, bindingContext);
        }
    }
}
