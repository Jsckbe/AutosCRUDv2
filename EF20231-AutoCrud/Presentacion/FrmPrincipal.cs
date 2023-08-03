using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Datos;
using Negocios;
using LiveCharts;
using LiveCharts.Wpf;



namespace Presentacion
{
    public partial class FrmPrincipal : Form
    {
        NegAuto objNegAuto = new NegAuto();
        private bool sortAscending = false;
        public FrmPrincipal()
        {
            InitializeComponent();
        }


        void ActualizarDatagridView()
        {
            dgAutos.DataSource = objNegAuto.ListarAuto();
            //dgAutos.Columns["placa"].Visible= false;  //Para no mostrar la columna placa
            btnModificar.Enabled=false;
            btnEliminar.Enabled=false;
            txtPlaca.Text = "";
            txtPlaca.Focus();
        }

        void ActualizarBoton()
        {
            dgAutos.DataSource = objNegAuto.ListarAuto();
            //dgAutos.Columns["placa"].Visible = false;
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
            txtPlaca.Text = "";
            //txtPlaca.Focus();
            cboMarca.Text = "";
            txtModelo.Text = "";
            txtColor.Text = "";
            cboAnio.Text = "";
            cboCombustible.Text = "";
            txtPlaca.Focus();
        }


        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            ActualizarDatagridView();
        }

        private void dgAutos_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            IEnumerable<Auto> listado = objNegAuto.ListarAuto();
            String NombreColSelec = dgAutos.Columns[e.ColumnIndex].Name;
            if (sortAscending)
                dgAutos.DataSource = listado.OrderBy(_ => _.GetType().GetProperty(NombreColSelec).GetValue(_)).ToList();
            else
                dgAutos.DataSource = listado.OrderByDescending(_ => _.GetType().GetProperty(NombreColSelec).GetValue(_)).ToList();
            sortAscending = !sortAscending;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (txtPlaca.Text != "" &  cboMarca.Text != "" & txtModelo.Text != "" & txtColor.Text != "" & cboAnio.Text != "" & cboCombustible.Text != "")
            {
                Auto objAuto = new Auto();
                objAuto.placa = txtPlaca.Text;
                objAuto.marca = cboMarca.Text;
                objAuto.modelo = txtModelo.Text;
                objAuto.color = txtColor.Text;
                objAuto.año = Convert.ToInt32(cboAnio.Text);
                objAuto.combustible = cboCombustible.Text;

                MessageBox.Show(objNegAuto.RegistrarAuto(objAuto));
                ActualizarDatagridView();
            }
            else
            {
                MessageBox.Show("Debe ingresar todos los datos del Auto");
            }
        }

        private void dgAutos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (dgAutos.SelectedCells.Count > 0)
            if(e.RowIndex > -1)
            {   //DataGridViewRow filaSeleccionada = dgPaises.SelectedRows[0];
                DataGridViewRow filaSeleccionada = dgAutos.Rows[e.RowIndex];
                txtPlaca.Text= filaSeleccionada.Cells["placa"].Value.ToString();
                btnModificar.Enabled= true;
                btnEliminar.Enabled= true;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (txtPlaca.Text != "" & cboMarca.Text != "" & txtModelo.Text != "" & txtColor.Text != "" & cboAnio.Text != "" & cboCombustible.Text != "")
            {

                string placa = Convert.ToString(dgAutos.SelectedRows[0].Cells[0].Value);
            Auto objAuto = new Auto();
            //objAuto.placa - string;
            objAuto.placa = placa;
            objAuto.marca = cboMarca.Text;
            
            objAuto.modelo = txtModelo.Text;
            objAuto.color = txtColor.Text;
            objAuto.año = Convert.ToInt32(cboAnio.Text);
            objAuto.combustible = cboCombustible.Text;

            MessageBox.Show(objNegAuto.ModificarAuto(objAuto));
            ActualizarDatagridView();
            }
            else
            {
                MessageBox.Show("Debe ingresar todos los datos");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string placa = Convert.ToString(dgAutos.SelectedRows[0].Cells[0].Value);
            MessageBox.Show(objNegAuto.EliminarAuto(placa));
            ActualizarDatagridView();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            //ActualizarDatagridView();
            ActualizarBoton();
        }

        /*private void btnPromedio_Click(object sender, EventArgs e)
        {
            if (cboMarca.Text != "" && cboAnio.Text != "")
            {
                List<Auto> listaAutos = objNegAuto.ListarAuto(cboMarca.Text, Convert.ToInt32(cboAnio.Text));
                dgAutos.DataSource = listaAutos;
                //Limpiar();
            }
            else
            {
                MessageBox.Show("Debe ingresar el Marca y Año para la busqueda");
            }
        }
        */
       

        private void btnPromedio_Click(object sender, EventArgs e)
        {

        if (cboMarca.Text != "" & cboAnio.Text != "")
            {
            string marcaSeleccionada = cboMarca.SelectedItem.ToString();
            int anioSeleccionado = int.Parse(cboAnio.SelectedItem.ToString());

            using (var db = new dbtallerEntities())
            {
                var autos = db.Autos
                    .Where(a => a.marca == marcaSeleccionada && a.año == anioSeleccionado)
                    .ToList();

                // Mostrar los resultados en un DataGridView o en cualquier otro control de tu elección
                dgAutos.DataSource = autos;
            }
        } 
        else
            {
                MessageBox.Show("Debe ingresar la marca y el año del Auto");
            }
        }

        private void btnBuscarColor_Click(object sender, EventArgs e)
        {
            string colorBuscado = txtBoxColor.Text;

            using (var db = new dbtallerEntities())
            {
                // Realiza una búsqueda insensible al caso (sensitiva) del color utilizando el método String.Equals
                var autos = db.Autos
                    .Where(a => a.color.Equals(colorBuscado, StringComparison.OrdinalIgnoreCase))
                    .ToList();

                // Mostrar los resultados en un DataGridView o en cualquier otro control de tu elección
                dgAutos.DataSource = autos;
            }
        }

        private void btnMostrarPorCombustible_Click(object sender, EventArgs e)
        {
            using (var db = new dbtallerEntities())
            {
                var autosPorCombustible = db.Autos
                    .GroupBy(a => a.combustible)
                    .Select(g => new
                    {
                        Combustible = g.Key,
                        Cantidad = g.Count()
                    })
                    .ToList();

                // Muestra los resultados en un DataGridView o en cualquier otro control de tu elección
                dgAutos.DataSource = autosPorCombustible;
            }
        }

        private void btnMostrarGrafico_Click(object sender, EventArgs e)
        {
            //Tipo barras
            using (var db = new dbtallerEntities())
            {
                var autosPorMarca = db.Autos
                    .GroupBy(a => a.marca)
                    .Select(g => new
                    {
                        Marca = g.Key,
                        Cantidad = g.Count()
                    })
                    .ToList();

                // Crea una nueva serie de columnas para el gráfico de barras
                var columnSeries = new System.Windows.Forms.DataVisualization.Charting.Series("Autos por Marca")
                {
                    ChartType = SeriesChartType.Column
                };

                // Agregar los puntos de datos al gráfico de barras
                foreach (var auto in autosPorMarca)
                {
                    columnSeries.Points.AddXY(auto.Marca, auto.Cantidad);
                }

                // Limpiar las series existentes en el gráfico para evitar duplicados
                chart2.Series.Clear();

                // Agregar la serie al gráfico
                chart2.Series.Add(columnSeries);

                // Personalizar el gráfico si es necesario
                chart2.Titles.Add("Gráfico de Barras - Número de Autos por Marca");
                chart2.ChartAreas[0].AxisX.Title = "Marcas";
                chart2.ChartAreas[0].AxisY.Title = "Cantidad de Autos";
            }



            //Tipo circular pie
            using (var db = new dbtallerEntities())
            {
                var autosPorMarca = db.Autos
                    .GroupBy(a => a.marca)
                    .Select(g => new
                    {
                        Marca = g.Key,
                        Cantidad = g.Count()
                    })
                    .ToList();

                // Crea una serie de tipo Pie para el gráfico
                var pieSeries = new System.Windows.Forms.DataVisualization.Charting.Series("Autos por Marca")
                {
                    ChartType = SeriesChartType.Pie
                };

                // Agregar los puntos de datos al gráfico de pastel
                foreach (var auto in autosPorMarca)
                {
                    pieSeries.Points.AddXY(auto.Marca, auto.Cantidad);
                }

                // Agregar la serie al gráfico
                chart1.Series.Clear();
                chart1.Series.Add(pieSeries);

                // Personalizar el gráfico si es necesario
                chart1.Titles.Add("Gráfico de Pastel - Número de Autos por Marca");
            }
        }
    }


}
