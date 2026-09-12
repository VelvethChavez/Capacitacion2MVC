using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;

namespace CapaModelo_prototipoumg2k26.Repositorios
{
    public abstract class RepositorioMaestro : Repositorio
    {
        private DataTable dtTablaDatos;

        public int EjecucionNonQuery(
            string _comandoTexto,
            List<OdbcParameter> _parametros,
            CommandType _comandoTipo)
        {
            using (var conexion = ObtenerConexion())
            {
                conexion.Open();

                using (var ocComando = new OdbcCommand())
                {
                    ocComando.Connection = conexion;
                    ocComando.CommandText = _comandoTexto;
                    ocComando.CommandType = _comandoTipo;

                    ocComando.Parameters.AddRange(
                        _parametros.ToArray());

                    return ocComando.ExecuteNonQuery();
                }
            }
        }

        public DataTable EjecucionConsulta(
            string _comandoTexto,
            CommandType _comandoTipo)
        {
            dtTablaDatos = new DataTable();

            using (var conexion = ObtenerConexion())
            {
                conexion.Open();

                using (var ocComando = new OdbcCommand())
                {
                    ocComando.Connection = conexion;
                    ocComando.CommandText = _comandoTexto;
                    ocComando.CommandType = _comandoTipo;

                    using (var reader =
                        ocComando.ExecuteReader())
                    {
                        dtTablaDatos.Load(reader);
                    }
                }

                return dtTablaDatos;
            }
        }
    }
}