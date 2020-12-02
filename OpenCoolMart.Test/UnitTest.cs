using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using OpenCoolMart.Gui.Controllers;
using OpenCoolMart.Gui.Models;
using Xunit;
//using Bogus;
namespace OpenCoolMart.Test
{
    //Api = localhost:44315
    //Gui = localhost:44368

    public class UnitTest
    {
        public HomeController ObjHomeController { get; }
        //public Faker DataFaker { get; set; }

        public UnitTest()
        {
            ObjHomeController = new HomeController();
            //DataFaker = new Faker();
        }

        [Fact]
        public async Task Usuario_Contraseña_CorrectosAsync()
        {

            LoginModel login = new LoginModel
            {
                //Email = DataFaker.Internet.Email(),
                //Password = DataFaker.Internet.Password(8)
            };
            var result = await ObjHomeController.IndexAsync(login) as RedirectToActionResult;
            Assert.Equal("Menu",result.ActionName);
        }
        [Fact]
        public async Task Usuario_Contraseña_No_ExistentesAsync()
        {
            LoginModel login = new LoginModel
            {
                Email = "kennetavila@gmail.com",
                Password = "1213131516"
            };
            var result = await ObjHomeController.IndexAsync(login) as ViewResult;
            Assert.Null(result.ViewName);
        }
        [Fact]
        public async Task Usuario_Contraseña_VaciosAsync()
        {
            LoginModel login = new LoginModel();
            var result = await ObjHomeController.IndexAsync(login) as ViewResult;
            Assert.Null(result.Model);
        }

        [Fact]
        public async Task Contraseña_VaciaAsync()
        {
            LoginModel login = new LoginModel()
            {
                Email = "kennetavila@gmail.com",
            };
            var result = await ObjHomeController.IndexAsync(login) as ViewResult;
            Assert.Null(result.ViewName);
        }
        [Fact]
        public async Task Usuario_VacioAsync()
        {
            LoginModel login = new LoginModel() 
            {
                Password = "1213131516"
            };
            var result = await ObjHomeController.IndexAsync(login) as ViewResult;
            Assert.Null(result.ViewName);
        }
    }
}
