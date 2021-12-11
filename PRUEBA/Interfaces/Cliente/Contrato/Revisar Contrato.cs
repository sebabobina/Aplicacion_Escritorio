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

namespace PRUEBA.Interfaces.Cliente.Contrato
{
    public partial class Revisar_Contrato : Form
    {
        OracleConnection ora = new OracleConnection("DATA SOURCE = ORCL; PASSWORD=123; USER ID= SEBA");
        public Revisar_Contrato()
        {
            InitializeComponent();
        }

        private void Revisar_Contrato_Load(object sender, EventArgs e)
        {
            ora.Open();
            OracleCommand comando = new OracleCommand("SELECT DISTINCT TO_CHAR(contr.fecha_contrato,'DD/MM/YYYY') as fecha, emp.nombre_empresa as nombreemp,prof.nombre_profesional as nombreprof, TO_CHAR(cp.monto_total,'$999G999G999') as monto FROM CONTRATO contr inner join empresa emp on emp.id_empresa = contr.id_empresa inner join profesional prof on prof.id_profesional = contr.id_profesional INNER JOIN CONTROL_PAGOS cp on cp.id_contrato = contr.id_contrato where contr.id_contrato = :idcont", ora);

            comando.Parameters.AddWithValue(":idcont", id_contr.Text);

            OracleDataReader lector = comando.ExecuteReader();

            lector.Read();

            lbl_fechaContrato.Text = lector["fecha"].ToString();
            lbl_monto.Text = lector["monto"].ToString();
            lbl_nombreemp.Text = lector["nombreemp"].ToString();
            lbl_nombreprof.Text = lector["nombreprof"].ToString();




            ora.Close();

        }
    }
}
