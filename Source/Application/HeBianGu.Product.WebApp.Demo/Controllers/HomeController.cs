using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HeBianGu.Product.WebApp.Demo.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using HeBianGu.Product.Respository.IService;
using Microsoft.Extensions.Logging;
using HeBianGu.Product.Respository.Model;
using HeBianGu.Product.Base.Model;
using Microsoft.AspNetCore.Http;
using HeBianGu.Product.General.ThridTool;
using System.Reflection;
using System.ComponentModel;

namespace HeBianGu.Product.WebApp.Demo.Controllers
{
    public class HomeController : Controller
    {
        IUserAccountRespositroy _respository;

        public HomeController(IUserAccountRespositroy respository)
        {
            _respository = respository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [DescriptionAttribute("用户登录操作")]
        public async Task<IActionResult> Login(LoginViewModel model)
        {

            ////跳转到系统首页
            //return RedirectToAction("Monitor", "Monitor");

            if (ModelState.IsValid)
            {
                //检查用户信息 
                var user = await _respository.FirstOrDefaultAsync(l => l.NAME == model.UserName && l.PASSWORD == model.Password);

                if (user != null)
                {
                    //记录Session
                    HttpContext.Session.SetString("CurrentUserId", user.ID.ToString());
                    HttpContext.Session.Set("CurrentUser", ByteConvertHelper.Object2Bytes(user));

                    //var type = MethodBase.GetCurrentMethod().GetCustomAttributes<DescriptionAttribute>();  

                    await this._respository.WriteUserLogger(user.ID, "用户登录", user.NAME);

                    //跳转到系统首页
                    return RedirectToAction("Monitor", "Monitor");

                }

                ViewBag.ErrorInfo = "用户名或密码错误。";

                return View();
            }

            foreach (var item in ModelState.Values)
            {
                if (item.Errors.Count > 0)
                {
                    ViewBag.ErrorInfo = item.Errors[0].ErrorMessage;
                    break;
                }
            }

            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        //  Message：每个控制器的基类Controler 都包含两个过滤器，这个在过滤器之后调用，下面在过滤器之前调用
        public override void OnActionExecuted(ActionExecutedContext context)
        {

            Debug.WriteLine("OnActionExecuted");

            base.OnActionExecuted(context);
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Debug.WriteLine("OnActionExecuting");

            base.OnActionExecuting(context);
        }
    }
}
