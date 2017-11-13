using MLMBiowillBusinessEntities.Common;
using MLMBiowillBusinessEntities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MLMBioWill.Models.Master
{
    public class CategoryViewModel
    {
        public CategoryViewModel()
        {
            CategoryInfo = new Category();

            FriendlyMessage = new List<FriendlyMessage>();

            CategoryList = new List<Category>();

            Pager = new PaginationInfo();

        }
        public Category CategoryInfo { get; set; }

        public CategoryFilter CategoryFilter { get; set; }

        public List<Category> CategoryList { get; set; }

        public PaginationInfo Pager { get; set; }

        public List<FriendlyMessage> FriendlyMessage { get; set; }

    }
    public class CategoryFilter
    {
        public string CategoryName { get; set; }
        public int CategoryId { get; set; }
    }
}