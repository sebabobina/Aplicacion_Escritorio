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
    public partial class Revisar_CheckList : Form
    {
        OracleConnection ora = new OracleConnection("DATA SOURCE = ORCL; PASSWORD=123; USER ID= SEBA");
        public Revisar_CheckList()
        {
            InitializeComponent();
        }

        private void Revisar_CheckList_Load(object sender, EventArgs e)
        {
            ora.Open();
            OracleCommand mostrar = new OracleCommand("SP_VER_CLIENTES_CHECKLIST", ora);
            mostrar.CommandType = System.Data.CommandType.StoredProcedure;

            mostrar.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;
            mostrar.Parameters.Add("id_contratos", OracleType.VarChar).Value = lbl_id_contrato.Text;

            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = mostrar;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dgvA.DataSource = tabla;
            ora.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dgvA.Rows.Count > 0)
            {
                ora.Open();
                OracleCommand comando = new OracleCommand("SP_CHECKLIST_NO", ora);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("id_check", OracleType.VarChar).Value = dgvA.CurrentRow.Cells["ID_CHECKEO"].Value.ToString();
                comando.ExecuteNonQuery();
                ora.Close();

                actualizar_grid();
            }
            else
            {

                MessageBox.Show("No se puede cambiar estado si no hay obejtivos en la lista.");
            }
               
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvA.Rows.Count > 0) {
                ora.Open();
                OracleCommand comando = new OracleCommand("SP_CHECKLIST_SI", ora);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("id_check", OracleType.VarChar).Value = dgvA.CurrentRow.Cells["ID_CHECKEO"].Value.ToString();
                comando.ExecuteNonQuery();
                ora.Close();

                actualizar_grid();
            }
            else
            {
                MessageBox.Show("No se puede cambiar estado si no hay obejtivos en la lista.");
            }
            
        }

        private void actualizar_grid()
        {
            ora.Open();
            OracleCommand mostrar = new OracleCommand("SP_VER_CLIENTES_CHECKLIST", ora);
            mostrar.CommandType = System.Data.CommandType.StoredProcedure;

            mostrar.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;
            mostrar.Parameters.Add("id_contratos", OracleType.VarChar).Value = lbl_id_contrato.Text;

            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = mostrar;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dgvA.DataSource = tabla;
            ora.Close();



        }
    }
}
