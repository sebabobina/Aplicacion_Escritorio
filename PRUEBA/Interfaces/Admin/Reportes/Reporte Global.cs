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
    public partial class Reporte_Global : Form
    {
        OracleConnection ora = new OracleConnection("DATA SOURCE = ORCL; PASSWORD=123; USER ID= SEBA");
        public Reporte_Global()
        {
            InitializeComponent();
        }



        private void btn_reporte_global_Click(object sender, EventArgs e)
        {
            ora.Open();
            //PROFESIONALES
            OracleCommand mostrar = new OracleCommand("SP_MOSTRAR_PROFESIONAL", ora);
            mostrar.CommandType = System.Data.CommandType.StoredProcedure;
            mostrar.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;

            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = mostrar;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dga_prof.DataSource = tabla;


            //EMPRESAS REGISTRADAS
            OracleCommand mostrar3 = new OracleCommand("SP_MOSTRAR_CLIENTES_REGISTRADOS", ora);
            mostrar3.CommandType = System.Data.CommandType.StoredProcedure;
            mostrar3.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;

            OracleDataAdapter adaptador3 = new OracleDataAdapter();
            adaptador3.SelectCommand = mostrar3;
            DataTable tabla3 = new DataTable();
            adaptador3.Fill(tabla3);
            dgv_empresas_reg.DataSource = tabla3;


            //CAPACITACION
            OracleCommand mostrar2 = new OracleCommand("SP_CAPACITACIONES_DEL_MES", ora);
            mostrar2.CommandType = System.Data.CommandType.StoredProcedure;
            mostrar2.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;

            OracleDataAdapter adaptador2 = new OracleDataAdapter();
            adaptador2.SelectCommand = mostrar2;
            DataTable tabla2 = new DataTable();
            adaptador2.Fill(tabla2);
            dgv_capacitaciones.DataSource = tabla2;

            //ASESORIAS
            OracleCommand mostrar4 = new OracleCommand("SP_ASESORIAS_DEL_MES", ora);
            mostrar4.CommandType = System.Data.CommandType.StoredProcedure;
            mostrar4.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;

            OracleDataAdapter adaptador4 = new OracleDataAdapter();
            adaptador4.SelectCommand = mostrar4;
            DataTable tabla4 = new DataTable();
            adaptador4.Fill(tabla4);
            dgv_asesorias.DataSource = tabla4;


            //Visitas mes
            OracleCommand mostrar5 = new OracleCommand("SP_VISITAS_DEL_MES", ora);
            mostrar5.CommandType = System.Data.CommandType.StoredProcedure;
            mostrar5.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;

            OracleDataAdapter adaptador5 = new OracleDataAdapter();
            adaptador5.SelectCommand = mostrar5;
            DataTable tabla5 = new DataTable();
            adaptador5.Fill(tabla5);
            dgv_visitas_mes.DataSource = tabla5;

            //Pagos Mes
            OracleCommand mostrar6 = new OracleCommand("SP_PAGOS_MES", ora);
            mostrar6.CommandType = System.Data.CommandType.StoredProcedure;
            mostrar6.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;

            OracleDataAdapter adaptador6 = new OracleDataAdapter();
            adaptador6.SelectCommand = mostrar6;
            DataTable tabla6 = new DataTable();
            adaptador6.Fill(tabla6);
            dgv_pagos.DataSource = tabla6;










            SaveFileDialog guardar = new SaveFileDialog();
            guardar.FileName = DateTime.Now.ToString("ddMMyyyyHHmmss") + ".pdf";

            string filas = string.Empty;
            string filas2 = string.Empty;
            string filas3 = string.Empty;
            string filas4 = string.Empty;
            string filas5 = string.Empty;
            string filas6 = string.Empty;
            string filas7 = string.Empty;
            //decimal total = 0;


            string paginahtml_texto = Properties.Resources.reporte_global.ToString();
            //paginahtml_texto = paginahtml_texto.Replace("@RUT", dgvA.CurrentRow.Cells["RUT Empresa"].Value.ToString());
            //paginahtml_texto = paginahtml_texto.Replace("@NOMBRE", dgvA.CurrentRow.Cells["Nombre Empresa"].Value.ToString());
            //paginahtml_texto = paginahtml_texto.Replace("@EMAIL", dgvA.CurrentRow.Cells["Email"].Value.ToString());
            //paginahtml_texto = paginahtml_texto.Replace("@DIRECCION", dgvA.CurrentRow.Cells["Direccion"].Value.ToString());
            //paginahtml_texto = paginahtml_texto.Replace("@COMUNA", dgvA.CurrentRow.Cells["Comuna"].Value.ToString());
            //paginahtml_texto = paginahtml_texto.Replace("@TELEFONO", dgvA.CurrentRow.Cells["Telefono"].Value.ToString());
            //paginahtml_texto = paginahtml_texto.Replace("@RUBRO", dgvA.CurrentRow.Cells["Rubro"].Value.ToString());

            
            //ADMIN
            foreach (DataGridViewRow row in dgv_admin.Rows)
            {
                filas += "<tr>";
                filas += "<td>" + "<h6>"+ row.Cells["ID ADMIN"].Value.ToString()+ "</h6>"+ "</td>";
                filas += "<td>" + "<h6>" + row.Cells["RUT"].Value.ToString() + "</h6>" + "</td>";
                filas += "<td>" + "<h6>" + row.Cells["NOMBRE"].Value.ToString() + "</h6>" + "</td>";
                filas += "<td>" + "<h6>" + row.Cells["COMUNA"].Value.ToString() + "</h6>" + "</td>";
                filas += "<td>" + "<h6>" + row.Cells["EMAIL"].Value.ToString() + "</h6>" + "</td>";
                filas += "</tr>";
             }

            paginahtml_texto = paginahtml_texto.Replace("@ADMIN", filas);

            //PROF
            foreach (DataGridViewRow row in dga_prof.Rows)
            {
                filas2 += "<tr>";
                filas2 += "<td>" + "<h6>" + row.Cells["ID PROFESIONAL"].Value.ToString() + "</h6>" + "</td>";
                filas2 += "<td>" + "<h6>" + row.Cells["NOMBRE"].Value.ToString() + "</h6>" + "</td>";
                filas2 += "<td>" + "<h6>" + row.Cells["RUT"].Value.ToString() + "</h6>" + "</td>";
                filas2 += "<td>" + "<h6>" + row.Cells["PROFESION"].Value.ToString() + "</h6>" + "</td>";
                filas2 += "<td>" + "<h6>" + row.Cells["EMAIL"].Value.ToString() + "</h6>" + "</td>";
                filas2 += "</tr>";
            }

            paginahtml_texto = paginahtml_texto.Replace("@PROF", filas2);


            //Empresa Registradas
            foreach (DataGridViewRow row in dgv_empresas_reg.Rows)
            {
                filas3 += "<tr>";
                filas3 += "<td>" + "<h6>" + row.Cells["ID de Empresa"].Value.ToString() + "</h6>" + "</td>";
                filas3 += "<td>" + "<h6>" + row.Cells["Nombre Empresa"].Value.ToString() + "</h6>" + "</td>";
                filas3 += "<td>" + "<h6>" + row.Cells["RUT Empresa"].Value.ToString() + "</h6>" + "</td>";
                filas3 += "<td>" + "<h6>" + row.Cells["Rubro"].Value.ToString() + "</h6>" + "</td>";
                filas3 += "<td>" + "<h6>" + row.Cells["Email"].Value.ToString() + "</h6>" + "</td>";
                filas3 += "</tr>";
            }

            paginahtml_texto = paginahtml_texto.Replace("@REGISTRADAS", filas3);


            //CAPACITACIONES
            foreach (DataGridViewRow row in dgv_capacitaciones.Rows)
            {
                filas4 += "<tr>";
                filas4 += "<td>" + "<h6>" + row.Cells["EMPRESA"].Value.ToString() + "</h6>" + "</td>";
                filas4 += "<td>" + "<h6>" + row.Cells["NOMBRE"].Value.ToString() + "</h6>" + "</td>";
                filas4 += "<td>" + "<h6>" + row.Cells["PROFESIONAL"].Value.ToString() + "</h6>" + "</td>";
                filas4 += "<td>" + "<h6>" + row.Cells["Fecha"].Value.ToString() + "</h6>" + "</td>";
                filas4 += "<td>" + "<h6>" + row.Cells["HORA"].Value.ToString() + "</h6>" + "</td>";
                filas4 += "<td>" + "<h6>" + row.Cells["ASISTENTES"].Value.ToString() + "</h6>" + "</td>";
                filas4 += "</tr>";
            }

            paginahtml_texto = paginahtml_texto.Replace("@CAPACITACIONES", filas4);


            //ASESORIAS
            foreach (DataGridViewRow row in dgv_asesorias.Rows)
            {
                filas5 += "<tr>";
                filas5 += "<td>" + "<h6>" + row.Cells["EMPRESA"].Value.ToString() + "</h6>" + "</td>";
                filas5 += "<td>" + "<h6>" + row.Cells["NOMBRE"].Value.ToString() + "</h6>" + "</td>";
                filas5 += "<td>" + "<h6>" + row.Cells["PROPUESTA_MEJORA"].Value.ToString() + "</h6>" + "</td>";
                filas5 += "<td>" + "<h6>" + row.Cells["ESTADO_MEJORA"].Value.ToString() + "</h6>" + "</td>";
                filas5 += "<td>" + "<h6>" + row.Cells["PROFESIONAL"].Value.ToString() + "</h6>" + "</td>";
                filas5 += "</tr>";
            }

            paginahtml_texto = paginahtml_texto.Replace("@ASESORIAS", filas5);

            //VISITAS
            foreach (DataGridViewRow row in dgv_visitas_mes.Rows)
            {
                filas6 += "<tr>";
                filas6 += "<td>" + "<h6>" + row.Cells["Nombre Empresa"].Value.ToString() + "</h6>" + "</td>";
                filas6 += "<td>" + "<h6>" + row.Cells["mes"].Value.ToString() + "</h6>" + "</td>";
                filas6 += "<td>" + "<h6>" + row.Cells["Primera visita"].Value.ToString() + "</h6>" + "</td>";
                filas6 += "<td>" + "<h6>" + row.Cells["Hora primera"].Value.ToString() + "</h6>" + "</td>";
                filas6 += "<td>" + "<h6>" + row.Cells["segunda visita"].Value.ToString() + "</h6>" + "</td>";
                filas6 += "<td>" + "<h6>" + row.Cells["hora segunda"].Value.ToString() + "</h6>" + "</td>";
                filas6 += "<td>" + "<h6>" + row.Cells["Nombre Profesional"].Value.ToString() + "</h6>" + "</td>";
                filas6 += "</tr>";
            }

            paginahtml_texto = paginahtml_texto.Replace("@VISITAS", filas6);

            //MONTOS
            foreach (DataGridViewRow row in dgv_pagos.Rows)
            {
                filas7 += "<tr>";
                filas7 += "<td>" + "<h6>" + row.Cells["NOMBRE"].Value.ToString() + "</h6>" + "</td>";
                filas7 += "<td>" + "<h6>" + row.Cells["FECHA"].Value.ToString() + "</h6>" + "</td>";
                filas7 += "<td>" + "<h6>" + row.Cells["MONTO"].Value.ToString() + "</h6>" + "</td>";
                filas7 += "<td>" + "<h6>" + row.Cells["ESTADO"].Value.ToString() + "</h6>" + "</td>";
                filas7 += "</tr>";
            }

            paginahtml_texto = paginahtml_texto.Replace("@PAGOS", filas7);





            //OracleCommand comando = new OracleCommand("SELECT ID_USUARIO, NOMBRE_USUARIO, CONTRASENA, ID_EMPRESA  FROM USUARIO WHERE ID_EMPRESA = :idcl ", ora);

            //comando.Parameters.AddWithValue(":idcl", dgvA.CurrentRow.Cells["ID de Empresa"].Value.ToString());

            //OracleDataReader lector = comando.ExecuteReader();

            //lector.Read();




            //paginahtml_texto = paginahtml_texto.Replace("@IDEMP", lector["ID_EMPRESA"].ToString());
            //paginahtml_texto = paginahtml_texto.Replace("@ID_USR", lector["ID_USUARIO"].ToString());
            //paginahtml_texto = paginahtml_texto.Replace("@USERNAME", lector["NOMBRE_USUARIO"].ToString());
            //paginahtml_texto = paginahtml_texto.Replace("@PASS", lector["CONTRASENA"].ToString());




            //OracleCommand comando2 = new OracleCommand("SELECT p.id_profesional, u.id_usuario, p.RUT, p.NOMBRE_PROFESIONAL, prof.nombre_profesion FROM PROFESIONAL p INNER JOIN USUARIO u ON u.id_profesional = p.id_profesional INNER JOIN profesion prof On prof.id_profesion = p.id_profesion INNER JOIN contrato con ON p.id_profesional = con.id_profesional where con.id_empresa = :idcl", ora);

            //comando2.Parameters.AddWithValue(":idcl", dgvA.CurrentRow.Cells["ID de Empresa"].Value.ToString());

            //OracleDataReader lector2 = comando2.ExecuteReader();

            //lector2.Read();

            //paginahtml_texto = paginahtml_texto.Replace("@ID_PROF", lector2["ID_PROFESIONAL"].ToString());
            //paginahtml_texto = paginahtml_texto.Replace("@IDUSR_PROF", lector2["ID_USUARIO"].ToString());
            //paginahtml_texto = paginahtml_texto.Replace("@RUPROF", lector2["RUT"].ToString());
            //paginahtml_texto = paginahtml_texto.Replace("@NOMPROF", lector2["NOMBRE_PROFESIONAL"].ToString());
            //paginahtml_texto = paginahtml_texto.Replace("@PROFESION", lector2["NOMBRE_PROFESION"].ToString());





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

        

        private void Reporte_Global_Load(object sender, EventArgs e)
        {
            ora.Open();
            OracleCommand mostrar = new OracleCommand("SP_MOSTRAR_ADMIN", ora);
            mostrar.CommandType = System.Data.CommandType.StoredProcedure;
            mostrar.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;

            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = mostrar;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dgv_admin.DataSource = tabla;
            ora.Close();
        }
    }
}
