﻿using System;
using System.Collections.Generic;

namespace Persistence
{
    public partial class Pagamento
    {
        public int CodigoPagamento { get; set; }
        public DateTime DataPagamento { get; set; }
        public double Valor { get; set; }
        public DateTime DataVencimento { get; set; }
        public string FormaDePagamento { get; set; }
        public int CodigoAluguel { get; set; }

        public virtual Aluguel CodigoAluguelNavigation { get; set; }
    }
}
