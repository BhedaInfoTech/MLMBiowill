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

    }
}
