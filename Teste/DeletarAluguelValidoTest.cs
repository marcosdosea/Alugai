// Generated by Selenium IDE
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;
[TestFixture]
public class DeletarAluguelValidoTest {
  private IWebDriver driver;
  public IDictionary<string, object> vars {get; private set;}
  private IJavaScriptExecutor js;
  [SetUp]
  public void SetUp() {
    driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), new ChromeOptions().ToCapabilities());
    js = (IJavaScriptExecutor)driver;
    vars = new Dictionary<string, object>();
  }
  [TearDown]
  protected void TearDown() {
    driver.Quit();
  }
  [Test]
  public void deletarAluguelValido() {
    driver.Navigate().GoToUrl("https://localhost:44368/");
    driver.Manage().Window.Size = new System.Drawing.Size(1366, 768);
    driver.FindElement(By.LinkText("Entrar ou Cadastrar")).Click();
    driver.FindElement(By.LinkText("Meus Alugueis")).Click();
    driver.FindElement(By.CssSelector("tr:nth-child(2) .fa-trash")).Click();
    driver.FindElement(By.CssSelector(".btn-danger")).Click();
  }
}
