using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services
{
    public interface IDeclaracaoAluguelService
    {
        int Inserir(Aluguel aluguel);
        void Alterar(Aluguel aluguel);
        void Excluir(int CodigoAluguel);
        Aluguel Buscar(int CodigoAluguel);
        IEnumerable<Aluguel> ObterTodos();
    }
}
