using Core;
using Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public class SolicitacaoManutencaoService : ISolicotacaoManutencaoService
    {
        private readonly alugaiContext _context;

        public SolicitacaoManutencaoService(alugaiContext context)
        {
            _context = context;
        }
        private IQueryable<Manuntencao> GetQuery()
        {
            IQueryable<Manuntencao> tb_SolicitacaoManutencao = _context.Manuntencao;
            var query = from manutencao in tb_SolicitacaoManutencao
                        select manutencao;
            return query;
        }

        public void Alterar(Manuntencao manuntencao)
        {
            _context.Update(manuntencao);
            _context.SaveChanges();
        }

        public Manuntencao Buscar(int CodigoManutencao)
        {
            IEnumerable<Manuntencao> manuntencao = GetQuery().Where(manuntencaoModel => manuntencaoModel.CodigoManuntencao.Equals(CodigoManutencao));

            return manuntencao.ElementAtOrDefault(0);

        }

        public void Excluir(int CodigoManuntencao)
        {
            var _manutencao = _context.Manuntencao.Find(CodigoManuntencao);
            _context.Manuntencao.Remove(_manutencao);
            _context.SaveChanges();
        }

        public int Inserir(Manuntencao manuntencao)
        {
            _context.Add(manuntencao);
            _context.SaveChanges();
            return manuntencao.CodigoManuntencao;
        }

        public IEnumerable<Manuntencao> ObterTodos()
        {
            return GetQuery();
        }
    }
}
