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
public class InserirImovelVlidoTest {
  private IWebDriver driver;
  public IDictionary<string, object> vars {get; private set;}
  private IJavaScriptExecutor js;
  [SetUp]
  public void SetUp() {
    driver = new ChromeDriver();
    js = (IJavaScriptExecutor)driver;
    vars = new Dictionary<string, object>();
  }
  [TearDown]
  protected void TearDown() {
    driver.Quit();
  }
  [Test]
  public void inserirImovelVlido() {
    driver.Navigate().GoToUrl("https://localhost:3001/");
    driver.Manage().Window.Size = new System.Drawing.Size(976, 1050);
    driver.FindElement(By.LinkText("Entrar ou Cadastrar")).Click();
    driver.FindElement(By.LinkText("Meus Imoveis")).Click();
    driver.FindElement(By.LinkText("Cadastrar")).Click();
    driver.FindElement(By.Id("CodigoImovel")).Click();
    driver.FindElement(By.Id("CodigoImovel")).SendKeys("3");
    driver.FindElement(By.Id("TipoImovel")).SendKeys("comercial");
    driver.FindElement(By.Id("QuantidadeDeQuartos")).SendKeys("3");
    driver.FindElement(By.Id("QuantidadeDeBanheiros")).SendKeys("2");
    driver.FindElement(By.Id("QuantidadeDeSuites")).SendKeys("0");
    driver.FindElement(By.Id("AreaQuadrada")).SendKeys("20");
    driver.FindElement(By.Id("QuantidadeDeAndares")).SendKeys("1");
    driver.FindElement(By.Id("QuantidadeDeGaragem")).SendKeys("1");
    driver.FindElement(By.Id("Descricao")).SendKeys("casa com garagem");
    driver.FindElement(By.Id("ValorDoAluguel")).SendKeys("350");
    driver.FindElement(By.Id("ValorDoCondominio")).SendKeys("0");
    driver.FindElement(By.Id("ValorDoIptu")).SendKeys("150");
    driver.FindElement(By.Id("QuantidadeCozinha")).SendKeys("1");
    driver.FindElement(By.Id("QuantidadeDeSala")).SendKeys("1");
    driver.FindElement(By.Id("Bairro")).SendKeys("centro");
    driver.FindElement(By.Id("Cidade")).SendKeys("aracaju");
    driver.FindElement(By.Id("EstadoUf")).SendKeys("sergipe");
    driver.FindElement(By.Id("Rua")).SendKeys("rua b");
    driver.FindElement(By.Id("Numero")).SendKeys("29");
    driver.FindElement(By.Id("ComplementoEndereco")).SendKeys("perto da igreja");
    driver.FindElement(By.Id("Cep")).SendKeys("6666778000");
    driver.FindElement(By.Id("StatusImovel")).SendKeys("1");
    driver.FindElement(By.CssSelector(".form-group > .btn")).Click();
  }
}
