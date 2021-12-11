
namespace PRUEBA
{
    partial class Modificar_Capacitacion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.cb_hora = new System.Windows.Forms.ComboBox();
            this.txt_num_asistentes = new System.Windows.Forms.TextBox();
            this.txt_nombre_capacitacion = new System.Windows.Forms.TextBox();
            this.lbl_id_contrato = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(560, 398);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(202, 50);
            this.button1.TabIndex = 13;
            this.button1.Text = "GUARDAR";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Font = new System.Drawing.Font("Century Gothic", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.monthCalendar1.Location = new System.Drawing.Point(435, 69);
            this.monthCalendar1.MaxDate = new System.DateTime(2030, 12, 31, 0, 0, 0, 0);
            this.monthCalendar1.MaxSelectionCount = 1;
            this.monthCalendar1.MinDate = new System.DateTime(2021, 11, 1, 0, 0, 0, 0);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 12;
            // 
            // cb_hora
            // 
            this.cb_hora.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_hora.FormattingEnabled = true;
            this.cb_hora.Location = new System.Drawing.Point(693, 138);
            this.cb_hora.Name = "cb_hora";
            this.cb_hora.Size = new System.Drawing.Size(121, 32);
            this.cb_hora.TabIndex = 11;
            // 
            // txt_num_asistentes
            // 
            this.txt_num_asistentes.Location = new System.Drawing.Point(827, 312);
            this.txt_num_asistentes.Name = "txt_num_asistentes";
            this.txt_num_asistentes.Size = new System.Drawing.Size(100, 20);
            this.txt_num_asistentes.TabIndex = 10;
            // 
            // txt_nombre_capacitacion
            // 
            this.txt_nombre_capacitacion.Location = new System.Drawing.Point(352, 312);
            this.txt_nombre_capacitacion.Name = "txt_nombre_capacitacion";
            this.txt_nombre_capacitacion.Size = new System.Drawing.Size(305, 20);
            this.txt_nombre_capacitacion.TabIndex = 9;
            // 
            // lbl_id_contrato
            // 
            this.lbl_id_contrato.AutoSize = true;
            this.lbl_id_contrato.Location = new System.Drawing.Point(942, 53);
            this.lbl_id_contrato.Name = "lbl_id_contrato";
            this.lbl_id_contrato.Size = new System.Drawing.Size(35, 13);
            this.lbl_id_contrato.TabIndex = 14;
            this.lbl_id_contrato.Text = "label1";
            // 
            // Modificar_Capacitacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.ClientSize = new System.Drawing.Size(1311, 632);
            this.Controls.Add(this.lbl_id_contrato);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.cb_hora);
            this.Controls.Add(this.txt_num_asistentes);
            this.Controls.Add(this.txt_nombre_capacitacion);
            this.Name = "Modificar_Capacitacion";
            this.Text = "Modificar_Capacitacion";
            this.Load += new System.EventHandler(this.Modificar_Capacitacion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.Label lbl_id_contrato;
        public System.Windows.Forms.MonthCalendar monthCalendar1;
        public System.Windows.Forms.ComboBox cb_hora;
        public System.Windows.Forms.TextBox txt_num_asistentes;
        public System.Windows.Forms.TextBox txt_nombre_capacitacion;
    }
}