using CapaModelo_prototipoumg2k26.Contratos;
using CapaModelo_prototipoumg2k26.Entidades;
using System.Data;
using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CapaModelo_prototipoumg2k26.Repositorios
{
     public class RepositorioCampeonato : RepositorioMaestro , IRepositorioCampeonato
    {
        private string selecAll;
        private string insert;
        private string update;
        private string delete;
        public RepositorioCampeonato()
        {
            selecAll = "SELECT * FROM tbl_Campeonato";
            insert = "INSERT INTO tbl_Campeonato VALUE (Null, ?, ?, ?, ?, ?)";
            update = "UPDATE tbl_Campeonato NombreCampeonato = ?, FechaInicioCampeonato = ?, FechaFinCampeonato = ?, IdDeporte_Campeonato = ?, IdTipoCampeonato_Campeonato = ?, IdEstado_Campeonato = ? WHERE IdCampeonato = ?";
            delete = "DELETE FROM tbl_Campeonato WHERE IdCampeonato = ?";
        }


        public int Agregar(Campeonato entidad)
        {
            var _parametros = new List<OdbcParameter>();
            {
                _parametros.Add(new OdbcParameter("NombreCampeonato", entidad.NombreCampeonato));
                _parametros.Add(new OdbcParameter("FechaInicioCampeonato", entidad.FechaInicioCampeonato));
                _parametros.Add(new OdbcParameter("FechaFinCampeonato", entidad.FechaFinCampeonato));
                _parametros.Add(new OdbcParameter("IdDeporte_Campeonato", entidad.IdDeporte_Campeonato));
                _parametros.Add(new OdbcParameter("IdTipoCampeonato_Campeonato", entidad.IdTipoCampeonato_Campeonato));
                _parametros.Add(new OdbcParameter("IdEstado_Campeonato", entidad.IdEstado_Campeonato));
                return EjecucionNonQuery(insert, _parametros, CommandType.Text);
            }
        }

        public int Editar(Campeonato entidad)
        {
            var _parametros = new List<OdbcParameter>();
            {
               _parametros.Add(new OdbcParameter("NombreCampeonato", entidad.NombreCampeonato));
                _parametros.Add(new OdbcParameter("FechaInicioCampeonato", entidad.FechaInicioCampeonato));
                _parametros.Add(new OdbcParameter("FechaFinCampeonato", entidad.FechaFinCampeonato));
                _parametros.Add(new OdbcParameter("IdDeporte_Campeonato", entidad.IdDeporte_Campeonato));
                _parametros.Add(new OdbcParameter("IdTipoCampeonato_Campeonato", entidad.IdTipoCampeonato_Campeonato));
                _parametros.Add(new OdbcParameter("IdEstado_Campeonato", entidad.IdEstado_Campeonato));
                _parametros.Add(new OdbcParameter("IdCampeonato", entidad.IdCampeonato));
                return EjecucionNonQuery(update, _parametros, CommandType.Text);
        }


        }

        public int Remover(Campeonato entidad)
        {
            var _parametros = new List<OdbcParameter>();
            {
                _parametros.Add(new OdbcParameter("IdCampeonato", entidad.IdCampeonato));
                return EjecucionNonQuery(delete, _parametros, CommandType.Text);
            }
        }

        public IEnumerable<Campeonato> GetAll()
        {
            var tblTabla = EjecucionConsulta(selecAll, CommandType.Text);
            var lstCampeonato = new List<Campeonato>();
            foreach (DataRow row in tblTabla.Rows)
            {
                var campeonato = new Campeonato();
                campeonato.IdCampeonato = Convert.ToInt32(row[0]);
                campeonato.NombreCampeonato = row[1].ToString();
                campeonato.FechaInicioCampeonato = Convert.ToDateTime(row[2]);
                campeonato.FechaFinCampeonato = Convert.ToDateTime(row[3]);
                campeonato.IdDeporte_Campeonato = Convert.ToInt32(row[4]);
                campeonato.IdTipoCampeonato_Campeonato = Convert.ToInt32(row[5]);
                campeonato.IdEstado_Campeonato = Convert.ToInt32(row[6]);



            }


                tblTabla.Clear();
                tblTabla = null;
                return lstCampeonato;
            }
            

        }
}
