using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services
{
    public interface IAnuncioService
    {
        int Inserir(Anuncio anuncio);
        void Alterar(Anuncio anuncio);
        void Excluir(int codigoAnuncio);
        Anuncio Buscar(int codigoAnuncio);
        IEnumerable<Anuncio> ObterTodos();
    }
}
