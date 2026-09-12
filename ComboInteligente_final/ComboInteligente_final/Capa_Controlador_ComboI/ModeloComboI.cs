using Capa_Modelo_ComboI.Repositorios;
using System.Data;

namespace Capa_Controlador_ComboI
{
    public class ModeloComboI
    {
        private RepositorioComboI sentencias =
            new RepositorioComboI();

        public DataTable enviarDatos(
            string _tabla,
            string _campo1,
            string _campo2)
        {
            DataTable dtTabla =
                sentencias.obtenerDatos(
                    _tabla,
                    _campo1,
                    _campo2
                );

            return dtTabla;
        }
    }
}
