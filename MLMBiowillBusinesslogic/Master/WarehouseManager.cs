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
    public class WarehouseManager
    {
        WarehouseRepo _warehouseRepo;
        public WarehouseManager()
        {
            _warehouseRepo = new WarehouseRepo();
        }
        public int Insert_Warehouse(WarehouseInfo _warehouseInfo)
        {
            return _warehouseRepo.Insert(_warehouseInfo);
        }

        public DataTable GetWarehouses(int branchId,string warehouseName, ref PaginationInfo pager)
        {
            return _warehouseRepo.GetWarehouses(branchId, warehouseName, ref pager);
        }

        public void Update_Warhouse(WarehouseInfo _warehouseInfo)
        {
            _warehouseRepo.Update(_warehouseInfo);
        }

        public bool CheckWarehouseExist(string warehouse)
        {
            return _warehouseRepo.CheckWarehouseExist(warehouse);
        }
    }
}
