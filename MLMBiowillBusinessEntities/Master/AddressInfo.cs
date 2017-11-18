using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLMBiowillBusinessEntities.Master
{
    public class AddressInfo
    {
        public int AddressId { get; set; }
        public string AddressType { get; set; }
        public string AddressFor { get; set; }
        public int ObjectId { get; set; }
        public string Address { get; set; }
        public int Country { get; set; }
        public int State { get; set; }
        public int City { get; set; }
        public string Pincode { get; set; }
        public string EmailId { get; set; }
        public string Website { get; set; }
        public bool IsDefault { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }     
        public DateTime CreatedOn { get; set; }
        public int UpdatedBy { get; set; }     
        public DateTime UpdatedOn { get; set; }

    }
}
