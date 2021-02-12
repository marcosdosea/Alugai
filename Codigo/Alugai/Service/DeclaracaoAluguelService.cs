using Core;
using Core.Services;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public class DeclaracaoAluguelService : IDeclaracaoAluguelService
    {
        private readonly alugaiContext _context;

        public DeclaracaoAluguelService(alugaiContext context)
        {
            _context = context;
        }

        public void Alterar(Aluguel aluguel)
        {
            _context.Update(aluguel);
            _context.SaveChanges();
        }

        public void Excluir(int CodigoAluguel)
        {
            var _aluguel = _context.Aluguel.Find(CodigoAluguel);
            _context.Aluguel.Remove(_aluguel);
            _context.SaveChanges();
        }

        public int Inserir(Aluguel aluguel)
        {
            _context.Add(aluguel);
            _context.SaveChanges();
            return aluguel.CodigoAluguel;
        }

        private IQueryable<Aluguel> GetQuery()
        {
            IQueryable<Aluguel> tb_aluguel = _context.Aluguel;
            var query = from aluguel in tb_aluguel select aluguel;
            return query;
        }

        public Aluguel Buscar (int CodigoAlguel)
        {
            IEnumerable<Aluguel> alugueis = GetQuery().Where(AluguelModel => AluguelModel.CodigoAluguel.Equals(CodigoAlguel));
            return alugueis.ElementAtOrDefault(0);
        }
        public IEnumerable<Aluguel> ObterTodos()
        {
            return GetQuery();
        }
    }
}
