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
    public partial class Form2 : Form
    {
        OracleConnection ora = new OracleConnection("DATA SOURCE = ORCL; PASSWORD=123; USER ID= SEBA");
        public Form2()
        {
            InitializeComponent();


            ora.Open();
            OracleCommand mostrar = new OracleCommand("SP_MOSTRAR_CLIENTES_REGISTRADOS", ora);
            mostrar.CommandType = System.Data.CommandType.StoredProcedure;
            mostrar.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;

            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = mostrar;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dgvA.DataSource = tabla;
            ora.Close();
        }

        private void dgvA_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void btn_modificar_Click(object sender, EventArgs e)
        {
            if (dgvA.Rows.Count > 0)
            {

                Modificar_Cliente modificar = new Modificar_Cliente();
                modificar.txt_id.Text = dgvA.CurrentRow.Cells["ID de Empresa"].Value.ToString();
                modificar.txt_rut.Text = dgvA.CurrentRow.Cells["RUT Empresa"].Value.ToString();
                modificar.txt_nombre.Text = dgvA.CurrentRow.Cells["Nombre Empresa"].Value.ToString();
                modificar.txt_email.Text = dgvA.CurrentRow.Cells["Email"].Value.ToString();
                modificar.txt_direccion.Text = dgvA.CurrentRow.Cells["Direccion"].Value.ToString();
                modificar.txt_nomd.Text = dgvA.CurrentRow.Cells["Nombre Dueño"].Value.ToString();
                modificar.txt_telefono.Text = dgvA.CurrentRow.Cells["Telefono"].Value.ToString();
                modificar.cb_comunas.Text = dgvA.CurrentRow.Cells["Comuna"].Value.ToString();
                modificar.cb_rubros.Text = dgvA.CurrentRow.Cells["Rubro"].Value.ToString();



                modificar.txt_id_usuario.Text = dgvA.CurrentRow.Cells["ID de Usuario"].Value.ToString();
                modificar.txt_username.Text = dgvA.CurrentRow.Cells["Nombre Usuario"].Value.ToString();
                modificar.txt_pass.Text = dgvA.CurrentRow.Cells["Contraseña"].Value.ToString();

                modificar.ShowDialog(this);
            }
            else
            { MessageBox.Show("Porfavor Seleccione a una empresa para modificar"); }
            
            

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ora.Open();
            OracleCommand comando = new OracleCommand("SP_ELIMINAR_EMPRESA", ora);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("id_emp", OracleType.VarChar).Value = dgvA.CurrentRow.Cells["ID de Empresa"].Value.ToString();
            comando.Parameters.Add("id_contr", OracleType.VarChar).Value = dgvA.CurrentRow.Cells["ID Contrato"].Value.ToString();



            comando.ExecuteNonQuery();
            ora.Close();

            actualizar_tabla();
        }

        private void actualizar_tabla()
        {
            ora.Open();
            OracleCommand mostrar = new OracleCommand("SP_MOSTRAR_CLIENTES_REGISTRADOS", ora);
            mostrar.CommandType = System.Data.CommandType.StoredProcedure;
            mostrar.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;

            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = mostrar;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dgvA.DataSource = tabla;
            ora.Close();


        }

        private void txt_buscar_emp_KeyUp(object sender, KeyEventArgs e)
        {
            ora.Open();

            OracleCommand mostrar = new OracleCommand("SP_BUSCAR_EMPRESA_REGISTRADA", ora);
            mostrar.CommandType = System.Data.CommandType.StoredProcedure;
            mostrar.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;
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
