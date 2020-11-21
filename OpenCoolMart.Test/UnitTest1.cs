using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using System;
using Xunit;

namespace OpenCoolMart.Test
{
    //aun no funciona NO TOCAR NADA
    public class BaseTest : IDisposable
    {
        public IWebDriver Navegator { get; set; }
        public BaseTest()
        {
            //TODO:RESOLVER ERROR
            Navegator = new EdgeDriver("c:\\WebDriver");
        }
        public void Dispose()
        {
            Navegator.Close();
        }
    }
    public class UnitTest1 : BaseTest
    {
        [Fact]
        public void Test1()
        {
            Navegator.Url = "https://www.google.com";
            Navegator.Close();

        }
    }
}
