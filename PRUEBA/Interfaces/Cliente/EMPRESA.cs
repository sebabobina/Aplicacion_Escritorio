using PRUEBA.Interfaces.Cliente.Accidentes;
using PRUEBA.Interfaces.Cliente.Asesoria_Especial;
using PRUEBA.Interfaces.Cliente.Capacitaciones;
using PRUEBA.Interfaces.Cliente.Contrato;
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
    public partial class EMPRESA : Form
    {
        OracleConnection ora = new OracleConnection("DATA SOURCE = ORCL; PASSWORD=123; USER ID= SEBA");
        public EMPRESA()
        {
            InitializeComponent();
            customizeDesing();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }
        private void customizeDesing()
        {
            panel_contrato.Visible = false;
            panel_capacitacion.Visible = false;
            panel_asesoria.Visible = false;
            panel_accidentes.Visible = false;

        }

        private void hideSubMenu()
        {
            if (panel_contrato.Visible == true)
                panel_contrato.Visible = false;
            if (panel_capacitacion.Visible == true)
                panel_capacitacion.Visible = false;
            if (panel_asesoria.Visible == true)
                panel_asesoria.Visible = false;
            if (panel_accidentes.Visible == true)
                panel_accidentes.Visible = false;
        }

        private void ShowSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel4.Controls.Add(childForm);
            panel4.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }


        private void button9_Click(object sender, EventArgs e)
        {
            Revisar_capacitacion_cliente rc = new Revisar_capacitacion_cliente();

            rc.lbl_idContrato.Text = lb_ID_CONTR.Text;

            openChildForm(rc);
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Reportar_Accidente rpa = new Reportar_Accidente();
            
            rpa.lbl_id_Contrato.Text = lb_ID_CONTR.Text;
            rpa.lbl_ID_PROF.Text = lb_idProf.Text;
            openChildForm(rpa);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Mostrar_Accidentes ma = new Mostrar_Accidentes();

            ma.lbl_id_contrato.Text = lb_ID_CONTR.Text;

            openChildForm(ma);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            ora.Open();
            OracleCommand comando1 = new OracleCommand("SP_AGREGAR_ACTIVIDAD_CLIENTE", ora);
            comando1.CommandType = System.Data.CommandType.StoredProcedure;
            comando1.Parameters.Add("idcontr", OracleType.VarChar).Value = lb_ID_CONTR.Text;
            comando1.Parameters.Add("actividad", OracleType.VarChar).Value = "Cerro Sesion";
            comando1.ExecuteNonQuery();
            ora.Close();


            this.Close();




            


        }

        private void btn_Cliente_Click(object sender, EventArgs e)
        {
            ShowSubMenu(panel_contrato);
        }

        private void btn_profesional_Click(object sender, EventArgs e)
        {
            ShowSubMenu(panel_capacitacion);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ShowSubMenu(panel_asesoria);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ShowSubMenu(panel_accidentes);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Asesoria_Especial ae = new Asesoria_Especial();

            ae.lbl_id_contrato.Text = lb_ID_CONTR.Text;
            ae.lbl_id_prof.Text = lb_idProf.Text;

            openChildForm(ae);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Revisar_Asesoria ra = new Revisar_Asesoria();

            ra.lbl_contrato.Text = lb_ID_CONTR.Text;

            openChildForm(ra);
        }

        private void btn_registrar_cliente_Click(object sender, EventArgs e)
        {
            Revisar_Contrato rc = new Revisar_Contrato();

            rc.id_contr.Text = lb_ID_CONTR.Text;

            openChildForm(rc);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Revisar_Fechas rf = new Revisar_Fechas();

            rf.lbl_idcontr.Text = lb_ID_CONTR.Text;

            openChildForm(rf);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Revisar_Pagos rp = new Revisar_Pagos();

            rp.lbl_id_contr.Text = lb_ID_CONTR.Text;

            openChildForm(rp);
        }
    }
}
