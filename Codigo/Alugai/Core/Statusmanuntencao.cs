using System.Collections.Generic;

namespace Core
{
    public partial class Statusmanuntencao
    {
        public Statusmanuntencao()
        {
            Manuntencao = new HashSet<Manuntencao>();
        }

        public int CodigoStatusManuntencao { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<Manuntencao> Manuntencao { get; set; }
    }
}
