using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace selenium_basic
{
    internal class Program
    {
        static void Main(string[] args)
        {

            ChromeDriver chrome = new ChromeDriver();// tạo mới tab chrome
            IJavaScriptExecutor js = (IJavaScriptExecutor)chrome;
            chrome.Navigate().GoToUrl("https://www.facebook.com/r.php?entry_point=login");//điều hướng chrome
            string url_page = chrome.Url;
            // get url hiện tại của chrome.
                                         //chrome.FindElement(By.XPath("/html/body/div[1]/div[1]/div[1]/div/div/div/div[2]/div/div[1]/form/div[1]/div[1]/input")).SendKeys("Xpath");
                                         //chrome.FindElement(By.Id("email")).SendKeys("id");
                                         //chrome.FindElement(By.Id("email")).SendKeys("name");
                                         //var text= chrome.FindElement(By.XPath("/html/body/div[1]/div[1]/div[1]/div/div/div/div[1]/h2")).Text;// get text hoienej tại cảu element
            Thread.Sleep(1000);// delay 1s
            chrome.FindElement(By.Name("firstname")).SendKeys("Hedsswawuy");
            Thread.Sleep(1000);
            chrome.FindElement(By.Name("lastname")).SendKeys("Mạnsh");
            Thread.Sleep(1000);
            Random r =new Random();
            chrome.FindElement(By.XPath($"/html/body/div[1]/div[1]/div[1]/div[2]/div/div[2]/div/div/div[1]/form/div[1]/div[2]/div[2]/span/span/select[1]/option[{r.Next(1,28)}]")).Click();
            Thread.Sleep(1000);
            chrome.FindElement(By.XPath($"/html/body/div[1]/div[1]/div[1]/div[2]/div/div[2]/div/div/div[1]/form/div[1]/div[2]/div[2]/span/span/select[2]/option[{r.Next(1,12)}]")).Click();
            Thread.Sleep(1000);
            chrome.FindElement(By.XPath($"/html/body/div[1]/div[1]/div[1]/div[2]/div/div[2]/div/div/div[1]/form/div[1]/div[2]/div[2]/span/span/select[3]/option[{r.Next(21,54)}]")).Click();
            Thread.Sleep(1000);
            if (r.Next(1, 10) % 2 == 0)
            {
                chrome.FindElement(By.XPath("/html/body/div[1]/div[1]/div[1]/div[2]/div/div[2]/div/div/div[1]/form/div[1]/div[4]/span/span[1]/label/input")).Click();
            }
            else
            {
                chrome.FindElement(By.XPath("/html/body/div[1]/div[1]/div[1]/div[2]/div/div[2]/div/div/div[1]/form/div[1]/div[4]/span/span[2]/label/input")).Click();
            }
            Thread.Sleep(1000);
            chrome.FindElement(By.Name("reg_email__")).SendKeys("0327645874");
            Thread.Sleep(1000);
            chrome.FindElement(By.Id("password_step_input")).SendKeys("Manh@2005");
            Thread.Sleep(1000);
            chrome.FindElement(By.Name("websubmit")).Click();
            Thread.Sleep(5000);
            while (true)
            {
                try {
                    chrome.FindElement(By.Name("websubmit"));
                    Thread.Sleep(1000);
                } catch { break; }
            }

            if(chrome.PageSource.Contains("We need more information"))
            {
                js.ExecuteScript("window.open();");// mowr tab moiws
                var tabs = chrome.WindowHandles; /// get số lượng tab của chrome
                chrome.SwitchTo().Window(tabs[1]);
                chrome.Navigate().GoToUrl("https://www.youtube.com/");
                chrome.FindElement(By.Name("search_query")).SendKeys("phim ma");
                chrome.FindElement(By.XPath("/html/body/ytd-app/div[1]/div[2]/ytd-masthead/div[4]/div[2]/yt-searchbox/button")).Click();
                chrome.SwitchTo().Window(tabs[0]);
                Console.WriteLine("nik die");
            }
            else
            {
                Console.WriteLine("nik live");

            }
            Console.ReadKey();
        }
    }
}
