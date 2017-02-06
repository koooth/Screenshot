using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using NUnit.Framework;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace ConsoleApplication5
{
    class OpenUrl
    {
        IWebDriver driver;

        [SetUp]
        public void Init()
        {
            driver = new FirefoxDriver();


            //Rectangle bounds = Screen.GetBounds(Point.Empty);
            //using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
            //{
            //    using (Graphics g = Graphics.FromImage(bitmap))
            //    {
            //        g.CopyFromScreen(Point.Empty, Point.Empty, bounds.Size);
            //    }
            //    bitmap.Save(saveLocation, ImageFormat.Jpeg);
            //}
        }

        [Test]
        public void TestApp()
        {
            driver.Url = "http://stage-journals.lww.com/jbjsoa/pages/default.aspx";
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(50));
            IWebElement page = driver.FindElement(By.CssSelector(".main-logo"));
            Assert.True(page.Displayed);
            ITakesScreenshot screenshotDriver = driver as ITakesScreenshot;
            Screenshot screenshot = screenshotDriver.GetScreenshot();
            screenshot.SaveAsFile("c:/src/test.png", ImageFormat.Jpeg);
        }

        [TearDown]
        public void Clean()
        {
            driver.Quit();
        }
    }
}