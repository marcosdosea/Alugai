using Core;
using Core.Services;
using System.Collections.Generic;
using System.Linq;


namespace Service
{
    public class PessoaService : IPessoaService
    {
        private readonly alugaiContext _context;

        public PessoaService (alugaiContext context)
        {
            _context = context;
        }

        public int Inserir(Pessoa pessoa)
        {
            _context.Add(pessoa);
            _context.SaveChanges();
            return pessoa.CodigoPessoa;
        }


         public void Excluir(int CodigoPessoa)
         {
            var _pessoa = _context.Pessoa.Find(CodigoPessoa);
            _context.Pessoa.Remove(_pessoa);
            _context.SaveChanges();
          }

        public void Alterar(Pessoa pessoa)
        {
            _context.Update(pessoa);
            _context.SaveChanges();

        }

        private IQueryable<Pessoa> GetQuery()
        {
            IQueryable<Pessoa> tb_pessoa = _context.Pessoa;
            var query = from pessoa in tb_pessoa
                        select pessoa;
            return query;
        }


        public Pessoa Buscar(int CodigoPessoa)
        {
            
            IEnumerable<Pessoa> pessoas = GetQuery().Where(pessoaModel => pessoaModel.CodigoPessoa.Equals(CodigoPessoa));

            return pessoas.ElementAtOrDefault(0);
        }

        public IEnumerable<Pessoa> ObterTodos()
        {
            return GetQuery();
        }
    }
}
