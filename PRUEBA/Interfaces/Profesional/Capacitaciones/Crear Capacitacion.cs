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
    public partial class Crear_Capacitacion : Form
    {
        OracleConnection ora = new OracleConnection("DATA SOURCE = ORCL; PASSWORD=123; USER ID= SEBA");
        public Crear_Capacitacion()
        {
            InitializeComponent();

            
            cb_hora.Items.Add("10:00");
            cb_hora.Items.Add("10:30");
            cb_hora.Items.Add("11:00");
            cb_hora.Items.Add("11:30");
            cb_hora.Items.Add("12:00");
            cb_hora.Items.Add("12:30");
            cb_hora.Items.Add("13:00");
            cb_hora.Items.Add("13:30");
            cb_hora.Items.Add("14:00");
            cb_hora.Items.Add("14:30");
            cb_hora.Items.Add("15:00");
            cb_hora.Items.Add("15:30");
            cb_hora.Items.Add("16:00");
            cb_hora.Items.Add("16:30");
            cb_hora.Items.Add("17:00");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ora.Open();
                OracleCommand comando = new OracleCommand("SP_GENERAR_CAPACITACION", ora);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("id_contrato", OracleType.VarChar).Value = id_contrato.Text;
                comando.Parameters.Add("asistentes", OracleType.Number).Value = txt_num_asistentes.Text;
                comando.Parameters.Add("nombre_cap", OracleType.VarChar).Value = txt_nombre_capacitacion.Text;
                comando.Parameters.Add("fecha", OracleType.VarChar).Value = monthCalendar1.SelectionRange.Start.ToShortDateString();
                comando.Parameters.Add("hora", OracleType.VarChar).Value = cb_hora.SelectedItem;

                comando.ExecuteNonQuery();
                ora.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Porfavor rellene los datos");
            }
        }

        private void txt_num_asistentes_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_num_asistentes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar)) { e.Handled = false; }
            else if (Char.IsControl(e.KeyChar)) { e.Handled = false; }
            else if (Char.IsSeparator(e.KeyChar)) { e.Handled = false; }
            else { e.Handled = true; }
        }
    }
    }

