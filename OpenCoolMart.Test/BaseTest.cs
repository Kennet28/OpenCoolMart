using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using OpenCoolMart.Gui;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace OpenCoolMart.Test
{

    public class BaseTest : IDisposable
    {
        public IWebDriver Navegator { get; set; }
        public BaseTest()
        {
            //var Server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            //Server.CreateClient();
            Navegator = new ChromeDriver("C:\\WebDrivers");
        }
        public void Dispose()
        {
            Navegator.Close();
        }
    }
}
