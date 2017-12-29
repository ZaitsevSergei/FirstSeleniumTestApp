using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2017.EPAM.FirstSeleniumTestApp.TestWebUIFramework;

namespace _2017.EPAM.FirstSeleniumTestApp.TestWebUIFramework
{
    /// <summary>
    /// GetWebElements provide methods to get web elements specific tag, attribute, type
    /// </summary>
    public class GetWebElemets
    {
        /// <summary>
        /// Gets all web elements that have tag 'input'
        /// </summary>
        /// <param name="webElements">Collection of web elements to search in</param>
        /// <returns></returns>
        public static IEnumerable<IWebElement> GetTagInputWebElements(IEnumerable<IWebElement> webElements)
        {
            var tagInputElements = from webElement in webElements
                                  where webElement.TagName == "input"
                                  select webElement;
            return tagInputElements;
        }

        /// <summary>
        /// Gets all text tag 'input' web elements
        /// </summary>
        /// <param name="webElements">Collection of web elements to search in</param>
        /// <returns></returns>
        public static IEnumerable<IWebElement> GetTextFields(IEnumerable<IWebElement> webElements)
        {
            var textWebElements = from webElement in webElements
                                  where webElement.TagName == "input" && webElement.GetAttribute("type") == "text"
                                  select webElement;
            return textWebElements;
        }

        /// <summary>
        /// Get input web element by type
        /// </summary>
        /// <param name="webElements">Collection of web elements to search in</param>
        /// <param name="value">type of inpute tag</param>
        /// <returns></returns>
        public static IEnumerable<IWebElement> GetSpecifiedTypeInputWebElements(IEnumerable<IWebElement> webElements, InputTypeAttributeValue value)
        {
            var inputWebElements = from webElement in webElements
                                  where webElement.TagName == "input" && webElement.GetAttribute("type") == value.ToString()
                                  select webElement;
            return inputWebElements;
        }        
    }
}
