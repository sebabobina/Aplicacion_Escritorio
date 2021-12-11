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
    public partial class Ver_Accidentes_Clientes : Form
    {
        OracleConnection ora = new OracleConnection("DATA SOURCE = ORCL; PASSWORD=123; USER ID= SEBA");
        public Ver_Accidentes_Clientes()
        {
            InitializeComponent();
        }

        private void Ver_Accidentes_Clientes_Load(object sender, EventArgs e)
        {
            nivel.Visible = false;
            ora.Open();
            OracleCommand mostrar = new OracleCommand("SP_MOSTRAR_ACCIDENTES_POR_EMPRESA", ora);
            mostrar.CommandType = System.Data.CommandType.StoredProcedure;

            mostrar.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;
            mostrar.Parameters.Add("idc", OracleType.VarChar).Value = lbl_idcontr.Text;

            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = mostrar;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dgvA.DataSource = tabla;
            ora.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ora.Open();
            OracleCommand mostrar = new OracleCommand("SP_MOSTRAR_ACCIDENTES_POR_EMPRESA_POR_MES", ora);
            mostrar.CommandType = System.Data.CommandType.StoredProcedure;

            mostrar.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;
            mostrar.Parameters.Add("idc", OracleType.VarChar).Value = lbl_idcontr.Text;
            mostrar.Parameters.Add("fecha", OracleType.VarChar).Value = monthCalendar1.SelectionRange.Start.ToShortDateString();

            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = mostrar;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dgvA.DataSource = tabla;



            OracleCommand mostrar1 = new OracleCommand("SP_MOSTRAR_ACCIDENTES_FECHA", ora);
            mostrar1.CommandType = System.Data.CommandType.StoredProcedure;

            mostrar1.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;
            mostrar1.Parameters.Add("idc", OracleType.VarChar).Value = lbl_idcontr.Text;
            mostrar1.Parameters.Add("fecha", OracleType.VarChar).Value = monthCalendar1.SelectionRange.Start.ToShortDateString();

            OracleDataAdapter adaptador1 = new OracleDataAdapter();
            adaptador1.SelectCommand = mostrar1;
            DataTable tabla1 = new DataTable();
            adaptador1.Fill(tabla1);
            datagrid1.DataSource = tabla1;


            lbl_numero.Text = datagrid1.CurrentRow.Cells["numero"].Value.ToString();


            if (int.Parse(lbl_numero.Text) > 20 )
            {
                nivel.Text = "Muy Malo";
                nivel.ForeColor = Color.Red;
                nivel.Visible = true;

            }

            else if (int.Parse(lbl_numero.Text) > 13)
            {
                nivel.Text = "Malo";
                nivel.ForeColor = Color.OrangeRed;
                nivel.Visible = true;

            }



            else if ((int.Parse(lbl_numero.Text) > 7))
            {
                nivel.Text = "Regular";
                nivel.ForeColor = Color.Yellow;
                nivel.Visible = true;
            }

            else if ((int.Parse(lbl_numero.Text) <= 7 ))
            {
                nivel.Text = "Bueno";
                nivel.ForeColor = Color.Green;
                nivel.Visible = true;
            }





            ora.Close();
        }
    }
}
