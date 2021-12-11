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
    public partial class Modificar_Cliente : Form
    {
        OracleConnection ora = new OracleConnection("DATA SOURCE = ORCL; PASSWORD=123; USER ID= SEBA");
        public Modificar_Cliente()
        {
            InitializeComponent();

            txt_rut.ReadOnly = true;
            chb_rut.Checked = false;

            txt_nombre.ReadOnly = true;
            chb_nombre.Checked = false;

            cb_rubros.Enabled = false;
            chb_rubro.Checked = false;

            txt_email.ReadOnly = true;
            chb_email.Checked = false;

            txt_direccion.ReadOnly = true;
            chb_direccion.Checked = false;

            cb_comunas.Enabled = false;
            chb_comuna.Checked = false;

            txt_telefono.ReadOnly = true;
            chb_telefono.Checked = false;

            txt_nomd.ReadOnly = true;
            chb_dueño.Checked = false;

            txt_username.ReadOnly = true;
            chb_username.Checked = false;

            txt_pass.ReadOnly = true;
            chb_pass.Checked = false;




            ora.Open();
            OracleCommand mostrar = new OracleCommand("SP_MOSTRAR_RUBROS", ora);
            mostrar.CommandType = System.Data.CommandType.StoredProcedure;
            mostrar.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;

            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = mostrar;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);



            cb_rubros.DataSource = tabla;

            cb_rubros.DisplayMember = "nombre_rubro";

            cb_rubros.ValueMember = "id_rubro";





            OracleCommand mostrar1 = new OracleCommand("SP_MOSTRAR_COMUNA", ora);
            mostrar1.CommandType = System.Data.CommandType.StoredProcedure;
            mostrar1.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;

            OracleDataAdapter adaptador1 = new OracleDataAdapter();
            adaptador1.SelectCommand = mostrar1;
            DataTable tabla2 = new DataTable();
            adaptador1.Fill(tabla2);



            cb_comunas.DataSource = tabla2;

            cb_comunas.DisplayMember = "nombre_comuna";

            cb_comunas.ValueMember = "id_comuna";

            ora.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ora.Open();
                OracleCommand comando = new OracleCommand("SP_MODIFICAR_CLIENTE2", ora);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("ID_emp", OracleType.VarChar).Value = txt_id.Text;
                comando.Parameters.Add("rutem", OracleType.VarChar).Value = txt_rut.Text;
                comando.Parameters.Add("nom", OracleType.VarChar).Value = txt_nombre.Text;
                comando.Parameters.Add("email", OracleType.VarChar).Value = txt_email.Text;
                comando.Parameters.Add("direccion", OracleType.VarChar).Value = txt_direccion.Text;
                comando.Parameters.Add("nomd", OracleType.VarChar).Value = txt_nomd.Text;
                comando.Parameters.Add("telf", OracleType.VarChar).Value = txt_telefono.Text;
                comando.Parameters.Add("idc", OracleType.VarChar).Value = cb_comunas.SelectedValue;
                comando.Parameters.Add("idr", OracleType.VarChar).Value = cb_rubros.SelectedValue;


                comando.ExecuteNonQuery();
                ora.Close();

                MessageBox.Show("Los datos han sido modificados con exito");

            }
            catch(Exception ex)
            {
                ora.Close();
                MessageBox.Show("No puedes dejar algun campo vacio","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
               
            

        }

        private void cb_rubros_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void chb_rut_CheckedChanged(object sender, EventArgs e)
        {
            if(chb_rut.Checked == true)
            {

                txt_rut.ReadOnly = false;

            }
            else
            {
                txt_rut.ReadOnly = true;
            }
        }

        private void chb_nombre_CheckedChanged(object sender, EventArgs e)
        {
            if (chb_nombre.Checked == true)
            {

                txt_nombre.ReadOnly = false;

            }
            else
            {
                txt_nombre.ReadOnly = true;
            }
        }

        private void chb_rubro_CheckedChanged(object sender, EventArgs e)
        {
            if (chb_rubro.Checked == true)
            {

                cb_rubros.Enabled = true;

            }
            else
            {
                cb_rubros.Enabled = false;
            }
        }

        private void chb_email_CheckedChanged(object sender, EventArgs e)
        {
            if (chb_email.Checked == true)
            {

                txt_email.ReadOnly = false;

            }
            else
            {
                txt_email.ReadOnly = true;
            }
        }

        private void chb_direccion_CheckedChanged(object sender, EventArgs e)
        {
            if (chb_direccion.Checked == true)
            {

                txt_direccion.ReadOnly = false;

            }
            else
            {
                txt_direccion.ReadOnly = true;
            }
        }

        private void chb_comuna_CheckedChanged(object sender, EventArgs e)
        {
            if (chb_comuna.Checked == true)
            {

                cb_comunas.Enabled = true;

            }
            else
            {
                cb_comunas.Enabled = false;
            }
        }

        private void chb_telefono_CheckedChanged(object sender, EventArgs e)
        {
            if (chb_telefono.Checked == true)
            {

                txt_telefono.ReadOnly = false;

            }
            else
            {
                txt_telefono.ReadOnly = true;
            }
        }

        private void chb_dueño_CheckedChanged(object sender, EventArgs e)
        {
            if (chb_dueño.Checked == true)
            {

                txt_nomd.ReadOnly = false;

            }
            else
            {
                txt_nomd.ReadOnly = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                ora.Open();
                OracleCommand comando = new OracleCommand("SP_MODIFICAR_CLIENTE", ora);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("ID_usr", OracleType.VarChar).Value = txt_id_usuario.Text;
                comando.Parameters.Add("usern", OracleType.VarChar).Value = txt_username.Text;
                comando.Parameters.Add("pass", OracleType.VarChar).Value = txt_pass.Text;



                comando.ExecuteNonQuery();
                ora.Close();
                MessageBox.Show("Los datos han sido modificados con exito");
            }

            catch(Exception ex)
            {
                ora.Close();
                MessageBox.Show("No puedes dejar algun campo vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void chb_username_CheckedChanged(object sender, EventArgs e)
        {
            if (chb_username.Checked == true)
            {

                txt_username.ReadOnly = false;

            }
            else
            {
                txt_username.ReadOnly = true;
            }
        }

        private void chb_pass_CheckedChanged(object sender, EventArgs e)
        {
            if (chb_pass.Checked == true)
            {

                txt_pass.ReadOnly = false;

            }
            else
            {
                txt_pass.ReadOnly = true;
            }
        }

        private void Modificar_Cliente_Load(object sender, EventArgs e)
        {

        }
    }
    
}
