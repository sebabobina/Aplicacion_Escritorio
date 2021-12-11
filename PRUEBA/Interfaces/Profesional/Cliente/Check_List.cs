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
    
    public partial class Check_List : Form
    {
        OracleConnection ora = new OracleConnection("DATA SOURCE = ORCL; PASSWORD=123; USER ID= SEBA");
        public Check_List()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvA.Rows.Count > 0)
            {
                Agregar_a_Checklist ach = new Agregar_a_Checklist();
                ach.lbl_IdContrato.Text = dgvA.CurrentRow.Cells["ID de Contrato"].Value.ToString();
                ach.lbl_id_prof.Text = label1.Text;

                ach.ShowDialog(this);
            }
            else
            {
                MessageBox.Show("Porfavor Seleccione a una empresa Agregar una nueva CheckList");
            }

            
        }

       

        private void Check_List_Load(object sender, EventArgs e)
        {
            ora.Open();
            OracleCommand mostrar = new OracleCommand("SP_VER_CLIENTES_CONTRATO", ora);
            mostrar.CommandType = System.Data.CommandType.StoredProcedure;

            mostrar.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;
            mostrar.Parameters.Add("id_prof", OracleType.VarChar).Value = label1.Text;

            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = mostrar;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dgvA.DataSource = tabla;
            ora.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Revisar_CheckList rev = new Revisar_CheckList();
            rev.lbl_id_contrato.Text = dgvA.CurrentRow.Cells["ID de Contrato"].Value.ToString();
            rev.ShowDialog(this);
        }

        private void txt_buscar_emp_KeyUp(object sender, KeyEventArgs e)
        {
            ora.Open();
            OracleCommand mostrar = new OracleCommand("SP_VER_CLIENTES_CONTRATO_BUSCAR", ora);
            mostrar.CommandType = System.Data.CommandType.StoredProcedure;

            mostrar.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;
            mostrar.Parameters.Add("id_prof", OracleType.VarChar).Value = label1.Text;
            mostrar.Parameters.Add("nombre", OracleType.VarChar).Value = txt_buscar_emp.Text;


            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = mostrar;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dgvA.DataSource = tabla;
            ora.Close();
        }
    }
}
