using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLMBiowillBusinessEntities.Master
{
    public class TeleponeInfo
    {
        public int Id { get; set; }
        public string ObjectType { get; set; }
        public int ObjectId { get; set; }
        public string Type { get; set; }
        public string CountryCode { get; set; }
        public string StdCode { get; set; }
        public string EmailId { get; set; }
        public string TelMobNumber { get; set; }
        public string SequenceNo { get; set; }
        public bool Active { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
