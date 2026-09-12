using System;
using System.Windows.Forms;
using CapaControlador_prototipoumg2k26;

namespace CapaVista_prototipoumg2k26.Formas
{
    public partial class FrmCampeonato : Form
    {
        private ModeloCampeonato campeonato =
            new ModeloCampeonato();

        public FrmCampeonato()
        {
            InitializeComponent();

            pnlIngresoDatos.Enabled = false;

            CargarCombos();
        }

        private void FrmCampeonato_Load(
            object sender,
            EventArgs e)
        {
            ListaCampeonato();
        }

        private void CargarCombos()
        {
            try
            {
                CargarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar los ComboBox: "
                    + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void CargarDatos()
        {
            comboI1.llenarCombo("tbl_campeonato", "IdCampeonato", "NombreCampeonato");

            cmbdeporte.DataSource =
                campeonato.GetDeportes();

            cmbdeporte.DisplayMember =
                "NombreDeporte";

            cmbdeporte.ValueMember =
                "IdDeporte";

            cmbdeporte.SelectedIndex = 1;


            cmbtipocampeonato.DataSource =
                campeonato.GetTiposCampeonato();

            cmbtipocampeonato.DisplayMember =
                "NombreTipoCampeonato";

            cmbtipocampeonato.ValueMember =
                "IdTipoCampeonato";

            cmbtipocampeonato.SelectedIndex = 1;


            cmbestadocameponato.DataSource =
                campeonato.GetEstadosCampeonato();

            cmbestadocameponato.DisplayMember =
                "NombreEstadoCampeonato";

            cmbestadocameponato.ValueMember =
                "IdEstadoCampeonato";

            cmbestadocameponato.SelectedIndex = 1;
        }

        private void ListaCampeonato()
        {
            try
            {
                dgvCampeonato.DataSource =
                    campeonato.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnBuscar_Click(
            object sender,
            EventArgs e)
        {
            dgvCampeonato.DataSource =
                campeonato.FindById(
                    txtSearch.Text);
        }

        private void txtSearch_TextChanged(
            object sender,
            EventArgs e)
        {
            dgvCampeonato.DataSource =
                campeonato.FindById(
                    txtSearch.Text);
        }

        private void btnNuevo_Click(
            object sender,
            EventArgs e)
        {
            Reinicio();

            pnlIngresoDatos.Enabled = true;

            campeonato.Estado =
                EstadoEntidad.Added;

            txtnombrecampeonato.Focus();
        }

        private void btnGrabar_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                campeonato.NombreCampeonato =
                    txtnombrecampeonato.Text;

                campeonato.FechaInicioCampeonato =
                    dtpfechainicio.Value;

                campeonato.FechaFinCampeonato =
                    dtpfechafinal.Value;

                if (cmbdeporte.SelectedValue == null)
                {
                    MessageBox.Show(
                        "Debe seleccionar un deporte.");

                    return;
                }

                campeonato.IdDeporte_Campeonato =
                    Convert.ToInt32(
                        cmbdeporte.SelectedValue);


                if (cmbtipocampeonato.SelectedValue == null)
                {
                    MessageBox.Show(
                        "Debe seleccionar un tipo de campeonato.");

                    return;
                }

                campeonato.IdTipoCampeonato_Campeonato =
                    Convert.ToInt32(
                        cmbtipocampeonato.SelectedValue);


                if (cmbestadocameponato.SelectedValue == null)
                {
                    MessageBox.Show(
                        "Debe seleccionar un estado.");

                    return;
                }

                campeonato.IdEstado_Campeonato =
                    Convert.ToInt32(
                        cmbestadocameponato.SelectedValue);


                bool valido =
                    new Ayudas.ValidacionDatos(
                        campeonato).Validar();

                if (valido)
                {
                    string resultado =
                        campeonato.GrabarCambios();

                    MessageBox.Show(resultado);

                    ListaCampeonato();

                    Reinicio();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al guardar: "
                    + ex.Message);
            }
        }

        private void Reinicio()
        {
            pnlIngresoDatos.Enabled = false;

            txtnombrecampeonato.Clear();

            dtpfechainicio.Value =
                DateTime.Today;

            dtpfechafinal.Value =
                DateTime.Today;

            cmbdeporte.SelectedIndex = -1;

            cmbtipocampeonato.SelectedIndex = -1;

            cmbestadocameponato.SelectedIndex = -1;
        }

        private void btnCancelar_Click(
            object sender,
            EventArgs e)
        {
            Reinicio();
        }

        private void btnEditar_Click(
            object sender,
            EventArgs e)
        {
            if (dgvCampeonato.SelectedRows.Count > 0)
            {
                pnlIngresoDatos.Enabled = true;

                campeonato.IdCampeonato =
                    Convert.ToInt32(
                        dgvCampeonato.CurrentRow
                            .Cells[0].Value);

                txtnombrecampeonato.Text =
                    dgvCampeonato.CurrentRow
                        .Cells[1].Value.ToString();

                dtpfechainicio.Value =
                    Convert.ToDateTime(
                        dgvCampeonato.CurrentRow
                            .Cells[2].Value);

                dtpfechafinal.Value =
                    Convert.ToDateTime(
                        dgvCampeonato.CurrentRow
                            .Cells[3].Value);

                cmbdeporte.SelectedValue =
                    Convert.ToInt32(
                        dgvCampeonato.CurrentRow
                            .Cells[4].Value);

                cmbtipocampeonato.SelectedValue =
                    Convert.ToInt32(
                        dgvCampeonato.CurrentRow
                            .Cells[5].Value);

                cmbestadocameponato.SelectedValue =
                    Convert.ToInt32(
                        dgvCampeonato.CurrentRow
                            .Cells[6].Value);

                campeonato.Estado =
                    EstadoEntidad.Modified;
            }
            else
            {
                MessageBox.Show(
                    "Debe seleccionar un registro");
            }
        }

        private void btnBorrar_Click(
            object sender,
            EventArgs e)
        {
            if (dgvCampeonato.SelectedRows.Count > 0)
            {
                DialogResult dialog =
                    MessageBox.Show(
                        "¿Está seguro de eliminar este campeonato?",
                        "Confirmar Eliminación",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                if (dialog == DialogResult.Yes)
                {
                    campeonato.Estado =
                        EstadoEntidad.Deleted;

                    campeonato.IdCampeonato =
                        Convert.ToInt32(
                            dgvCampeonato.CurrentRow
                                .Cells[0].Value);

                    string resultado =
                        campeonato.GrabarCambios();

                    MessageBox.Show(resultado);

                    ListaCampeonato();

                    Reinicio();
                }
            }
            else
            {
                MessageBox.Show(
                    "Debe seleccionar un registro");
            }
        }
    }
}