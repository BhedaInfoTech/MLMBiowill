using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLMBiowillBusinessEntities.Master
{
    public class BranchInfo
    {
        public int Id { get; set; }
        public string BranchName { get; set; }
        public string GSTNumber { get; set; }
        public string PANNumber { get; set; }
        public int CompanyId { get; set; }
        public bool Active { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }


    }
}
