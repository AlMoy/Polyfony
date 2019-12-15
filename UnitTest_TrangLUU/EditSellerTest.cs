using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using ASP.Net_SellIt.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests_TrangLUU
{
    [TestClass]
    public class EditSellerTest
    {
        [TestMethod]
        public async Task EditSeller(long? id)
        {
            //https://docs.microsoft.com/en-us/aspnet/mvc/overview/older-versions-1/unit-testing/creating-unit-tests-for-asp-net-mvc-applications-cs

            // Arrange
            PeopleController controller = new PeopleController();

            // Act
            ViewResult result = await controller.Edit(id) as ViewResult; ;

            // Assert
            Assert.IsNotNull(result);


        }
    }
}
