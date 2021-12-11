using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRUEBA
{
    public partial class Elegir_Cliente_Visita : Form
    {
        OracleConnection ora = new OracleConnection("DATA SOURCE = ORCL; PASSWORD=123; USER ID= SEBA");
        public Elegir_Cliente_Visita()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dgvA.Rows.Count > 0)
            {
                Fecha fecha = new Fecha();
                fecha.id_prof.Text = txt_id.Text;
                fecha.id_empresa.Text = dgvA.CurrentRow.Cells["ID de Contrato"].Value.ToString();
                fecha.ShowDialog(this);
            }
            else
            {
                MessageBox.Show("Porfavor Seleccione a una empresa para Agendar Visita");
            }
        }
            

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dgvA.Rows.Count > 0)
            {
                Revisar_Visitas visita = new Revisar_Visitas();
                visita.textBox1.Text = dgvA.CurrentRow.Cells["ID de Contrato"].Value.ToString();
                visita.ShowDialog(this);
            }
            else
            {
                MessageBox.Show("Porfavor Seleccione a una empresa para Revisar Visitas");

            }
        }

        private void Elegir_Cliente_Visita_Load(object sender, EventArgs e)
        {
            ora.Open();
            OracleCommand mostrar = new OracleCommand("SP_VER_CLIENTES_CONTRATO", ora);
            mostrar.CommandType = System.Data.CommandType.StoredProcedure;

            mostrar.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;
            mostrar.Parameters.Add("id_prof", OracleType.VarChar).Value = txt_id.Text;

            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = mostrar;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dgvA.DataSource = tabla;
            ora.Close();
        }

        private void txt_buscar_emp_KeyUp(object sender, KeyEventArgs e)
        {
            ora.Open();
            OracleCommand mostrar = new OracleCommand("SP_VER_CLIENTES_CONTRATO_BUSCAR", ora);
            mostrar.CommandType = System.Data.CommandType.StoredProcedure;

            mostrar.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;
            mostrar.Parameters.Add("id_prof", OracleType.VarChar).Value = txt_id.Text;
            mostrar.Parameters.Add("nombre", OracleType.VarChar).Value = txt_buscar_emp.Text;


            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = mostrar;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dgvA.DataSource = tabla;
            ora.Close();
        }
    }
}
