using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transcation_app.Dtos;
using Transcation_app.Enum;
using Transcation_app.Interfaces;
using Transcation_app.Models;
using Transcation_app.Services;
using Transcation_app.ViewModel;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Transcation_app.Controllers
{
    public class TransactionController : Controller
    {
        //private readonly TransactionService _service;
        private readonly ITransactionService _service;
        public TransactionController(ITransactionService service)
        {
            _service = service;
        }
        // GET: Transaction
        public async Task<IActionResult> Index(TransactionIndexViewModel vm)
        {
            TransactionIndexViewModel data = await _service.Index(vm);
            return View(data);
        }

        // GET: Transactions/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var transaction = await _service.Details(id);
            if (transaction == null)
            {
                return NotFound();
            }
            return View(transaction);
        }

        // GET: Transaction/Create
        public IActionResult Create()
        {
            var transaction = new TransactionUpdateViewModel();
            transaction.data = new TransactionDto_Post
            {
                Status = string.Empty,
                Contents = string.Empty,
                CreatedDateTime = DateTime.Now,
                Amount = 0,
                UpdateUserId = 1
            };
            transaction.status = CreateOptions();
            return View(transaction);
        }

        // POST: Transaction/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] TransactionUpdateViewModel transaction)
        {
            if (ModelState.IsValid)
            {
                await _service.Create(transaction.data);
                return RedirectToAction(nameof(Index));
            }
            return View(transaction);
        }
        // GET: Transaction/Edit/5
        public async Task<IActionResult> Edit([FromRoute] Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var transaction = new TransactionUpdateViewModel();
            transaction.data = await _service.Edit_Get(id);
            transaction.status = CreateOptions();
            transaction.status.Find(x => x.Value == transaction.data.Status).Selected = true;
            if (transaction.data == null)
            {
                return NotFound();
            }
            return View(transaction);
        }

        // POST: Transaction/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromRoute] Guid id, [FromForm] TransactionDto_Post data)
        {
            if (id != data.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                await _service.Edit_Post(data);
                return RedirectToAction(nameof(Index));
            }
            return View(data);
        }

        // GET: Transaction/Delete/5
        public async Task<IActionResult> Delete([FromRoute] Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var transaction = await _service.Delete_Get(id);
            if (transaction == null)
            {
                return NotFound();
            }
            return View(transaction);
        }

        // POST: Transaction/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed([FromRoute] Guid id)
        {
            await _service.DeleteConfirmed(id);
            return RedirectToAction(nameof(Index));
        }
        public List<SelectListItem> CreateOptions()
        {
            SelectListItem PENDING = new SelectListItem() { Text = "處理中", Value = "PENDING" };
            SelectListItem SUCCESS = new SelectListItem() { Text = "已付款", Value = "SUCCESS" };
            SelectListItem CANCEL = new SelectListItem() { Text = "取消", Value = "CANCEL" };
            return new List<SelectListItem> { PENDING, SUCCESS, CANCEL };
        }
    }
}
