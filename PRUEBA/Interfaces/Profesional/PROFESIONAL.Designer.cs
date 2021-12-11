
namespace PRUEBA
{
    partial class PROFESIONAL
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PROFESIONAL));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_minimizar = new System.Windows.Forms.PictureBox();
            this.btn_cerrar = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button6 = new System.Windows.Forms.Button();
            this.panel_asesorias = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel_capacitaciones = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.btn_profesional = new System.Windows.Forms.Button();
            this.panel_cliente = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.btn_registrar_cliente = new System.Windows.Forms.Button();
            this.btn_Cliente = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel_child_form = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Hora = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.username = new System.Windows.Forms.Label();
            this.horafecha = new System.Windows.Forms.Timer(this.components);
            this.button7 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_minimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_cerrar)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel_asesorias.SuspendLayout();
            this.panel_capacitaciones.SuspendLayout();
            this.panel_cliente.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel_child_form.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.panel1.Controls.Add(this.btn_minimizar);
            this.panel1.Controls.Add(this.btn_cerrar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1664, 33);
            this.panel1.TabIndex = 6;
            // 
            // btn_minimizar
            // 
            this.btn_minimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_minimizar.Image = ((System.Drawing.Image)(resources.GetObject("btn_minimizar.Image")));
            this.btn_minimizar.Location = new System.Drawing.Point(1608, 12);
            this.btn_minimizar.Name = "btn_minimizar";
            this.btn_minimizar.Size = new System.Drawing.Size(25, 25);
            this.btn_minimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btn_minimizar.TabIndex = 2;
            this.btn_minimizar.TabStop = false;
            this.btn_minimizar.Click += new System.EventHandler(this.btn_minimizar_Click);
            // 
            // btn_cerrar
            // 
            this.btn_cerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_cerrar.Image = ((System.Drawing.Image)(resources.GetObject("btn_cerrar.Image")));
            this.btn_cerrar.Location = new System.Drawing.Point(1639, 5);
            this.btn_cerrar.Name = "btn_cerrar";
            this.btn_cerrar.Size = new System.Drawing.Size(25, 25);
            this.btn_cerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btn_cerrar.TabIndex = 2;
            this.btn_cerrar.TabStop = false;
            this.btn_cerrar.Click += new System.EventHandler(this.btn_cerrar_Click);
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.panel2.Controls.Add(this.button6);
            this.panel2.Controls.Add(this.panel_asesorias);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.panel_capacitaciones);
            this.panel2.Controls.Add(this.btn_profesional);
            this.panel2.Controls.Add(this.panel_cliente);
            this.panel2.Controls.Add(this.btn_Cliente);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 33);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(257, 912);
            this.panel2.TabIndex = 7;
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold);
            this.button6.Location = new System.Drawing.Point(22, 783);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(204, 51);
            this.button6.TabIndex = 12;
            this.button6.Text = "CERRAR SESION";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // panel_asesorias
            // 
            this.panel_asesorias.AutoScroll = true;
            this.panel_asesorias.BackColor = System.Drawing.Color.Gray;
            this.panel_asesorias.Controls.Add(this.button3);
            this.panel_asesorias.Controls.Add(this.button10);
            this.panel_asesorias.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_asesorias.Location = new System.Drawing.Point(0, 525);
            this.panel_asesorias.Name = "panel_asesorias";
            this.panel_asesorias.Size = new System.Drawing.Size(257, 88);
            this.panel_asesorias.TabIndex = 5;
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Top;
            this.button3.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.button3.Location = new System.Drawing.Point(0, 43);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(257, 42);
            this.button3.TabIndex = 2;
            this.button3.Text = "Revisar Estado Mejora";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button10
            // 
            this.button10.Dock = System.Windows.Forms.DockStyle.Top;
            this.button10.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.button10.Location = new System.Drawing.Point(0, 0);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(257, 43);
            this.button10.TabIndex = 0;
            this.button10.Text = "Crear Asesoria";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(0, 480);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(257, 45);
            this.button1.TabIndex = 4;
            this.button1.Text = "Asesorias";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // panel_capacitaciones
            // 
            this.panel_capacitaciones.AutoScroll = true;
            this.panel_capacitaciones.BackColor = System.Drawing.Color.Gray;
            this.panel_capacitaciones.Controls.Add(this.button2);
            this.panel_capacitaciones.Controls.Add(this.button9);
            this.panel_capacitaciones.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_capacitaciones.Location = new System.Drawing.Point(0, 395);
            this.panel_capacitaciones.Name = "panel_capacitaciones";
            this.panel_capacitaciones.Size = new System.Drawing.Size(257, 85);
            this.panel_capacitaciones.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Top;
            this.button2.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.button2.Location = new System.Drawing.Point(0, 42);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(257, 43);
            this.button2.TabIndex = 1;
            this.button2.Text = "Revisar Capacitacion";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button9
            // 
            this.button9.Dock = System.Windows.Forms.DockStyle.Top;
            this.button9.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.button9.Location = new System.Drawing.Point(0, 0);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(257, 42);
            this.button9.TabIndex = 0;
            this.button9.Text = "Crear Capacitacion";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // btn_profesional
            // 
            this.btn_profesional.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btn_profesional.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_profesional.FlatAppearance.BorderSize = 0;
            this.btn_profesional.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_profesional.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_profesional.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.btn_profesional.ForeColor = System.Drawing.Color.White;
            this.btn_profesional.Location = new System.Drawing.Point(0, 350);
            this.btn_profesional.Name = "btn_profesional";
            this.btn_profesional.Size = new System.Drawing.Size(257, 45);
            this.btn_profesional.TabIndex = 2;
            this.btn_profesional.Text = "Capacitaciones";
            this.btn_profesional.UseVisualStyleBackColor = false;
            this.btn_profesional.Click += new System.EventHandler(this.btn_profesional_Click);
            // 
            // panel_cliente
            // 
            this.panel_cliente.BackColor = System.Drawing.Color.Gray;
            this.panel_cliente.Controls.Add(this.button7);
            this.panel_cliente.Controls.Add(this.button4);
            this.panel_cliente.Controls.Add(this.button5);
            this.panel_cliente.Controls.Add(this.btn_registrar_cliente);
            this.panel_cliente.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_cliente.Location = new System.Drawing.Point(0, 173);
            this.panel_cliente.Name = "panel_cliente";
            this.panel_cliente.Size = new System.Drawing.Size(257, 177);
            this.panel_cliente.TabIndex = 0;
            // 
            // button4
            // 
            this.button4.Dock = System.Windows.Forms.DockStyle.Top;
            this.button4.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.button4.Location = new System.Drawing.Point(0, 87);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(257, 44);
            this.button4.TabIndex = 5;
            this.button4.Text = "CheckList";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Silver;
            this.button5.Dock = System.Windows.Forms.DockStyle.Top;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.button5.Location = new System.Drawing.Point(0, 43);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(257, 44);
            this.button5.TabIndex = 3;
            this.button5.Text = "Visitas";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // btn_registrar_cliente
            // 
            this.btn_registrar_cliente.BackColor = System.Drawing.Color.Silver;
            this.btn_registrar_cliente.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_registrar_cliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_registrar_cliente.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.btn_registrar_cliente.Location = new System.Drawing.Point(0, 0);
            this.btn_registrar_cliente.Name = "btn_registrar_cliente";
            this.btn_registrar_cliente.Size = new System.Drawing.Size(257, 43);
            this.btn_registrar_cliente.TabIndex = 0;
            this.btn_registrar_cliente.Text = "Revisar Cliente";
            this.btn_registrar_cliente.UseVisualStyleBackColor = false;
            this.btn_registrar_cliente.Click += new System.EventHandler(this.btn_registrar_cliente_Click);
            // 
            // btn_Cliente
            // 
            this.btn_Cliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btn_Cliente.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_Cliente.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_Cliente.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_Cliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Cliente.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.btn_Cliente.ForeColor = System.Drawing.Color.White;
            this.btn_Cliente.Image = ((System.Drawing.Image)(resources.GetObject("btn_Cliente.Image")));
            this.btn_Cliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Cliente.Location = new System.Drawing.Point(0, 128);
            this.btn_Cliente.Name = "btn_Cliente";
            this.btn_Cliente.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btn_Cliente.Size = new System.Drawing.Size(257, 45);
            this.btn_Cliente.TabIndex = 1;
            this.btn_Cliente.Text = "Cliente";
            this.btn_Cliente.UseVisualStyleBackColor = false;
            this.btn_Cliente.Click += new System.EventHandler(this.btn_Cliente_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.pictureBox2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(257, 128);
            this.panel3.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.label1.Font = new System.Drawing.Font("Century Gothic", 27.75F, System.Drawing.FontStyle.Italic);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(44, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 44);
            this.label1.TabIndex = 5;
            this.label1.Text = "BIG BRO";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(0, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(257, 75);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // panel_child_form
            // 
            this.panel_child_form.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.panel_child_form.Controls.Add(this.label4);
            this.panel_child_form.Controls.Add(this.pictureBox1);
            this.panel_child_form.Controls.Add(this.label3);
            this.panel_child_form.Controls.Add(this.Hora);
            this.panel_child_form.Controls.Add(this.label2);
            this.panel_child_form.Controls.Add(this.username);
            this.panel_child_form.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel_child_form.Location = new System.Drawing.Point(263, 43);
            this.panel_child_form.Name = "panel_child_form";
            this.panel_child_form.Size = new System.Drawing.Size(1401, 987);
            this.panel_child_form.TabIndex = 8;
            this.panel_child_form.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_child_form_Paint);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(556, 565);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(292, 78);
            this.label4.TabIndex = 8;
            this.label4.Text = "BIG BRO";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(298, 189);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(782, 348);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "label3";
            this.label3.Visible = false;
            // 
            // Hora
            // 
            this.Hora.AutoSize = true;
            this.Hora.Font = new System.Drawing.Font("Century Gothic", 72F, System.Drawing.FontStyle.Bold);
            this.Hora.Location = new System.Drawing.Point(532, 788);
            this.Hora.Name = "Hora";
            this.Hora.Size = new System.Drawing.Size(334, 112);
            this.Hora.TabIndex = 5;
            this.Hora.Text = "label3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 36F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(260, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(299, 56);
            this.label2.TabIndex = 4;
            this.label2.Text = "Bienvenido ";
            // 
            // username
            // 
            this.username.AutoSize = true;
            this.username.Font = new System.Drawing.Font("Century Gothic", 36F, System.Drawing.FontStyle.Bold);
            this.username.Location = new System.Drawing.Point(617, 77);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(170, 56);
            this.username.TabIndex = 3;
            this.username.Text = "label2";
            // 
            // horafecha
            // 
            this.horafecha.Enabled = true;
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.Silver;
            this.button7.Dock = System.Windows.Forms.DockStyle.Top;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.button7.Location = new System.Drawing.Point(0, 131);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(257, 44);
            this.button7.TabIndex = 6;
            this.button7.Text = "Accidentes";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // PROFESIONAL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.ClientSize = new System.Drawing.Size(1664, 945);
            this.Controls.Add(this.panel_child_form);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PROFESIONAL";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PROFESIONAL";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btn_minimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_cerrar)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel_asesorias.ResumeLayout(false);
            this.panel_capacitaciones.ResumeLayout(false);
            this.panel_cliente.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel_child_form.ResumeLayout(false);
            this.panel_child_form.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox btn_minimizar;
        private System.Windows.Forms.PictureBox btn_cerrar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel_capacitaciones;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button btn_profesional;
        private System.Windows.Forms.Panel panel_cliente;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button btn_Cliente;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel_child_form;
        private System.Windows.Forms.Panel panel_asesorias;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_registrar_cliente;
        public System.Windows.Forms.Label Hora;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label username;
        public System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button6;
        public System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer horafecha;
        private System.Windows.Forms.Button button7;
    }
}