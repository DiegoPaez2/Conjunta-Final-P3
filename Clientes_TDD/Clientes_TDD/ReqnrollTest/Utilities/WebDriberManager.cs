using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqnrollTest.Utilities
{
    public static  class WebDriberManager
    {
        public static IWebDriver GetDriver(string browser)
        {
            return browser.ToLower() switch
            {
                "chrome" => new EdgeDriver(),
                _ => throw new ArgumentException("Navegador no soportado")
            };
        }
    }
}
