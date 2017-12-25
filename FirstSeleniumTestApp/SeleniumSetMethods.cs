using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace FirstSeleniumTestApp
{
    public class SeleniumSetMethods
    {
        /// <summary>
        /// Finds an control with specified attribute name and attribute value
        /// </summary>
        /// <param name="webDriver">current web driver</param>
        /// <param name="attribute">The name of attribute: Id, ClassName, Name</param>
        /// <param name="attributeValue">value of attribute</param>
        /// <returns>web control IWebElement if exist. Else return null</returns>
        static IWebElement FindElement(IWebDriver webDriver, string attribute, string attributeValue)
        {
            try
            {
                // Find method from By class with reflection by the name that after will be used if FindElement method of web driver instance
                var findByMethod = typeof(By).GetMethod(attribute);
                // Find the control by the element value and put test string into control
                return webDriver.FindElement((By)findByMethod.Invoke(null, new object[] { attributeValue }));
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("One of the params is null");
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Element with the Element name: '{0}' doesn't exists", attribute, attributeValue);
            }

            return null;
        }

        // Enter Text
        /// <summary>
        /// Test method to put text into text control
        /// </summary>
        /// <param name="webDriver">Web driver of browser</param>
        /// <param name="attribute">Tag, Id, ClassName, Name</param>
        /// <param name="attributeValue">value of element</param>
        /// <param name="testValue">value to test the control</param>
        public static void EnterText(IWebDriver webDriver, string attribute, string attributeValue, string testValue)
        {
            IWebElement webElement = FindElement(webDriver, attribute, attributeValue);
            webElement?.SendKeys(testValue);
        }

        // Click
        /// <summary>
        /// Test method on the specified control 
        /// </summary>
        /// <param name="webDriver">Web driver of browser</param>
        /// <param name="attribute">Tag, Id, ClassName, Name</param>
        /// <param name="attributeValue">value of element</param>
        /// <param name="testValue">value to test the control</param>
        public static void Click(IWebDriver webDriver, string attribute, string attributeValue)
        {
            IWebElement webElement = FindElement(webDriver, attribute, attributeValue);
            webElement?.Click();
        }

        /// <summary>
        /// Selects an specific item in specified dropdown list
        /// </summary>
        /// <param name="webDriver">Web driver of browser</param>
        /// <param name="attribute">Tag, Id, ClassName, Name</param>
        /// <param name="attributeValue">value of element</param>
        /// <param name="itemToSelect">item to select in dropdown list</param>
        public static void SelectDropDownListItem(IWebDriver webDriver, string attribute, string attributeValue, string itemToSelect)
        {
            IWebElement dropDownList = FindElement(webDriver, attribute, attributeValue);
            SelectElement selectDropDownListElement = new SelectElement(dropDownList);
            selectDropDownListElement.SelectByText(itemToSelect);
            
        }
    }
}
