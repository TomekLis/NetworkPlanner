using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NetworkPlanner.Model
{
    public class LatLng
    {
        [Key]
        public int Id { get; set; }
        //public int? CellId { get; set; }

        //public int? VertexId { get; set; }

        public double? Lat { get; set; }
        public double? Lng { get; set; }
    }
}
