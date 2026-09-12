using System.Data;
using System.Data.Odbc;

namespace Capa_Modelo_ComboI.Repositorios
{
    public class RepositorioComboI : Repositorio
    {
        public DataTable obtenerDatos(
            string _tabla,
            string _campo1,
            string _campo2)
        {
            string sql =
                "SELECT " +
                _campo1 +
                ", " +
                _campo2 +
                " FROM " +
                _tabla;

            using (OdbcCommand comando =
                new OdbcCommand(sql, ObtenerConexion()))
            {
                using (OdbcDataAdapter adaptador =
                    new OdbcDataAdapter(comando))
                {
                    DataTable dtDatos = new DataTable();

                    adaptador.Fill(dtDatos);

                    return dtDatos;
                }
            }
        }
    }
}