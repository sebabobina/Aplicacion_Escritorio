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
    public partial class Mostrar_Accidentes : Form
    {
        OracleConnection ora = new OracleConnection("DATA SOURCE = ORCL; PASSWORD=123; USER ID= SEBA");
        public Mostrar_Accidentes()
        {
            InitializeComponent();
        }

        private void dgvA_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Mostrar_Accidentes_Load(object sender, EventArgs e)
        {
            OracleCommand mostrar = new OracleCommand("SP_MOSTRAR_ACCIDENTES_POR_EMPRESA", ora);
            mostrar.CommandType = System.Data.CommandType.StoredProcedure;

            mostrar.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;
            mostrar.Parameters.Add("idc", OracleType.VarChar).Value = lbl_id_contrato.Text;

            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = mostrar;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dgvA.DataSource = tabla;
            ora.Close();
        }
    }
}
