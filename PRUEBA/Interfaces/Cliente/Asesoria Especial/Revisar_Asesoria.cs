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

namespace PRUEBA.Interfaces.Cliente.Asesoria_Especial
{
    public partial class Revisar_Asesoria : Form
    {
        OracleConnection ora = new OracleConnection("DATA SOURCE = ORCL; PASSWORD=123; USER ID= SEBA");
        public Revisar_Asesoria()
        {
            InitializeComponent();
        }

        private void Revisar_Asesoria_Load(object sender, EventArgs e)
        {
            ora.Open();
            OracleCommand mostrar = new OracleCommand("SP_MOSTRAR_ASESORIAS", ora);
            mostrar.CommandType = System.Data.CommandType.StoredProcedure;

            mostrar.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;
            mostrar.Parameters.Add("idcontr", OracleType.VarChar).Value = lbl_contrato.Text;

            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = mostrar;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dgvA.DataSource = tabla;
            ora.Close();
        }
    }
}
