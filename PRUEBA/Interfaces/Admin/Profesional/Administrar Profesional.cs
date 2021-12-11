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

namespace PRUEBA.Interfaces.Admin.Profesional
{
    public partial class Administrar_Profesional : Form
    {
        OracleConnection ora = new OracleConnection("DATA SOURCE = ORCL; PASSWORD=123; USER ID= SEBA");
        public Administrar_Profesional()
        {
            InitializeComponent();
        }

        private void Administrar_Profesional_Load(object sender, EventArgs e)
        {

            ora.Open();
            OracleCommand mostrar = new OracleCommand("SP_MOSTRAR_PROFESIONAL", ora);
            mostrar.CommandType = System.Data.CommandType.StoredProcedure;
            mostrar.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;

            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = mostrar;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dgvA.DataSource = tabla;
            ora.Close();

        }

        private void btn_modificar_Click(object sender, EventArgs e)
        {
            Modifcar_Profesional mp = new Modifcar_Profesional();

            mp.lbl_Id_Prof.Text = dgvA.CurrentRow.Cells["ID PROFESIONAL"].Value.ToString();
            mp.id_usr.Text = dgvA.CurrentRow.Cells["ID USUARIO"].Value.ToString();
            mp.txt_RUT.Text = dgvA.CurrentRow.Cells["RUT"].Value.ToString();
            mp.txt_Nombre.Text = dgvA.CurrentRow.Cells["NOMBRE"].Value.ToString();
            mp.cb_sexo.Text = dgvA.CurrentRow.Cells["GENERO"].Value.ToString();
            mp.cb_profesion.Text = dgvA.CurrentRow.Cells["PROFESION"].Value.ToString();
            mp.txt_Email.Text = dgvA.CurrentRow.Cells["EMAIL"].Value.ToString();
            mp.txt_Direccion.Text = dgvA.CurrentRow.Cells["DIRECCION"].Value.ToString();
            mp.cb_comuna.Text = dgvA.CurrentRow.Cells["COMUNA"].Value.ToString();
            mp.txt_Telefono.Text = dgvA.CurrentRow.Cells["TELEFONO"].Value.ToString();
            mp.txt_user.Text = dgvA.CurrentRow.Cells["NOMBRE USUARIO"].Value.ToString();
            mp.txt_pass.Text = dgvA.CurrentRow.Cells["CONTRASENA"].Value.ToString();

            mp.ShowDialog(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ora.Open();
            OracleCommand comando = new OracleCommand("SP_ELIMINAR_PROF", ora);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("id_prof", OracleType.VarChar).Value = dgvA.CurrentRow.Cells["ID PROFESIONAL"].Value.ToString();




            comando.ExecuteNonQuery();
            ora.Close();

            actualizar_tabla();

        }

        private void actualizar_tabla()
        {
            ora.Open();
            OracleCommand mostrar = new OracleCommand("SP_MOSTRAR_PROFESIONAL", ora);
            mostrar.CommandType = System.Data.CommandType.StoredProcedure;
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
            Empresas_a_cargo eac = new Empresas_a_cargo();

            eac.lbl_id_prof.Text = dgvA.CurrentRow.Cells["ID PROFESIONAL"].Value.ToString();
            eac.ShowDialog(this);
        }

        private void txt_buscarprof_KeyUp(object sender, KeyEventArgs e)
        {
            ora.Open();

            OracleCommand mostrar = new OracleCommand("SP_MOSTRAR_PROFESIONAL_BUSCAR", ora);
            mostrar.CommandType = System.Data.CommandType.StoredProcedure;
            mostrar.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;
            mostrar.Parameters.Add("nombre", OracleType.VarChar).Value = txt_buscarprof.Text;

            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = mostrar;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dgvA.DataSource = tabla;



            ora.Close();
        }
    }
}
