﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLMBiowillBusinessEntities.Common
{
    public enum DataTypes
    {
        Int,
        String,
        DateTime,
        Boolean,
    }


    public enum MessageType
    {
        Information = 1,
        Error = 2,
        Success = 3,
        Warning = 4,
        AcessDenied = 5
    }

    public enum Gender
    {
        Male = 1,
        Female = 2,
        Transgender = 3,
    }


    public enum PaymentOption
    {
        DebitCard = 1,
        CreditCard = 2,
        Cash = 3,
        NEFT = 4,
        Cheque = 5,
    }


    public enum VendorType
    {
        Individual = 1,
        Company = 2,
        Partnership = 3,
    }


    public enum UserRole
    {
        Sale = 1,
        Admin = 2,
        Master = 3,
    }

    public enum Days
    {
        Sunday = 1,
        Monday = 2,
        Tuesday = 3,
        Wednesday = 4,
        Thursday = 5,
        Friday = 6,
        Saturday = 7,
    }

    public enum Months
    {

        Jan = 1,
        Feb = 2,
        Mar = 3,
        Apr = 4,
        May = 5,
        Jun = 6,
        Jul = 7,
        Aug = 8,
        Sep = 9,
        Oct = 10,
        Nov = 11,
        Dec = 12,

    }

    public enum AssignedType
    {
        Auto = 1,
        Manual = 2,

    }

    public enum RoleModule
    {
        Company = 1,
    }

    public enum Function
    {
        Null = 0,
        Create = 1,
        Edit = 2,
        View = 3,
        Delete = 4,
    }

    public enum CustomerType
    {
        Customer = 1,
        Agent = 2,
        Guest = 3,
    }

    public enum DocumentType
    {
        AdharCard = 1,
        Pancard = 2,
        PassportNo = 3,
        DrivingLicense = 4,
    }

    public enum ContactType
    {
        Mobile = 1,
        Landline = 2,
        Fax = 3,
        Emergency = 4,
    }

    public enum AddressType
    {
        Permanent = 1,
        Present = 2,
        Correspondence = 3,
        Office = 4,
    }


}