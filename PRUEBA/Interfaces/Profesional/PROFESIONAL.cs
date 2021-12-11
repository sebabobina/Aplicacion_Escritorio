using PRUEBA.Interfaces.Profesional;
using PRUEBA.Interfaces.Profesional.Asesorias;
using PRUEBA.Interfaces.Profesional.Capacitaciones;
using PRUEBA.Interfaces.Profesional.Cliente;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRUEBA
{
    public partial class PROFESIONAL : Form
    {
        public PROFESIONAL()
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
            panel_cliente.Visible = false;
            panel_capacitaciones.Visible = false;
            panel_asesorias.Visible = false;
            
        }

        private void hideSubMenu()
        {
            if (panel_cliente.Visible == true)
                panel_cliente.Visible = false;
            if (panel_capacitaciones.Visible == true)
                panel_capacitaciones.Visible = false;
            if (panel_asesorias.Visible == true)
                panel_asesorias.Visible = false;
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
            panel_child_form.Controls.Add(childForm);
            panel_child_form.Tag = childForm;
            childForm.BringToFront();
            
            childForm.Show();
           
        }

        private void btn_profesional_Click(object sender, EventArgs e)
        {
            ShowSubMenu(panel_capacitaciones);
        }

        private void btn_registrar_cliente_Click(object sender, EventArgs e)
        {
            Revisar_Clientes_PROF rcp = new Revisar_Clientes_PROF();

            rcp.lbl_id_prof.Text = label3.Text;
            

            openChildForm(rcp);

            


        }

        private void btn_minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            Elegir_Cliente_Visita ecv = new Elegir_Cliente_Visita();

            ecv.txt_id.Text = label3.Text;
            openChildForm(ecv);

        }



        private void panel_child_form_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            Capacitaciones cap = new Capacitaciones();

            cap.lbl_id_PROF.Text = label3.Text;
            openChildForm(cap);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Lista_Revisar_Cliente lrv = new Lista_Revisar_Cliente();

            lrv.label1.Text = label3.Text;
            openChildForm(lrv);


        }

        private void button4_Click(object sender, EventArgs e)
        {
            Check_List chk = new Check_List();
            chk.label1.Text = label3.Text;
            openChildForm(chk);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Crear_Asesoria ase = new Crear_Asesoria();

            ase.lbl_id_prof.Text = label3.Text;
            openChildForm(ase);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Elegir_Empresa_Asesoria ema = new Elegir_Empresa_Asesoria();
            ema.lbl_id_prof.Text = label3.Text;
            openChildForm(ema);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();




            
        }

        private void btn_Cliente_Click(object sender, EventArgs e)
        {
            ShowSubMenu(panel_cliente);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ShowSubMenu(panel_asesorias);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            PROF_ACCIDENTES pac = new PROF_ACCIDENTES();
            pac.lbl_id_prof.Text = label3.Text;
            openChildForm(pac);
        }
    }
}
    
