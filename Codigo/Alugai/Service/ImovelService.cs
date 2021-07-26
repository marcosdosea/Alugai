using System.Collections.Generic;
using System.Linq;
using Core;
using Core.Services;
using Microsoft.EntityFrameworkCore;
using Service.Exceptions;

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
            try
            {
                var _imovel = _context.Imovel.Find(CodigoImovel);
                _context.Imovel.Remove(_imovel);
                _context.SaveChanges();
            }
            catch(DbUpdateException)
            {
                throw new IntegridadeException("Erro: Não foi possível deletar o imóvel, o mesmo tem registros em uso.");
            }
            
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
