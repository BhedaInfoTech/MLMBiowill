using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MLMBioWill.Common
{
    public class CustomRazorViewEngine:RazorViewEngine
    {
        public CustomRazorViewEngine() : base()
        {
            ViewLocationFormats = new[] {
                "~/Views/Shared/{0}.cshtml",

                "~/Views/PostLogin/Master/{1}/{0}.cshtml",

                "~/Views/PostLogin/{1}/{0}.cshtml",

            };

            this.ViewLocationFormats = ViewLocationFormats;
            this.PartialViewLocationFormats = ViewLocationFormats;
            this.MasterLocationFormats = ViewLocationFormats;
        }
    }
}