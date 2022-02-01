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
     public static readonly string EditName = "/html//input[@id='name']";
        public static readonly string EditSave = " //button[contains(@class,'primary')]";
        public static readonly string Delete = "//button[contains(@class,'delete')]";
        public static readonly string NewName = "//a[contains(text(),'New')]";


        public static void addlocatonblank() 
        {
            IWebElement element = SeleniumDriver.driver().FindElement(By.XPath(Profiling));
            element.Click();
            Thread.Sleep(1000);
            IWebElement location = SeleniumDriver.driver().FindElement(By.LinkText("Locations"));
            location.Click();
            IWebElement add = SeleniumDriver.driver().FindElement(By.Id("add"));//a[contains(text(),'New')]
            add.Click();
            IWebElement name = SeleniumDriver.driver().FindElement(By.XPath(NewName));
           name.Click();
            IWebElement addname = SeleniumDriver.driver().FindElement(By.XPath("//*[@id='name']"));
            addname.Clear();
            addname.SendKeys("");

            BaseClass.TakeScreenshot("add1");
            Thread.Sleep(1000);
            IWebElement save = SeleniumDriver.driver().FindElement(By.XPath(Save));
         save.Click(); 
            IWebElement cancel = SeleniumDriver.driver().FindElement(By.XPath(Cancel));
            Thread.Sleep(3000);
            cancel.Click();
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void addlocatonwithcorrect(string labor)
        {
            
            IWebElement add = SeleniumDriver.driver().FindElement(By.Id("add")); 
            add.Click();
            IWebElement name = SeleniumDriver.driver().FindElement(By.XPath(NewName));
          name.Click();
            IWebElement addname = SeleniumDriver.driver().FindElement(By.XPath("//*[@id='name']"));
            addname.Clear();
            addname.SendKeys(labor);
            BaseClass.TakeScreenshot("add2");

            Thread.Sleep(1000);          IWebElement save = SeleniumDriver.driver().FindElement(By.XPath(Save));
            save.Click();
            BaseClass._AttachScreenshot.Value = true;

        }
        public static void addlocatonwithexisting(string labor)
        {
            Thread.Sleep(2000);

            IWebElement add = SeleniumDriver.driver().FindElement(By.Id("add"));
            add.Click();
            IWebElement name = SeleniumDriver.driver().FindElement(By.XPath(NewName));
            name.Click();
            IWebElement addname = SeleniumDriver.driver().FindElement(By.XPath("//*[@id='name']"));
            addname.Clear();
            addname.SendKeys(labor);
            BaseClass.TakeScreenshot("add3");

            Thread.Sleep(1000); IWebElement save = SeleniumDriver.driver().FindElement(By.XPath(Save));
            save.Click();

            Thread.Sleep(3000);
            IWebElement cancel = SeleniumDriver.driver().FindElement(By.XPath(Cancel));

        cancel.Click();
            BaseClass._AttachScreenshot.Value = true;

        }
        public static void editlocationblank()
        {
           
           
           
            Thread.Sleep(3000);

           
            IWebElement Editname = SeleniumDriver.driver().FindElement(By.XPath(EditName));
              Editname.Clear();
            Editname.Click();
         
          
            Editname.SendKeys(Keys.Control + "a");
            Editname.SendKeys(Keys.Delete);
            Editname.SendKeys(Keys.Space);

            IWebElement enter = SeleniumDriver.driver().FindElement(By.XPath(EditSave));
            enter.Click();
            BaseClass.TakeScreenshot("edit1");
            Thread.Sleep(3000);
            // IWebElement can = SeleniumDriver.driver().FindElement(By.XPath("//button[contains(@class,'cancel')]"));
            //   can.Click();
            BaseClass._AttachScreenshot.Value = true;


        }       public static void editlocationexisting(string labor)
        {



            Thread.Sleep(3000);


            IWebElement Editname = SeleniumDriver.driver().FindElement(By.XPath(EditName));
            Editname.Clear();
            Editname.Click();


            Editname.SendKeys(Keys.Control + "a");
            Editname.SendKeys(Keys.Delete);
            Editname.SendKeys(Keys.Space);
            Editname.SendKeys(labor);

            IWebElement enter = SeleniumDriver.driver().FindElement(By.XPath(EditSave));
            enter.Click();
            BaseClass.TakeScreenshot("edit2");
            Thread.Sleep(3000);

            BaseClass._AttachScreenshot.Value = true;
        }
        public static void editlocationcorrect(string labor)
        {




            Thread.Sleep(3000);

            IWebElement Cancel = SeleniumDriver.driver().FindElement(By.XPath("//div[@id='app']//div[@role='grid']/div[2]/div[@role='presentation']//table[@role='presentation']/tbody/tr[1]/td[5]"));
            Cancel.Click();

            IWebElement Editname = SeleniumDriver.driver().FindElement(By.XPath(EditName));
            Editname.Clear();
            Editname.Click();


            Editname.SendKeys(Keys.Control + "a");
            Editname.SendKeys(Keys.Delete);
            Editname.SendKeys(Keys.Space);
            Editname.SendKeys(labor);

            IWebElement enter = SeleniumDriver.driver().FindElement(By.XPath(EditSave));
            enter.Click();
            BaseClass.TakeScreenshot("edit3");
            Thread.Sleep(3000);
            BaseClass._AttachScreenshot.Value = true;
        }
            
            
     
        public static void delete()
        {
 
            Thread.Sleep(3000);

            IWebElement Cancel = SeleniumDriver.driver().FindElement(By.XPath("//div[@id='app']//div[@role='grid']/div[2]/div[@role='presentation']//table[@role='presentation']/tbody/tr[1]/td[5]"));
            Cancel.Click();

            IWebElement Editname = SeleniumDriver.driver().FindElement(By.XPath(EditName));
            Editname.Clear();
            Editname.Click();
            IWebElement enter = SeleniumDriver.driver().FindElement(By.XPath(Delete));
            enter.Click(); 
            BaseClass.TakeScreenshot("delete");
            IWebElement Cance = SeleniumDriver.driver().FindElement(By.XPath("//button[contains(@class,'danger')]"));
            Cance.Click();
            BaseClass._AttachScreenshot.Value = true;


        }
    }
}