using System.Collections.Generic;

namespace Core
{
    public partial class Statusmanutencao
    {
        public Statusmanutencao()
        {
            Manuntencao = new HashSet<Manuntencao>();
        }

        public int CodigoStatusManutencao { get; set; }
        public string StatusManutencao1 { get; set; }

        public virtual ICollection<Manuntencao> Manuntencao { get; set; }
    }
}
