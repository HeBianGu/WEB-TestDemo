using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HeBianGu.Product.WebApp.Demo
{
    public abstract class ControllerBase : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Debug.WriteLine("OnActionExecuting");

            byte[] result;

            filterContext.HttpContext.Session.TryGetValue("CurrentUser", out result);

            if (result == null)
            {
                filterContext.Result = new RedirectResult("/Home/Login");
                return;
            }

            base.OnActionExecuting(filterContext);
        }

        //  Message：每个控制器的基类Controler 都包含两个过滤器，这个在过滤器之后调用，下面在过滤器之前调用
        public override void OnActionExecuted(ActionExecutedContext context)
        {

            Debug.WriteLine("OnActionExecuted");

            base.OnActionExecuted(context);
        }

        /// <summary>
        /// 获取服务端验证的第一条错误信息
        /// </summary>
        /// <returns></returns>
        public string GetModelStateError()
        {
            foreach (var item in ModelState.Values)
            {
                if (item.Errors.Count > 0)
                {
                    return item.Errors[0].ErrorMessage;
                }
            }
            return "";
        }

        /// <summary>
        /// 获取登录的ID信息
        /// </summary>
        /// <returns></returns>
        public string GetUserID()
        {
            string result = HttpContext.Session.GetString("CurrentUserId");

            return result;
        }

    }
}
