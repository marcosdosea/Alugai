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
	public class PessoaServiceTests
	{
		private alugaiContext _context;
		private IPessoaService _pessoaService;

		[TestInitialize]
		public void Initialize()
		{

			var builder = new DbContextOptionsBuilder<alugaiContext>();
			builder.UseInMemoryDatabase("alugai");
			var options = builder.Options;

			_context = new alugaiContext(options);
			_context.Database.EnsureDeleted();
			_context.Database.EnsureCreated();
			var Pessoas = new List<Pessoa>
				{
					new Pessoa {  CodigoPessoa = 1,
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
				TipoPessoa = 1  },

					new Pessoa { CodigoPessoa = 2,
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
								TipoPessoa = 2},
				};
			_context.AddRange(Pessoas);
			_context.SaveChanges();

			_pessoaService = new PessoaService(_context);
		}


		[TestMethod()]
		public void InserirTest()
		{
			// Act
			_pessoaService.Inserir(new Pessoa
			{
				CodigoPessoa = 3,
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
				TipoPessoa = 1
			});
			// Assert
			Assert.AreEqual(3, _pessoaService.ObterTodos().Count());
			var pessoa = _pessoaService.Buscar(3);
			Assert.AreEqual("Cirino", pessoa.Nome);
			Assert.AreEqual(3, pessoa.CodigoPessoa);
		}

		[TestMethod()]
		public void EditarTest()
		{
			var pessoa = _pessoaService.Buscar(1);
			pessoa.Nome = "Maycon";
			pessoa.CodigoPessoa = 1;
			_pessoaService.Alterar(pessoa);
			pessoa = _pessoaService.Buscar(1);
			Assert.AreEqual("Maycon", pessoa.Nome);
			Assert.AreEqual(1, pessoa.CodigoPessoa);
		}

		[TestMethod()]
		public void RemoverTest()
		{
			// Act
			_pessoaService.Excluir(2);
			// Assert
			Assert.AreEqual(1, _pessoaService.ObterTodos().Count());
			var pessoa = _pessoaService.Buscar(2);
			Assert.AreEqual(null, pessoa);
		}

		[TestMethod()]
		public void ObterTodosTest()
		{
			// Act
			var listaPessoas = _pessoaService.ObterTodos();
			// Assert
			Assert.IsInstanceOfType(listaPessoas, typeof(IEnumerable<Pessoa>));
			Assert.IsNotNull(listaPessoas);
			Assert.AreEqual(2, listaPessoas.Count());
			Assert.AreEqual(1, listaPessoas.First().CodigoPessoa);
			Assert.AreEqual("Maycon", listaPessoas.First().Nome);
		}

		[TestMethod()]
		public void ObterTest()
		{
			var pessoa = _pessoaService.Buscar(1);
			Assert.IsNotNull(pessoa);
			Assert.AreEqual("Maycon", pessoa.Nome);
		}
	}
}