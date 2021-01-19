using Core;
using Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public class AnuncioService : IAnuncioService
    {
        private readonly alugaiContext _context;

        public AnuncioService(alugaiContext context)
        {
            _context = context;
        }
        public int Inserir(Anuncio anuncio)
        {
            _context.Add(anuncio);
            _context.SaveChanges();
            return anuncio.CodigoAnuncio;
        }
        public void Alterar(Anuncio anuncio)
        {
            _context.Update(anuncio);
            _context.SaveChanges();
        }
        public void Excluir(int codigoAnuncio)
        {
            var _anuncio = _context.Anuncio.Find(codigoAnuncio);
            _context.Anuncio.Remove(_anuncio);
            _context.SaveChanges();
        }
        private IQueryable<Anuncio> GetQuery()
        {
            IQueryable<Anuncio> tb_anuncio = _context.Anuncio;
            var query = from anuncio in tb_anuncio select anuncio;
            return query;
        }
        public Anuncio Buscar(int codigoAnuncio)
        {
            IEnumerable<Anuncio> anuncios = GetQuery().Where(anuncioModel => anuncioModel.CodigoAnuncio.Equals(codigoAnuncio));
            return anuncios.ElementAtOrDefault(0);
        }
        public IEnumerable<Anuncio> ObterTodos()
        {
            return GetQuery();
        }
    }
}
