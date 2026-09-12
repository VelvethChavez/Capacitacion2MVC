using CapaModelo_prototipoumg2k26.Entidades;
using System;
using System.Collections.Generic;
using System.Data;

namespace CapaModelo_prototipoumg2k26.Repositorios
{
    public class RepositorioDeporte : RepositorioMaestro
    {
        public IEnumerable<Deporte> GetAll()
        {
            var tabla =
                EjecucionConsulta(
                    "SELECT * FROM tbl_deporte",
                    CommandType.Text);

            var lista =
                new List<Deporte>();

            foreach (DataRow row in tabla.Rows)
            {
                lista.Add(
                    new Deporte
                    {
                        IdDeporte =
                            Convert.ToInt32(row[0]),

                        NombreDeporte =
                            row[1].ToString()
                    });
            }

            return lista;
        }
    }

    public class RepositorioTipoCampeonato
        : RepositorioMaestro
    {
        public IEnumerable<TipoCampeonato> GetAll()
        {
            var tabla =
                EjecucionConsulta(
                    "SELECT * FROM tbl_tipocampeonato",
                    CommandType.Text);

            var lista =
                new List<TipoCampeonato>();

            foreach (DataRow row in tabla.Rows)
            {
                lista.Add(
                    new TipoCampeonato
                    {
                        IdTipoCampeonato =
                            Convert.ToInt32(row[0]),

                        NombreTipoCampeonato =
                            row[1].ToString()
                    });
            }

            return lista;
        }
    }

    public class RepositorioEstadoCampeonato
        : RepositorioMaestro
    {
        public IEnumerable<EstadoCampeonato> GetAll()
        {
            var tabla =
                EjecucionConsulta(
                    "SELECT * FROM tbl_estadocampeonato",
                    CommandType.Text);

            var lista =
                new List<EstadoCampeonato>();

            foreach (DataRow row in tabla.Rows)
            {
                lista.Add(
                    new EstadoCampeonato
                    {
                        IdEstadoCampeonato =
                            Convert.ToInt32(row[0]),

                        NombreEstadoCampeonato =
                            row[1].ToString()
                    });
            }

            return lista;
        }
    }
}