using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services
{
    public interface IStatuspagamentoService
    {
        int Inserir(Statuspagamento statuspagemnto);
        void Alterar(Statuspagamento statuspagamento);
        void Excluir(int CodigoStatusPagamento);
        Statuspagamento Buscar(int CodigoStatusPagamento);
        IEnumerable<Statuspagamento> ObterTodos();
    }
}
