using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OracleClient;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRUEBA
{
    public partial class Registrar_Clientes : Form
    {
        OracleConnection ora = new OracleConnection("DATA SOURCE = ORCL; PASSWORD=123; USER ID= SEBA");
        public Registrar_Clientes()
        {
            InitializeComponent();

            


            ora.Open();
            OracleCommand mostrar = new OracleCommand("SP_MOSTRAR_CLIENTES_POR_REGISTRAR", ora);
            mostrar.CommandType = System.Data.CommandType.StoredProcedure;
            mostrar.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;

            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = mostrar;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dgv_clientes.DataSource = tabla;


            OracleCommand mostrar2 = new OracleCommand("SP_MOSTRAR_PROFESIONALES_CONTRATO", ora);
            mostrar2.CommandType = System.Data.CommandType.StoredProcedure;
            mostrar2.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;

            OracleDataAdapter adaptador2 = new OracleDataAdapter();
            adaptador2.SelectCommand = mostrar2;
            DataTable tabla2 = new DataTable();
            adaptador2.Fill(tabla2);
            dgv_prof.DataSource = tabla2;









            ora.Close();






        }

        

        

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {

        }

        private void Registrar_Clientes_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            if (txt_Cliente.Text == "")
            {

                MessageBox.Show("Campo Vacio Porfavor Seleccione bien");

            }


            else
            {

                if (txt_Cliente.Text == "" && txt_Profesional.Text == "")
                {

                    MessageBox.Show("Campo Vacio Porfavor Seleccione bien");

                }
                else
                {
                    ora.Open();
                    OracleCommand comando = new OracleCommand("SP_GENERAR_CONTRATO", ora);
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.Add("idemp", OracleType.VarChar).Value = dgv_clientes.CurrentRow.Cells["ID"].Value.ToString();
                    comando.Parameters.Add("idp", OracleType.VarChar).Value = dgv_prof.CurrentRow.Cells["ID"].Value.ToString();
                    comando.Parameters.Add("monto", OracleType.Number).Value = "200000";

                    comando.ExecuteNonQuery();

                    OracleCommand comando1 = new OracleCommand("SELECT u.nombre_usuario as usuario, u.contrasena as contrasena, conp.fecha_facturacion as fecha, to_char(conp.monto_total,'$999G999G999') as monto from usuario u inner join contrato contr on u.id_empresa = contr.id_empresa inner join control_pagos conp on contr.id_contrato = conp.id_contrato where u.id_empresa = :idempresa", ora);

                    comando1.Parameters.AddWithValue(":idempresa", dgv_clientes.CurrentRow.Cells["ID"].Value.ToString());

                    OracleDataReader lector1 = comando1.ExecuteReader();

                    lector1.Read();
                    

                    System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();

                    mmsg.To.Add("sebabobina@gmail.com");
                    mmsg.Subject = "Entrega Credenciales y Fecha de Pago - Big Bro";
                    mmsg.SubjectEncoding = System.Text.Encoding.UTF8;


                    mmsg.Body = "Junto con saludarlo, Su registro se ha hecho con exito, a continuacion le dejaremos sus credenciales  Nombre de Usuario: " + lector1["usuario"].ToString() + " | Contraseña: "
                        + lector1["contrasena"].ToString() + " Y su primer pago tiene fecha de vencimiento hasta el " + lector1["fecha"].ToString() + " Con un monto de " + lector1["monto"].ToString() + " Para mas informacion puede ingresar desde la aplicacion o desde la version Web, Saludos Cordiales.";
                    mmsg.BodyEncoding = System.Text.Encoding.UTF8;
                    mmsg.From = new System.Net.Mail.MailAddress("bigbro53822@gmail.com");


                    System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();

                    cliente.Credentials = new System.Net.NetworkCredential("bigbro53822@gmail.com", "bigbro123.");

                    cliente.Port = 587;
                    cliente.EnableSsl = true;
                    cliente.Host = "smtp.gmail.com";

                    try
                    {
                        cliente.Send(mmsg);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error al enviar");
                    }



                    ora.Close();

                    MessageBox.Show("El Contrato se ha generado Correctamente");
                    txt_Cliente.Text = "";
                    txt_Profesional.Text = "";
                    Actualizar_Tabla();

                    

                }

            }




        }

        private void dgv_Clientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_clientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_Cliente.Text = dgv_clientes.CurrentRow.Cells["NOMBRE"].Value.ToString();
        }

        private void dgv_prof_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_Profesional.Text = dgv_prof.CurrentRow.Cells["NOMBRE"].Value.ToString();
        }

        private void Actualizar_Tabla()
        {
            ora.Open();
            OracleCommand mostrar = new OracleCommand("SP_MOSTRAR_CLIENTES_POR_REGISTRAR", ora);
            mostrar.CommandType = System.Data.CommandType.StoredProcedure;
            mostrar.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;

            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = mostrar;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dgv_clientes.DataSource = tabla;



            ora.Close();
        }

        private void txt_buscar_emp_KeyUp(object sender, KeyEventArgs e)
        {
            ora.Open();

            OracleCommand mostrar = new OracleCommand("SP_BUSCAR_EMP_REG", ora);
            mostrar.CommandType = System.Data.CommandType.StoredProcedure;
            mostrar.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;
            mostrar.Parameters.Add("nombre", OracleType.VarChar).Value = txt_buscar_emp.Text;

            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = mostrar;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dgv_clientes.DataSource = tabla;



            ora.Close();
        }

        private void txt_buscarprof_KeyUp(object sender, KeyEventArgs e)
        {

            ora.Open();

            OracleCommand mostrar = new OracleCommand("SP_BUSCAR_PROF", ora);
            mostrar.CommandType = System.Data.CommandType.StoredProcedure;
            mostrar.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;
            mostrar.Parameters.Add("nombre", OracleType.VarChar).Value = txt_buscarprof.Text;

            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = mostrar;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dgv_prof.DataSource = tabla;



            ora.Close();
        }

        private void txt_buscar_emp_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
