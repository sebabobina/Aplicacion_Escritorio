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

namespace PRUEBA.Interfaces.Profesional.Capacitaciones
{
    public partial class Lista_Revisar_Cliente : Form
    {
        OracleConnection ora = new OracleConnection("DATA SOURCE = ORCL; PASSWORD=123; USER ID= SEBA");
        public Lista_Revisar_Cliente()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvA.Rows.Count > 0)
            {
                Revisar_Capacitaciones rcp = new Revisar_Capacitaciones();

                rcp.lbl_idContrato.Text = dgvA.CurrentRow.Cells["ID de Contrato"].Value.ToString();
                rcp.ShowDialog(this);
            }
            else
            {
                MessageBox.Show("Porfavor Seleccione a una empresa para Revisar Capacitaciones");
            }
        }
            

        private void Lista_Revisar_Cliente_Load(object sender, EventArgs e)
        {
            ora.Open();
            OracleCommand mostrar = new OracleCommand("SP_VER_CLIENTES_CONTRATO", ora);
            mostrar.CommandType = System.Data.CommandType.StoredProcedure;

            mostrar.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;
            mostrar.Parameters.Add("id_prof", OracleType.VarChar).Value = label1.Text;

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
            mostrar.Parameters.Add("id_prof", OracleType.VarChar).Value = label1.Text;
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
