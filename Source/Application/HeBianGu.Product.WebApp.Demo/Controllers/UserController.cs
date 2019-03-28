using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HeBianGu.Product.Base.Model;
using HeBianGu.Product.General.LocalDataBase;
using HeBianGu.Prodoct.Domain.DataServce;
using System.Diagnostics;
using HeBianGu.Product.Respository.IService;

namespace HeBianGu.Product.WebApp.Demo.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly IUserAccountRespositroy _respository;

        public UserController(IUserAccountRespositroy respository)
        {
            _respository = respository;
        }

        // GET: User
        public async Task<IActionResult> Index()
        {
            var result = await _respository.GetListAsync();

            return View(result);
        }

        // GET: User/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = _respository.GetByIDAsync(id);

            if (model.Result == null)
            {
                return NotFound();
            }

            return View(model.Result);
        }

        // GET: User/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,NAME,PASSWORD,USERNAME,TEL,ROLEID")] ehc_dv_user model)
        {
            if (ModelState.IsValid)
            {
                model.CDATE = DateTime.Now.ToDateTimeString();
                model.UDATE = DateTime.Now.ToDateTimeString();
                model.ISENBLED = 1;

                await _respository.InsertAsync(model);

                await _respository.WriteUserLogger(this.GetUserID(), "添加系统用户", model.USERNAME);

                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: User/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = await _respository.GetByIDAsync(id);

            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ID,NAME,PASSWORD,USERNAME,TEL,ROLEID")] ehc_dv_user model)
        {
            if (id != model.ID.ToString())
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _respository.UpdateAsync(model);

                    await _respository.WriteUserLogger(this.GetUserID(), "编辑系统用户", model.USERNAME);
                }
                catch (DbUpdateConcurrencyException)
                {
                    var result = await _respository.GetByIDAsync(id);

                    if (result == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {

            await _respository.DeleteAsync(id);

            await _respository.WriteUserLogger(this.GetUserID(), "添加系统用户", id);

            return RedirectToAction(nameof(Index));
        }
    }
}
