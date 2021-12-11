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
    public partial class Modifcar_Profesional : Form
    {
        OracleConnection ora = new OracleConnection("DATA SOURCE = ORCL; PASSWORD=123; USER ID= SEBA");
        public Modifcar_Profesional()
        {
            InitializeComponent();

            txt_RUT.ReadOnly = true;
            chb_rut.Checked = false;

            txt_Nombre.ReadOnly = true;
            chb_nombre.Checked = false;

            cb_sexo.Enabled = false;
            chb_genero.Checked = false;

            cb_profesion.Enabled = false;
            chb_profeison.Checked = false;

            txt_Email.ReadOnly = true;
            chb_email.Checked = false;

            txt_Direccion.ReadOnly = true;
            chb_direccion.Checked = false;

            cb_comuna.Enabled = false;
            chb_comuna.Checked = false;

            txt_Telefono.ReadOnly = true;
            chb_telefono.Checked = false;

            txt_user.ReadOnly = true;
            checkBox7.Checked = false;

            txt_pass.ReadOnly = true;
            checkBox5.Checked = false;


            comunas();
            profesion();
            genero();
        }

        private void btn_Crear_Click(object sender, EventArgs e)
        {
            try
            {
                ora.Open();
                OracleCommand comando = new OracleCommand("SP_MODIFICAR_PROFESIONAL2", ora);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("ID_prof", OracleType.VarChar).Value = lbl_Id_Prof.Text;
                comando.Parameters.Add("ruts", OracleType.VarChar).Value = txt_RUT.Text;
                comando.Parameters.Add("nombre", OracleType.VarChar).Value = txt_Nombre.Text;
                comando.Parameters.Add("genero", OracleType.VarChar).Value = cb_sexo.SelectedItem;
                comando.Parameters.Add("correo", OracleType.VarChar).Value = txt_Email.Text;
                comando.Parameters.Add("direc", OracleType.VarChar).Value = txt_Direccion.Text;
                comando.Parameters.Add("idc", OracleType.VarChar).Value = cb_comuna.SelectedValue;
                comando.Parameters.Add("telef", OracleType.VarChar).Value = txt_Telefono.Text;
                comando.Parameters.Add("idp", OracleType.VarChar).Value = cb_profesion.SelectedValue;


                comando.ExecuteNonQuery();
                ora.Close();
                MessageBox.Show("Datos Guardados Correctamente");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Porfavor rellene todos los campos");
                ora.Close();
            }
        }

        private void comunas()
        {
            ora.Open();
            OracleCommand mostrar1 = new OracleCommand("SP_MOSTRAR_COMUNA", ora);
            mostrar1.CommandType = System.Data.CommandType.StoredProcedure;
            mostrar1.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;

            OracleDataAdapter adaptador1 = new OracleDataAdapter();
            adaptador1.SelectCommand = mostrar1;
            DataTable tabla2 = new DataTable();
            adaptador1.Fill(tabla2);



            cb_comuna.DataSource = tabla2;

            cb_comuna.DisplayMember = "nombre_comuna";

            cb_comuna.ValueMember = "id_comuna";

            ora.Close();

        }

        private void profesion()
        {
            ora.Open();
            OracleCommand mostrar1 = new OracleCommand("SP_MOSTRAR_PROFESION", ora);
            mostrar1.CommandType = System.Data.CommandType.StoredProcedure;
            mostrar1.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;

            OracleDataAdapter adaptador1 = new OracleDataAdapter();
            adaptador1.SelectCommand = mostrar1;
            DataTable tabla2 = new DataTable();
            adaptador1.Fill(tabla2);



            cb_profesion.DataSource = tabla2;

            cb_profesion.DisplayMember = "nombre_profesion";

            cb_profesion.ValueMember = "id_profesion";

            ora.Close();


        }



        private void genero()
        {

            cb_sexo.Items.Add("MASCULINO");
            cb_sexo.Items.Add("FEMENINO");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ora.Open();
                OracleCommand comando = new OracleCommand("SP_MODIFICAR_PROFESIONAL", ora);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("id_user", OracleType.VarChar).Value = id_usr.Text;
                comando.Parameters.Add("usern", OracleType.VarChar).Value = txt_user.Text;
                comando.Parameters.Add("pass", OracleType.VarChar).Value = txt_pass.Text;


                comando.ExecuteNonQuery();
                ora.Close();

                MessageBox.Show("Datos Guardados Correctamente");


            }
            catch (Exception ex)
            {
                MessageBox.Show("Porfavor rellene todos los campos");
                ora.Close();
            }
            
        }

        private void Modifcar_Profesional_Load(object sender, EventArgs e)
        {

        }

        private void chb_rut_CheckedChanged(object sender, EventArgs e)
        {
            if (chb_rut.Checked == true)
            {

                txt_RUT.ReadOnly = false;

            }
            else
            {
                txt_RUT.ReadOnly = true;
            }
        }

        private void chb_nombre_CheckedChanged(object sender, EventArgs e)
        {
            if (chb_nombre.Checked == true)
            {

                txt_Nombre.ReadOnly = false;

            }
            else
            {
                txt_Nombre.ReadOnly = true;
            }
        }

        private void chb_genero_CheckedChanged(object sender, EventArgs e)
        {
            if (chb_genero.Checked == true)
            {

                cb_sexo.Enabled = true;

            }
            else
            {
                cb_sexo.Enabled = false;
            }
        }

        private void chb_profeison_CheckedChanged(object sender, EventArgs e)
        {
            if (chb_profeison.Checked == true)
            {

                cb_profesion.Enabled = true;

            }
            else
            {
                cb_profesion.Enabled = false;
            }
        }

        private void chb_email_CheckedChanged(object sender, EventArgs e)
        {
            if (chb_email.Checked == true)
            {

                txt_Email.ReadOnly = false;

            }
            else
            {
                txt_Email.ReadOnly = true;
            }
        }

        private void chb_direccion_CheckedChanged(object sender, EventArgs e)
        {
            if (chb_direccion.Checked == true)
            {

                txt_Direccion.ReadOnly = false;

            }
            else
            {
                txt_Direccion.ReadOnly = true;
            }
        }

        private void chb_comuna_CheckedChanged(object sender, EventArgs e)
        {
            if (chb_comuna.Checked == true)
            {

                cb_comuna.Enabled = true;

            }
            else
            {
                cb_comuna.Enabled = false;
            }
        }

        private void chb_telefono_CheckedChanged(object sender, EventArgs e)
        {
            if (chb_telefono.Checked == true)
            {

                txt_Telefono.ReadOnly = false;

            }
            else
            {
                txt_Telefono.ReadOnly = true;
            }
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked == true)
            {

                txt_user.ReadOnly = false;

            }
            else
            {
                txt_user.ReadOnly = true;
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked == true)
            {

                txt_pass.ReadOnly = false;

            }
            else
            {
                txt_pass.ReadOnly = true;
            }
        }
    }
}
