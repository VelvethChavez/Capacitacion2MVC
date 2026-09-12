using System.Data.Odbc;

namespace CapaModelo_prototipoumg2k26.Repositorios
{
    public abstract class Repositorio
    {
        public readonly string connectionString;

        public Repositorio()
        {
            connectionString = "Dsn=sistema_polideportivo";
        }

        protected OdbcConnection ObtenerConexion()
        {
            return new OdbcConnection(connectionString);
        }
    }
}