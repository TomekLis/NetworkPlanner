using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NetworkPlanner.Model
{
    public class Grid
    {
        [Key]
        public int Id { get; set; }
        public virtual ICollection<Cell> Cells { get; set; }
        public int? PlanId { get; set; }
        public Plan Plan { get; set; }
        public Grid()
        {
            Cells = new HashSet<Cell>();
        }
    }
}
