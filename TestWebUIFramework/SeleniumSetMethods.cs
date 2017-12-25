using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;

namespace _2017.EPAM.FirstSeleniumTestApp.TestWebUIFramework
{
    public class SeleniumSetMethods
    {
        // Enter Text
        /// <summary>
        /// Test method to put text into text control
        /// </summary>
        /// <param name="attribute">Tag, Id, ClassName, Name</param>
        /// <param name="attributeValue">value of element</param>
        /// <param name="testValue">value to test the control</param>
        public static void EnterText(How attribute, string attributeValue, string testValue)
        {
            IWebElement webElement = WebDriverTools.FindElement(attribute, attributeValue);
            webElement?.SendKeys(testValue);
        }

        // Click
        /// <summary>
        /// Test method on the specified control 
        /// </summary>
        /// <param name="attribute">Tag, Id, ClassName, Name</param>
        /// <param name="attributeValue">value of element</param>
        /// <param name="testValue">value to test the control</param>
        public static void Click(How attribute, string attributeValue)
        {
            IWebElement webElement = WebDriverTools.FindElement(attribute, attributeValue);
            webElement?.Click();
        }

        /// <summary>
        /// Selects an specific item in specified dropdown list
        /// </summary>
        /// <param name="attribute">Tag, Id, ClassName, Name</param>
        /// <param name="attributeValue">value of element</param>
        /// <param name="itemToSelect">item to select in dropdown list</param>
        public static void SelectDropDownListItem(How attribute, string attributeValue, string itemToSelect)
        {
            IWebElement dropDownList = WebDriverTools.FindElement(attribute, attributeValue);
            SelectElement selectDropDownListElement = new SelectElement(dropDownList);
            selectDropDownListElement.SelectByText(itemToSelect);
            
        }
    }
}
