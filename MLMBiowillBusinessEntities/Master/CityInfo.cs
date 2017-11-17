﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLMBiowillBusinessEntities.City
{
    public class CityInfo
    {
        public CityInfo()
        {

        }

        public int CityId { get; set; }

        public int CountryId { get; set; }

        public string CountryName { get; set; }

        public int StateId { get; set; }

        public string StateName { get; set; }

        public string CityCode { get; set; }

        public string CityName { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedOn { get; set; }

        public int CreatedBy { get; set; }

        public DateTime UpdatedOn { get; set; }

        public int UpdatedBy { get; set; }

    }
}
