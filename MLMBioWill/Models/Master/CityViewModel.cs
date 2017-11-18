﻿using MLMBiowillBusinessEntities.City;
using MLMBiowillBusinessEntities.Common;
using MLMBiowillBusinessEntities.Country;
using MLMBiowillBusinessEntities.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

                                     

namespace MLMBioWill.Models.Master
{
    public class CityViewModel
    {

        public CityViewModel()
        {
            City = new CityInfo();

            Filter = new CityFilter();

            Cities = new List<CityInfo>();

            Countries = new List<CountryInfo>();

            States = new List<StateInfo>();

            Pager = new PaginationInfo();

            FriendlyMessage = new List<FriendlyMessage>();

        }

        public CityInfo City { get; set; }

        public CityFilter Filter { get; set; }

        public List<CityInfo> Cities { get; set; }

        public PaginationInfo Pager { get; set; }

        public List<CountryInfo> Countries { get; set; }

        public List<StateInfo> States { get; set; }

        public List<FriendlyMessage> FriendlyMessage { get; set; }

    }

    public class CityFilter
    {
        public string CityName { get; set; }

        public string CityId { get; set; }

    }

}