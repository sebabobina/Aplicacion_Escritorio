using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRUEBA
{
    public partial class Login2 : Form
    {
        public Login2()
        {
            InitializeComponent();


            
        }
        OracleConnection ora = new OracleConnection("DATA SOURCE = ORCL; PASSWORD=123; USER ID= SEBA");

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void btn_acceder_Click(object sender, EventArgs e)
        {
            ora.Open();
            OracleCommand comando = new OracleCommand("SELECT u.ID_USUARIO, u.NOMBRE_USUARIO, u.CONTRASENA, u.ID_ADM, adm.nombre_admin FROM USUARIO u INNER JOIN ADM adm on u.id_adm = adm.id_adm WHERE u.NOMBRE_USUARIO = :usuarios AND u.CONTRASENA = :clave AND u.id_adm LIKE 'ADM_%%%' ", ora);


            comando.Parameters.AddWithValue(":usuarios", txt_usuario.Text);
            comando.Parameters.AddWithValue(":clave", txt_contraseña.Text);

            OracleDataReader lector = comando.ExecuteReader();

           

            if (lector.Read())
            {

                MessageBox.Show("Bienvenido Usuario: Administrador");
                ADMIN admin = new ADMIN();

                this.Hide();
                admin.username.Text = lector["NOMBRE_ADMIN"].ToString();
                ora.Close();
                admin.ShowDialog();
                this.Show();

                txt_usuario.Text = "";
                txt_contraseña.Text = "";

                


            }

            else
            {

                OracleCommand comando1 = new OracleCommand("SELECT u.ID_USUARIO, u.NOMBRE_USUARIO, u.CONTRASENA," +
                    " u.ID_EMPRESA, emp.nombre_empresa," +
                    " cont.id_contrato, cont.id_profesional" +
                    " FROM USUARIO " +
                    "u INNER JOIN EMPRESA emp on u.id_empresa = emp.id_empresa INNER JOIN CONTRATO cont on emp.id_empresa = cont.id_empresa WHERE u.NOMBRE_USUARIO = :usuarios AND " +
                    " u.CONTRASENA = :clave AND u.ID_EMPRESA LIKE 'CL_%%%' ", ora);

                comando1.Parameters.AddWithValue(":usuarios", txt_usuario.Text);
                comando1.Parameters.AddWithValue(":clave", txt_contraseña.Text);

                OracleDataReader lector1 = comando1.ExecuteReader();


                if (lector1.Read())
                {

                    MessageBox.Show("Bienvenido Usuario: Cliente");
                    EMPRESA emp = new EMPRESA();

                    this.Hide();
                    emp.username.Text = lector1["NOMBRE_EMPRESA"].ToString();

                    emp.lb_EMP.Text = lector1["ID_EMPRESA"].ToString();
                    emp.lb_idProf.Text = lector1["ID_PROFESIONAL"].ToString();
                    emp.lb_ID_CONTR.Text = lector1["ID_CONTRATO"].ToString();


                    OracleCommand comando5 = new OracleCommand("SP_AGREGAR_ACTIVIDAD_CLIENTE", ora);
                    comando5.CommandType = System.Data.CommandType.StoredProcedure;
                    comando5.Parameters.Add("idcontr", OracleType.VarChar).Value = lector1["ID_CONTRATO"].ToString();
                    comando5.Parameters.Add("actividad", OracleType.VarChar).Value = "Inicio de Sesion";
                    comando5.ExecuteNonQuery();


                    ora.Close();
                    emp.ShowDialog();
                    this.Show();

                    txt_usuario.Text = "";
                    txt_contraseña.Text = "";

                    




                }
                else
                {
                    OracleCommand comandoprof = new OracleCommand("SELECT u.ID_USUARIO, u.NOMBRE_USUARIO, u.CONTRASENA, u.ID_PROFESIONAL, prof.nombre_profesional FROM USUARIO u INNER JOIN PROFESIONAL prof on u.id_profesional = prof.id_profesional WHERE u.NOMBRE_USUARIO = :usuarios AND u.CONTRASENA = :clave AND u.id_profesional LIKE 'PROF_%%%'", ora);

                    comandoprof.Parameters.AddWithValue(":usuarios", txt_usuario.Text);
                    comandoprof.Parameters.AddWithValue(":clave", txt_contraseña.Text);

                    OracleDataReader lectorprof = comandoprof.ExecuteReader();

                    if (lectorprof.Read())
                    {
                        MessageBox.Show("Bienvenido Usuario: PROFESIONAL");
                        PROFESIONAL prof = new PROFESIONAL();

                        this.Hide();

                        prof.username.Text = lectorprof["NOMBRE_PROFESIONAL"].ToString();
                        prof.label3.Text = lectorprof["ID_PROFESIONAL"].ToString();
                        ora.Close();
                        prof.ShowDialog();
                        this.Show();

                        txt_usuario.Text = "";
                        txt_contraseña.Text = "";

                        




                    }
                    else
                    {
                        MessageBox.Show("Usuario no existe");
                        ora.Close();


                    }


                }
            }

        }

        private void txt_usuario_Enter(object sender, EventArgs e)
        {
            if (txt_usuario.Text == "USUARIO")
            {
                txt_usuario.Text = "";
                txt_usuario.ForeColor = Color.LightGray;


            }
        }

        private void txt_usuario_Leave(object sender, EventArgs e)
        {
            if (txt_usuario.Text == "")
            {
                txt_usuario.Text = "USUARIO";
                txt_usuario.ForeColor = Color.Black;

            }
        }

        private void txt_contraseña_Enter(object sender, EventArgs e)
        {
            if (txt_contraseña.Text == "CONTRASEÑA")
            {
                txt_contraseña.Text = "";
                txt_contraseña.ForeColor = Color.LightGray;
                txt_contraseña.UseSystemPasswordChar = true;

            }
        }

        private void txt_contraseña_Leave(object sender, EventArgs e)
        {
            if (txt_contraseña.Text == "")
            {
                txt_contraseña.Text = "CONTRASEÑA";
                txt_contraseña.ForeColor = Color.Black;
                txt_contraseña.UseSystemPasswordChar = false;
            }
        }

        private void Login2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            agregar_datos_emp rdc = new agregar_datos_emp();

            rdc.ShowDialog(this);
        }
    }
}
