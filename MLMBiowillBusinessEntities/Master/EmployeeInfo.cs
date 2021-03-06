﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLMBiowillBusinessEntities.Master
{
    public class EmployeeInfo
    {
        public int Id { get; set; }
        public string EmployeeCode { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int CompanyId { get; set; }
        public int BranchId { get; set; }
        public int EmploymentType { get; set; }
        public int DesignationId { get; set; }
        public int DepartmentId { get; set; }
        public DateTime JoiningDate { get; set; }
        public int Sex { get; set; }
        public string EmailId { get; set; }
        public DateTime BirthDate { get; set; }
        public String ImagePath { get; set; }
        public bool Active { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
