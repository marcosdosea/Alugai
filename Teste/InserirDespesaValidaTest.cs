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
public class InserirDespesaValidaTest {
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
  public void inserirDespesaValida() {
    driver.Navigate().GoToUrl("https://localhost:44368/Despesas/Despesas");
    driver.Manage().Window.Size = new System.Drawing.Size(1366, 768);
    driver.FindElement(By.LinkText("Cadastrar")).Click();
    driver.FindElement(By.Id("CodigoDespesas")).Click();
    driver.FindElement(By.Id("CodigoDespesas")).SendKeys("3");
    driver.FindElement(By.Id("DescricaoDespesa")).SendKeys("troca de chuveiro");
    driver.FindElement(By.Id("TipoDeDespesa")).SendKeys("nada");
    driver.FindElement(By.Id("wrapper")).Click();
    driver.FindElement(By.Id("TipoDeDespesa")).SendKeys(Keys.Down);
    driver.FindElement(By.Id("TipoDeDespesa")).SendKeys("manuntenção hidraulica");
    driver.FindElement(By.Id("TipoDeDespesa")).SendKeys(Keys.Tab);
    driver.FindElement(By.Id("Valor")).SendKeys("7");
    driver.FindElement(By.Id("Valor")).SendKeys("75");
    driver.FindElement(By.CssSelector(".form-group > .btn")).Click();
  }
}
