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

namespace PRUEBA.Interfaces.Profesional.Cliente
{
    public partial class PROF_ACCIDENTES : Form
    {
        OracleConnection ora = new OracleConnection("DATA SOURCE = ORCL; PASSWORD=123; USER ID= SEBA");
        public PROF_ACCIDENTES()
        {
            InitializeComponent();
        }

        private void PROF_ACCIDENTES_Load(object sender, EventArgs e)
        {
            ora.Open();
            OracleCommand mostrar = new OracleCommand("SP_VER_CLIENTES_CONTRATO", ora);
            mostrar.CommandType = System.Data.CommandType.StoredProcedure;
            mostrar.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;
            mostrar.Parameters.Add("id_prof", OracleType.VarChar).Value = lbl_id_prof.Text;

            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = mostrar;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dgvA.DataSource = tabla;
            ora.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvA.Rows.Count > 0)
            {
                Revisar_Accidentes_PROF vac = new Revisar_Accidentes_PROF();

                vac.lbl_idcontr.Text = dgvA.CurrentRow.Cells["ID de Contrato"].Value.ToString();
                vac.label3.Text = dgvA.CurrentRow.Cells["Nombre Empresa"].Value.ToString();
                vac.ShowDialog(this);
            }
            else
            {
                MessageBox.Show("Porfavor Seleccione una empresa para continuar");
            }
        }
    }
}
