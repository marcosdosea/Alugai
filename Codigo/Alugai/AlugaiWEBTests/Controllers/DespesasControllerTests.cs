using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlugaiWEB.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using AlugaiWEB.Models;
using Moq;
using Core.Services;
using AutoMapper;
using AlugaiWEB.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace AlugaiWEB.Controllers.Tests
{
    [TestClass()]
    public class DespesasControllerTests
    {
        private static DespesasController controller;

        [ClassInitialize]
        public static void Initialize(TestContext testContext)
        {
            // Arrange
            var mockServiceIDespesas = new Mock<IManterDespesasService>();
            var mockServiceIImovel= new Mock<IImovelService>();

            IMapper mapper = new MapperConfiguration(cfg =>
                cfg.AddProfile(new DespesasProfile())).CreateMapper();

            // mock para Despesas service
            mockServiceIDespesas.Setup(service => service.ObterTodos())
                .Returns(GetTestDespesas());
            mockServiceIDespesas.Setup(service => service.Buscar(1))
                .Returns(GetTargetDespesa());
            mockServiceIDespesas.Setup(service => service.Alterar(It.IsAny<Despesas>()))
                .Verifiable();
            mockServiceIDespesas.Setup(service => service.Inserir(It.IsAny<Despesas>()))
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

            controller = new DespesasController(mockServiceIDespesas.Object, mockServiceIImovel.Object, mapper);
        }

        [TestMethod()]
        public void IndexTest()
        {
            // Act
            var result = controller.Index();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<DespesasModel>));
            List<DespesasModel> lista = (List<DespesasModel>)viewResult.ViewData.Model;
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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(DespesasModel));
            DespesasModel despesasModel = (DespesasModel)viewResult.ViewData.Model;
            Assert.AreEqual("Conserto de torneira", despesasModel.DescricaoDespesa);
            Assert.AreEqual(1, despesasModel.CodigoImovel);
            Assert.AreEqual(1, despesasModel.CodigoDespesas);
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
            var result = controller.Create(GetNewDespesa());

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
            controller.ModelState.AddModelError("DescricaoDespesa", "Campo requerido");

            // Act
            var result = controller.Create(GetNewDespesa());

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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(DespesasModel));
            DespesasModel despesasModel = (DespesasModel)viewResult.ViewData.Model;
            Assert.AreEqual("Conserto de torneira", despesasModel.DescricaoDespesa);
            Assert.AreEqual(1, despesasModel.CodigoDespesas);
        }

        [TestMethod()]
        public void EditTest_Get()
        {
            // Act
            var result = controller.Edit(GetTargetDespesasModel().CodigoDespesas, GetTargetDespesasModel());

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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(DespesasModel));
            DespesasModel despesasModel = (DespesasModel)viewResult.ViewData.Model;
            Assert.AreEqual("Conserto de torneira", despesasModel.DescricaoDespesa);
            Assert.AreEqual(1, despesasModel.CodigoImovel);
        }

        public void DeleteTest_Get()
        {
            // Act
            var result = controller.Delete(GetTargetDespesasModel().CodigoDespesas, GetTargetDespesasModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }


        private static DespesasModel GetNewDespesa()
        {
            return new DespesasModel { CodigoDespesas = 3, TipoDeDespesa = "TESTE 3", Valor = 20, DescricaoDespesa = "Nova despesa", CodigoImovel = 1 };
        }

        private static DespesasModel GetTargetDespesasModel()
        {
            return new DespesasModel { CodigoDespesas = 2, TipoDeDespesa = "TESTE 2", Valor = 150, DescricaoDespesa = "Troca de chuveiro", CodigoImovel = 1 };
        }
        private static Despesas GetTargetDespesa()
        {
            return new Despesas { CodigoDespesas = 1, TipoDeDespesa = "TESTE", Valor = 45, DescricaoDespesa = "Conserto de torneira", CodigoImovel = 1 };
        }
        private static IEnumerable<Despesas> GetTestDespesas()
        {
            return new List<Despesas>
            {
                new Despesas { CodigoDespesas = 1, TipoDeDespesa = "TESTE", Valor = 45, DescricaoDespesa = "Conserto de torneira", CodigoImovel = 1  },
                new Despesas { CodigoDespesas = 2, TipoDeDespesa = "TESTE 2", Valor = 150, DescricaoDespesa = "Troca de chuveiro", CodigoImovel = 1  },
            };
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
    }
}