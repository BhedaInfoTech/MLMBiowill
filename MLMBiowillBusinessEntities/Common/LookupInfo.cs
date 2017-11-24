using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLMBiowillBusinessEntities.Common
{
    public class LookupInfo
    {
        public static Dictionary<int, string> Get_ContactType()
        {
            Dictionary<int, string> Get_ContactType = new Dictionary<int, string>();

            Get_ContactType.Add(1, ContactType.Mobile.ToString());

            Get_ContactType.Add(2, ContactType.Landline.ToString());

            Get_ContactType.Add(3, ContactType.Fax.ToString());

            Get_ContactType.Add(4, ContactType.Emergency.ToString());

            return Get_ContactType;
        }

        public static Dictionary<int, string> Get_AddressType()
        {
            Dictionary<int, string> addressType = new Dictionary<int, string>();

            addressType.Add(1, AddressType.Corporate.ToString());

            addressType.Add(2, AddressType.Registered.ToString());

            addressType.Add(3, AddressType.HeadOffice.ToString());
            
            addressType.Add(4, AddressType.Permanent.ToString());

            addressType.Add(5, AddressType.Correspondence.ToString());

            return addressType;
        }

        public static Dictionary<int, string> Get_AddressFor()
        {
            Dictionary<int, string> addressFor = new Dictionary<int, string>();

            addressFor.Add(1, AddressFor.Company.ToString());

            addressFor.Add(2, AddressFor.Branch.ToString());

            addressFor.Add(3, AddressFor.Warehouse.ToString());

            addressFor.Add(4, AddressFor.Employee.ToString());

            addressFor.Add(5, AddressFor.Customer.ToString());

            addressFor.Add(6, AddressFor.Agent.ToString());

            addressFor.Add(7, AddressFor.Courier.ToString());

            return addressFor;
        }
    }
}
