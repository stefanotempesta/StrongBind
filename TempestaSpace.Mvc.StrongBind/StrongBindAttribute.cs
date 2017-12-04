using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace TempestaSpace.Mvc.StrongBind
{
    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false)]
    public sealed class StrongBindAttribute : CustomModelBinderAttribute
    {
        public override IModelBinder GetBinder()
        {
            return ModelBinders.Binders[typeof(StrongModelBinder)];
        }
    }
}
