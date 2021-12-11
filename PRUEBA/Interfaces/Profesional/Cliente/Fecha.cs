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
    public partial class Fecha : Form
    {
        OracleConnection ora = new OracleConnection("DATA SOURCE = ORCL; PASSWORD=123; USER ID= SEBA");

        

        

        public Fecha()
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

            cb_dia1.Items.Add("10:00");
            cb_dia1.Items.Add("10:30");
            cb_dia1.Items.Add("11:00");
            cb_dia1.Items.Add("11:30");
            cb_dia1.Items.Add("12:00");
            cb_dia1.Items.Add("12:30");
            cb_dia1.Items.Add("13:00");
            cb_dia1.Items.Add("13:30");
            cb_dia1.Items.Add("14:00");
            cb_dia1.Items.Add("14:30");
            cb_dia1.Items.Add("15:00");
            cb_dia1.Items.Add("15:30");
            cb_dia1.Items.Add("16:00");
            cb_dia1.Items.Add("16:30");
            cb_dia1.Items.Add("17:00");



        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            




            ora.Open();
            OracleCommand comando2 = new OracleCommand("SELECT * FROM  AGENDAR_VISITA WHERE ID_PROFESIONAL = :idprof AND fecha_primera_visita = :fecha1 OR fecha_segunda_visita = :fecha1", ora);

            comando2.Parameters.AddWithValue(":idprof", id_prof.Text);
            comando2.Parameters.AddWithValue(":fecha1", monthCalendar1.SelectionRange.Start.ToShortDateString());
            OracleDataReader lector2 = comando2.ExecuteReader();

            if(monthCalendar1.SelectionRange.Start.ToShortDateString() == monthCalendar2.SelectionRange.Start.ToShortDateString())
            {
                MessageBox.Show("Hubo un error al Agendar las Fechas, No puede agendar las 2 visitas en el mismo dia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ora.Close();
            }
            else
            {
                if (lector2.Read())
                {
                    MessageBox.Show("No es posible agendar la visita de Fecha 1 ya que existe una visita agendada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ora.Close();
                }
                else
                {
                    OracleCommand comando3 = new OracleCommand("SELECT * FROM  AGENDAR_VISITA WHERE ID_PROFESIONAL = :idprof AND fecha_primera_visita = :fecha1 OR fecha_segunda_visita = :fecha1", ora);

                    comando3.Parameters.AddWithValue(":idprof", id_prof.Text);
                    comando3.Parameters.AddWithValue(":fecha1", monthCalendar2.SelectionRange.Start.ToShortDateString());
                    OracleDataReader lector3 = comando3.ExecuteReader();

                    if (lector3.Read())
                    {
                        MessageBox.Show("No es posible agendar la visita de Fecha 2 ya que existe una visita agendada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ora.Close();
                    }
                    else
                    {

                        OracleCommand comando4 = new OracleCommand("SELECT * FROM AGENDAR_VISITA WHERE id_profesional = :idprof AND id_contrato = :idcontr AND TO_CHAR(fecha_primera_visita,'MONTH') = TO_CHAR(TO_DATE(:fecha1),'MONTH')", ora);

                        comando4.Parameters.AddWithValue(":idprof", id_prof.Text);
                        comando4.Parameters.AddWithValue(":idcontr", id_empresa.Text);
                        comando4.Parameters.AddWithValue(":fecha1", monthCalendar1.SelectionRange.Start.ToShortDateString());
                        OracleDataReader lector4 = comando4.ExecuteReader();

                        if (lector4.Read())
                        {
                            MessageBox.Show("No es posible agendar la visita Porque este Mes ya tiene Visitas Agendadas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            ora.Close();
                        }
                        else
                        {
                            //OracleCommand comando5 = new OracleCommand("SELECT * FROM AGENDAR_VISITA WHERE id_profesional = :idprof AND id_contrato = :idcontr AND TO_CHAR(fecha_primera_visita,'MONTH') = TO_CHAR(TO_DATE(:fecha1),'MONTH')", ora);

                            //comando5.Parameters.AddWithValue(":idprof", id_prof.Text);
                            //comando5.Parameters.AddWithValue(":idcontr", id_empresa.Text);
                            //comando5.Parameters.AddWithValue(":fecha1", monthCalendar1.SelectionRange.Start.ToShortDateString());
                            //OracleDataReader lector5 = comando5.ExecuteReader();

                            //if(monthCalendar1.SelectionRange.Start.ToShortDateString() < )


                            try
                            {

                                OracleCommand comando = new OracleCommand("SP_AGENDAR_VISITA", ora);
                                comando.CommandType = System.Data.CommandType.StoredProcedure;

                                comando.Parameters.Add("fecha1", OracleType.VarChar).Value = monthCalendar1.SelectionRange.Start.ToShortDateString();
                                comando.Parameters.Add("fecha2", OracleType.VarChar).Value = monthCalendar2.SelectionRange.Start.ToShortDateString();
                                comando.Parameters.Add("idcontrato", OracleType.VarChar).Value = id_empresa.Text;
                                comando.Parameters.Add("idprof", OracleType.VarChar).Value = id_prof.Text;
                                comando.Parameters.Add("hora1", OracleType.VarChar).Value = cb_dia1.SelectedItem;
                                comando.Parameters.Add("hora2", OracleType.VarChar).Value = cb_hora.SelectedItem;



                                comando.ExecuteNonQuery();
                                ora.Close();

                                MessageBox.Show("Visita Agendada Correctamente");

                            }
                            catch (Exception ex)
                            {
                                ora.Close();
                                MessageBox.Show("Hubo un error al Agendar las Fechas, Asegurese de llenar todos los campos, Que las dos Fechas sean del mismo Mes y que las fechas Elegidas no sean de un dia ya pasado ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


                            }
                        }


                        

                    }

                }
            }

            


                
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void Fecha_Load(object sender, EventArgs e)
        {

        }
    }
}
