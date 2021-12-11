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
    public partial class Pagos_Clientes : Form
    {
        OracleConnection ora = new OracleConnection("DATA SOURCE = ORCL; PASSWORD=123; USER ID= SEBA");

        public Pagos_Clientes()
        {
            InitializeComponent();
        }

        private void Pagos_Clientes_Load(object sender, EventArgs e)
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

        private void btn_Pagos_Click(object sender, EventArgs e)
        {

            if (dgvA.Rows.Count > 0)
            {

                Ver_Pagos vp = new Ver_Pagos();

                vp.lbl_idcontr.Text = dgvA.CurrentRow.Cells["ID Contrato"].Value.ToString();
                vp.lbl_correo.Text = dgvA.CurrentRow.Cells["Email"].Value.ToString();
                vp.label2.Text = dgvA.CurrentRow.Cells["Nombre Empresa"].Value.ToString();
                vp.ShowDialog(this);
            }
            else
            {

                MessageBox.Show("Porfavor Seleccione a una empresa para revisar Pagos");
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
