using MLMBiowillBusinessEntities.Master;
using MLMBiowillBusinessEntities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MLMBiowillBusinessEntities.City;

namespace MLMBioWill.Models
{
    public class CompanyViewModel
    {
        public CompanyInfo Company { get; set; }
        public List<CompanyInfo> Companylist { get; set; }
        public CompanyFilter Filter { get; set; }
        public PaginationInfo Pager { get; set; }
        public List<FriendlyMessage> FriendlyMessage { get; set; }
        public AddressViewModel AddressViewModelList { get; set; }
        public ContactViewModel ContactViewModelList { get; set; }
        //public List<AddressInfo> Addresslist { get; set; }
        //public List<TeleponeInfo> Contactlist { get; set; }
        //public List<ContactPersonInfo> ContactPersonlist { get; set; }
        //public List<CityInfo> Cities { get; set; }

        public CompanyViewModel()
        {
            Company = new CompanyInfo();
            Companylist = new List<CompanyInfo>();
            Filter = new CompanyFilter();
            Pager = new PaginationInfo();
            FriendlyMessage = new List<FriendlyMessage>();
            AddressViewModelList = new AddressViewModel();
            ContactViewModelList = new ContactViewModel();

            AddressViewModelList.Address.AddressFor = AddressFor.Company.ToString();
            ContactViewModelList.ContactDetails.ContactFor = AddressFor.Company.ToString();

            //Addresslist = new List<AddressInfo>();
            //Contactlist = new List<TeleponeInfo>();
            //ContactPersonlist = new List<ContactPersonInfo>();
            //Cities = new List<CityInfo>();
            
        }



    }
}