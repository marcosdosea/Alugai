using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlugaiWEB.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Services;
using Moq;
using AutoMapper;
using AlugaiWEB.Mappers;
using Core;
using Microsoft.AspNetCore.Mvc;
using AlugaiWEB.Models;

namespace AlugaiWEB.Controllers.Tests
{
    [TestClass()]
    public class AluguelControllerTests
    {

        private static AluguelController controller;

        [ClassInitialize]
        public static void Initialize(TestContext testContext)
        {
            // Arrange
            var mockServiceIAlguel = new Mock<IAluguelService>();
            var mockServiceIStatusPagamento = new Mock<IStatuspagamentoService>();

            IMapper mapper = new MapperConfiguration(cfg =>
                cfg.AddProfile(new AluguelProfile())).CreateMapper();

            // mock para Aluguel service
            mockServiceIAlguel.Setup(service => service.ObterTodos())
                .Returns(GetTestAlugueis());
            mockServiceIAlguel.Setup(service => service.Buscar(1))
                .Returns(GetTargetAluguel());
            mockServiceIAlguel.Setup(service => service.Alterar(It.IsAny<Aluguel>()))
                .Verifiable();
            mockServiceIAlguel.Setup(service => service.Inserir(It.IsAny<Aluguel>()))
                .Verifiable();

            // mock para Status pagamento service
            mockServiceIStatusPagamento.Setup(service => service.ObterTodos())
                .Returns(GetTestStatusPagamento());
            mockServiceIStatusPagamento.Setup(service => service.Buscar(1))
                .Returns(GetTargetStatusPagamento());
            mockServiceIStatusPagamento.Setup(service => service.Alterar(It.IsAny<Statuspagamento>()))
                .Verifiable();
            mockServiceIStatusPagamento.Setup(service => service.Inserir(It.IsAny<Statuspagamento>()))
                .Verifiable();

            controller = new AluguelController(mockServiceIAlguel.Object, mockServiceIStatusPagamento.Object, mapper);
        }

        [TestMethod()]
        public void IndexTest()
        {
            // Act
            var result = controller.Index();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<AluguelModel>));
            List<AluguelModel> lista = (List<AluguelModel>)viewResult.ViewData.Model;
            Assert.AreEqual(3, lista.Count);
        }

        [TestMethod()]
        public void DetailsTest()
        {
            // Act
            var result = controller.Details(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(AluguelModel));
            AluguelModel aluguelModel = (AluguelModel)viewResult.ViewData.Model;
            Assert.AreEqual("Aluguel da Maria", aluguelModel.Descricao);
            Assert.AreEqual(1, aluguelModel.CodigoStatusPagamento);
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
            var result = controller.Create(GetNewAluguel());

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
            controller.ModelState.AddModelError("Descricao", "Campo requerido");

            // Act
            var result = controller.Create(GetNewAluguel());

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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(AluguelModel));
            AluguelModel aluguelModel = (AluguelModel)viewResult.ViewData.Model;
            Assert.AreEqual("Aluguel da Maria", aluguelModel.Descricao);
            Assert.AreEqual(1, aluguelModel.CodigoStatusPagamento);
        }

        [TestMethod()]
        public void EditTest_Get()
        {
            // Act
            var result = controller.Edit(GetTargetAluguelModel().CodigoAluguel, GetTargetAluguelModel());

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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(AluguelModel));
            AluguelModel aluguelModel = (AluguelModel)viewResult.ViewData.Model;
            Assert.AreEqual("Aluguel da Maria", aluguelModel.Descricao);
            Assert.AreEqual(1, aluguelModel.CodigoStatusPagamento);
        }

        public void DeleteTest_Get()
        {
            // Act
            var result = controller.Delete(GetTargetAluguelModel().CodigoStatusPagamento, GetTargetAluguelModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        private static Aluguel GetTargetAluguel()
        {
            return new Aluguel { CodigoAluguel = 1, Descricao = "Aluguel da Maria", CodigoStatusPagamento = 1 };
        }

        private static IEnumerable<Aluguel> GetTestAlugueis()
        {
            return new List<Aluguel>
            {
                new Aluguel { CodigoAluguel = 1, Descricao= "Aluguel da Maria", CodigoStatusPagamento = 1 },
                new Aluguel { CodigoAluguel = 2, Descricao= "Aluguel do João", CodigoStatusPagamento = 2 },
                new Aluguel { CodigoAluguel = 3, Descricao= "Aluguel do josé", CodigoStatusPagamento = 3 },
            };
        }

        private static AluguelModel GetNewAluguel()
        {
            return new AluguelModel { CodigoAluguel = 4, Descricao = "Aluguel do Adriano", CodigoStatusPagamento = 1 };
        }

        private static Statuspagamento GetTargetStatusPagamento()
        {
            return new Statuspagamento { CodigoStatusPagamento = 1, Descricao = "EM ABERTO" };
        }

        private static AluguelModel GetTargetAluguelModel()
        {
            return new AluguelModel { CodigoAluguel = 4, Descricao = "Aluguel do Adriano", CodigoStatusPagamento = 1 };
        }


        private static IEnumerable<Statuspagamento> GetTestStatusPagamento()
        {
            return new List<Statuspagamento>
            {
                new Statuspagamento { CodigoStatusPagamento = 1, Descricao = "EM ABERTO" },
                new Statuspagamento { CodigoStatusPagamento = 2, Descricao = "PAGO" },
                new Statuspagamento { CodigoStatusPagamento = 3, Descricao = "ATRASADO" },
            };
        }
    }
}

