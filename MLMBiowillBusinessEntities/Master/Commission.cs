using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLMBiowillBusinessEntities.Master
{
    public class Commission
    {
        public int Id { get; set; }
        public int LevelId { get; set; }
        public decimal MinAmt { get; set; }
        public decimal MaxAmt { get; set; }
        public decimal PercentageAmt { get; set; }
        public bool Active { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
