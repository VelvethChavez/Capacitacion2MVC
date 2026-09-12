using CapaModelo_prototipoumg2k26.Contratos;
using CapaModelo_prototipoumg2k26.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;

namespace CapaModelo_prototipoumg2k26.Repositorios
{
    public class RepositorioCampeonato
        : RepositorioMaestro,
          IRepositorioCampeonato
    {
        private readonly string selectAll;
        private readonly string insert;
        private readonly string update;
        private readonly string delete;

        public RepositorioCampeonato()
        {
            selectAll =
                "SELECT * FROM tbl_campeonato";

            insert =
                "INSERT INTO tbl_campeonato " +
                "VALUES (Null, ?, ?, ?, ?, ?, ?)";

            update =
                "UPDATE tbl_campeonato SET " +
                "NombreCampeonato = ?, " +
                "FechaInicioCampeonato = ?, " +
                "FechaFinCampeonato = ?, " +
                "IdDeporte_Campeonato = ?, " +
                "IdTipoCampeonato_Campeonato = ?, " +
                "IdEstado_Campeonato = ? " +
                "WHERE IdCampeonato = ?";

            delete =
                "DELETE FROM tbl_campeonato " +
                "WHERE IdCampeonato = ?";
        }

        public int Agregar(Campeonato entidad)
        {
            var parametros =
                new List<OdbcParameter>
                {
                    new OdbcParameter(
                        "NombreCampeonato",
                        entidad.NombreCampeonato),

                    new OdbcParameter(
                        "FechaInicioCampeonato",
                        entidad.FechaInicioCampeonato),

                    new OdbcParameter(
                        "FechaFinCampeonato",
                        entidad.FechaFinCampeonato),

                    new OdbcParameter(
                        "IdDeporte_Campeonato",
                        entidad.IdDeporte_Campeonato),

                    new OdbcParameter(
                        "IdTipoCampeonato_Campeonato",
                        entidad.IdTipoCampeonato_Campeonato),

                    new OdbcParameter(
                        "IdEstado_Campeonato",
                        entidad.IdEstado_Campeonato)
                };

            return EjecucionNonQuery(
                insert,
                parametros,
                CommandType.Text);
        }

        public int Editar(Campeonato entidad)
        {
            var parametros =
                new List<OdbcParameter>
                {
                    new OdbcParameter(
                        "NombreCampeonato",
                        entidad.NombreCampeonato),

                    new OdbcParameter(
                        "FechaInicioCampeonato",
                        entidad.FechaInicioCampeonato),

                    new OdbcParameter(
                        "FechaFinCampeonato",
                        entidad.FechaFinCampeonato),

                    new OdbcParameter(
                        "IdDeporte_Campeonato",
                        entidad.IdDeporte_Campeonato),

                    new OdbcParameter(
                        "IdTipoCampeonato_Campeonato",
                        entidad.IdTipoCampeonato_Campeonato),

                    new OdbcParameter(
                        "IdEstado_Campeonato",
                        entidad.IdEstado_Campeonato),

                    new OdbcParameter(
                        "IdCampeonato",
                        entidad.IdCampeonato)
                };

            return EjecucionNonQuery(
                update,
                parametros,
                CommandType.Text);
        }

        public int Remover(Campeonato entidad)
        {
            var parametros =
                new List<OdbcParameter>
                {
                    new OdbcParameter(
                        "IdCampeonato",
                        entidad.IdCampeonato)
                };

            return EjecucionNonQuery(
                delete,
                parametros,
                CommandType.Text);
        }

        public IEnumerable<Campeonato> GetAll()
        {
            var tabla =
                EjecucionConsulta(
                    selectAll,
                    CommandType.Text);

            var lista =
                new List<Campeonato>();

            foreach (DataRow row in tabla.Rows)
            {
                var campeonato = new Campeonato
                {
                    IdCampeonato =
                        Convert.ToInt32(row[0]),

                    NombreCampeonato =
                        row[1].ToString(),

                    FechaInicioCampeonato =
                        Convert.ToDateTime(row[2]),

                    FechaFinCampeonato =
                        Convert.ToDateTime(row[3]),

                    IdDeporte_Campeonato =
                        Convert.ToInt32(row[4]),

                    IdTipoCampeonato_Campeonato =
                        Convert.ToInt32(row[5]),

                    IdEstado_Campeonato =
                        Convert.ToInt32(row[6])
                };

                lista.Add(campeonato);
            }

            tabla.Clear();

            return lista;
        }
    }
}