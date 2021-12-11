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

namespace PRUEBA.Interfaces.Admin.Cliente
{
    public partial class Elegir_Empresa_Accidentes : Form
    {
        OracleConnection ora = new OracleConnection("DATA SOURCE = ORCL; PASSWORD=123; USER ID= SEBA");
        public Elegir_Empresa_Accidentes()
        {
            InitializeComponent();
        }

        private void Elegir_Empresa_Accidentes_Load(object sender, EventArgs e)
        {
            ora.Open();
            OracleCommand mostrar = new OracleCommand("SP_MOSTRAR_CLIENTES_REGISTRADOS", ora);
            mostrar.CommandType = System.Data.CommandType.StoredProcedure;
            mostrar.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;

            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = mostrar;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dgvA.DataSource = tabla;
            ora.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvA.Rows.Count >0)
            {
                Ver_Accidentes_Clientes vac = new Ver_Accidentes_Clientes();

                vac.lbl_idcontr.Text = dgvA.CurrentRow.Cells["ID Contrato"].Value.ToString();
                vac.label3.Text = dgvA.CurrentRow.Cells["Nombre Empresa"].Value.ToString();
                vac.ShowDialog(this);
            }
            else
            {
                MessageBox.Show("Porfavor Seleccione una empresa para continuar");
            }
            
        }

        private void txt_buscar_emp_KeyUp(object sender, KeyEventArgs e)
        {
            ora.Open();

            OracleCommand mostrar = new OracleCommand("SP_BUSCAR_EMPRESA_REGISTRADA", ora);
            mostrar.CommandType = System.Data.CommandType.StoredProcedure;
            mostrar.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;
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
