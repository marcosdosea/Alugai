using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlugaiWEB.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Core.Services;
using AutoMapper;
using AlugaiWEB.Mappers;
using Core;
using Microsoft.AspNetCore.Mvc;
using AlugaiWEB.Models;

namespace AlugaiWEB.Controllers.Tests
{
    [TestClass()]
    public class AnuncioControllerTests
    {
        private static AnuncioController controller;

        [ClassInitialize]
        public static void Initialize(TestContext testContext)
        {
            // Arrange
            var mockServiceIAnuncio = new Mock<IAnuncioService>();
            var mockServiceIImovel = new Mock<IImovelService>();
            var mockServiceIPessoa = new Mock<IPessoaService>();

            IMapper mapper = new MapperConfiguration(cfg =>
                cfg.AddProfile(new AnuncioProfile())).CreateMapper();

            // mock para Anuncio service
            mockServiceIAnuncio.Setup(service => service.ObterTodos())
                .Returns(GetTestAnuncio());
            mockServiceIAnuncio.Setup(service => service.Buscar(1))
                .Returns(GetTargetAnuncio());
            mockServiceIAnuncio.Setup(service => service.Alterar(It.IsAny<Anuncio>()))
                .Verifiable();
            mockServiceIAnuncio.Setup(service => service.Inserir(It.IsAny<Anuncio>()))
                .Verifiable();

            // mock para Imovel Service
            mockServiceIImovel.Setup(service => service.ObterTodos())
                .Returns(GetTestImovel());
            mockServiceIImovel.Setup(service => service.Buscar(1))
                .Returns(GetTargetImovel());
            mockServiceIImovel.Setup(service => service.Alterar(It.IsAny<Imovel>()))
                .Verifiable();
            mockServiceIImovel.Setup(service => service.Inserir(It.IsAny<Imovel>()))
                .Verifiable();

            //mock para pessoa service
            mockServiceIPessoa.Setup(service => service.ObterTodos())
                .Returns(GetTestPessoa());
            mockServiceIPessoa.Setup(service => service.Buscar(1))
                .Returns(GetTargetPessoa());
            mockServiceIPessoa.Setup(service => service.Alterar(It.IsAny<Pessoa>()))
                .Verifiable();
            mockServiceIPessoa.Setup(service => service.Inserir(It.IsAny<Pessoa>()))
                .Verifiable();

            controller = new AnuncioController(mockServiceIAnuncio.Object, mockServiceIImovel.Object, mockServiceIPessoa.Object, mapper);
        }

        [TestMethod()]
        public void IndexTest()
        {
            // Act
            var result = controller.Index();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<AnuncioModel>));
            List<AnuncioModel> lista = (List<AnuncioModel>)viewResult.ViewData.Model;
            Assert.AreEqual(2, lista.Count);
        }

        [TestMethod()]
        public void DetailsTest()
        {
            // Act
            var result = controller.Details(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(AnuncioModel));
            AnuncioModel anuncioModel = (AnuncioModel)viewResult.ViewData.Model;
            Assert.AreEqual("TESTE 3", anuncioModel.Descricao);
            Assert.AreEqual(1, anuncioModel.CodigoImovel);
            Assert.AreEqual(1, anuncioModel.CodigoAnuncio);
            Assert.AreEqual(1, anuncioModel.CodigoPessoa);
        }

        [TestMethod()]
        public void CreateTest()
        {
            // Act
            var result = controller.Create();
            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod()]
        public void CreateTest_Valid()
        {
            // Act
            var result = controller.Create(GetNewAnuncio());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        [TestMethod()]
        public void CreateTest_InValid()
        {
            // Arrange
            controller.ModelState.AddModelError("Descricaoe", "Campo requerido");

            // Act
            var result = controller.Create(GetNewAnuncio());

            // Assert
            Assert.AreEqual(1, controller.ModelState.ErrorCount);
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        [TestMethod()]
        public void EditTest_Post()
        {
            // Act
            var result = controller.Edit(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(AnuncioModel));
            AnuncioModel anuncioModel = (AnuncioModel)viewResult.ViewData.Model;
            Assert.AreEqual("TESTE 3", anuncioModel.Descricao);
            Assert.AreEqual(1, anuncioModel.CodigoImovel);
            Assert.AreEqual(1, anuncioModel.CodigoPessoa);
        }

        [TestMethod()]
        public void EditTest_Get()
        {
            // Act
            var result = controller.Edit(GetTargetAnuncioModel().CodigoAnuncio, GetTargetAnuncioModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        [TestMethod()]
        public void DeleteTest_Post()
        {
            // Act
            var result = controller.Delete(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(AnuncioModel));
            AnuncioModel anuncioModel = (AnuncioModel)viewResult.ViewData.Model;
            Assert.AreEqual("TESTE 3", anuncioModel.Descricao);
            Assert.AreEqual(1, anuncioModel.CodigoImovel);
            Assert.AreEqual(1, anuncioModel.CodigoPessoa);
        }

        public void DeleteTest_Get()
        {
            // Act
            var result = controller.Delete(GetTargetAnuncioModel().CodigoAnuncio, GetTargetAnuncioModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }


        private static Anuncio GetTargetAnuncio()
        {
            return new Anuncio { CodigoAnuncio = 1, Descricao = "TESTE 3", TipoDeAnuncio = "casa", CodigoImovel = 1, CodigoPessoa = 1 };
        }
        private static IEnumerable<Anuncio> GetTestAnuncio()
        {
            return new List<Anuncio>
            {
                new Anuncio { CodigoAnuncio = 1, Descricao= "TESTE 3", TipoDeAnuncio = "casa", CodigoImovel = 1, CodigoPessoa = 1},
                new Anuncio { CodigoAnuncio = 2, Descricao = "TESTE 3", TipoDeAnuncio = "casa", CodigoImovel = 1, CodigoPessoa = 1 },
            };
        }
        private static AnuncioModel GetNewAnuncio()
        {
            return new AnuncioModel { CodigoAnuncio = 1, Descricao = "TESTE 3", TipoDeAnuncio = "casa", CodigoImovel = 1, CodigoPessoa = 1 };
        }

        private static AnuncioModel GetTargetAnuncioModel()
        {
            return new AnuncioModel { CodigoAnuncio = 2, Descricao = "TESTE 2", TipoDeAnuncio = "casa", CodigoImovel = 1, CodigoPessoa = 1 };
        }
        private static Imovel GetTargetImovel() => new Imovel
        {
            CodigoImovel = 1,
            TipoImovel = "COMERCIAL",
            QuantidadeDeQuartos = 3,
            QuantidadeDeBanheiros = 2,
            QuantidadeDeSuites = 1,
            AreaQuadrada = 20,
            QuantidadeDeAndares = 0,
            QuantidadeDeGaragem = 1,
            Descricao = "Imóvel em ótima localização",
            ValorDoAluguel = 450,
            ValorDoCondominio = 0,
            ValorDoIptu = 0,
            QuantidadeCozinha = 1,
            QuantidadeDeSala = 1,
            Bairro = "Centro",
            Cidade = "Itabaiana",
            EstadoUf = "SE",
            Rua = "Avenida João Teixeira",
            Numero = 1149,
            ComplementoEndereco = "Apto 104",
            Cep = "49506093",
            StatusImovel = 1
        };

        private static IEnumerable<Imovel> GetTestImovel()
        {
            return new List<Imovel>
            {
                new Imovel
                {
                    CodigoImovel = 1,
                    TipoImovel = "COMERCIAL",
                    QuantidadeDeQuartos = 3,
                    QuantidadeDeBanheiros = 2,
                    QuantidadeDeSuites = 1,
                    AreaQuadrada = 20,
                    QuantidadeDeAndares = 0,
                    QuantidadeDeGaragem = 1,
                    Descricao = "Imóvel em ótima localização",
                    ValorDoAluguel = 450,
                    ValorDoCondominio = 0,
                    ValorDoIptu = 0,
                    QuantidadeCozinha = 1,
                    QuantidadeDeSala = 1,
                    Bairro = "Centro",
                    Cidade = "Itabaiana",
                    EstadoUf = "SE",
                    Rua = "Avenida João Teixeira",
                    Numero = 1149,
                    ComplementoEndereco = "Apto 104",
                    Cep = "49506093",
                    StatusImovel = 1
                },

                new Imovel
                {
                    CodigoImovel = 2,
                    TipoImovel = "COMERCIAL",
                    QuantidadeDeQuartos = 3,
                    QuantidadeDeBanheiros = 2,
                    QuantidadeDeSuites = 1,
                    AreaQuadrada = 20,
                    QuantidadeDeAndares = 0,
                    QuantidadeDeGaragem = 1,
                    Descricao = "Imóvel em ótima localização",
                    ValorDoAluguel = 450,
                    ValorDoCondominio = 0,
                    ValorDoIptu = 0,
                    QuantidadeCozinha = 1,
                    QuantidadeDeSala = 1,
                    Bairro = "Centro",
                    Cidade = "Itabaiana",
                    EstadoUf = "SE",
                    Rua = "Avenida João Teixeira",
                    Numero = 1149,
                    ComplementoEndereco = "Apto 104",
                    Cep = "49506093",
                    StatusImovel = 1
                },
            };
        }
        private static Pessoa GetTargetPessoa() => new Pessoa
        {
            CodigoPessoa = 1,
            Nome = "gilton",
            Email = "gilton@gmail.com",
            Senha = "senha1234",
            Telefone = "7999999999",
            Cpf = "06875344556",
            Sexo = "masculino",
            DataNascimento = DateTime.Parse("1997-03-01"),
            Rg = "256556666",
            Rua = "carrilho",
            Bairro = "carrilho",
            Cidade = "ita",
            Cep = "495000",
            EstadoUf = "se",
            NumeroDoEndereco = 195,
            TipoPessoa = 1
        };
        private static IEnumerable<Pessoa> GetTestPessoa()
        {
            return new List<Pessoa>
            {
                new Pessoa
                {
                    CodigoPessoa = 1,
                    Nome = "gilton",
                    Email = "gilton@gmail.com",
                    Senha = "senha1234",
                    Telefone = "7999999999",
                    Cpf = "06875344556",
                    Sexo = "masculino",
                    DataNascimento = DateTime.Parse("1997-03-01"),
                    Rg = "256556666",
                    Rua = "carrilho",
                    Bairro = "carrilho",
                    Cidade = "ita",
                    Cep = "495000",
                    EstadoUf = "se",
                    NumeroDoEndereco = 195,
                    TipoPessoa = 1

                },

                new Pessoa
                {
                    CodigoPessoa = 2,
                    Nome = "gilton",
                    Email = "gilton@gmail.com",
                    Senha = "senha1234",
                    Telefone = "7999999999",
                    Cpf = "06875344556",
                    Sexo = "masculino",
                    DataNascimento = DateTime.Parse("1997-03-01"),
                    Rg = "256556666",
                    Rua = "carrilho",
                    Bairro = "carrilho",
                    Cidade = "ita",
                    Cep = "495000",
                    EstadoUf = "se",
                    NumeroDoEndereco = 195,
                    TipoPessoa = 1
                },
            };
        }

    }
}