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
    /// EA Login form page object 
    /// </summary>
    public class PageObjectEALoginForm
    {
        public PageObjectEALoginForm()
        {
            PageFactory.InitElements(WebDriverTools.WebDriver, this);
        }

        /// <summary>
        /// UserName text input
        /// </summary>
        [FindsBy(How = How.Name, Using = "UserName")]
        public IWebElement UserName { get; set; }

        /// <summary>
        /// Password input
        /// </summary>
        [FindsBy(How = How.Name, Using = "Password")]
        public IWebElement UserPassword { get; set; }

        /// <summary>
        /// Login button
        /// </summary>
        [FindsBy(How = How.Name, Using = "Login")]
        public IWebElement LoginButton { get; set; }

        /// <summary>
        /// Login action on page
        /// </summary>
        /// <param name="userName">user's name</param>
        /// <param name="password">user's password</param>
        public PageObjectEAUserForm Login(string userName, string password)
        {
            // Send keys to text inputs
            UserName.SendKeys(userName);
            UserPassword.SendKeys(password);

            //Click login button
            LoginButton.Submit();

            return new PageObjectEAUserForm();
        }
    }
}
