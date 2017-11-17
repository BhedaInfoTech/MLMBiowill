﻿using MLMBiowillBusinessEntities.Common;
using MLMBiowillBusinesslogic.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MLMBioWill.Controllers.PostLogin
{
    public class AutoCompleteController : Controller
    {
        // GET: AutoComplete
        public JsonResult GetTableData(string q, int page, int pageLimit, string idFieldName, string textFieldName, string tableName, string dependentFieldName, string dependentFieldValue, string extraFields)
        {
            //List<IdTextInfo> aList = new List<IdTextInfo>();

            DataTable aList = new DataTable();

            AutoCompleteManager aRepo = new AutoCompleteManager();

            int totalCount = 0;

            string data = "";

            try
            {
                aList = aRepo.GetTableData(q, page, idFieldName, textFieldName, tableName, dependentFieldName, dependentFieldValue, extraFields);

                totalCount = aList.Rows.Count;

                data = JsonConvert.SerializeObject(aList);
            }
            catch (Exception ex)
            {

            }

            return Json(new
            {
                data,
                totalCount,
                page
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetTableDataById(string id, string idFieldName, string textFieldName, string tableName, string extraFields)
        {
            //List<IdTextInfo> aList = new List<IdTextInfo>();

            DataTable aList = new DataTable();

            AutoCompleteManager autoManager = new AutoCompleteManager();

            int totalCount = 0;

            string data = "";

            try
            {
                aList = autoManager.GetTableDataById(id, idFieldName, textFieldName, tableName, extraFields);

                totalCount = aList.Rows.Count;

                data = JsonConvert.SerializeObject(aList);
            }
            catch (Exception ex)
            {

            }

            return Json(new
            {
                data
            }, JsonRequestBehavior.AllowGet);
        }

        public JavaScriptResult GetScriptByPageName(string pageName)
        {
            string javascript = "";

            AutoCompleteManager autoManager = new AutoCompleteManager();

            List<AutocompleteInfo> autoCompleteList = new List<AutocompleteInfo>();

            try
            {
                autoCompleteList = autoManager.GetAutocompletesByPageName(pageName);

                javascript += "$(function(){ ";

                foreach (var item in autoCompleteList)
                {
                    javascript += "SetAutocomplete('" + item.ControlName + "','" + item.IdFieldName + "','" + item.TextFieldName + "','" + item.TableName + "','" + item.DependentControlName + "','" + item.DependentFieldName + "','" + item.ExtraFields + "');";

                    javascript += "GetAutocomplete('" + item.ControlName + "','" + item.IdFieldName + "','" + item.TextFieldName + "','" + item.TableName + "','" + item.ExtraFields + "');";

                    if (!string.IsNullOrEmpty(item.DependentControlName) && item.IsMultiselect != true)
                    {
                        foreach (var itm in item.DependentControlName.Split(','))
                        {
                            javascript += "$(\"[name='" + itm + "']\").change(function(){";

                            javascript += "$(\"[name='" + item.ControlName + "']\").html('');";

                            javascript += "});";
                        }
                    }
                }

                javascript += "});";
            }
            catch (Exception ex)
            {

            }

            return JavaScript(javascript);
        }
    }
}