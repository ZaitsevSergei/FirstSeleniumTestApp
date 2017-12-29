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
using System.Diagnostics;

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
            var page = new PageObjectEAUserForm();
            page.FirstNameInput.SendKeys("hi");
            // get properties of page objects that define the page web elements
            var pageProperties = page.GetType().GetProperties();
            // create an array of web elements of the page ant init it in the loop
            IWebElement[] pageWebElements = new IWebElement[pageProperties.Length];
            for(int i = 0; i < pageProperties.Length; i++)
            {
                pageWebElements[i] = pageProperties[i].GetValue(page) as IWebElement;
            }

            // get all input text fields
            var textWebElements = GetWebElemets.GetSpecifiedTypeInputWebElements(pageWebElements, InputTypeAttributeValue.text).ToArray();
            // send test strings to them
            WebElementExtensions.SendKeys(textWebElements, "test string");
            Debug.WriteLine("test strings sent to inputs");
            // get values of these fields
            var textWebElementValues = WebElementExtensions.GetValuesOfInputs(textWebElements);
            // check that they isn't empty
            Assert.AreEqual(true, WebElementExtensions.IsFieldsNotEmpty(textWebElementValues));

            // get all input checkboxes
            var checkboxWebElements = GetWebElemets.GetSpecifiedTypeInputWebElements(pageWebElements, InputTypeAttributeValue.checkbox).ToArray();
            WebElementExtensions.Click(checkboxWebElements);
            
            // get all input radio buttons
            var radioWebElements = GetWebElemets.GetSpecifiedTypeInputWebElements(pageWebElements, InputTypeAttributeValue.radio).ToArray();
            WebElementExtensions.Click(radioWebElements);

            // get all buttons
            var buttonWebElements = GetWebElemets.GetSpecifiedTypeInputWebElements(pageWebElements, InputTypeAttributeValue.button).ToArray();
            WebElementExtensions.Click(buttonWebElements);

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
