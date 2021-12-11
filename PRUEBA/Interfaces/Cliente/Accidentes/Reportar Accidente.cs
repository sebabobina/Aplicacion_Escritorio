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

namespace PRUEBA.Interfaces.Cliente.Accidentes
{
    public partial class Reportar_Accidente : Form
    {
        OracleConnection ora = new OracleConnection("DATA SOURCE = ORCL; PASSWORD=123; USER ID= SEBA");
        public Reportar_Accidente()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ora.Open();
                OracleCommand comando = new OracleCommand("SP_GENERAR_CASO_ACCIDENTABILIDAD", ora);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("descrp", OracleType.VarChar).Value = txt_accidente.Text;
                comando.Parameters.Add("idcon", OracleType.VarChar).Value = lbl_id_Contrato.Text;
                comando.Parameters.Add("idprof", OracleType.VarChar).Value = lbl_ID_PROF.Text;
                comando.ExecuteNonQuery();



                OracleCommand comando1 = new OracleCommand("SP_AGREGAR_ACTIVIDAD_CLIENTE", ora);
                comando1.CommandType = System.Data.CommandType.StoredProcedure;
                comando1.Parameters.Add("idcontr", OracleType.VarChar).Value = lbl_id_Contrato.Text;
                comando1.Parameters.Add("actividad", OracleType.VarChar).Value = "Reporto un Accidente";
                comando1.ExecuteNonQuery();



                ora.Close();

                MessageBox.Show("Accidente reportado con exito");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Porfavor rellene los datos");
            }
        }


        

    }
}
