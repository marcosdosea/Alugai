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
	public class StatuspagamentoServiceTests
	{
		private alugaiContext _context;
		private IStatuspagamentoService _statuspagamentoService;

		[TestInitialize]
		public void Initialize()
		{

			var builder = new DbContextOptionsBuilder<alugaiContext>();
			builder.UseInMemoryDatabase("alugai");
			var options = builder.Options;

			_context = new alugaiContext(options);
			_context.Database.EnsureDeleted();
			_context.Database.EnsureCreated();
			var statuspagamentos = new List<Statuspagamento>
				{
					new Statuspagamento {   CodigoStatusPagamento = 1, Descricao = "Pago" },

					new Statuspagamento {  CodigoStatusPagamento = 2, Descricao = "Atrazado"},
				};
			_context.AddRange(statuspagamentos);
			_context.SaveChanges();

			_statuspagamentoService = new StatuspagamentoService(_context);
		}


		[TestMethod()]
		public void InserirTest()
		{
			
			_statuspagamentoService.Inserir(new Statuspagamento { CodigoStatusPagamento = 3, Descricao = "Pago" });
			Assert.AreEqual(3, _statuspagamentoService.ObterTodos().Count());
			var statuspagamento = _statuspagamentoService.Buscar(3);
			Assert.AreEqual("Pago", statuspagamento.Descricao);
			Assert.AreEqual(3, statuspagamento.CodigoStatusPagamento);
		}

		[TestMethod()]
		public void EditarTest()
		{
			var statuspagamento = _statuspagamentoService.Buscar(1);
			statuspagamento.Descricao = "Pago";
			statuspagamento.CodigoStatusPagamento = 1;
			_statuspagamentoService.Alterar(statuspagamento);
			statuspagamento = _statuspagamentoService.Buscar(1);
			Assert.AreEqual("Pago", statuspagamento.Descricao);
			Assert.AreEqual(1, statuspagamento.CodigoStatusPagamento);
		}

		[TestMethod()]
		public void RemoverTest()
		{
			// Act
			_statuspagamentoService.Excluir(2);
			// Assert
			Assert.AreEqual(1, _statuspagamentoService.ObterTodos().Count());
			var statuspagamento = _statuspagamentoService.Buscar(2);
			Assert.AreEqual(null, statuspagamento);
		}

		[TestMethod()]
		public void ObterTodosTest()
		{
			// Act
			var listaStatuspagamentos = _statuspagamentoService.ObterTodos();
			// Assert
			Assert.IsInstanceOfType(listaStatuspagamentos, typeof(IEnumerable<Statuspagamento>));
			Assert.IsNotNull(listaStatuspagamentos);
			Assert.AreEqual(2, listaStatuspagamentos.Count());
			Assert.AreEqual(1, listaStatuspagamentos.First().CodigoStatusPagamento);
			Assert.AreEqual("Pago", listaStatuspagamentos.First().Descricao);
		}

		[TestMethod()]
		public void ObterTest()
		{
			var statuspagamentos = _statuspagamentoService.Buscar(1);
			Assert.IsNotNull(statuspagamentos);
			Assert.AreEqual("Pago", statuspagamentos.Descricao);
		}
	}
}