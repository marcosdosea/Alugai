using Core;
using Core.Services;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public class ManterDespesasService : IManterDespesasService
    {
        private readonly alugaiContext _context;

        public ManterDespesasService(alugaiContext context)
        {
            _context = context;
        }
        public int Inserir(Despesas despesas)
        {
            _context.Add(despesas);
            _context.SaveChanges();
            return despesas.CodigoDespesas;
        }
        public void Alterar(Despesas despesas)
        {
            _context.Update(despesas);
            _context.SaveChanges();
        }
        public void Excluir(int codigoDespesas)
        {
            var _despesas = _context.Despesas.Find(codigoDespesas);
            _context.Despesas.Remove(_despesas);
            _context.SaveChanges();
        }
        private IQueryable<Despesas> GetQuery()
        {
            IQueryable<Despesas> tb_despesas = _context.Despesas;
            var query = from despesas in tb_despesas select despesas;
            return query;
        }
        public Despesas Buscar(int codigoDespesas)
        {
            IEnumerable<Despesas> despesas= GetQuery().Where(despesasModel => despesasModel.CodigoDespesas.Equals(codigoDespesas));
            return despesas.ElementAtOrDefault(0);
        }
        public IEnumerable<Despesas> ObterTodos()
        {
            return GetQuery();
        }
    }
}
