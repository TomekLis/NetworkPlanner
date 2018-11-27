using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NetworkPlanner.Model
{
    public class Cell
    {
        [Key]
        public int Id { get; set; }
        public CellShape CellShape { get; set; }
        public virtual ICollection<Vertex> Vertices { get; set; }
        public virtual LatLng Center { get; set; }
    }
    public enum CellShape
    {
        Hexagonal,
        Square
    }
}
