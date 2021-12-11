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

namespace PRUEBA.Interfaces.Profesional.Asesorias
{
    public partial class Crear_Asesoriaa : Form
    {
        OracleConnection ora = new OracleConnection("DATA SOURCE = ORCL; PASSWORD=123; USER ID= SEBA");
        public Crear_Asesoriaa()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ora.Open();
                OracleCommand comando = new OracleCommand("SP_GENERAR_ASESORIA", ora);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("idprof", OracleType.VarChar).Value = lbl_id_prof.Text;
                comando.Parameters.Add("idcontr", OracleType.VarChar).Value = lbl_id_contrato.Text;
                comando.Parameters.Add("descripcion", OracleType.VarChar).Value = txt_asesoria.Text;
                comando.Parameters.Add("propuesta", OracleType.VarChar).Value = txt_propuesta_mejora.Text;


                comando.ExecuteNonQuery();
                ora.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Porfavor rellene los campos");
                ora.Close();
            }
        }
    }
}
