using FluentValidationWebApp.Models;
using FluentValidationWebApp.Validators;
using Microsoft.AspNetCore.Mvc;

namespace FluentValidationWebApp.Controllers
{
    public class LoanController : Controller
    {
        private readonly LoanApplicationValidator _validator = new LoanApplicationValidator();

        [HttpGet]
        public IActionResult LoanApplication()
        {
            return View(new LoanApplicationModel());
        }

        [HttpPost]
        public IActionResult LoanApplication(LoanApplicationModel model)
        {
            // Validate the model using FluentValidation
            var result = _validator.Validate(model);
            if (!result.IsValid)
            {
                // Add validation errors to ModelState so they appear in the Razor view
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                // Return the view with validation errors
                return View(model);
            }
            // In a real finance scenario, you would save the application or process it here.
            ViewBag.Message = "Loan application submitted successfully!";
            return View(model);
        }
    }
}
