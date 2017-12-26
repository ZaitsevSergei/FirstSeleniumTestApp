using _2017.EPAM.FirstSeleniumTestApp.TestWebUIFramework;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using _2017.EPAM.FirstSeleniumTestApp.PageObjectLibrary.ExecuteAutomation;

namespace _2017.EPAM.FirstSeleniumTestApp.FirstSeleniumTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //var method = typeof(By).GetMethod("Id");
        }

        [SetUp]
        public void Initialize()
        {
            // Navigate to web page
            WebDriverTools.WebDriver = new ChromeDriver();
            WebDriverTools.WebDriver.Navigate().GoToUrl("http://executeautomation.com/demosite/index.html?UserName=&amp;Password=&amp;Login=Login");
        }

        // test EA user form web element using page object
        [Test]
        public void TestPageObjectEAUserForm()
        {
            // create page object instance of this page
            PageObjectEAUserForm page = new PageObjectEAUserForm();
            // get properties of page objects that define the page web elements
            var pageProperties = page.GetType().GetProperties();
            // create an array of web elements of the page
            IWebElement[] pageWebElements = new IWebElement[pageProperties.Length];
            for(int i = 0; i < pageProperties.Length; i++)
            {
                pageWebElements[i] = pageProperties[i].GetValue(page) as IWebElement;
            }
            var textWebElements = GetWebElemets.GetSpecifiedTypeInputWebElements(pageWebElements, InputTypeAttributeValue.text).ToArray();
            
        }

        [Test]
        public void TestEAUserFormPositive()
        {

            // enter in FirstName tb "Vasya"
            SeleniumSetMethods.EnterText(How.Id, "FirstName", "Vasya");

            // Select title Mr.
            SeleniumSetMethods.SelectDropDownListItem(How.Id, "TitleId", "Mr.");

            // Click save button
            SeleniumSetMethods.Click(How.Name, "Save");

            System.Diagnostics.Debug.WriteLine("FirstName field is {0}", SeleniumGetMethods.GetText(How.Id, "FirstName"));

            System.Diagnostics.Debug.WriteLine("Title dropdown list's selected item is {0}", SeleniumGetMethods.GetDropDownListSelectedItem(How.Id, "TitleId"));
        }

        [Test]
        public void ExecuteTest()
        {
            //// Find an element
            //IWebElement webElement = webDriver.FindElement(By.Name("q"));
            
            //// Perform operation
            //webElement.SendKeys("mssql");

            //Console.WriteLine("Executed Test");
        }

        [TearDown]
        public void CleanUp()
        {
            Console.WriteLine("All test executed. Do yo want close chrome? y/n: ");
            
            
                WebDriverTools.WebDriver.Close();
            
        }
    }
}
