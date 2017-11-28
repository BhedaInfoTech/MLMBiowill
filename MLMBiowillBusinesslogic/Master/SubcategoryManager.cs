using MLMBiowillBusinessEntities.Common;
using MLMBiowillBusinessEntities.Master;
using MLMBiowillRepo.Master;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLMBiowillBusinesslogic.Master
{
    public class SubcategoryManager
    {
        SubcategoryRepo _subcategoryRepo;
        public SubcategoryManager()
        {
            _subcategoryRepo = new SubcategoryRepo();
        }
        public int Insert_Subcategory(SubcategoryInfo _subcategoryInfo)
        {
            return _subcategoryRepo.Insert(_subcategoryInfo);
        }

        public DataTable GetSubcategories(int CategoryId, string SubcategoryName, ref PaginationInfo pager)
        {
            return _subcategoryRepo.GetSubcategories(CategoryId, SubcategoryName, ref pager);
        }

        public void Update_Subcategory(SubcategoryInfo _subcategoryInfo)
        {
            _subcategoryRepo.Update_Subcategory(_subcategoryInfo);
        }
                 
        public bool CheckSubcategoryNameExist(string SubcategoryName)
        {
            return _subcategoryRepo.CheckSubcategoryExist(SubcategoryName);
        }

        public List<Category> GetCategories()
        {
            return _subcategoryRepo.GetCategories();
        }

    }
}
