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
    public class ContactPersonManager
    {                                                          
        ContactPersonRepo _ContactPersonRepo;

        public ContactPersonManager()
        {
            _ContactPersonRepo = new ContactPersonRepo();
        }

        public Int32 Insert_ContactPerson(ContactPersonInfo AddInfo)
        {
            return _ContactPersonRepo.Insert_ContactPersonMaster(AddInfo);
        }

        public void Update_ContactPerson(ContactPersonInfo AddInfo)
        {
            _ContactPersonRepo.Update_ContactPersonMaster(AddInfo);
        }

        public List<ContactPersonInfo> Get_ContactPersonList(ref PaginationInfo pager)
        {
            return _ContactPersonRepo.Get_ContactPersonMasters(ref pager);
        }

        public ContactPersonInfo Get_ContactPerson_By_Id(int AddInfoId)
        {
            return _ContactPersonRepo.Get_ContactPersonMaster_By_Id(AddInfoId);
        }

        public DataTable Get_Contact_By_Type_For(ContactPersonInfo AddInfo, ref PaginationInfo pager)
        {
            return _ContactPersonRepo.Get_ContactPersonMaster_By_Type_For_Id(AddInfo, ref pager);
        }


        public void Delete_ContactPerson_By_Id(int AddInfoId)
        {
            _ContactPersonRepo.Delete_ContactPersonMaster_By_Id(AddInfoId);
        }

        public bool CheckContactPersonFirstMiddleLastName(string FirstName, string MiddleName, string LastName,string ObjectFor, string ObjectId)
        {
            return _ContactPersonRepo.CheckFirstMiddleLastNameExists(FirstName, MiddleName, LastName, ObjectFor, ObjectId);
        }

        public bool CheckContactPersonEmailId(string EmailId, string ObjectFor, string ObjectId)
        {
            return _ContactPersonRepo.CheckEmailIdExistsforCP(EmailId,ObjectFor,ObjectId);
        }


    }

}
