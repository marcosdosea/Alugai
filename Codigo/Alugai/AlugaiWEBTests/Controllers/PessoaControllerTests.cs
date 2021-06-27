using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlugaiWEB.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Services;
using AutoMapper;
using AlugaiWEB.Mappers;
using Core;
using Microsoft.AspNetCore.Mvc;
using AlugaiWEB.Models;
using Moq;

namespace AlugaiWEB.Controllers.Tests
{
    [TestClass()]
    public class PessoaControllerTests
    {
       
        private static PessoaController controller;

        [ClassInitialize]
        public static void Initialize(TestContext testContext)
        {
            // Arrange
            var mockServiceIPessoa = new Mock<IPessoaService>();


            IMapper mapper = new MapperConfiguration(cfg =>
                cfg.AddProfile(new PessoaProfile())).CreateMapper();

            // mock para Pessoa service

            mockServiceIPessoa.Setup(service => service.ObterTodos())
                .Returns(GetTestPessoas());
            mockServiceIPessoa.Setup(service => service.Buscar(1))
                .Returns(GetTargetPessoas());
            mockServiceIPessoa.Setup(service => service.Alterar(It.IsAny<Pessoa>()))
                .Verifiable();
            mockServiceIPessoa.Setup(service => service.Inserir(It.IsAny<Pessoa>()))
                .Verifiable();

            controller = new PessoaController(mockServiceIPessoa.Object, mapper);
        }

        [TestMethod()]
        public void IndexTest()
        {
            // Act
            var result = controller.Index();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<PessoaModel>));
            List<PessoaModel> lista = (List<PessoaModel>)viewResult.ViewData.Model;
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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(PessoaModel));
            PessoaModel pessoaModel = (PessoaModel)viewResult.ViewData.Model;
            Assert.AreEqual("Maycon", pessoaModel.Nome);
            Assert.AreEqual(1, pessoaModel.CodigoPessoa);
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
            var result = controller.Create(GetNewPessoa());

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
            var result = controller.Create(GetNewPessoa());

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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(PessoaModel));
            PessoaModel pessoaModel = (PessoaModel)viewResult.ViewData.Model;
            Assert.AreEqual("Maycon", pessoaModel.Nome);
            Assert.AreEqual(1, pessoaModel.CodigoPessoa);
        }

        [TestMethod()]
        public void EditTest_Get()
        {
            // Act

            var result = controller.Edit(GetTargetPessoaModel().CodigoPessoa, GetTargetPessoaModel());

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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(PessoaModel));
            PessoaModel pessoaModel = (PessoaModel)viewResult.ViewData.Model;
            Assert.AreEqual("Maycon", pessoaModel.Nome);
            Assert.AreEqual(1, pessoaModel.CodigoPessoa);
        }

        public void DeleteTest_Get()
        {
            // Act
            var result = controller.Delete(GetTargetPessoaModel().CodigoPessoa, GetTargetPessoaModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        private static Pessoa GetTargetPessoas()
        {
            return new Pessoa
            {
                CodigoPessoa = 1,
                Nome = "Maycon",
                Email = "maycon27@hotmail.com",
                Senha = "123456778",
                Telefone = "99999999999",
                Cpf = "123443566",
                Sexo = "masculino",
                DataNascimento = DateTime.Parse("1997-03-01"),
                Rg = "7758573635",
                Rua = "rua A",
                Bairro = "centro",
                Cidade = "aracaju",
                Cep = "48777999",
                EstadoUf = "SE",
                NumeroDoEndereco = 17,
                TipoPessoa = 1

            };
        }

        private static IEnumerable<Pessoa> GetTestPessoas()
        {
            return new List<Pessoa>
            {
                new Pessoa {    CodigoPessoa = 1,
                                Nome = "Maycon",
                                Email = "maycon27@hotmail.com",
                                Senha = "123456778",
                                Telefone = "99999999999",
                                Cpf = "123443566",
                                Sexo = "masculino",
                                DataNascimento = DateTime.Parse("1997-03-01"),
                                Rg = "7758573635",
                                Rua = "rua A",
                                Bairro = "centro",
                                Cidade = "aracaju",
                                Cep = "48777999",
                                EstadoUf = "SE",
                                NumeroDoEndereco = 17,
                                TipoPessoa = 1 },

                new Pessoa {    CodigoPessoa = 2,
                                Nome = "Gilton",
                                Email = "gilton27@hotmail.com",
                                Senha = "9877767665",
                                Telefone = "988888888",
                                Cpf = "876656556",
                                Sexo = "masculino",
                                DataNascimento = DateTime.Parse("1996-10-12"),
                                Rg = "776766767",
                                Rua = "rua b",
                                Bairro = "centro",
                                Cidade = "Itabaiana",
                                Cep = "487799888",
                                EstadoUf = "SE",
                                NumeroDoEndereco = 20,
                                TipoPessoa = 2 },

                new Pessoa {    CodigoPessoa = 3,
                                Nome = "Cirino",
                                Email = "Cirino27@hotmail.com",
                                Senha = "65757657",
                                Telefone = "777777777",
                                Cpf = "777777777",
                                Sexo = "masculino",
                                DataNascimento = DateTime.Parse("1995-03-01"),
                                Rg = "22222222222",
                                Rua = "rua C",
                                Bairro = "centro",
                                Cidade = "aracaju",
                                Cep = "48777999",
                                EstadoUf = "SE",
                                NumeroDoEndereco = 37,
                                TipoPessoa = 1 },
            };
        }

        private static PessoaModel GetNewPessoa()
        {
            return new PessoaModel
            {
                CodigoPessoa = 4,
                Nome = "Jeovani",
                Email = "Jeovani27@hotmail.com",
                Senha = "1111111111",
                Telefone = "88888999",
                Cpf = "12333333333",
                Sexo = "masculino",
                DataNascimento = DateTime.Parse("1994-05-01"),
                Rg = "7222222222",
                Rua = "rua D",
                Bairro = "centro",
                Cidade = "aracaju",
                Cep = "48777999",
                EstadoUf = "SE",
                NumeroDoEndereco = 27,
                TipoPessoa = 2
            };
        }


        private static PessoaModel GetTargetPessoaModel()
        {
            return new PessoaModel
            {
                CodigoPessoa = 4,
                Nome = "Jeovani",
                Email = "Jeovani27@hotmail.com",
                Senha = "1111111111",
                Telefone = "88888999",
                Cpf = "12333333333",
                Sexo = "masculino",
                DataNascimento = DateTime.Parse("1994-05-01"),
                Rg = "7222222222",
                Rua = "rua D",
                Bairro = "centro",
                Cidade = "aracaju",
                Cep = "48777999",
                EstadoUf = "SE",
                NumeroDoEndereco = 27,
                TipoPessoa = 2
            };
        }



    }
}