using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SampleMvc.Models
{
    public class Location
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        [NotMapped]
        [DataType(DataType.Url)]
        public Uri GoogleMapsUrl => new Uri($"https://www.google.com/maps/place/{Name}/@{Latitude},{Longitude},12z");
    }
}