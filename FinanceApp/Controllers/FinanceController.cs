using FinanceApp.Data;
using FinanceApp.Data.Services;
using FinanceApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinanceApp.Controllers
{
    public class FinanceController : Controller
    {
        //we write this line so we can be able to communicate with our database
        private readonly IExpenseService _expenseService;
        public FinanceController(IExpenseService expenseService)
        {
            _expenseService = expenseService;
        }
        public async Task<IActionResult> Index()
        {
            var expenses = await _expenseService.GetAll();
            return View(expenses);
        }

         public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Expense expense)
        {
            if (ModelState.IsValid)
            {
                await _expenseService.Add(expense);
                return RedirectToAction("Index");
            }
            return View(expense);
        }

        public IActionResult GetChart()
        {
            var data = _expenseService.GetChartData();
            return Json(data);
        }
    }
}
