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
    public class StatuspagamentoControllerTests
    {

        private static StatuspagamentoController controller;

        [ClassInitialize]
        public static void Initialize(TestContext testContext)
        {
            // Arrange
            var mockServiceIStatuspagamento = new Mock<IStatuspagamentoService>();

            IMapper mapper = new MapperConfiguration(cfg =>
                cfg.AddProfile(new StatuspagamentoProfile())).CreateMapper();

            // mock para Aluguel service
            mockServiceIStatuspagamento.Setup(service => service.ObterTodos())
                .Returns(GetTestStatuspagamento());
            mockServiceIStatuspagamento.Setup(service => service.Buscar(1))
                .Returns(GetTargetStatuspagamento());
            mockServiceIStatuspagamento.Setup(service => service.Alterar(It.IsAny<Statuspagamento>()))
                .Verifiable();
            mockServiceIStatuspagamento.Setup(service => service.Inserir(It.IsAny<Statuspagamento>()))
                .Verifiable();

            controller = new StatuspagamentoController(mockServiceIStatuspagamento.Object, mapper);
        }

        [TestMethod()]
        public void IndexTest()
        {
            // Act
            var result = controller.Index();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<StatuspagamentoModel>));
            List<StatuspagamentoModel> lista = (List<StatuspagamentoModel>)viewResult.ViewData.Model;
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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(StatuspagamentoModel));
            StatuspagamentoModel StatuspagamentoModel = (StatuspagamentoModel)viewResult.ViewData.Model;
            Assert.AreEqual("Pago", StatuspagamentoModel.Descricao);
            Assert.AreEqual(1, StatuspagamentoModel.CodigoStatusPagamento);
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
            var result = controller.Create(GetNewStatuspagamento());

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
            var result = controller.Create(GetNewStatuspagamento());

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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(StatuspagamentoModel));
            StatuspagamentoModel StatuspagamentoModel = (StatuspagamentoModel)viewResult.ViewData.Model;
            Assert.AreEqual("Pago", StatuspagamentoModel.Descricao);
            Assert.AreEqual(1, StatuspagamentoModel.CodigoStatusPagamento);
        }

        [TestMethod()]
        public void EditTest_Get()
        {
            // Act
            var result = controller.Edit(GetTargetStatuspagamentoModel().CodigoStatusPagamento, GetTargetStatuspagamentoModel());

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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(StatuspagamentoModel));
            StatuspagamentoModel StatuspagamentoModel = (StatuspagamentoModel)viewResult.ViewData.Model;
            Assert.AreEqual("Pago", StatuspagamentoModel.Descricao);
            Assert.AreEqual(1, StatuspagamentoModel.CodigoStatusPagamento);
        }

        public void DeleteTest_Get()
        {
            // Act
            var result = controller.Delete(GetTargetStatuspagamentoModel().CodigoStatusPagamento, GetTargetStatuspagamentoModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        private static Statuspagamento GetTargetStatuspagamento()
        {
            return new Statuspagamento { CodigoStatusPagamento = 1, Descricao = "Pago"};
        }

        private static IEnumerable<Statuspagamento> GetTestStatuspagamento()
        {
             return new List<Statuspagamento>
            {
                new Statuspagamento { CodigoStatusPagamento = 1, Descricao = "Pago"},
                new Statuspagamento { CodigoStatusPagamento = 2, Descricao = "Atrazado"},
                new Statuspagamento { CodigoStatusPagamento = 3, Descricao = "Pago"}
            };
        }

        private static StatuspagamentoModel GetNewStatuspagamento()
        {
        return new StatuspagamentoModel { CodigoStatusPagamento = 4, Descricao = "Atrazado"};
        }

        private static StatuspagamentoModel GetTargetStatuspagamentoModel()
        {
            return new StatuspagamentoModel { CodigoStatusPagamento = 4, Descricao = "Atrazado"};
        }
    }
}


