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
    public partial class Revisar_Capacitaciones : Form
    {
        OracleConnection ora = new OracleConnection("DATA SOURCE = ORCL; PASSWORD=123; USER ID= SEBA");
        public Revisar_Capacitaciones()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvA.Rows.Count > 0)
            {
                ora.Open();
                OracleCommand comando = new OracleCommand("SP_ELIMINAR_CAPACITACION", ora);
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                comando.Parameters.Add("id_cap", OracleType.VarChar).Value = dgvA.CurrentRow.Cells["ID CAPACITACION"].Value.ToString(); ;

                comando.ExecuteNonQuery();
                ora.Close();

                MessageBox.Show("Capacitacion borrada exitosamente");

                Actualizar_tabla();

            }
            else
            {
                ora.Close();
                MessageBox.Show("Porfavor Seleccione una capacitacion para borrar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                



            
        }

        private void Revisar_Capacitaciones_Load(object sender, EventArgs e)
        {
            ora.Open();
            OracleCommand mostrar = new OracleCommand("SP_MOSTRAR_CAPACITACION", ora);
            mostrar.CommandType = System.Data.CommandType.StoredProcedure;

            mostrar.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;
            mostrar.Parameters.Add("idcontr", OracleType.VarChar).Value = lbl_idContrato.Text;

            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = mostrar;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dgvA.DataSource = tabla;
            ora.Close();
        }

        private void Actualizar_tabla()
        {
            ora.Open();
            OracleCommand mostrar = new OracleCommand("SP_MOSTRAR_CAPACITACION", ora);
            mostrar.CommandType = System.Data.CommandType.StoredProcedure;

            mostrar.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;
            mostrar.Parameters.Add("idcontr", OracleType.VarChar).Value = lbl_idContrato.Text;

            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = mostrar;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dgvA.DataSource = tabla;
            ora.Close();

        }
    }
}
