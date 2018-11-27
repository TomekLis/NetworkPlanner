using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NetworkPlanner.Model
{
    public class Plan
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual AppUser User { get; set; }
        public string UserId { get; set; }
        public virtual Grid Grid { get; set; }
        public AreaType AreaType { get; set; }

        public double TransmitterPower { get; set; }
        public double AntennaGain { get; set; }
        public double CableLoss { get; set; }
        public double Cirf { get; set; }
        public double ChannelReuseDistnace { get; set; }
        public double ClusterSize { get; set; }
        public double CellRange { get; set; }
        public double RequiredCi { get; set; }
        public double SystemCapacity { get; set; }
        public double Eirp { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public int ChannelMax { get; set; }
        public int ChannelMin { get; set; }
    }

    public enum AreaType
    {
        LargeCity,
        SmallCity,
        Suburb,
        RularArea
    }
}
