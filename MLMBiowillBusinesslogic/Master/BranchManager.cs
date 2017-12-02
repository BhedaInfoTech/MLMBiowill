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
    public class BranchManager
    {
        BranchRepo _branchRepo;
        CompanyRepo _companyRepo;

        public BranchManager()
        {
            _branchRepo = new BranchRepo();
            _companyRepo = new CompanyRepo();
        }
        public int Insert_Branch(BranchInfo _branchInfo)
        {
            return _branchRepo.Insert(_branchInfo);
        }

        public DataTable GetBranches(int CompanyId, string BranchName, ref PaginationInfo pager)
        {
            return _branchRepo.GetBranches(CompanyId, BranchName, ref pager);
        }

        public void Update_Branch(BranchInfo _branchInfo)
        {
            _branchRepo.Update(_branchInfo);
        }
        
        public bool CheckBranchNameExist(string branchName)
        {
            return _branchRepo.CheckbranchNameExist(branchName);
        }

        public List<CompanyInfo> GetCompanies()
        {
            return _companyRepo.GetCompanies();
        }
    }
}
