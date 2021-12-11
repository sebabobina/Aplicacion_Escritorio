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

namespace PRUEBA.Interfaces.Admin.Cliente
{
    public partial class Ver_Actividad : Form
    {
        OracleConnection ora = new OracleConnection("DATA SOURCE = ORCL; PASSWORD=123; USER ID= SEBA");
        public Ver_Actividad()
        {
            InitializeComponent();
        }

        private void Ver_Actividad_Load(object sender, EventArgs e)
        {

            ora.Open();
            OracleCommand mostrar = new OracleCommand("SP_VER_ACTIVIDAD_CLIENTE", ora);
            mostrar.CommandType = System.Data.CommandType.StoredProcedure;

            mostrar.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;
            mostrar.Parameters.Add("id_contr", OracleType.VarChar).Value = lbl_idcontr.Text;

            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = mostrar;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dgvA.DataSource = tabla;
            ora.Close();
            
        }
    }
}
