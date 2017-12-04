using System;
using System.Collections.Generic;
using System.Linq;
using TempestaSpace.Mvc.StrongBind;

namespace SampleMvc.Models
{
    class SampleMvcModelBinder : StrongModelBinder
    {
        public SampleMvcModelBinder()
        {
            Include<Person>("Create", m => new { m.FirstName, m.MiddleName, m.LastName, m.DateOfBirth, m.Email });
            Exclude<Person>("EditSafe", m => new { m.Email });
            Include<Location>("Edit");
        }
    }
}