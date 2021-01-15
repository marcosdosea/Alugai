using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core;
using Core.Services;

namespace Service
{
    public class ImovelService : IImovelService
    {
        private readonly alugaiContext _context;

        public ImovelService(alugaiContext context)
        {
            _context = context;
        }
        public int Inserir(Imovel imovel)
        {
            _context.Add(imovel);
            _context.SaveChanges();
            return imovel.CodigoImovel;
        }
        public void Alterar(Imovel imovel)
        {
            _context.Update(imovel);
            _context.SaveChanges();
        }
        public void Excluir(int CodigoImovel)
        {
            var _imovel = _context.Imovel.Find(CodigoImovel);
            _context.Imovel.Remove(_imovel);
            _context.SaveChanges();
        }
        private IQueryable<Imovel> GetQuery()
        {
            IQueryable<Imovel> tb_imovel = _context.Imovel;
            var query = from imovel in tb_imovel select imovel;
            return query;
        }
        public Imovel Buscar(int CodigoImovel)
        {
            IEnumerable<Imovel> imoveis = GetQuery().Where(imovelModel => imovelModel.CodigoImovel.Equals(CodigoImovel));
            return imoveis.ElementAtOrDefault(0);
        }
        public IEnumerable<Imovel> ObterTodos()
        {
            return GetQuery();
        }
    }
}
