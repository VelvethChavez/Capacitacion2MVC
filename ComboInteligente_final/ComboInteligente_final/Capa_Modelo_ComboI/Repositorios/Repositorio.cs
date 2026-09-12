using System.Data.Odbc;

namespace Capa_Modelo_ComboI.Repositorios
{
    public abstract class Repositorio
    {
        public readonly string connectionString;

        public Repositorio()
        {
            connectionString =
                "Dsn=sistema_polideportivo";
        }

        protected OdbcConnection ObtenerConexion()
        {
            return new OdbcConnection(
                connectionString
            );
        }
    }
}