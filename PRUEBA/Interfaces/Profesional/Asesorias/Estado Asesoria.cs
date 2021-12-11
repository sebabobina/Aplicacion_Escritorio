using PRUEBA.Interfaces.Profesional.Asesorias;
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

namespace PRUEBA.Interfaces.Profesional
{
    public partial class Estado_Asesoria : Form
    {
        OracleConnection ora = new OracleConnection("DATA SOURCE = ORCL; PASSWORD=123; USER ID= SEBA");

        public Estado_Asesoria()
        {
            InitializeComponent();
        }

        private void Estado_Asesoria_Load(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvA.Rows.Count>0)
            {
                Agregar_Estado_Mejora aem = new Agregar_Estado_Mejora();

                aem.lbl_id_propuesta.Text = dgvA.CurrentRow.Cells["ID Propuesta"].Value.ToString();
                aem.lbl_nombre_asesoria.Text = dgvA.CurrentRow.Cells["Descripcion"].Value.ToString();
                aem.lbl_Propuesta_Mejora.Text = dgvA.CurrentRow.Cells["Propuesta de Mejora"].Value.ToString();
                aem.ShowDialog(this);
            }
            else
            {
                MessageBox.Show("Seleccione un Asesoria para continuar");
            }
        }
    }
}
