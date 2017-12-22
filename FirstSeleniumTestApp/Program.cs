using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstSeleniumTestApp
{
    class Program
    {
        // Create a reference for browser
        IWebDriver webDriver = new ChromeDriver();

        static void Main(string[] args)
        {            
        }

        [SetUp]
        public void Initialize()
        {
            // Navigate to web page
            webDriver.Navigate().GoToUrl("http://executeautomation.com/demosite/index.html?UserName=&amp;Password=&amp;Login=Login");
        }

        [Test]
        public void ExecuteTest()
        {
            // Find an element
            IWebElement webElement = webDriver.FindElement(By.Name("q"));
            
            // Perform operation
            webElement.SendKeys("mssql");

            Console.WriteLine("Executed Test");
        }

        [TearDown]
        public void CleanUp()
        {
            webDriver.Close();
        }
    }
}
