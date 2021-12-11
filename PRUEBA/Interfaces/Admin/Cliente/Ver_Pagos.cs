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

namespace PRUEBA.Interfaces.Admin.Cliente
{
    public partial class Ver_Pagos : Form
    {
        OracleConnection ora = new OracleConnection("DATA SOURCE = ORCL; PASSWORD=123; USER ID= SEBA");

        public Ver_Pagos()
        {
            InitializeComponent();
        }

        private void Ver_Pagos_Load(object sender, EventArgs e)
        {
            Actualizar_Tabla();
        }

        private void btn_nueva_factura_Click(object sender, EventArgs e)
        {
            try
            {
                ora.Open();
                OracleCommand comando = new OracleCommand("SP_NUEVA_FACTURACION", ora);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("id_contr", OracleType.VarChar).Value = lbl_idcontr.Text;



                comando.ExecuteNonQuery();
                ora.Close();
                Actualizar_Tabla();
                Generar_Correo();

                MessageBox.Show("Factura generada Correctamente");
            }
            catch (Exception ex)
            {

                
                MessageBox.Show("Ya se realizo la facturacion del proximo mes, porfavor intente el proximo mes");
                ora.Close();
            }
           

        }

        private void Actualizar_Tabla()
        {

            ora.Open();
            OracleCommand mostrar = new OracleCommand("SP_MOSTRAR_PAGOS", ora);
            mostrar.CommandType = System.Data.CommandType.StoredProcedure;

            mostrar.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;
            mostrar.Parameters.Add("idcontr", OracleType.VarChar).Value = lbl_idcontr.Text;

            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = mostrar;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dgvA.DataSource = tabla;
            ora.Close();
        }


        private void Generar_Correo()
        {

            System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();

            mmsg.To.Add("sebabobina@gmail.com");
            mmsg.Subject = "Nueva Facturacion de Pago - Big Bro";
            mmsg.SubjectEncoding = System.Text.Encoding.UTF8;


            mmsg.Body = "Junto con saludarlo, Su proxima facturacion tiene plazo de pago hasta el " + dgvA.CurrentRow.Cells["Fecha Vencimiento"].Value.ToString() +
             " con un monto de" + dgvA.CurrentRow.Cells["Monto Facturado"].Value.ToString() + " Saludos.";
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



        }


        private void btn_correo_Click(object sender, EventArgs e)
        {

            if (dgvA.CurrentRow.Cells["Estado"].Value.ToString() == "NO")
            {



                System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();

                mmsg.To.Add("sebabobina@gmail.com");
                mmsg.Subject = "Atraso en el pago - Big Bro";
                mmsg.SubjectEncoding = System.Text.Encoding.UTF8;


                mmsg.Body = "Junto con saludarlo, usted tiene pendiente un pago, este vencio el " +
                    dgvA.CurrentRow.Cells["Fecha Vencimiento"].Value.ToString() + " Con el monto de" + dgvA.CurrentRow.Cells["Monto Facturado"].Value.ToString() +
                    " Porfavor le pedimos que haga el pago o en los proximos dias se hara la cancelacion de su contrato.";
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

                    MessageBox.Show("Cliente Notificado por Email Exitosamente");
                }
                catch (Exception)
                {
                    MessageBox.Show("Error al enviar");
                }
            }
            else
            {

                MessageBox.Show("El cliente ya pago esta factura");

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ora.Open();
            OracleCommand comando = new OracleCommand("SP_CAMBIAR_ESTADO_PAGO_SI", ora);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("idp", OracleType.VarChar).Value = dgvA.CurrentRow.Cells["ID de Pago"].Value.ToString();



            comando.ExecuteNonQuery();
            ora.Close();
            Actualizar_Tabla();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ora.Open();
            OracleCommand comando = new OracleCommand("SP_CAMBIAR_ESTADO_PAGO_NO", ora);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("idp", OracleType.VarChar).Value = dgvA.CurrentRow.Cells["ID de Pago"].Value.ToString();



            comando.ExecuteNonQuery();
            ora.Close();
            Actualizar_Tabla();
        }
    }
    }

