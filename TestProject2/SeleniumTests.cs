using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;

namespace TestProject2
{
    [TestFixture]
    public class SeleniumTests
    {
        private FirefoxDriver driver;

        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
        }

        [Test]
        public void W3C_Invalid()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<xml>");
            sb.AppendLine("<usuario>Lazaro Lima</usuario>");
            sb.AppendLine(" <livros>");
            sb.AppendLine("   <livro>The Art of Unit Testing: With Examples in .Net</livro>");
            sb.AppendLine("   <livro>TProfessional ASP.NET Design Patterns</livro>");
            sb.AppendLine("   <livro>Building Social Web Applications: Establishing Community at the Heart of Your Site</livro>");
            sb.AppendLine("   <livro>CLR via C#</livro>");
            sb.AppendLine("   <livro>Designing Social Interfaces: Principles, Patterns, and Practices for Improving the User Experience (Animal Guide)</livro>");
            sb.AppendLine("   <livro>The Lean Startup: How Today's Entrepreneurs Use Continuous Innovation to Create Radically Successful Businesses</livro>");
            sb.AppendLine(" </livros>");
            sb.AppendLine("</xml>");

            driver.Navigate().GoToUrl("http://validator.w3.org");
            driver.FindElementByPartialLinkText("Direct Input").Click();
            driver.FindElementByName("fragment").SendKeys(sb.ToString());
            driver.FindElementByPartialLinkText("Check").Click();

            Assert.IsTrue(driver.Title.Contains("[Invalid]"));
        }

        [Test]
        public void W3C_Valid()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<?xml version=\"1.0\"?>");
            sb.AppendLine("<xml>");
            sb.AppendLine("<usuario>Lazaro Lima</usuario>");
            sb.AppendLine(" <livros>");
            sb.AppendLine("   <livro>The Art of Unit Testing: With Examples in .Net</livro>");
            sb.AppendLine("   <livro>TProfessional ASP.NET Design Patterns</livro>");
            sb.AppendLine("   <livro>Building Social Web Applications: Establishing Community at the Heart of Your Site</livro>");
            sb.AppendLine("   <livro>CLR via C#</livro>");
            sb.AppendLine("   <livro>Designing Social Interfaces: Principles, Patterns, and Practices for Improving the User Experience (Animal Guide)</livro>");
            sb.AppendLine("   <livro>The Lean Startup: How Today's Entrepreneurs Use Continuous Innovation to Create Radically Successful Businesses</livro>");
            sb.AppendLine(" </livros>");
            sb.AppendLine("</xml>");

            driver.Navigate().GoToUrl("http://validator.w3.org");
            driver.FindElementByPartialLinkText("Direct Input").Click();
            driver.FindElementByName("fragment").SendKeys(sb.ToString());
            driver.FindElementByPartialLinkText("Check").Click();

            Assert.IsTrue(driver.Title.Contains("[Valid]"));
        }

        [TearDown]
        public void TeardownTest()
        {
            driver.Close();
            driver.Dispose();
        }

    }
}
