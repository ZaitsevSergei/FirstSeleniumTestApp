using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017.EPAM.FirstSeleniumTestApp.TestWebUIFramework
{
    /// <summary>
    /// Class of extension methods for IWebElement
    /// </summary>
    public static class WebElementExtensions
    {
        /// <summary>
        /// Invokes SendKeys for each web element in collection
        /// </summary>
        /// <param name="webElements">web elements collection</param>
        /// <param name="testText">test string</param>
        public static void SendKeys(this IEnumerable<IWebElement> webElements, string testText)
        {
            Parallel.ForEach(webElements, (webElement) => webElement.SendKeys(testText));            
        }

        /// <summary>
        /// Get values of input elements in collection
        /// </summary>
        /// <param name="webElementCollection">web elements collection</param>
        /// <returns></returns>
        public static string[] GetValuesOfInputs(this IEnumerable<IWebElement> webElementCollection)
        {
            var webElements = webElementCollection.ToArray();
            string[] inputValues = new string[webElements.Length];
            for(int i = 0; i < webElements.Length; i++)
            {
                inputValues[i] = webElements[i].GetAttribute("value");
            }

            return inputValues;
        }

        /// <summary>
        /// Checks that all strings in collection aren't empty 
        /// </summary>
        /// <param name="fieldsValues">Collection of fields string values </param>
        /// <returns></returns>
        public static bool IsFieldsNotEmpty(IEnumerable<string> fieldsValues)
        {
            bool flag = true;
            Parallel.ForEach(fieldsValues, (fieldValue) =>
            {
                if (fieldValue == String.Empty)
                {
                    flag = false;
                }
            });

            return flag;
        }

        /// <summary>
        /// Clicks on each web element in collection
        /// </summary>
        /// <param name="webElements">web elements collection</param>
        public static void Click(this IEnumerable<IWebElement> webElements)
        {
            Parallel.ForEach(webElements, (webElement) => webElement.Click());
        }
    }
}
