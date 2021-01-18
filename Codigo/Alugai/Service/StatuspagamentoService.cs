using Core;
using Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public class StatuspagamentoService : IStatuspagamentoService
    {
        private readonly alugaiContext _context;

        public StatuspagamentoService(alugaiContext context)
        {
            _context = context;
        }

        public int Inserir(Statuspagamento statuspagamento)
        {
            _context.Add(statuspagamento);
            _context.SaveChanges();
            return statuspagamento.CodigoStatusPagamento;
        }

        public void Excluir(int codigoStatusPagamento)
        {
            var _statuspagamento = _context.Pagamento.Find(codigoStatusPagamento);
            _context.Pagamento.Remove(_statuspagamento);
            _context.SaveChanges();
        }

        public void Alterar(Statuspagamento statuspagamento)
        {
            _context.Update(statuspagamento);
            _context.SaveChanges();

        }
        private IQueryable<Statuspagamento> GetQuery()
        {
            IQueryable<Statuspagamento> tb_statuspagamento = _context.Statuspagamento;
            var query = from statuspagamento in tb_statuspagamento
                        select statuspagamento;
            return query;
        }

        public IEnumerable<Statuspagamento> ObterTodos()
        {
            return GetQuery();
        }

        Statuspagamento IStatuspagamentoService.Buscar(int CodigoStatusPagamento)
        {
            throw new NotImplementedException();
        }
    }
}
