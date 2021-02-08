using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OpenCoolMart.Gui.Controllers;
using OpenCoolMart.Gui.Models;
using Xunit;

//using Bogus;
namespace OpenCoolMart.XUnitTest
{
    //Api = localhost:44315
    //Gui = localhost:44368

    public class UnitTest
    {
        // private HomeController ObjHomeController { get; }
        // //public Faker DataFaker { get; set; }

        // public UnitTest()
        // {
        //     ObjHomeController = new HomeController();
        //     //DataFaker = new Faker();
        // }

        // [Fact]
        // public async Task Usuario_Contrase�a_CorrectosAsync()
        // {

        //     var login = new LoginModel
        //     {
        //         //Email = DataFaker.Internet.Email(),
        //         //Password = DataFaker.Internet.Password(8)
        //     };
        //     if (await ObjHomeController.Index(login) is RedirectToActionResult result) Assert.Equal("Menu", result.ActionName);
        // }
        // [Fact]
        // public async Task Usuario_Contrase�a_No_ExistentesAsync()
        // {
        //     var login = new LoginModel
        //     {
        //         Email = "kennetavila@gmail.com",
        //         Password = "1213131516"
        //     };
        //     if (await ObjHomeController.Index(login) is ViewResult result) Assert.Null(result.ViewName);
        // }
        // [Fact]
        // public async Task Usuario_Contrase�a_VaciosAsync()
        // {
        //     var login = new LoginModel();
        //     if (await ObjHomeController.Index(login) is ViewResult result) Assert.Null(result.Model);
        // }

        // [Fact]
        // public async Task Contrase�a_VaciaAsync()
        // {
        //     var login = new LoginModel()
        //     {
        //         Email = "kennetavila@gmail.com",
        //     };
        //     if (await ObjHomeController.Index(login) is ViewResult result) Assert.Null(result.ViewName);
        // }
        // [Fact]
        // public async Task Usuario_VacioAsync()
        // {
        //     var login = new LoginModel() 
        //     {
        //         Password = "1213131516"
        //     };
        //     if (await ObjHomeController.Index(login) is ViewResult result) Assert.Null(result.ViewName);
        // }
    }
}
