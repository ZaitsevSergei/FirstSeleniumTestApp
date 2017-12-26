using _2017.EPAM.FirstSeleniumTestApp.TestWebUIFramework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017.EPAM.FirstSeleniumTestApp.PageObjectLibrary.ExecuteAutomation
{
    /// <summary>
    /// PageObject class for Execute Automation User form
    /// </summary>
    public class PageObjectEAUserForm
    {
        public PageObjectEAUserForm()
        {
            PageFactory.InitElements(WebDriverTools.WebDriver, this);
        }

        /// <summary>
        /// Dropdown list item
        /// </summary>
        [FindsBy(How = How.Id, Using = "TitleId")]
        public IWebElement TitleIdDdl { get; set; }

        /// <summary>
        /// Inital input element
        /// </summary>
        [FindsBy(How = How.Id, Using = "Initial")]
        public IWebElement InitialInput { get; set; }

        /// <summary>
        /// First Name input
        /// </summary>
        [FindsBy(How = How.Id, Using = "FirstName")]
        public IWebElement FirstNameInput { get; set; }

        /// <summary>
        /// Middle Name input
        /// </summary>
        [FindsBy(How = How.Id, Using = "MiddleName")]
        public IWebElement MiddleNameInput { get; set; }

        /// <summary>
        /// Gender male radio buttons
        /// </summary>
        [FindsBy(How = How.Name, Using = "Male")]
        public IWebElement GenderMaleRadioButton { get; set; }

        /// <summary>
        /// Gender female radio buttons
        /// </summary>
        [FindsBy(How = How.Name, Using = "Female")]
        public IWebElement GenderFemaleRadioButton { get; set; }

        /// <summary>
        /// Language english radio buttons
        /// </summary>
        [FindsBy(How = How.Name, Using = "english")]
        public IWebElement LanguageEnglishCheckBox { get; set; }

        /// <summary>
        /// Language female radio buttons
        /// </summary>
        [FindsBy(How = How.Name, Using = "Hindi")]
        public IWebElement LanguageHindiCheckBox { get; set; }

        /// <summary>
        /// Save button
        /// </summary>
        [FindsBy(How = How.Name, Using = "Save")]
        public IWebElement SaveButton { get; set; }
    }
}
