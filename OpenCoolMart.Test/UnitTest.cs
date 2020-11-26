using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using OpenCoolMart.Gui.Controllers;
using OpenCoolMart.Gui.Models;
using OpenQA.Selenium;
using Xunit;

namespace OpenCoolMart.Test
{
    //Api = localhost:44315
    //Gui = localhost:44368

    public class UnitTest /*: BaseTest*/
    {
        public HomeController ObjHomeController { get; }

        public UnitTest()
        {
            ObjHomeController = new HomeController();
        }

        [Fact]
        public void Usuario_Contraseña_CorrectosAsync()
        {
            //Navegator.Url = "https://localhost:44368";
            //Quita acepta que el localhost es inseguro y continua a la pagina
            //Navegator.FindElement(By.Id("details-button")).Click();
            //Navegator.FindElement(By.Id("proceed-link")).Click();
            //Valida que el navegador este en la pagina del login
            //Navegator.FindElement(By.Id("Email")).Click();
            //Navegator.FindElement(By.Id("Email")).SendKeys("kennetavila@gmail.com");
            //Navegator.FindElement(By.Id("Password")).Click();
            //Navegator.FindElement(By.Id("Password")).SendKeys("123456");
            //Navegator.FindElement(By.Id("boton")).Click();
            LoginModel login = new LoginModel
            {
                Email = "kennetavila@gmail.com"/*Navegator.FindElement(By.Id("Email")).Text*/,
                Password = "123456"
            };
            //Act
            //ViewResult ObjResult =  as ViewResult;
            //Assert
            //Assert.Equal(RedirectToAction("Menu"), await ObjHomeController.IndexAsync(login));

        }
    }
}
