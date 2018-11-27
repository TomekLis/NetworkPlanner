using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetworkPlanner.Model;

namespace NetworkPlanner.ViewModels
{
    public class CellRadiusCalculationViewModel
    {
        public double TransmitterHeight { get; set; }
        public double Frequency { get; set; }
        public double TransmitterPower { get; set; }
        public double AntennaGain { get; set; }
        public double CableLoss { get; set; }
        public AreaType AreaType { get; set; }
    }
}
