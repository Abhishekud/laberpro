using laberpro.drivers;
using laberpro.hooks;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laberpro.pages
{
    public class location
    {
        public static readonly string Profiling = "//span[contains(text(),'Profiling')]";
        public static readonly string Save= "//body/div[@role='dialog']/div[@role='dialog']//div[@role='document']/div[@class='modal-footer']/button[2]";
        public static readonly string Cancel = "//body/div[@role='dialog']/div[@role='dialog']//div[@role='document']/div[@class='modal-footer']/button[1]";
        public static readonly string LocationProfiles = "/html//div[@id='app']/div//div[@class='flyout-button']/button[@type='button']";
        public static readonly string Edit = "/html//div[@id='app']/div/div[@class='page-body']//div[@class='sidebar-body']/div[5]/button[@type='button']";
        public static readonly string EditName = "/html//input[@id='name']";
        public static readonly string EditSave = "/html//div[@id='app']/div/div[@class='page-body']/div[@class='sidebar undefined']//div[@class='actions']/div/button[1]";
        public static readonly string Profile1 = "//div[@id='app']//div[@role='grid']/div[2]/div[@role='presentation']//table[@role='presentation']/tbody/tr[1]/td[.='Active']";
        public static readonly string Delete = "/html//div[@id='app']/div//div[@class='controlled-actions']/button[2]";
        public static void addlocaton()
        {
            IWebElement element = SeleniumDriver.driver().FindElement(By.XPath(Profiling));
            element.Click();
            Thread.Sleep(1000);
            IWebElement elementg = SeleniumDriver.driver().FindElement(By.LinkText("Locations"));
            elementg.Click();
            IWebElement elementggrs = SeleniumDriver.driver().FindElement(By.Id("add"));//a[contains(text(),'New')]
            elementggrs.Click();
            IWebElement ele = SeleniumDriver.driver().FindElement(By.XPath("//a[contains(text(),'New')]"));
            ele.Click();
            IWebElement el = SeleniumDriver.driver().FindElement(By.XPath("//*[@id='name']"));
            el.Clear();
            el.SendKeys("");

            BaseClass.TakeScreenshot("add1");
            Thread.Sleep(1000);
            IWebElement e = SeleniumDriver.driver().FindElement(By.XPath(Save));
            e.Click();//body/div[@role='dialog']/div[@role='dialog']//div[@role='document']/div[@class='modal-footer']/button[1]
             
            IWebElement f = SeleniumDriver.driver().FindElement(By.XPath(Cancel));
            Thread.Sleep(3000);
            f.Click();
        }
        public static void addlocatonp()
        {
            
            IWebElement elementggrs = SeleniumDriver.driver().FindElement(By.Id("add"));//a[contains(text(),'New')]
            elementggrs.Click();
            IWebElement ele = SeleniumDriver.driver().FindElement(By.XPath("//a[contains(text(),'New')]"));
            ele.Click();
            IWebElement el = SeleniumDriver.driver().FindElement(By.XPath("//*[@id='name']"));
            el.Clear();
            el.SendKeys("Abhi");
            BaseClass.TakeScreenshot("add2");

            Thread.Sleep(1000);
            IWebElement e = SeleniumDriver.driver().FindElement(By.XPath(Save));
            e.Click();
         
        }
        public static void addlocatonq()
        {
             

           // Thread.Sleep(3000);
            IWebElement elementggrs = SeleniumDriver.driver().FindElement(By.Id("add"));//a[contains(text(),'New')]
            elementggrs.Click();
            IWebElement ele = SeleniumDriver.driver().FindElement(By.XPath("//a[contains(text(),'New')]"));
            ele.Click();
            IWebElement el = SeleniumDriver.driver().FindElement(By.XPath("//*[@id='name']"));
            el.Clear();
            el.SendKeys("Abhi");
             

            Thread.Sleep(1000);
            IWebElement e = SeleniumDriver.driver().FindElement(By.XPath(Save));
            e.Click();
            Thread.Sleep(3000);
            BaseClass.TakeScreenshot("add3");

            IWebElement j = SeleniumDriver.driver().FindElement(By.XPath(Cancel));

            j.Click();

        }
        public static void editlocation()
        {
           
            IWebElement elementggrs = SeleniumDriver.driver().FindElement(By.XPath(LocationProfiles));//a[contains(text(),'New')]
            elementggrs.Click();
           
            Thread.Sleep(3000);

            IWebElement e = SeleniumDriver.driver().FindElement(By.XPath(Edit));

            e.Click(); 
            Thread.Sleep(1000);
            IWebElement ejh = SeleniumDriver.driver().FindElement(By.XPath(EditName));
            ejh.Clear();
            ejh.SendKeys("");
            IWebElement elemg = SeleniumDriver.driver().FindElement(By.XPath(EditSave));
            elemg.Click();
            BaseClass.TakeScreenshot("edit1");

        }
        public static void editlocationp()
        {
            

            Thread.Sleep(3000);

            IWebElement e = SeleniumDriver.driver().FindElement(By.XPath(Edit));

            e.Click();
            Thread.Sleep(1000);
            IWebElement ejh = SeleniumDriver.driver().FindElement(By.XPath(EditName));
            ejh.Clear();
            ejh.SendKeys("Abhi");
            IWebElement elemg = SeleniumDriver.driver().FindElement(By.XPath(EditSave));
            elemg.Click();
            BaseClass.TakeScreenshot("edit2");IWebElement element = SeleniumDriver.driver().FindElement(By.XPath("/html//div[@id='app']/div/div[@class='page-body']/div[@class='sidebar undefined']//div[@class='actions']/div/button[2]"));
            element.Click();

        }
        public static void editlocationq()
        {
            

            Thread.Sleep(5000);

            IWebElement e = SeleniumDriver.driver().FindElement(By.XPath(Edit));

            e.Click();
            Thread.Sleep(1000);
            IWebElement ejh = SeleniumDriver.driver().FindElement(By.XPath(EditName));
            ejh.Clear();
            ejh.SendKeys("Abhi");
            IWebElement elemg = SeleniumDriver.driver().FindElement(By.XPath(EditSave));
            elemg.Click();
            BaseClass.TakeScreenshot("edit3");

        }
        public static void delete()
        {
            //

            //Thread.Sleep(1000);

            ////  Thread.Sleep(5000);
            //IWebElement elementg = SeleniumDriver.driver().FindElement(By.LinkText("Locations"));
            //elementg.Click();

            IWebElement elementggrs = SeleniumDriver.driver().FindElement(By.XPath(LocationProfiles));//a[contains(text(),'New')]
            elementggrs.Click();
            Thread.Sleep(3000);
            IWebElement yjntg = SeleniumDriver.driver().FindElement(By.XPath("//tr[@role='row']/td[5]")) ;
            yjntg.Click();
            IWebElement ejh = SeleniumDriver.driver().FindElement(By.XPath(Delete));
            ejh.Click();
            IWebElement elemg = SeleniumDriver.driver().FindElement(By.XPath("//body/div[@role='dialog']/div[@role='dialog']//div[@role='document']/div[@class='modal-footer']/button[2]"));
            elemg.Click(); 
            BaseClass.TakeScreenshot("delete");


        }
    }
}