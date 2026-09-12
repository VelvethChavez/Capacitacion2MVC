using System;

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

    public class Deporte
    {
        public int IdDeporte { get; set; }

        public string NombreDeporte { get; set; }
    }

    public class TipoCampeonato
    {
        public int IdTipoCampeonato { get; set; }

        public string NombreTipoCampeonato { get; set; }
    }

    public class EstadoCampeonato
    {
        public int IdEstadoCampeonato { get; set; }

        public string NombreEstadoCampeonato { get; set; }
    }
}