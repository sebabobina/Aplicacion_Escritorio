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
    public partial class Agregar_Estado_Mejora : Form
    {
        OracleConnection ora = new OracleConnection("DATA SOURCE = ORCL; PASSWORD=123; USER ID= SEBA");
        public Agregar_Estado_Mejora()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ora.Open();
            OracleCommand comando = new OracleCommand("SP_ESTADO_MEJORA", ora);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("idprop", OracleType.VarChar).Value = lbl_id_propuesta.Text;
            comando.Parameters.Add("mejora", OracleType.VarChar).Value = txt_estado.Text;
            

            comando.ExecuteNonQuery();
            ora.Close();
        }
    }
}
