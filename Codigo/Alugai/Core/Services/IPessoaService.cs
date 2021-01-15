using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services
{
   
        public interface IPessoaService
        {
            int Inserir(Pessoa pessoa);
            void Alterar(Pessoa pessoa);
            void Excluir(int CodigoPessoa);
           Pessoa Buscar(int CodigoPessoa);
           IEnumerable<Pessoa> ObterTodos();

    }
}
