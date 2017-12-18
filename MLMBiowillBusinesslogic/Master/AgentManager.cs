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
   public class AgentManager
    {
        AgentRepo _agentRepo;

        public AgentManager()
        {
            _agentRepo = new AgentRepo();
        }
        public int Insert_Agent(AgentInfo agentInfo)
        {
            return _agentRepo.Insert(agentInfo);
        }

        public DataTable GetAgents(int BranchId,string FirstName, ref PaginationInfo pager)
        {
            return _agentRepo.GetAgents(BranchId,FirstName, ref pager);
        }

        public void Update_Agent(AgentInfo agentInfo)
        {
            _agentRepo.Update(agentInfo);
        }

        //public bool CheckCourierNameExist(string courierName)
        //{
        //    return _agentRepo.CheckCourierNameExist(courierName);
        //}

        public AgentInfo GetAgentById(int agentId)
        {
            return _agentRepo.Get_Agent_By_Id(agentId);
        }
    }
}
