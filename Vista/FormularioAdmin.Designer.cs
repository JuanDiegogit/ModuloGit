namespace Vista
{
    partial class FormularioAdmin
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCambiarRol = new System.Windows.Forms.Button();
            this.btnRestablecer = new System.Windows.Forms.Button();
            this.btnSuspender = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.comboOficina = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.TablaUsuario = new System.Windows.Forms.DataGridView();
            this.lblAlerta = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.timerSegundoPlano = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TablaUsuario)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(610, 39);
            this.label1.TabIndex = 1;
            this.label1.Text = "Administrador";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCambiarRol);
            this.panel1.Controls.Add(this.btnRestablecer);
            this.panel1.Controls.Add(this.btnSuspender);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 265);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(610, 43);
            this.panel1.TabIndex = 2;
            // 
            // btnCambiarRol
            // 
            this.btnCambiarRol.Location = new System.Drawing.Point(476, 8);
            this.btnCambiarRol.Name = "btnCambiarRol";
            this.btnCambiarRol.Size = new System.Drawing.Size(124, 23);
            this.btnCambiarRol.TabIndex = 2;
            this.btnCambiarRol.Text = "Cambiar Rol";
            this.btnCambiarRol.UseVisualStyleBackColor = true;
            this.btnCambiarRol.Click += new System.EventHandler(this.btnCambiarRol_Click);
            // 
            // btnRestablecer
            // 
            this.btnRestablecer.Location = new System.Drawing.Point(246, 8);
            this.btnRestablecer.Name = "btnRestablecer";
            this.btnRestablecer.Size = new System.Drawing.Size(124, 23);
            this.btnRestablecer.TabIndex = 1;
            this.btnRestablecer.Text = "Restablecer  Cuenta";
            this.btnRestablecer.UseVisualStyleBackColor = true;
            this.btnRestablecer.Click += new System.EventHandler(this.btnRestablecer_Click);
            // 
            // btnSuspender
            // 
            this.btnSuspender.Location = new System.Drawing.Point(16, 8);
            this.btnSuspender.Name = "btnSuspender";
            this.btnSuspender.Size = new System.Drawing.Size(124, 23);
            this.btnSuspender.TabIndex = 0;
            this.btnSuspender.Text = "Suspender Cuenta";
            this.btnSuspender.UseVisualStyleBackColor = true;
            this.btnSuspender.Click += new System.EventHandler(this.btnSuspender_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnAgregar);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.comboOficina);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 39);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(610, 46);
            this.panel2.TabIndex = 3;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(454, 8);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(146, 32);
            this.btnAgregar.TabIndex = 4;
            this.btnAgregar.Text = "Agregar Usuario";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(330, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Suspendido";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Yellow;
            this.pictureBox1.Location = new System.Drawing.Point(305, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(19, 20);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // comboOficina
            // 
            this.comboOficina.FormattingEnabled = true;
            this.comboOficina.Location = new System.Drawing.Point(118, 9);
            this.comboOficina.Name = "comboOficina";
            this.comboOficina.Size = new System.Drawing.Size(152, 21);
            this.comboOficina.TabIndex = 1;
            this.comboOficina.SelectedIndexChanged += new System.EventHandler(this.comboOficina_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Filtrar Por Oficinas :";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.TablaUsuario);
            this.panel3.Controls.Add(this.lblAlerta);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 85);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(10);
            this.panel3.Size = new System.Drawing.Size(610, 180);
            this.panel3.TabIndex = 4;
            // 
            // TablaUsuario
            // 
            this.TablaUsuario.AllowUserToAddRows = false;
            this.TablaUsuario.AllowUserToDeleteRows = false;
            this.TablaUsuario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TablaUsuario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TablaUsuario.Location = new System.Drawing.Point(10, 33);
            this.TablaUsuario.Name = "TablaUsuario";
            this.TablaUsuario.ReadOnly = true;
            this.TablaUsuario.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.TablaUsuario.Size = new System.Drawing.Size(590, 137);
            this.TablaUsuario.TabIndex = 5;
            this.TablaUsuario.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.TablaUsuario_CellFormatting);
            this.TablaUsuario.SelectionChanged += new System.EventHandler(this.TablaUsuario_SelectionChanged);
            // 
            // lblAlerta
            // 
            this.lblAlerta.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblAlerta.Location = new System.Drawing.Point(10, 10);
            this.lblAlerta.Name = "lblAlerta";
            this.lblAlerta.Size = new System.Drawing.Size(590, 23);
            this.lblAlerta.TabIndex = 0;
            this.lblAlerta.Visible = false;
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.Red;
            this.btnSalir.Location = new System.Drawing.Point(454, 1);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(146, 32);
            this.btnSalir.TabIndex = 3;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // timerSegundoPlano
            // 
            this.timerSegundoPlano.Tick += new System.EventHandler(this.timerSegundoPlano_Tick);
            // 
            // FormularioAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 308);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Name = "FormularioAdmin";
            this.Text = "FormularioAdmin";
            this.Load += new System.EventHandler(this.FormularioAdmin_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TablaUsuario)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnCambiarRol;
        private System.Windows.Forms.Button btnRestablecer;
        private System.Windows.Forms.Button btnSuspender;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox comboOficina;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView TablaUsuario;
        private System.Windows.Forms.Label lblAlerta;
        private System.Windows.Forms.Timer timerSegundoPlano;
    }
}