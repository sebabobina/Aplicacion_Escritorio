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
    public partial class Agregar_a_Checklist : Form
    {
        OracleConnection ora = new OracleConnection("DATA SOURCE = ORCL; PASSWORD=123; USER ID= SEBA");
        public Agregar_a_Checklist()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ora.Open();
                OracleCommand comando = new OracleCommand("SP_GENERAR_CHECKLIST", ora);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("descrip", OracleType.VarChar).Value = txt_descripcion.Text;
                comando.Parameters.Add("id_contr", OracleType.VarChar).Value = lbl_IdContrato.Text;
                comando.Parameters.Add("id_prof", OracleType.VarChar).Value = lbl_id_prof.Text;



                comando.ExecuteNonQuery();
                ora.Close();

                Actualizar_Grid();
            }
            catch (Exception ex )
            {
                MessageBox.Show("Porfavor rellene todos los datos para continuar");
                ora.Close();
            }

        }

        private void Agregar_a_Checklist_Load(object sender, EventArgs e)
        {
            ora.Open();
            OracleCommand mostrar = new OracleCommand("SP_VER_CLIENTES_CHECKLIST", ora);
            mostrar.CommandType = System.Data.CommandType.StoredProcedure;

            mostrar.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;
            mostrar.Parameters.Add("id_contratos", OracleType.VarChar).Value = lbl_IdContrato.Text;

            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = mostrar;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dgvA.DataSource = tabla;
            ora.Close();
        }


        private void Actualizar_Grid()
        {

            ora.Open();
            OracleCommand mostrar = new OracleCommand("SP_VER_CLIENTES_CHECKLIST", ora);
            mostrar.CommandType = System.Data.CommandType.StoredProcedure;

            mostrar.Parameters.Add("id_contratos", OracleType.VarChar).Value = lbl_IdContrato.Text;
            mostrar.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;
            

            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = mostrar;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dgvA.DataSource = tabla;
            ora.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
           
                if(dgvA.Rows.Count > 0) {
                    ora.Open();
                    OracleCommand comando = new OracleCommand("SP_ELIMINAR_CHECKLIST", ora);
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.Add("idch", OracleType.VarChar).Value = dgvA.CurrentRow.Cells["ID_CHECKEO"].Value.ToString();
                    comando.ExecuteNonQuery();
                    ora.Close();

                    Actualizar_Grid();
                }
                else
                {
                    MessageBox.Show("Porfavor seleccione para poder eliminar");
                    ora.Close();
                }
                
                

            
        }
    }
}
