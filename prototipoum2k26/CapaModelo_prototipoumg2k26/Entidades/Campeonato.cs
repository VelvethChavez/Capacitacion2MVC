using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo_prototipoumg2k26.Entidades
{
    public class Campeonato
    {
        public int IdCampeonato { get; set; }
        public string NombreCampeonato { get; set; }

        public DateTime FechaInicioCampeonato { get; set; }

        public DateTime FechaFinCampeonato { get; set; }

        public int IdDeporte_Campeonato { get; set; }

        public int IdTipoCampeonato_Campeonato { get; set; }    

        public int IdEstado_Campeonato { get; set; }

    }
}
