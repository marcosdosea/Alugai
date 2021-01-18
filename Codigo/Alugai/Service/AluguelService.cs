using Core;
using Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    class AluguelService : IAluguelService
    {
        private readonly alugaiContext _context;

        public AluguelService(alugaiContext context)
        {
            _context = context;
        }
        public int Inserir(Aluguel aluguel)
        {
            _context.Add(aluguel);
            _context.SaveChanges();
            return aluguel.CodigoAluguel;
        }
        public void Alterar(Aluguel aluguel)
        {
            _context.Update(aluguel);
            _context.SaveChanges();
        }
        public void Excluir(int codigoAluguel)
        {
            var _aluguel = _context.Aluguel.Find(codigoAluguel);
            _context.Aluguel.Remove(_aluguel);
            _context.SaveChanges();
        }
        private IQueryable<Aluguel> GetQuery()
        {
            IQueryable<Aluguel> tb_aluguel = _context.Aluguel;
            var query = from aluguel in tb_aluguel select aluguel;
            return query;
        }
        public Aluguel Buscar(int codigoAluguel)
        {
            IEnumerable<Aluguel> alugueis = GetQuery().Where(aluguelModel => aluguelModel.CodigoAluguel.Equals(codigoAluguel));
            return alugueis.ElementAtOrDefault(0);
        }
        public IEnumerable<Aluguel> ObterTodos()
        {
            return GetQuery();
        }
    }
}
