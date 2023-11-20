using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class ApplicationManager
    {
        protected IWebDriver driver;      
        protected string baseURL;       

        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost";           
        }        
        
        ~ApplicationManager()
        {
            try
            {
                driver.Quit();                
            }
            catch (Exception)
            {
                //Ignore errors if unable to close the browser               
            }
        }             
       
        public static ApplicationManager GetIntance()
        {
            if (! app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.driver.Url = "http://localhost/mantisbt-1.2.17/login_page.php";
                app.Value = newInstance;
            }
            return app.Value;
        }

        public IWebDriver Driver 
        { 
            get
            {
                return driver;
            }
        }              
    }
}
