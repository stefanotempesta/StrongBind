using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace TempestaSpace.Core.StrongBind
{
    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false), ModelBinder]
    public sealed class StrongBindAttribute : ModelBinderAttribute
    {
        public override BindingSource BindingSource
        {
            get => base.BindingSource;
            protected set => base.BindingSource = value;
        }

        public override IModelBinder GetBinder()
        {
            return ModelBinders.Binders[typeof(StrongModelBinder)];
        }
    }
}
