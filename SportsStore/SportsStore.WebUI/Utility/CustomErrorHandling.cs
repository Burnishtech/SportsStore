using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO.Log;
using log4net;
using SportsStore.WebUI.Utility;
using SportsStore.Domain.Entities;

namespace SportsStore.WebUI.Utility
{
    public class CustomErrorHandling : FilterAttribute, IExceptionFilter
    {
        void IExceptionFilter.OnException(ExceptionContext exceptionContext)
        {
            if (!exceptionContext.ExceptionHandled)
            {
                string controllerName = (string)exceptionContext.RouteData.Values["controller"];
                string actionName = (string)exceptionContext.RouteData.Values["action"];

                Exception custException = new Exception("There is some error");
                LogTarget target = LogTarget.Database;
                logDetail LogDetailObject = new logDetail();
                LogDetailObject.ActionName = actionName;
                LogDetailObject.AccessDateTime = DateTime.Now;
                LogDetailObject.ControllerName = controllerName;
                LogHelper.Log(target, LogDetailObject);

                var model = new HandleErrorInfo(custException, controllerName, actionName);

                exceptionContext.Result = new ViewResult
                {
                    ViewName = "~/Views/Shared/Error.cshtml",
                    ViewData = new ViewDataDictionary<HandleErrorInfo>(model),
                    TempData = exceptionContext.Controller.TempData
                };

                exceptionContext.ExceptionHandled = true;

            }
        }

       
    }
}