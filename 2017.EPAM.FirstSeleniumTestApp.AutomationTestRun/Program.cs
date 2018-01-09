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
            
            // send test strings to text fields using TextInputFields
            WebElementExtensions.SendKeys(page.TextInputTags, "another string");

            // get values of these fields
            var textWebElementValues = WebElementExtensions.GetValuesOfInputs(page.TextInputTags);
            // check that they isn't empty
            Assert.AreEqual(true, WebElementExtensions.IsFieldsNotEmpty(textWebElementValues));

            // get all input checkboxes, click them
            WebElementExtensions.Click(page.CheckBoxes);            

            // get all input radio buttons, click them
            WebElementExtensions.Click(page.RadioButtons);

            // save changes by clicking save button
            page.SaveButton.Click();

            // check controls
            // verify checkboxes
            Assert.AreEqual(true, ButtonsExtensions.VerifyCheckboxesGroup(page.CheckBoxes, 2));
            // verify radio buttons
            Assert.AreEqual(true, ButtonsExtensions.VerifyRadioButtonsGroup(page.RadioButtons));
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
