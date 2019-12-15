using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web;
using ASP.Net_SellIt.Controllers;
using ASP.Net_SellIt.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests_TrangLUU
{
    [TestClass]
    public class LoginTest
    {
        //https://stackoverflow.com/questions/25718394/getting-error-cannot-convert-type-actionresult-to-viewresult-in-unit-testing
        [TestMethod]
        public async Task Login_Test()
        {
            // Arrange
            var loginModel = new LoginViewModel() { Email = "Admin@admin.com", Password = "admin123" };
            var controller = new AccountController();

            // Validate model state start
            var validationContext = new ValidationContext(loginModel, null, null);
            var validationResults = new List<ValidationResult>();

            //set validateAllProperties to true to validate all properties; if false, only required attributes are validated.
            Validator.TryValidateObject(loginModel, validationContext, validationResults, true);
            foreach (var validationResult in validationResults)
            {
                controller.ModelState.AddModelError(validationResult.MemberNames.First(), validationResult.ErrorMessage);
            }
            // Validate model state end


            // Act

            var result = await controller.Login(loginModel, null) as RedirectToRouteResult;

            // Assert
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.AreEqual("Home", result.RouteValues["controller"]);
        }
    }
}
