using PRUEBA.Interfaces.Admin.Asesorias;
using PRUEBA.Interfaces.Admin.Capacitaciones;
using PRUEBA.Interfaces.Admin.Cliente;
using PRUEBA.Interfaces.Admin.Profesional;
using PRUEBA.Interfaces.Admin.Reportes;
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
    public partial class ADMIN : Form
    {
        


        public ADMIN()
        {
            InitializeComponent();
            customizeDesing();
        }

        private void btn_cliente_Click(object sender, EventArgs e)
        {
            

            
        }

        private void customizeDesing()
        {
            panel_cliente.Visible = false;
            panel_submenuProf.Visible = false;
            panel_capacitacion.Visible = false;
            panel_asesoria.Visible = false;
            panel_reporte.Visible = false;
        }

        private void hideSubMenu()
        {
            if (panel_cliente.Visible == true)
                panel_cliente.Visible = false;
            if (panel_submenuProf.Visible == true)
                panel_submenuProf.Visible = false;
            if (panel_capacitacion.Visible == true)
                panel_capacitacion.Visible = false;
            if (panel_asesoria.Visible == true)
                panel_asesoria.Visible = false;
            if (panel_reporte.Visible == true)
                panel_reporte.Visible = false;
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




        void cierrevistacliente(object sender, EventArgs e)
        {
            

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btn_cerrar_sesion_Click(object sender, EventArgs e)
        {
            this.Close();
           
        }

        private void ADMIN_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void btn_profesional_Click(object sender, EventArgs e)
        {
            
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

       

        private void btn_Revisar_Clientes_Click_1(object sender, EventArgs e)
        {
            openChildForm(new Form2());
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btn_registrar_cliente_Click(object sender, EventArgs e)
        {
            openChildForm(new Registrar_Clientes());
        }

        private void btn_Cliente_Click_1(object sender, EventArgs e)
        {
            ShowSubMenu(panel_cliente);
        }

        private void btn_profesional_Click_1(object sender, EventArgs e)
        {
            ShowSubMenu(panel_submenuProf);
        }

        private void username_Click(object sender, EventArgs e)
        {

        }

        private void horafecha_Tick(object sender, EventArgs e)
        {
            Hora.Text = DateTime.Now.ToLongTimeString();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            openChildForm(new Añadir_Profesional());


            

            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            
            openChildForm(new Administrar_Profesional());

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            openChildForm(new Actividad_Clientes());
            
        }

        private void button16_Click(object sender, EventArgs e)
        {
            openChildForm(new Reporte_Cliente());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowSubMenu(panel_capacitacion);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ShowSubMenu(panel_asesoria);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            ShowSubMenu(panel_reporte);
        }

        private void btn_Pagos_Click(object sender, EventArgs e)
        {
            openChildForm(new Pagos_Clientes());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            


            openChildForm(new Administrar_Capacitaciones());
        }

        private void button12_Click(object sender, EventArgs e)
        {
            openChildForm(new Administrar_Asesorias());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openChildForm(new Elegir_Empresa_Accidentes());
        }

        private void button15_Click(object sender, EventArgs e)
        {
            openChildForm(new Reporte_Global());
        }
    }
}
