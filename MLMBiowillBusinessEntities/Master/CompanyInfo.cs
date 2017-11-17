using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLMBiowillBusinessEntities.Master
{
    public class CompanyInfo
    {
        public int CompanyId { get; set; }

        public string CompanyName { get; set; }

        public string GSTNumber { get; set; }

        public string PAN { get; set; }

        public bool IsActive { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public int UpdatedBy { get; set; }

        public DateTime UpdatedOn { get; set; }
                                        
        public int PhoneNo { get; set; }

        public int MobileNo { get; set; }

        public int FaxNo { get; set; }

        public string  EmailId { get; set; }

        public string Website { get; set; }

        public string Pincode { get; set; }

        public string Address { get; set; }

        public string City { get; set; }
    }

    public class CompanyFilter
    {
        public int CompanyId { get; set; }

        public string CompanyName { get; set; }

    }
}
