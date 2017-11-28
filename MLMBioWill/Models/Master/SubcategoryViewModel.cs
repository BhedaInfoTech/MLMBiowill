using MLMBiowillBusinessEntities.Common;
using MLMBiowillBusinessEntities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MLMBioWill.Models.Master
{
    public class SubcategoryViewModel
    {
        public SubcategoryViewModel()
        {
            SubcategoryInfo = new SubcategoryInfo();

            FriendlyMessage = new List<FriendlyMessage>();

            SubcategoryList = new List<SubcategoryInfo>();

            CategoryList = new List<Category>();

            Pager = new PaginationInfo();

        }
        public SubcategoryInfo SubcategoryInfo { get; set; }

        public SubcategoryFilter SubcategoryFilter { get; set; }

        public List<SubcategoryInfo> SubcategoryList { get; set; }

        public List<Category> CategoryList { get; set; }

        public PaginationInfo Pager { get; set; }

        public List<FriendlyMessage> FriendlyMessage { get; set; }
    }
    public class SubcategoryFilter
    {
        public string SubcategoryName { get; set; }
        public int Id { get; set; }
    }
}