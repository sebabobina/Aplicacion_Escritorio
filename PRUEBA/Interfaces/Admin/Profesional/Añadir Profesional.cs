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
    public partial class Añadir_Profesional : Form
    {
        OracleConnection ora = new OracleConnection("DATA SOURCE = ORCL; PASSWORD=123; USER ID= SEBA");
        public Añadir_Profesional()
        {
            InitializeComponent();

            comunas();
            profesion();
            genero();




        }

        private void btn_Crear_Click(object sender, EventArgs e)
        {
            ora.Open();
            OracleCommand comando2 = new OracleCommand("SELECT * FROM PROFESIONAL WHERE RUT = :rut", ora);

            comando2.Parameters.AddWithValue(":rut", txt_RUT1.Text + txt_RUT2.Text + txt_RUT3.Text + txt_RUT4.Text + txt_RUT5.Text + txt_RUT6.Text + txt_RUT7.Text);
            OracleDataReader lector2 = comando2.ExecuteReader();


            if (lector2.Read())
            {
                MessageBox.Show("Profesional con ese rut ya ha sido creado, verifique los datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                ora.Close();

            }
            else
            {

                try
                {
                    
                    OracleCommand comando = new OracleCommand("SP_AGREGAR_PROFESIONAL", ora);
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.Add("ruts", OracleType.VarChar).Value = txt_RUT1.Text + txt_RUT2.Text + txt_RUT3.Text + txt_RUT4.Text + txt_RUT5.Text + txt_RUT6.Text + txt_RUT7.Text ;
                    comando.Parameters.Add("nombre", OracleType.VarChar).Value = txt_Nombre.Text;
                    comando.Parameters.Add("genero", OracleType.VarChar).Value = cb_sexo.SelectedItem;
                    comando.Parameters.Add("correo", OracleType.VarChar).Value = txt_Email.Text;
                    comando.Parameters.Add("direc", OracleType.VarChar).Value = txt_Direccion.Text;
                    comando.Parameters.Add("idc", OracleType.VarChar).Value = cb_comuna.SelectedValue;
                    comando.Parameters.Add("telef", OracleType.VarChar).Value = txt_569.Text + txt_Telefono.Text;
                    comando.Parameters.Add("idp", OracleType.VarChar).Value = cb_profesion.SelectedValue;


                    comando.ExecuteNonQuery();
                    ora.Close();

                    MessageBox.Show("Profesional Creado Correctamente");

                }

                catch (Exception ex)
                {
                    MessageBox.Show("Hubo un problema al crear a profesional, porfavor verifique que los datos este correctos" , "Error" ,MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ora.Close();

                }


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

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txt_Telefono_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_Telefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar)) { e.Handled = false; }
            else if (Char.IsControl(e.KeyChar)) { e.Handled = false; }
            else if (Char.IsSeparator(e.KeyChar)) { e.Handled = false; }
            else { e.Handled = true; }
        }

        private void txt_RUT1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar)) { e.Handled = false; }
            else if (Char.IsControl(e.KeyChar)) { e.Handled = false; }
            else if (Char.IsSeparator(e.KeyChar)) { e.Handled = false; }
            else { e.Handled = true; }
        }

        private void txt_RUT3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar)) { e.Handled = false; }
            else if (Char.IsControl(e.KeyChar)) { e.Handled = false; }
            else if (Char.IsSeparator(e.KeyChar)) { e.Handled = false; }
            else { e.Handled = true; }
        }

        private void txt_RUT5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar)) { e.Handled = false; }
            else if (Char.IsControl(e.KeyChar)) { e.Handled = false; }
            else if (Char.IsSeparator(e.KeyChar)) { e.Handled = false; }
            else { e.Handled = true; }
        }

        private void txt_RUT7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar)) { e.Handled = false; }
            else if (Char.IsControl(e.KeyChar)) { e.Handled = false; }
            else if (Char.IsSeparator(e.KeyChar)) { e.Handled = false; }
            else { e.Handled = true; }
        }
    }
    }

