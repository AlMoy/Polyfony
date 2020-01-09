using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityASP;
using EntityASP.Entity;
using EntityASP.Repository;
using NUnit.Framework;
using System.Web.Mvc;
using ASP.Net_SellIt.Models;
using ASP.Net_SellIt.Controllers;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace UnitTestASPNet
{
    [TestFixture]
    public class UnitTest1
        {
        [SetUp]
        protected void SetUp()
            {}

        [Test]
        public void ConnectionDatabase(AppDbContext appDbContext)
            {
            Assert.IsTrue(appDbContext.CheckConnection());
            }

        [Test]
        public async Task<List<T>> GetListAsync<T>(Repository<T> repository)
            {
            List<T> list = await repository.FindAllAsync();
            Assert.IsEmpty(list);
            return list;
            }

        [Test]
        public async Task<List<T>> GetListFilteredAsync<T>(Repository<T> repository, Dictionary<String, String> criteria, Dictionary<String, String> orderBy = null, long? limit = null, long? offset = null)
            {
            List<T> list = await repository.FindByAsync(criteria, orderBy, limit, offset);
            Assert.IsEmpty(list);
            return list;
            }

        [Test]
        public void ToAccessAdmin(Person person)
            {
            Assert.IsTrue(person.Role.Name == "admin");
            }

        [Test]
        public void LoginTest()
            {//https://stackoverflow.com/questions/25718394/getting-error-cannot-convert-type-actionresult-to-viewresult-in-unit-testing
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

            //var result =  controller.Login(loginModel, null) as RedirectToRouteResult;

            // Assert
            //Assert.AreEqual("Index", result.RouteValues["action"]);
           // Assert.AreEqual("Home", result.RouteValues["controller"]);
        }

        [Test]
        public void EditSeller(ulong id)
            {
            //https://docs.microsoft.com/en-us/aspnet/mvc/overview/older-versions-1/unit-testing/creating-unit-tests-for-asp-net-mvc-applications-cs

            // Arrange
            /*PeopleController controller = new PeopleController();

            // Act
            ViewResult result =  controller.Edit(id) as ViewResult; 

            // Assert
            Assert.IsNotNull(result);*/
            }

        [Test]
        public async Task DeleteElementAsync<T>(Repository<T> repository, long id)
            {
            await repository.Remove(await repository.FindAsync(id));
            Assert.IsTrue(await repository.FindAsync(id) != null);
            }

        [Test]
        public async Task FindElementAsync<T>(Repository<T> repository, long id) 
            {
            Assert.IsNotNull(await repository.FindAsync(id));
            }

        [Test]
        public void CreateElement<T>(Repository<T> repository, T element)
            {
            Assert.IsNotNull(repository.CreateAsync(element));
            }
        }
    }
