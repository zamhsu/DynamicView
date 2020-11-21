using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DynamicView.Core
{
    public class CustomRazorViewEngine : RazorViewEngine
    {
        public CustomRazorViewEngine() : base()
        {
            AreaViewLocationFormats = new[]
            {
                //themes
                "~/Themes/#Theme#/Views/Areas/{2}/{1}/{0}.cshtml",
                "~/Themes/#Theme#/Shared/{0}.cshtml",
                "~/Areas/{2}/Views/{1}/{0}.cshtml",
                "~/Areas/{2}/Views/Shared/{0}.cshtml"
            };
            AreaMasterLocationFormats = new[]
            {
                //themes
                "~/Themes/#Theme#/Views/Areas/{2}/{1}/{0}.cshtml",
                "~/Themes/#Theme#/Views/Areas/{2}/Shared/{0}.cshtml",
                "~/Themes/#Theme#/Views/Shared/{0}.cshtml",
                "~/Areas/{2}/Views/{1}/{0}.cshtml",
                "~/Areas/{2}/Views/Shared/{0}.cshtml"
            };
            AreaPartialViewLocationFormats = new[]
            {
                //themes
                "~/Themes/#Theme#/Views/Shared/{0}.cshtml",
                "~/Areas/{2}/Views/{1}/{0}.cshtml",
                "~/Areas/{2}/Views/Shared/{0}.cshtml"
            };
            ViewLocationFormats = new[]
            {
                //themes
                "~/Themes/#Theme#/Views/{1}/{0}.cshtml",
                "~/Views/{1}/{0}.cshtml",
                "~/Views/Shared/{0}.cshtml"
            };
            MasterLocationFormats = new[]
            {
                //themes
                "~/Themes/#Theme#/Views/Shared/{0}.cshtml",
                "~/Views/{1}/{0}.cshtml",
                "~/Views/Shared/{0}.cshtml"
            };
            PartialViewLocationFormats = new[]
            {
                //themes
                "~/Themes/#Theme#/Views/Shared/{0}.cshtml",
                "~/Views/{1}/{0}.cshtml",
                "~/Views/Shared/{0}.cshtml"
            };

            FileExtensions = new[] { "cshtml" };
        }

        protected override IView CreatePartialView(ControllerContext controllerContext, string partialPath)
        {
            string theme = GetTheme(controllerContext);
            return base.CreatePartialView(controllerContext, partialPath.Replace("#Theme#", theme));
        }
        protected override IView CreateView(ControllerContext controllerContext, string viewPath, string masterPath)
        {
            string theme = GetTheme(controllerContext);
            return base.CreateView(controllerContext, viewPath.Replace("#Theme#", theme), masterPath.Replace("#Theme#", theme));
        }
        protected override bool FileExists(ControllerContext controllerContext, string virtualPath)
        {
            string theme = GetTheme(controllerContext);
            return base.FileExists(controllerContext, virtualPath.Replace("#Theme#", theme));
        }

        private string GetTheme(ControllerContext controllerContext)
        {
            //從Cookie取得主題
            HttpCookie cookie = controllerContext.RequestContext.HttpContext.Request.Cookies["theme"];
            return cookie == null ? null : cookie.Value;
        }
    }
}