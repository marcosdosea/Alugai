using System;
using System.Collections.Generic;

namespace Persistence
{
    public partial class Pessoaaluguel
    {
        public int CodigoPessoa { get; set; }
        public int CodigoAluguel { get; set; }

        public virtual Aluguel CodigoAluguelNavigation { get; set; }
        public virtual Pessoa CodigoPessoaNavigation { get; set; }
    }
}
