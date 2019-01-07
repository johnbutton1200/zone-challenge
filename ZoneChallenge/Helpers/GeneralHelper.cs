using System;
using OpenQA.Selenium;
using ZoneChallenge.BaseClasses;

namespace ZoneChallenge.Helpers
{
    public class GeneralHelper : BaseClass
    {
        public static string GetTimeStamp(DateTime value, string format)
        {
            // Gets timestamp in defined format
            var timeStamp = value.ToString(format);
            Log.Info("Timestamp generated: " + timeStamp);
            return timeStamp;
        }

        public static bool IsElementPresent(IWebElement element)
        {
            //if (element.Displayed.Equals(true))
            //{
            //    Log.Info("Element present: " + element);
            //    return element.Displayed.Equals(true);
            //}
            //Log.Error("Element not present: " + element);
            //return element.Displayed.Equals(false);
            try
            {
                Log.Info("Checking for the element: " + element);
                return element.Displayed.Equals(true);
            }
            catch (Exception)
            {
                Log.Error("Element not present: " + element);
                return false;
            }
        }

        public static string GenerateUniqueEmail()
        {
            // Appends timestamp to first part of email to create unique address
            var timestamp = GetTimeStamp(DateTime.Now, "yyyyMMddHHmmssfff");
            var emailAddress = "johnbuttone3+" + timestamp + "@gmail.com";
            Log.Info("Email address generated: " + emailAddress);
            return emailAddress;
        }

        public static int GetBrowserWidth()
        {
            // returns browser width
            var size = Driver.Manage().Window.Size;
            var width = size.Width;
            Log.Info("Browser width of: " + width);
            return width;
        }
    }

}
