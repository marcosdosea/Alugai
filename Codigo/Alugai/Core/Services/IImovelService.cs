using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services
{
    public interface IImovelService
    {
        int Inserir(Imovel imovel);
        void Alterar(Imovel imovel);
        void Excluir(int CodigoImovel);
        Imovel Buscar(int CodigoImovel);
        IEnumerable<Imovel> ObterTodos();
    }
}
