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
    public class ManterDespesasServiceTests
    {
		private alugaiContext _context;
		private IManterDespesasService _despesasService;

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
			var despesas = new List<Despesas>
				{
					new Despesas { CodigoDespesas = 1, TipoDeDespesa = "TESTE", Valor = 45, DescricaoDespesa = "Conserto de torneira", CodigoImovel = 1  },
					new Despesas { CodigoDespesas = 2, TipoDeDespesa = "TESTE 2", Valor = 150, DescricaoDespesa = "Troca de chuveiro", CodigoImovel = 1  },
				};

			_context.AddRange(despesas);
			_context.SaveChanges();

			_despesasService = new ManterDespesasService(_context);
		}


		[TestMethod()]
		public void InserirTest()
		{
			// Act
			_despesasService.Inserir(new Despesas { CodigoDespesas = 3, TipoDeDespesa = "TESTE 3", Valor = 60, DescricaoDespesa = "Nova despesa teste", CodigoImovel = 2 });
			// Assert
			Assert.AreEqual(3, _despesasService.ObterTodos().Count());
			var despesa = _despesasService.Buscar(3);
			Assert.AreEqual("Nova despesa teste", despesa.DescricaoDespesa);
			Assert.AreEqual(2, despesa.CodigoImovel);
		}

		[TestMethod()]
		public void EditarTest()
		{
			var despesa = _despesasService.Buscar(1);
			despesa.DescricaoDespesa = "Conserto de torneira alterado";
			despesa.CodigoImovel = 2;
			_despesasService.Alterar(despesa);
			despesa = _despesasService.Buscar(1);
			Assert.AreEqual("Conserto de torneira alterado", despesa.DescricaoDespesa);
			Assert.AreEqual(2, despesa.CodigoImovel);
		}

		[TestMethod()]
		public void RemoverTest()
		{
			// Act
			_despesasService.Excluir(2);
			// Assert
			Assert.AreEqual(1, _despesasService.ObterTodos().Count());
			var despesa = _despesasService.Buscar(2);
			Assert.AreEqual(null, despesa);
		}

		[TestMethod()]
		public void ObterTodosTest()
		{
			// Act
			var listaDespesas = _despesasService.ObterTodos();
			// Assert
			Assert.IsInstanceOfType(listaDespesas, typeof(IEnumerable<Despesas>));
			Assert.IsNotNull(listaDespesas);
			Assert.AreEqual(2, listaDespesas.Count());
			Assert.AreEqual(1, listaDespesas.First().CodigoDespesas);
			Assert.AreEqual("Conserto de torneira", listaDespesas.First().DescricaoDespesa);
		}

		[TestMethod()]
		public void ObterTest()
		{
			var despesa = _despesasService.Buscar(1);
			Assert.IsNotNull(despesa);
			Assert.AreEqual("Conserto de torneira", despesa.DescricaoDespesa);
		}
	}
}