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
public class InserirAluguelValidoTest {
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
  public void inserirAluguelValido() {
    driver.Navigate().GoToUrl("https://localhost:44368/");
    driver.Manage().Window.Size = new System.Drawing.Size(1366, 768);
    driver.FindElement(By.LinkText("Entrar ou Cadastrar")).Click();
    driver.FindElement(By.LinkText("Meus Alugueis")).Click();
    driver.FindElement(By.LinkText("Cadastrar")).Click();
    driver.FindElement(By.Id("CodigoAluguel")).Click();
    driver.FindElement(By.Id("CodigoAluguel")).SendKeys("3");
    driver.FindElement(By.Id("Descricao")).SendKeys("aluguel da casa de praia");
    {
      var dropdown = driver.FindElement(By.Id("CodigoStatusPagamento"));
      dropdown.FindElement(By.XPath("//option[. = 'nao pago']")).Click();
    }
    driver.FindElement(By.CssSelector(".form-group > .btn")).Click();
    driver.FindElement(By.CssSelector(".p-3")).Click();
    driver.FindElement(By.CssSelector("tr:nth-child(2) > td:nth-child(1)")).Click();
    driver.FindElement(By.CssSelector("tr:nth-child(2) > td:nth-child(1)")).Click();
    Assert.That(driver.FindElement(By.CssSelector("tr:nth-child(2) > td:nth-child(1)")).Text, Is.EqualTo("3"));
    driver.FindElement(By.CssSelector("tr:nth-child(2) > td:nth-child(2)")).Click();
    Assert.That(driver.FindElement(By.CssSelector("tr:nth-child(2) > td:nth-child(2)")).Text, Is.EqualTo("aluguel da casa de praia"));
    driver.FindElement(By.CssSelector("tr:nth-child(2) > td:nth-child(3)")).Click();
    Assert.That(driver.FindElement(By.CssSelector("tr:nth-child(2) > td:nth-child(3)")).Text, Is.EqualTo("2"));
    driver.FindElement(By.Id("page-content-wrapper")).Click();
  }
}