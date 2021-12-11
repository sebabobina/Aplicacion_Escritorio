using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System.IO;
using System.Data.OracleClient;

namespace PRUEBA.Interfaces.Admin.Reportes
{
    public partial class Reporte_Cliente : Form
    {
        OracleConnection ora = new OracleConnection("DATA SOURCE = ORCL; PASSWORD=123; USER ID= SEBA");
        public Reporte_Cliente()
        {
            InitializeComponent();
        }

        private void btn_imprimir_Click(object sender, EventArgs e)
        {
            ora.Open();
            //FECHAS
            OracleCommand mostrar = new OracleCommand("SP_MOSTRAR_FECHAS_ID", ora);
            mostrar.CommandType = System.Data.CommandType.StoredProcedure;
            mostrar.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;
            mostrar.Parameters.Add("ids", OracleType.VarChar).Value = dgvA.CurrentRow.Cells["ID de Empresa"].Value.ToString();

            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = mostrar;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dgv_fechas.DataSource = tabla;


            //ASESORIAS
            OracleCommand mostrar3 = new OracleCommand("SP_MOSTRAR_ASESORIAS_ID", ora);
            mostrar3.CommandType = System.Data.CommandType.StoredProcedure;
            mostrar3.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;
            mostrar3.Parameters.Add("ids", OracleType.VarChar).Value = dgvA.CurrentRow.Cells["ID de Empresa"].Value.ToString();

            OracleDataAdapter adaptador3 = new OracleDataAdapter();
            adaptador3.SelectCommand = mostrar3;
            DataTable tabla3 = new DataTable();
            adaptador3.Fill(tabla3);
            dgv_asesoria.DataSource = tabla3;


            //CAPACITACION
            OracleCommand mostrar2 = new OracleCommand("SP_MOSTRAR_CAPACITACION_ID", ora);
            mostrar2.CommandType = System.Data.CommandType.StoredProcedure;
            mostrar2.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;
            mostrar2.Parameters.Add("idemp", OracleType.VarChar).Value = dgvA.CurrentRow.Cells["ID de Empresa"].Value.ToString();

            OracleDataAdapter adaptador2 = new OracleDataAdapter();
            adaptador2.SelectCommand = mostrar2;
            DataTable tabla2 = new DataTable();
            adaptador2.Fill(tabla2);
            dgv_capacitaciones.DataSource = tabla2;

            //CHELIST
            OracleCommand mostrar4 = new OracleCommand("SP_VER_CLIENTES_CHECKLIST_ID", ora);
            mostrar4.CommandType = System.Data.CommandType.StoredProcedure;
            mostrar4.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;
            mostrar4.Parameters.Add("idempr", OracleType.VarChar).Value = dgvA.CurrentRow.Cells["ID de Empresa"].Value.ToString();

            OracleDataAdapter adaptador4 = new OracleDataAdapter();
            adaptador4.SelectCommand = mostrar4;
            DataTable tabla4 = new DataTable();
            adaptador4.Fill(tabla4);
            dga_checkl.DataSource = tabla4;


            //ACCIDENTES
            OracleCommand mostrar5 = new OracleCommand("SP_MOSTRAR_ACCIDENTES_POR_EMPRESA_ID", ora);
            mostrar5.CommandType = System.Data.CommandType.StoredProcedure;
            mostrar5.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;
            mostrar5.Parameters.Add("idc", OracleType.VarChar).Value = dgvA.CurrentRow.Cells["ID de Empresa"].Value.ToString();

            OracleDataAdapter adaptador5 = new OracleDataAdapter();
            adaptador5.SelectCommand = mostrar5;
            DataTable tabla5 = new DataTable();
            adaptador5.Fill(tabla5);
            dgv_accidente.DataSource = tabla5;

            //HISTORIAL
            OracleCommand mostrar6 = new OracleCommand("SP_VER_ACTIVIDAD_CLIENTE_ID", ora);
            mostrar6.CommandType = System.Data.CommandType.StoredProcedure;
            mostrar6.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;
            mostrar6.Parameters.Add("idpr", OracleType.VarChar).Value = dgvA.CurrentRow.Cells["ID de Empresa"].Value.ToString();

            OracleDataAdapter adaptador6 = new OracleDataAdapter();
            adaptador6.SelectCommand = mostrar6;
            DataTable tabla6 = new DataTable();
            adaptador6.Fill(tabla6);
            dgv_historial.DataSource = tabla6;










            SaveFileDialog guardar = new SaveFileDialog();
            guardar.FileName = DateTime.Now.ToString("ddMMyyyyHHmmss") + ".pdf";

            string filas = string.Empty;
            string filas2 = string.Empty;
            string filas3 = string.Empty;
            string filas4 = string.Empty;
            string filas5 = string.Empty;
            string filas6 = string.Empty;
            decimal total = 0;

            
            string paginahtml_texto = Properties.Resources.CLEINTES_PDF.ToString();
            paginahtml_texto = paginahtml_texto.Replace("@RUT", dgvA.CurrentRow.Cells["RUT Empresa"].Value.ToString());
            paginahtml_texto = paginahtml_texto.Replace("@NOMBRE", dgvA.CurrentRow.Cells["Nombre Empresa"].Value.ToString());
            paginahtml_texto = paginahtml_texto.Replace("@EMAIL", dgvA.CurrentRow.Cells["Email"].Value.ToString());
            paginahtml_texto = paginahtml_texto.Replace("@DIRECCION", dgvA.CurrentRow.Cells["Direccion"].Value.ToString());
            paginahtml_texto = paginahtml_texto.Replace("@COMUNA", dgvA.CurrentRow.Cells["Comuna"].Value.ToString());
            paginahtml_texto = paginahtml_texto.Replace("@TELEFONO", dgvA.CurrentRow.Cells["Telefono"].Value.ToString());
            paginahtml_texto = paginahtml_texto.Replace("@RUBRO", dgvA.CurrentRow.Cells["Rubro"].Value.ToString());

            
            //FECHAS
            foreach (DataGridViewRow row in dgv_fechas.Rows)
            {
                filas += "<tr>";
                filas += "<td>" + row.Cells["FECHA PRIMERA VISITA"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["HORA PRIMERA VISITA"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["FECHA SEGUNDA VISITA"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["HORA SEGUNDA VISITA"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["MES"].Value.ToString() + "</td>";
                filas += "</tr>";
             }

            paginahtml_texto = paginahtml_texto.Replace("@FILAS", filas);

            //CAPACITACION
            foreach (DataGridViewRow row in dgv_capacitaciones.Rows)
            {
                filas2 += "<tr>";
                filas2 += "<td>" + row.Cells["NOMBRE CAPACITACION"].Value.ToString() + "</td>";
                filas2 += "<td>" + row.Cells["FECHA"].Value.ToString() + "</td>";
                filas2 += "<td>" + row.Cells["HORA"].Value.ToString() + "</td>";
                filas2 += "<td>" + row.Cells["ASISTENTES"].Value.ToString() + "</td>";
                filas2 += "</tr>";
            }

            paginahtml_texto = paginahtml_texto.Replace("@CAPACITACIONES", filas2);


            //ASESORIA
            foreach (DataGridViewRow row in dgv_asesoria.Rows)
            {
                filas3 += "<tr>";
                filas3 += "<td>" + row.Cells["ID Asesoria"].Value.ToString() + "</td>";
                filas3 += "<td>" + row.Cells["Descripcion"].Value.ToString() + "</td>";
                filas3 += "<td>" + row.Cells["ID Propuesta"].Value.ToString() + "</td>";
                filas3 += "<td>" + row.Cells["Propuesta de Mejora"].Value.ToString() + "</td>";
                filas3 += "<td>" + row.Cells["Estado Mejora"].Value.ToString() + "</td>";
                filas3 += "</tr>";
            }

            paginahtml_texto = paginahtml_texto.Replace("@ASESORIAS", filas3);


            //CHECKLIST
            foreach (DataGridViewRow row in dga_checkl.Rows)
            {
                filas4 += "<tr>";
                filas4 += "<td>" + row.Cells["ID_CHECKEO"].Value.ToString() + "</td>";
                filas4 += "<td>" + row.Cells["descripcion"].Value.ToString() + "</td>";
                filas4 += "<td>" + row.Cells["estado"].Value.ToString() + "</td>";
                filas4 += "</tr>";
            }

            paginahtml_texto = paginahtml_texto.Replace("@LISTACHEQUEO", filas4);


            //ACCIDENTES
            foreach (DataGridViewRow row in dgv_accidente.Rows)
            {
                filas5 += "<tr>";
                filas5 += "<td>" + row.Cells["ACCIDENTE"].Value.ToString() + "</td>";
                filas5 += "<td>" + row.Cells["DESCRIPCION"].Value.ToString() + "</td>";
                filas5 += "<td>" + row.Cells["FECHA/HORA"].Value.ToString() + "</td>";
                filas5 += "</tr>";
            }

            paginahtml_texto = paginahtml_texto.Replace("@ACCIDENTES", filas5);

            //HISTORIAL
            foreach (DataGridViewRow row in dgv_historial.Rows)
            {
                filas6 += "<tr>";
                filas6 += "<td>" + row.Cells["ACTIVIDAD"].Value.ToString() + "</td>";
                filas6 += "<td>" + row.Cells["FECHA"].Value.ToString() + "</td>";
                filas6 += "</tr>";
            }

            paginahtml_texto = paginahtml_texto.Replace("@HISTORIAL", filas6);





            OracleCommand comando = new OracleCommand("SELECT ID_USUARIO, NOMBRE_USUARIO, CONTRASENA, ID_EMPRESA  FROM USUARIO WHERE ID_EMPRESA = :idcl ", ora);

            comando.Parameters.AddWithValue(":idcl", dgvA.CurrentRow.Cells["ID de Empresa"].Value.ToString());

            OracleDataReader lector = comando.ExecuteReader();

            lector.Read();




            paginahtml_texto = paginahtml_texto.Replace("@IDEMP", lector["ID_EMPRESA"].ToString());
            paginahtml_texto = paginahtml_texto.Replace("@ID_USR", lector["ID_USUARIO"].ToString());
            paginahtml_texto = paginahtml_texto.Replace("@USERNAME", lector["NOMBRE_USUARIO"].ToString());
            paginahtml_texto = paginahtml_texto.Replace("@PASS", lector["CONTRASENA"].ToString());




            OracleCommand comando2 = new OracleCommand("SELECT p.id_profesional, u.id_usuario, p.RUT, p.NOMBRE_PROFESIONAL, prof.nombre_profesion FROM PROFESIONAL p INNER JOIN USUARIO u ON u.id_profesional = p.id_profesional INNER JOIN profesion prof On prof.id_profesion = p.id_profesion INNER JOIN contrato con ON p.id_profesional = con.id_profesional where con.id_empresa = :idcl", ora);

            comando2.Parameters.AddWithValue(":idcl", dgvA.CurrentRow.Cells["ID de Empresa"].Value.ToString());

            OracleDataReader lector2 = comando2.ExecuteReader();

            lector2.Read();

            paginahtml_texto = paginahtml_texto.Replace("@ID_PROF", lector2["ID_PROFESIONAL"].ToString());
            paginahtml_texto = paginahtml_texto.Replace("@IDUSR_PROF", lector2["ID_USUARIO"].ToString());
            paginahtml_texto = paginahtml_texto.Replace("@RUPROF", lector2["RUT"].ToString());
            paginahtml_texto = paginahtml_texto.Replace("@NOMPROF", lector2["NOMBRE_PROFESIONAL"].ToString());
            paginahtml_texto = paginahtml_texto.Replace("@PROFESION", lector2["NOMBRE_PROFESION"].ToString());





            ora.Close();


            if (guardar.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(guardar.FileName, FileMode.Create))
                {
                    Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 25);

                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);

                    pdfDoc.Open();

                    pdfDoc.Add(new Phrase(""));

                    using (StringReader sr = new StringReader(paginahtml_texto))
                    {
                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);

                    }

                        pdfDoc.Close();

                    stream.Close();
                }

                    
            } 


        }

        private void Reporte_Cliente_Load(object sender, EventArgs e)
        {
            ora.Open();
            OracleCommand mostrar = new OracleCommand("SP_MOSTRAR_CLIENTES_REGISTRADOS", ora);
            mostrar.CommandType = System.Data.CommandType.StoredProcedure;
            mostrar.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;

            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = mostrar;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dgvA.DataSource = tabla;
            ora.Close();
        }

        private void txt_buscar_emp_KeyUp(object sender, KeyEventArgs e)
        {
            ora.Open();

            OracleCommand mostrar = new OracleCommand("SP_BUSCAR_EMPRESA_REGISTRADA", ora);
            mostrar.CommandType = System.Data.CommandType.StoredProcedure;
            mostrar.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;
            mostrar.Parameters.Add("nombre", OracleType.VarChar).Value = txt_buscar_emp.Text;

            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = mostrar;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dgvA.DataSource = tabla;

            ora.Close();
        }
    }
}
