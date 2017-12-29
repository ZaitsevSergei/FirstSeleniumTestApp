using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017.EPAM.FirstSeleniumTestApp.TestWebUIFramework
{
    /// <summary>
    /// extension method for web buttons: checkboxes, radio, submit
    /// </summary>
    public static class ButtonsExtensions
    {
        /// <summary>
        /// Verify that checked only one radio batton in group
        /// </summary>
        /// <param name="radioButtons"></param>
        /// <returns></returns>
        public static bool VerifyRadioButtonsGroup(this IEnumerable<IWebElement> radioButtons)
        {
            int selectedQuantity = SelectedCount(radioButtons);
            return CheckBounds(selectedQuantity, 1, 1);
        }

        /// <summary>
        /// Verify that quantity of checked element not less as required
        /// </summary>
        /// <param name="checkboxes"></param>
        /// <param name="maximum"></param>
        /// <returns></returns>
        public static bool VerifyCheckboxesGroup(this IEnumerable<IWebElement> checkboxes,  int maximum)
        {
            int selectedQuantity = SelectedCount(checkboxes);
            return CheckBounds(selectedQuantity, 1, maximum);
        }

        /// <summary>
        /// Caluculate a count of selected elements
        /// </summary>
        /// <param name="webElements"></param>
        /// <returns></returns>
        public static int SelectedCount(IEnumerable<IWebElement> webElements)
        {
            int selectedQuantity = 0;
            foreach (var webElement in webElements)
            {
                if (webElement.Selected)
                {
                    selectedQuantity++;
                }
            }

            return selectedQuantity;
        }
        
        /// <summary>
        /// Check that value is in bounds
        /// </summary>
        /// <param name="value"></param>
        /// <param name="lowBound"></param>
        /// <param name="upperBound"></param>
        /// <returns></returns>
        static bool CheckBounds(int value, int lowBound, int upperBound)
        {
            return value >= lowBound && value <= upperBound;
        }
    }
}