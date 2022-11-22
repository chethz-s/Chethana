using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using Microsoft.VisualBasic.FileIO;
using OpenQA.Selenium.Interactions;

namespace Chethana
{
    class Program
    {
        static IWebDriver driver = new ChromeDriver();
        static IWebElement radioEle;
        static IWebElement suggestionEle;
        private static ReadOnlyCollection<IWebElement> suggclass;

        public static object ObjectRepository { get; private set; }

        static void Main(string[] args)
        {
            String Url = "http://www.qaclickacademy.com/practice.php ";
            driver.Navigate().GoToUrl(Url);
            radioEle = driver.FindElement(By.ClassName("radioButton"));
            suggestionEle = driver.FindElement(By.Id("autocomplete"));



            //function call
            //Exercise1();
            //Exercise2();
            //Exercise3();
            //Exercise4();
            //Exercise41();
            //Exercise42();
            //Exercise5();
            //Exercise6();
            //Exercise7();
            //Exercise8();
            //Exercise9();
        }

        //Radio button
        public static void Exercise1()
        {
            IWebElement radio1 = driver.FindElement(By.ClassName("radioButton"));
            radio1.Click();
            Thread.Sleep(1000);
            System.Console.WriteLine("click on radio button");

            IWebElement radio2 = driver.FindElement(By.ClassName("radioButton"));
            radio1.Click();
            Thread.Sleep(1000);
            System.Console.WriteLine("click on radio button");

            IWebElement radio3 = driver.FindElement(By.ClassName("radioButton"));
            radio1.Click();
            Thread.Sleep(1000);
            System.Console.WriteLine("click on radio button");

            string[] options = { "1", "2", "3" };
            for (int i = 0; i < options.Length; i++)
            {
                radioEle = driver.FindElement(By.XPath("//input[@value='radio" + options[i] + "']"));
                radioEle.Click();
                if (radioEle.GetAttribute("checked") == "true")
                {
                    Console.WriteLine("the" + (i + 1) + "radio buttons are checked");
                }
                else
                {
                    Console.WriteLine("radio buttons are not checked");
                }
            }
            Thread.Sleep(1000);
        }
        //suggestion box
        public static void Exercise2()
        {
            IWebElement suggclass = driver.FindElement(By.Id("autocomplete"));
            suggclass.Click();
            suggclass.SendKeys("United");
            IList<IWebElement> selectionbox = driver.FindElements(By.XPath("//div[@class='ui-menu-item-wrapper']"));
            foreach (var selement in selectionbox)
            {
                if (selement.Text.Contains("United States (USA)")) ;
                {
                    selement.Click();
                }
            }
        }

        //drop down

        public static void Exercise3()
        {
            IWebElement dropdown = driver.FindElement(By.Id("dropdown-class-example"));
            SelectElement down = new SelectElement(dropdown);
            dropdown.Click();
            for(int i = 1; i < 4; i++)
            {
                down.SelectByText("Option" + i + "");
                Thread.Sleep(1000);
            }
        }
        //check box
        public static void Exercise4()
        {
            IWebElement Checkbox1 = driver.FindElement(By.XPath("//*[@id=\"checkBoxOption1\"]"));
            Checkbox1.Click();
            Thread.Sleep(2000);
            Checkbox1.Click();
            IWebElement Checkbox2 = driver.FindElement(By.XPath("//*[@id=\"checkBoxOption2\"]"));
            Checkbox2.Click();
            Thread.Sleep(2000);
            Checkbox2.Click();
            IWebElement Checkbox3 = driver.FindElement(By.XPath("//*[@id=\"checkBoxOption3\"]"));
            Checkbox3.Click();
            Thread.Sleep(2000);
            Checkbox3.Click();
        }

        //check box1
        public static void Exercise41()
        {
            for(int i = 1; i <= 3; i++)
            {
                IWebElement check = driver.FindElement(By.XPath("//*[@id=\"checkBoxOption" + i + "\"]"));
                check.Click();
            }
            Thread.Sleep(2000);
            driver.Quit();

        }

        //check box2
        public static void Exercise42()
        {
            for(int j = 1; j <= 3; j++)
            {
                IWebElement check = driver.FindElement(By.XPath("//*[@id=\"checkBoxOption" + j + "\"]"));
                check.Click();
            }
            Thread.Sleep(3000);
            Console.WriteLine("all checkboxes are deselected");
            driver.Quit();
        }

        //switch window
        public static void Exercise5()
        {
            IWebElement switchwin = driver.FindElement(By.Id("openwindow"));
            switchwin.Click();
            Thread.Sleep(3000);
            driver.SwitchTo().Window(driver.WindowHandles[0]);
        }

        //switch tab

        public static void Exercise6()
        {
            IWebElement switchtab = driver.FindElement(By.Id("opentab"));
            switchtab.Click();
            Thread.Sleep(3000);
            driver.SwitchTo().Window(driver.WindowHandles[0]);
        }

        //switch alter
        public static void Exercise7()
        {
            IWebElement switchalt = driver.FindElement(By.Id("name"));
            switchalt.Click();
            switchalt.SendKeys("Cheth");
            Thread.Sleep(1000);
            IWebElement altbt = driver.FindElement(By.Id("alertbtn"));
            altbt.Click();
            driver.SwitchTo().Alert().Accept();
            Thread.Sleep(1000);
        }

        //table
        public static void Exercise8()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript(System.String.Format("window.scrollTo({0},{1})", 400, 627));
            Thread.Sleep(1000);
        }

        //mouse hover
        public static void Exercise9()
        {
            var element = driver.FindElement(By.Id("mousehover"));
            Actions action = new Actions(driver);
            action.MoveToElement(element).Perform();
            Thread.Sleep(2000);
            IWebElement up = driver.FindElement(By.XPath("//a[@href='#top']"));
            action.MoveToElement(element).Perform();
            up.Click();
            Thread.Sleep(2000);
        } 
    }
}
