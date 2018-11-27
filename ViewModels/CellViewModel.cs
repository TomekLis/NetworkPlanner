using NetworkPlanner.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetworkPlanner.ViewModels
{
    public class CellViewModel
    {
        public List<VertexViewModel> Vertices { get; set; }
        public LatLngViewModel Center { get; set; }
        public CellShape Shape { get; set; }
    }
}
