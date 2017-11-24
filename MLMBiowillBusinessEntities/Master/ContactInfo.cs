using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLMBiowillBusinessEntities.Master
{
    public class ContactInfo
    {
        public int ContactId { get; set; }
        public string ContactFor { get; set; }
        public int ObjectId { get; set; }
        public string ContactType { get; set; }
        public string CountryCode { get; set; }
        public string StdCode { get; set; }
        public string TelMobNumber { get; set; }
        public bool IsDefault { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
    }

    public class ContactFilterInfo
    {
        public int ContactId { get; set; }

    }
}
