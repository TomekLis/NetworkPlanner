using NetworkPlanner.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetworkPlanner.ViewModels
{
    public class GridViewModel
    {
        public List<CellViewModel> Cells { get; set; }
        public CellShape CellShape { get; set; }
    }
}
