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
    public partial class Revisar_Visitas : Form
    {
        OracleConnection ora = new OracleConnection("DATA SOURCE = ORCL; PASSWORD=123; USER ID= SEBA");
        public Revisar_Visitas()
        {
            InitializeComponent();
        }

        private void Revisar_Visitas_Load(object sender, EventArgs e)
        {
            ora.Open();
            OracleCommand mostrar = new OracleCommand("SP_MOSTRAR_FECHAS", ora);
            mostrar.CommandType = System.Data.CommandType.StoredProcedure;

            mostrar.Parameters.Add("ids", OracleType.VarChar).Value = textBox1.Text;
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
           
        }
    }
}
