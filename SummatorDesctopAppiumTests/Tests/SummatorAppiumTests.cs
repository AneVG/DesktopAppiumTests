using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Windows;
using SummatorDesktopAppiumTests.Window;
using System;


namespace SummatorDesktopAppiumTests.Tests
{
    public class SummatorAppiumTests
    {

        private WindowsDriver<WindowsElement> driver;
        private const string AppiumServer = "http://127.0.0.1:4723/wd/hub";
        private AppiumOptions options;

        [OneTimeSetUp]
        public void Setup()
        {
            this.options = new AppiumOptions() { PlatformName = "Windows" };
            options.AddAdditionalCapability(MobileCapabilityType.App, @"C:\Users\anelia.georgieva\Desktop\ANI\SummatorDesctopApp.exe");
            this.driver = new WindowsDriver<WindowsElement>(new Uri(AppiumServer), options);
        }

        [OneTimeTearDown]

        public void ShutDownApp()
        {
            this.driver.Quit();
        }

        [Test]  
        public void Test_TwoPositiveNumbers_POM()
        {
            var window = new SummatorWindow(driver);
            string value1 = "5";
            string value2 = "15";
            string result = window.Calculate(value1, value2);
            Assert.That(result, Is.EqualTo("20"));
        }
    }
}
