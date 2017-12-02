using MLMBiowillBusinessEntities.Common;
using MLMBiowillBusinessEntities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MLMBioWill.Models.Master
{
    public class SeriesViewModel
    {
        public SeriesViewModel()
        {
            SeriesInfo = new SeriesInfo();

            FriendlyMessage = new List<FriendlyMessage>();

            Pager = new PaginationInfo();

            CompanyInfo = new List<CompanyInfo>();

            SeriesInfoList = new List<SeriesInfo>();
        }

        public List<SeriesInfo> SeriesInfoList { get; set; }

        public SeriesInfo SeriesInfo { get; set; }

        public List<FriendlyMessage> FriendlyMessage { get; set; }

        public PaginationInfo Pager { get; set; }

        public List<CompanyInfo> CompanyInfo { get; set; }
    }

    public class SeriesFilter
    {         
        public int Id { get; set; }
    }
}