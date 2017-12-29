using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;


namespace _2017.EPAM.FirstSeleniumTestApp.TestWebUIFramework
{
    public class WebDriverTools
    {
        public static IWebDriver WebDriver { get; set; }
        public static IWebElement FindElement(How attribute, string attributeValue)
        {
            try
            {
                // Find method from By class with reflection by the name that after will be used if FindElement method of web driver instance
                var findByMethod = typeof(By).GetMethod(attribute.ToString());
                // Find the control by the element value and put test string into control
                return WebDriver.FindElement((By)findByMethod.Invoke(null, new object[] { attributeValue }));
            }
            catch (ArgumentNullException)
            {
                System.Diagnostics.Debug.WriteLine("One of the params is null");
            }
            catch (NullReferenceException)
            {
                System.Diagnostics.Debug.WriteLine("Element with the Element name: '{0}' doesn't exists", attribute, attributeValue);
            }

            return null;
        }
    }
}
