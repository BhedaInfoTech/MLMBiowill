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
    public class BankManager
    {
        BankRepo _bankRepo;
        public BankManager()
        {
            _bankRepo = new BankRepo();
        }
        public int Insert_Bank(BankInfo _bankInfo)
        {
            return _bankRepo.Insert(_bankInfo);
        }

        public DataTable GetBanks( string bankName, ref PaginationInfo pager)
        {
            return _bankRepo.GetBanks(bankName, ref pager);
        }

        public void Update_Bank(BankInfo _bankInfo)
        {
            _bankRepo.Update(_bankInfo);
        }

        public bool CheckBankExist(string bank)
        {
            return _bankRepo.CheckbankNameExist(bank);
        }
    }
}
