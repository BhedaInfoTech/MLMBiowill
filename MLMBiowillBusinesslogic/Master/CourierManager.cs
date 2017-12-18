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
    public class CourierManager
    {
        CourierRepo _courierRepo;      

        public CourierManager()
        {
            _courierRepo = new CourierRepo();            
        }
        public int Insert_Courier(CourierInfo courierInfo)
        {
            return _courierRepo.Insert(courierInfo);
        }

        public DataTable GetCouriers(string CourierName, ref PaginationInfo pager)
        {
            return _courierRepo.GetCouriers(CourierName, ref pager);
        }

        public void Update_Courier(CourierInfo courierInfo)
        {
            _courierRepo.Update(courierInfo);
        }

        public bool CheckCourierNameExist(string courierName)
        {
            return _courierRepo.CheckCourierNameExist(courierName);
        }

        public CourierInfo GetCourierInfoById(int courierId)
        {
            return _courierRepo.Get_Courier_By_Id(courierId);
        }
    }
}
