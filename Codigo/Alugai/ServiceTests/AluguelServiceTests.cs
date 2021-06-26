using Core;
using Core.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service.Tests
{
    [TestClass()]
    public class AluguelServiceTests
    {
		private alugaiContext _context;
		private IAluguelService _aluguelService;

		[TestInitialize]
		public void Initialize()
		{
			//Arrange
			var builder = new DbContextOptionsBuilder<alugaiContext>();
			builder.UseInMemoryDatabase("alugai");
			var options = builder.Options;

			_context = new alugaiContext(options);
			_context.Database.EnsureDeleted();
			_context.Database.EnsureCreated();
			var alugueis = new List<Aluguel>
				{
					new Aluguel { CodigoAluguel = 1, Descricao= "Aluguel da Maria", CodigoStatusPagamento = 1 },
					new Aluguel { CodigoAluguel = 2, Descricao= "Aluguel do João", CodigoStatusPagamento = 2 },
					new Aluguel { CodigoAluguel = 3, Descricao= "Aluguel do josé", CodigoStatusPagamento = 3 },
				};

			_context.AddRange(alugueis);
			_context.SaveChanges();

			_aluguelService = new AluguelService(_context);
		}

		[TestMethod()]
		public void InserirTest()
		{
			// Act
			_aluguelService.Inserir(new Aluguel { CodigoAluguel = 4, Descricao = "Aluguel novo", CodigoStatusPagamento = 1 });
			// Assert
			Assert.AreEqual(4, _aluguelService.ObterTodos().Count());
			var aluguel = _aluguelService.Buscar(4);
			Assert.AreEqual("Aluguel novo", aluguel.Descricao);
			Assert.AreEqual(1, aluguel.CodigoStatusPagamento);
		}

		[TestMethod()]
		public void EditarTest()
		{
			var aluguel = _aluguelService.Buscar(3);
			aluguel.Descricao = "Aluguel do josé alterado";
			aluguel.CodigoStatusPagamento = 1;
			_aluguelService.Alterar(aluguel);
			aluguel = _aluguelService.Buscar(3);
			Assert.AreEqual("Aluguel do josé alterado", aluguel.Descricao);
			Assert.AreEqual(1, aluguel.CodigoStatusPagamento);
		}
		
		[TestMethod()]
		public void RemoverTest()
		{
			// Act
			_aluguelService.Excluir(2);
			// Assert
			Assert.AreEqual(2, _aluguelService.ObterTodos().Count());
			var aluguel = _aluguelService.Buscar(2);
			Assert.AreEqual(null, aluguel);
		}

		[TestMethod()]
		public void ObterTodosTest()
		{
			// Act
			var listaAlugueis = _aluguelService.ObterTodos();
			// Assert
			Assert.IsInstanceOfType(listaAlugueis, typeof(IEnumerable<Aluguel>));
			Assert.IsNotNull(listaAlugueis);
			Assert.AreEqual(3, listaAlugueis.Count());
			Assert.AreEqual(1, listaAlugueis.First().CodigoAluguel);
			Assert.AreEqual("Aluguel da Maria", listaAlugueis.First().Descricao);
		}

		[TestMethod()]
		public void ObterTest()
		{
			var aluguel = _aluguelService.Buscar(1);
			Assert.IsNotNull(aluguel);
			Assert.AreEqual("Aluguel da Maria", aluguel.Descricao);
		}
	}
}