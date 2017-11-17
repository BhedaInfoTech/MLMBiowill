using MLMBiowillBusinessEntities.Common;
using MLMBiowillBusinessEntities.Master;
using MLMBiowillRepo.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLMBiowillBusinesslogic.Master
{

    public class AddressManager
    {

        AddressRepo _AddressRepo;

        public AddressManager()
        {
            _AddressRepo = new AddressRepo();
        }

        public void Insert_Address(AddressInfo AddInfo)
        {
            _AddressRepo.Insert_AddressMaster(AddInfo);
        }

        public void Update_Address(AddressInfo AddInfo)
        {
            _AddressRepo.Update_AddressMaster(AddInfo);
        }

        public List<AddressInfo> Get_AddressList(ref PaginationInfo pager)
        {
            return _AddressRepo.Get_AddressMasters(ref pager);
        }

        public AddressInfo Get_Address_By_Id(int AddInfoId)
        {
            return _AddressRepo.Get_AddressMaster_By_Id(AddInfoId);
        }

        public void Delete_Address_By_Id(int AddInfoId)
        {
            _AddressRepo.Delete_AddressMaster_By_Id(AddInfoId);
        }
    }

}
