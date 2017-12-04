using System;
using System.Collections.Generic;
using System.Linq;

namespace TempestaSpace.Mvc.StrongBind
{
    public interface IStrongBinder
    {
        Type ModelType { get; set; }

        string Action { get; set; }

        IEnumerable<string> Properties { get; set; }
    }
}
