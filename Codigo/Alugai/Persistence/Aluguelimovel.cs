using System;
using System.Collections.Generic;

namespace Persistence
{
    public partial class Aluguelimovel
    {
        public int CodigoAluguel { get; set; }
        public int CodigoImovel { get; set; }

        public virtual Aluguel CodigoAluguelNavigation { get; set; }
        public virtual Imovel CodigoImovelNavigation { get; set; }
    }
}
