using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CapaModelo_prototipoumg2k26.Contratos;
using CapaModelo_prototipoumg2k26.Entidades;
using CapaModelo_prototipoumg2k26.Repositorios;

namespace CapaControlador_prototipoumg2k26
{
    public class ModeloCampeonato
    {
        private int _IdCampeonato;
        private string _NombreCampeonato;
        private DateTime _FechaInicioCampeonato;
        private DateTime _FechaFinCampeonato;
        private int _IdDeporte_Campeonato;
        private int _IdTipoCampeonato_Campeonato;
        private int _IdEstado_Campeonato;

        private IRepositorioCampeonato RepositorioCampeonato;

        public EstadoEntidad Estado { private get; set; }

        private List<ModeloCampeonato> ListaCampeonatos;

        public int IdCampeonato
        {
            get => _IdCampeonato;
            set => _IdCampeonato = value;
        }

        [Required(ErrorMessage = "El nombre del campeonato es requerido")]
        [StringLength(
            100,
            MinimumLength = 3,
            ErrorMessage = "El nombre debe tener entre 3 y 100 caracteres")]
        [RegularExpression(
            @"^[a-zA-Z0-9á-úÁ-ÚñÑ\s]+$",
            ErrorMessage = "El nombre solo puede contener letras, números y espacios")]
        public string NombreCampeonato
        {
            get => _NombreCampeonato;
            set => _NombreCampeonato = value;
        }

        [Required(ErrorMessage = "La fecha de inicio es requerida")]
        public DateTime FechaInicioCampeonato
        {
            get => _FechaInicioCampeonato;
            set => _FechaInicioCampeonato = value;
        }

        [Required(ErrorMessage = "La fecha de finalización es requerida")]
        public DateTime FechaFinCampeonato
        {
            get => _FechaFinCampeonato;
            set => _FechaFinCampeonato = value;
        }

        [Required(ErrorMessage = "Debe seleccionar un deporte")]
        [Range(1, int.MaxValue,
            ErrorMessage = "Debe seleccionar un deporte válido")]
        public int IdDeporte_Campeonato
        {
            get => _IdDeporte_Campeonato;
            set => _IdDeporte_Campeonato = value;
        }

        [Required(ErrorMessage = "Debe seleccionar un tipo de campeonato")]
        [Range(1, int.MaxValue,
            ErrorMessage = "Debe seleccionar un tipo de campeonato válido")]
        public int IdTipoCampeonato_Campeonato
        {
            get => _IdTipoCampeonato_Campeonato;
            set => _IdTipoCampeonato_Campeonato = value;
        }

        [Required(ErrorMessage = "Debe seleccionar un estado para el campeonato")]
        [Range(1, int.MaxValue,
            ErrorMessage = "Debe seleccionar un estado válido")]
        public int IdEstado_Campeonato
        {
            get => _IdEstado_Campeonato;
            set => _IdEstado_Campeonato = value;
        }

        public ModeloCampeonato()
        {
            RepositorioCampeonato = new RepositorioCampeonato();
        }

        public string GrabarCambios()
        {
            string mensaje = null;

            try
            {
                var modeloDatosCampeonato = new Campeonato();

                modeloDatosCampeonato.IdCampeonato = _IdCampeonato;
                modeloDatosCampeonato.NombreCampeonato = _NombreCampeonato;
                modeloDatosCampeonato.FechaInicioCampeonato = _FechaInicioCampeonato;
                modeloDatosCampeonato.FechaFinCampeonato = _FechaFinCampeonato;
                modeloDatosCampeonato.IdDeporte_Campeonato =
                    _IdDeporte_Campeonato;
                modeloDatosCampeonato.IdTipoCampeonato_Campeonato =
                    _IdTipoCampeonato_Campeonato;
                modeloDatosCampeonato.IdEstado_Campeonato =
                    _IdEstado_Campeonato;

                switch (Estado)
                {
                    case EstadoEntidad.Added:

                        RepositorioCampeonato.Agregar(
                            modeloDatosCampeonato);

                        mensaje = "Grabacion exitosa";

                        break;

                    case EstadoEntidad.Modified:

                        RepositorioCampeonato.Editar(
                            modeloDatosCampeonato);

                        mensaje = "Actualizacion exitosa";

                        break;

                    case EstadoEntidad.Deleted:

                        RepositorioCampeonato.Remover(
                            modeloDatosCampeonato);

                        mensaje = "Eliminacion exitosa";

                        break;
                }
            }
            catch (Exception ex)
            {
                mensaje = ex.ToString();
            }

            return mensaje;
        }

        public List<ModeloCampeonato> GetAll()
        {
            var modeloDatosCampeonato =
                RepositorioCampeonato.GetAll();

            ListaCampeonatos = new List<ModeloCampeonato>();

            foreach (Campeonato item in modeloDatosCampeonato)
            {
                ListaCampeonatos.Add(
                    new ModeloCampeonato
                    {
                        _IdCampeonato = item.IdCampeonato,
                        _NombreCampeonato = item.NombreCampeonato,
                        _FechaInicioCampeonato =
                            item.FechaInicioCampeonato,
                        _FechaFinCampeonato =
                            item.FechaFinCampeonato,
                        _IdDeporte_Campeonato =
                            item.IdDeporte_Campeonato,
                        _IdTipoCampeonato_Campeonato =
                            item.IdTipoCampeonato_Campeonato,
                        _IdEstado_Campeonato =
                            item.IdEstado_Campeonato
                    });
            }

            return ListaCampeonatos;
        }

        public IEnumerable<ModeloCampeonato> FindById(string filter)
        {
            if (ListaCampeonatos == null)
            {
                GetAll();
            }

            return ListaCampeonatos.FindAll(
                e =>
                    e.NombreCampeonato.Contains(filter) ||
                    e.IdCampeonato
                        .ToString()
                        .Contains(filter));
        }

        public object GetEstadosCampeonato()
        {
            RepositorioEstadoCampeonato repositorio = new RepositorioEstadoCampeonato();
            return repositorio.GetAll();
        }

        public object GetDeportes()
        {
            RepositorioDeporte repositorio = new RepositorioDeporte();
            return repositorio.GetAll();
        }

        public object GetTiposCampeonato()
        {
            RepositorioTipoCampeonato repositorio = new RepositorioTipoCampeonato();
            return repositorio.GetAll();
        }
    }
}