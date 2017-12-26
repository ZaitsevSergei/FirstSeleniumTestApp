using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
namespace _2017.EPAM.FirstSeleniumTestApp.TestWebUIFramework
{
    public class SeleniumGetMethods
    {
        
        /// <summary>
        /// Test method to put text into text control
        /// </summary>
        /// <param name="attribute">Tag, Id, ClassName, Name</param>
        /// <param name="attributeValue">value of element</param>
        /// <param name="testValue">value to test the control</param>
        /// <returns>value of element's 'value' attribute</returns>
        public static string GetText(How attribute, string attributeValue)
        {
            IWebElement webElement = WebDriverTools.FindElement(attribute, attributeValue);
            return webElement?.GetAttribute("value");
        }

        public static string GetDropDownListSelectedItem(How attribute, string attributeValue)
        {
            IWebElement webElement = WebDriverTools.FindElement(attribute, attributeValue);
            if (webElement != null)
            {
                return new SelectElement(webElement).AllSelectedOptions.SingleOrDefault().Text;
            }
            System.Diagnostics.Debug.WriteLine("The element with attribte '{0}' doesn't exist", attribute.ToString());
            return String.Empty;
        }
    }
}
