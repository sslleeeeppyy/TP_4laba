using Laba1_TP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;

namespace Laba1_TP.Controllers
{
    public class CalculatorController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(new CalculatorModel());
        }

        [HttpPost]
        public IActionResult Index(CalculatorModel model, string action)
        {
            double compareValue = 100; // Пример значения для сравнения
            ViewBag.CompareValue = compareValue;

            if (action == "Очистить")
            {
                ModelState.Clear();
                return View(new CalculatorModel());
            }

            if (!ModelState.IsValid)
                return View(model);

            switch (model.Operation)
            {
                case "+":
                    model.Result = model.Operand1 + model.Operand2;
                    break;
                case "-":
                    model.Result = model.Operand1 - model.Operand2;
                    break;
                case "*":
                    model.Result = model.Operand1 * model.Operand2;
                    break;
                case "/":
                    model.Result = model.Operand2 != 0 ? model.Operand1 / model.Operand2 : double.NaN;
                    break;
                default:
                    model.Result = double.NaN;
                    break;
            }

            // Сохраняем операцию в cookie
            string opString = $"{model.Operand1} {model.Operation} {model.Operand2} = {model.Result}";
            Response.Cookies.Append("LastOperation", opString, new CookieOptions { Expires = DateTimeOffset.Now.AddMinutes(10) });

            return View(model);
        }

        public IActionResult Result()
        {
            string? opString = Request.Cookies["LastOperation"];
            ViewBag.OperationString = opString;
            return View();
        }
    }
} 