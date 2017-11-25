using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLMBiowillBusinessEntities.Master
{
    public class ContactPersonInfo
    {
        public int ContactPersonId { get; set; }
        public string ContactFor { get; set; }
        public int ObjectId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string EmailId { get; set; }
        public string MobileNo { get; set; }
        public bool IsDefault { get; set; }
        public bool Active { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }


    public class ContactPersonFilterInfo
    {
        public int ContactPersonId { get; set; }
    }

}


