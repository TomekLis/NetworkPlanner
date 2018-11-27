using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NetworkPlanner.Model
{
    public class Vertex
    {
        [Key]
        public int Id { get; set; }
        public int? CellId { get; set; }
        public int? Position { get; set; }
        public LatLng LatLng { get; set; }
    }
}
