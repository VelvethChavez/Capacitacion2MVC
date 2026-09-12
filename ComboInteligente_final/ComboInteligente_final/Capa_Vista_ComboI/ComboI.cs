using Capa_Controlador_ComboI;
using System;
using System.Data;
using System.Windows.Forms;

namespace Capa_Vista_ComboI
{
    public partial class ComboI : UserControl
    {
        private ModeloComboI controlador =
            new ModeloComboI();

        public ComboI()
        {
            InitializeComponent();

            cboPrueba.AutoCompleteMode =
                AutoCompleteMode.SuggestAppend;

            cboPrueba.AutoCompleteSource =
                AutoCompleteSource.CustomSource;
        }

        public void llenarCombo(
            string _tabla,
            string _campo1,
            string _campo2)
        {
            try
            {
                DataTable dtTabla =
                    controlador.enviarDatos(
                        _tabla,
                        _campo1,
                        _campo2
                    );

                if (dtTabla == null)
                {
                    cboPrueba.DataSource = null;
                    return;
                }

                cboPrueba.DataSource = dtTabla;

                // El primer campo será el valor
                cboPrueba.ValueMember = _campo1;

                // El segundo campo será lo que se muestra
                cboPrueba.DisplayMember = _campo2;

                // Crear lista para autocompletado
                AutoCompleteStringCollection coleccion =
                    new AutoCompleteStringCollection();

                foreach (DataRow row in dtTabla.Rows)
                {
                    string valor1 =
                        Convert.ToString(row[_campo1]);

                    string valor2 =
                        Convert.ToString(row[_campo2]);

                    coleccion.Add(
                        valor1 + " - " + valor2
                    );

                    coleccion.Add(
                        valor2 + " - " + valor1
                    );
                }

                cboPrueba.AutoCompleteCustomSource =
                    coleccion;

                cboPrueba.AutoCompleteMode =
                    AutoCompleteMode.SuggestAppend;

                cboPrueba.AutoCompleteSource =
                    AutoCompleteSource.CustomSource;

                if (dtTabla.Rows.Count > 0)
                {
                    cboPrueba.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar el ComboBox: " +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        public object SelectedValue
        {
            get
            {
                return cboPrueba.SelectedValue;
            }
        }

        public string TextValue
        {
            get
            {
                return cboPrueba.Text;
            }
        }

        public void Limpiar()
        {
            cboPrueba.DataSource = null;
            cboPrueba.Items.Clear();
            cboPrueba.Text = "";
        }
    }
}