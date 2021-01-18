using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services
{
    public interface IPagamentoService
    {
        int Inserir(Pagamento pagamento);
        void Alterar(Pagamento pagamento);
        void Excluir(int CodigoPagamento);
        Pagamento Buscar(int CodigoPagamento);
        IEnumerable<Pagamento> ObterTodos();
    }
}
