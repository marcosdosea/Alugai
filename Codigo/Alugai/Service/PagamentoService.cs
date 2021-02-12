using Core;
using Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public class PagamentoService : IPagamentoService
    {
        private readonly alugaiContext _context;

        public PagamentoService(alugaiContext context)
        {
            _context = context;
        }

        public int Inserir(Pagamento pagamento)
        {
            _context.Add(pagamento);
            _context.SaveChanges();
            return pagamento.CodigoPagamento;
        }

        public void Excluir(int CodigoPagamento)
        {
            var _pagamento = _context.Pagamento.Find(CodigoPagamento);
            _context.Pagamento.Remove(_pagamento);
            _context.SaveChanges();
        }

        public void Alterar(Pagamento pagamento)
        {
            _context.Update(pagamento);
            _context.SaveChanges();

        }
        private IQueryable<Pagamento> GetQuery()
        {
            IQueryable<Pagamento> tb_pagamento = _context.Pagamento;
            var query = from pagamento in tb_pagamento
                        select pagamento;
            return query;
        }
        public Pagamento Buscar(int CodigoPagamento)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pagamento> ObterTodos()
        {
            return GetQuery();
        }

       
    }
}
