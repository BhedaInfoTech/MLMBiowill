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
        public string ComapanyName { get; set; }
        public bool Active { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
