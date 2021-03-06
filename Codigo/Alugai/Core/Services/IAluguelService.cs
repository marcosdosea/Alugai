﻿using System.Collections.Generic;

namespace Core.Services
{
    public interface IAluguelService
    {
        int Inserir(Aluguel aluguel);
        void Alterar(Aluguel aluguel);
        void Excluir(int codigoAluguel);
        Aluguel Buscar(int codigoAluguel);
        IEnumerable<Aluguel> ObterTodos();
    }
}
