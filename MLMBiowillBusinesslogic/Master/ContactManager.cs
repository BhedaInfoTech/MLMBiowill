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

    public class ContactManager
    {

        ContactRepo _ContactRepo;

        public ContactManager()
        {
            _ContactRepo = new ContactRepo();
        }

        public Int32 Insert_Contact(ContactInfo AddInfo)
        {
            return _ContactRepo.Insert_ContactMaster(AddInfo);
        }

        public void Update_Contact(ContactInfo AddInfo)
        {
            _ContactRepo.Update_ContactMaster(AddInfo);
        }

        public List<ContactInfo> Get_ContactList(ref PaginationInfo pager)
        {
            return _ContactRepo.Get_ContactMasters(ref pager);
        }

        public ContactInfo Get_Contact_By_Id(int AddInfoId)
        {
            return _ContactRepo.Get_ContactMaster_By_Id(AddInfoId);
        }

        public DataTable Get_Contact_By_Type_For(ContactInfo AddInfo, ref PaginationInfo pager)
        {
            return _ContactRepo.Get_ContactMaster_By_Type_For_Id(AddInfo, ref pager);
        }


        public void Delete_Contact_By_Id(int AddInfoId)
        {
            _ContactRepo.Delete_ContactMaster_By_Id(AddInfoId);
        }

        //public bool CheckContactType(string ContactType, string ContactFor, string ObjectId)
        //{
        //    return _ContactRepo.CheckContactType(ContactType, ContactFor, ObjectId);
        //}
    }

}
