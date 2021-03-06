﻿using System.Collections.Generic;

namespace Core.Services
{
    public interface IManterDespesasService
    {
        int Inserir(Despesas despesas);
        void Alterar(Despesas despesas);
        void Excluir(int codigoDespesas);
        Despesas Buscar(int codigoDespesas);
        IEnumerable<Despesas> ObterTodos();
    }
}
