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
    public partial class agregar_datos_emp : Form
    {
        OracleConnection ora = new OracleConnection("DATA SOURCE = ORCL; PASSWORD=123; USER ID= SEBA");
        public agregar_datos_emp()
        {
            InitializeComponent();

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
            

            if (txt_rut.Text == "" && txt_rut3.Text == "" && txt_rut5.Text == "" && txt_rut7.Text == "")
            {
                MessageBox.Show("Porfavor ingrese un RUT Valido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                ora.Open();
                OracleCommand comando2 = new OracleCommand("SELECT * FROM EMPRESA WHERE RUT_EMPRESA = :rut", ora);

                comando2.Parameters.AddWithValue(":rut", txt_rut.Text + txt_rut2.Text + txt_rut3.Text + txt_rut4.Text + txt_rut5.Text + txt_rut6.Text + txt_rut7.Text);
                OracleDataReader lector2 = comando2.ExecuteReader();

                if (lector2.Read())
                {
                    MessageBox.Show("Una Empresa con ese rut ya ha sido creado, verifique bien los datos","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    ora.Close();

                }
                else
                {
                    try
                    {
                        
                        OracleCommand comando = new OracleCommand("SP_AGREGAR_CONTACTO_EMPRESA", ora);
                        comando.CommandType = System.Data.CommandType.StoredProcedure;
                        //comando.Parameters.Add("ID_emp", OracleType.VarChar).Value = txt_id.Text;
                        comando.Parameters.Add("rute", OracleType.VarChar).Value = txt_rut.Text + txt_rut2.Text + txt_rut3.Text + txt_rut4.Text + txt_rut5.Text + txt_rut6.Text + txt_rut7.Text;
                        comando.Parameters.Add("nombre", OracleType.VarChar).Value = txt_nombre.Text;
                        comando.Parameters.Add("email", OracleType.VarChar).Value = txt_email.Text;
                        comando.Parameters.Add("direccion", OracleType.VarChar).Value = txt_direccion.Text;
                        comando.Parameters.Add("nomd", OracleType.VarChar).Value = txt_nomd.Text;
                        comando.Parameters.Add("telef", OracleType.VarChar).Value = txt_telefono2.Text + txt_telefono.Text;
                        comando.Parameters.Add("idcom", OracleType.VarChar).Value = cb_comunas.SelectedValue;
                        comando.Parameters.Add("idrubro", OracleType.VarChar).Value = cb_rubros.SelectedValue;


                        comando.ExecuteNonQuery();
                        ora.Close();

                        MessageBox.Show("Datos Enviados Correctamente, pronto nos contactaremos con usted.");
                    }
                    catch (Exception ex)
                    {
                        ora.Close();
                        MessageBox.Show("Hubo un problema al enviar los datos, porfavor verifique que los datos este correctos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }

            }






            


            

        }

        private void txt_rut_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar)) { e.Handled = false; }
            else if (Char.IsControl(e.KeyChar)) { e.Handled = false; }
            else if (Char.IsSeparator(e.KeyChar)) { e.Handled = false; }
            else { e.Handled = true; }
        }

        private void txt_rut3_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_rut3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar)) { e.Handled = false; }
            else if (Char.IsControl(e.KeyChar)) { e.Handled = false; }
            else if (Char.IsSeparator(e.KeyChar)) { e.Handled = false; }
            else { e.Handled = true; }
        }

        private void txt_rut5_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_rut5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar)) { e.Handled = false; }
            else if (Char.IsControl(e.KeyChar)) { e.Handled = false; }
            else if (Char.IsSeparator(e.KeyChar)) { e.Handled = false; }
            else { e.Handled = true; }
        }

        private void txt_rut7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar)) { e.Handled = false; }
            else if (Char.IsControl(e.KeyChar)) { e.Handled = false; }
            else if (Char.IsSeparator(e.KeyChar)) { e.Handled = false; }
            else { e.Handled = true; }
        }

        private void txt_telefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar)) { e.Handled = false; }
            else if (Char.IsControl(e.KeyChar)) { e.Handled = false; }
            else if (Char.IsSeparator(e.KeyChar)) { e.Handled = false; }
            else { e.Handled = true; }
        }
    }
}
