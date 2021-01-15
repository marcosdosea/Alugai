using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services
{
   
        public interface ISolicotacaoManutencaoService
        {
            int Inserir(Manuntencao manuntencao);
            void Alterar(Manuntencao manuntencao);
            void Excluir(int CodigoManuntencao);
            Manuntencao Buscar(int CodigoManuntencao);
            IEnumerable<Manuntencao> ObterTodos();

        }

    
}
