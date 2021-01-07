using System;
using System.Collections.Generic;

namespace Persistence
{
    public partial class Aluguel
    {
        public Aluguel()
        {
            Aluguelimovel = new HashSet<Aluguelimovel>();
            Pagamento = new HashSet<Pagamento>();
            Pessoaaluguel = new HashSet<Pessoaaluguel>();
        }

        public int CodigoAluguel { get; set; }
        public string Descricao { get; set; }
        public int CodigoStatusPagamento { get; set; }

        public virtual Statuspagamento CodigoStatusPagamentoNavigation { get; set; }
        public virtual ICollection<Aluguelimovel> Aluguelimovel { get; set; }
        public virtual ICollection<Pagamento> Pagamento { get; set; }
        public virtual ICollection<Pessoaaluguel> Pessoaaluguel { get; set; }
    }
}
