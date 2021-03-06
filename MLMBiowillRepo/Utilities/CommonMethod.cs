﻿using MLMBiowillBusinessEntities.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MLMBiowillRepo.Utilities
{
    public class CommonMethods
    {

        public static string GetUniqueKey()
        {
            int maxSize = 8;
            //int minSize = 5;
            char[] chars = new char[62];
            string a;
            a = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            chars = a.ToCharArray();
            int size = maxSize;
            byte[] data = new byte[1];
            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            crypto.GetNonZeroBytes(data);
            size = maxSize;
            data = new byte[size];
            crypto.GetNonZeroBytes(data);
            StringBuilder result = new StringBuilder(size);
            foreach (byte b in data)
            {
                result.Append((b % (chars.Length)));

            }
            return result.ToString();
        }

        public static DataTable GetPaginatedTable(DataTable dt, ref PaginationInfo pager)
        {
            if (dt != null && dt.Rows.Count > 0)
            {
                List<DataRow> drList = new List<DataRow>();

                pager = new PaginationInfo(dt.Rows.Count, pager.CurrentPage);

                if (dt != null && dt.Rows.Count > 0)
                {
                    int count = 0;

                    drList = dt.AsEnumerable().ToList();

                    count = drList.Count();

                    dt = dt.Select().Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize).CopyToDataTable();
                }
            }

            return dt;
        }

        public static List<DataRow> GetRows(DataTable dt, ref PaginationInfo pager)
        {
            List<DataRow> drList = new List<DataRow>();

            drList = dt.AsEnumerable().ToList();

            if (pager.IsPagingRequired)
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    int count = 0;

                    count = drList.Count();

                    if (pager.IsPagingRequired)
                    {
                        drList = drList.Skip(pager.CurrentPage * pager.PageSize).Take(pager.PageSize).ToList();
                    }

                    pager.TotalRecords = count;
                    int pages = 1;
                    if (pager.PageSize > 0)
                    {
                        pages = (pager.TotalRecords + pager.PageSize - 1) / pager.PageSize;
                    }   
                    pager.TotalPages = pages;
                }
            }

            return drList;
        }

        internal static IEnumerable<DataRow> GetRows(DataTable dt)
        {
            List<DataRow> drList = new List<DataRow>();

            if (dt != null && dt.Rows.Count > 0)
            {
                int count = 0;

                drList = dt.AsEnumerable().ToList();

                count = drList.Count();


            }

            return drList;
        }

    }
}
