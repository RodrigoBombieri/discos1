namespace discos1
{
    partial class FormDiscos
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvDiscos = new System.Windows.Forms.DataGridView();
            this.pibDiscos = new System.Windows.Forms.PictureBox();
            this.btnAgregarDisco = new System.Windows.Forms.Button();
            this.btnModificarDisco = new System.Windows.Forms.Button();
            this.btnEliminarFisico = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiscos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pibDiscos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDiscos
            // 
            this.dgvDiscos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDiscos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvDiscos.Location = new System.Drawing.Point(29, 76);
            this.dgvDiscos.MultiSelect = false;
            this.dgvDiscos.Name = "dgvDiscos";
            this.dgvDiscos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDiscos.Size = new System.Drawing.Size(525, 315);
            this.dgvDiscos.TabIndex = 0;
            this.dgvDiscos.SelectionChanged += new System.EventHandler(this.dgvDiscos_SelectionChanged);
            // 
            // pibDiscos
            // 
            this.pibDiscos.Location = new System.Drawing.Point(692, 76);
            this.pibDiscos.Name = "pibDiscos";
            this.pibDiscos.Size = new System.Drawing.Size(387, 315);
            this.pibDiscos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pibDiscos.TabIndex = 1;
            this.pibDiscos.TabStop = false;
            // 
            // btnAgregarDisco
            // 
            this.btnAgregarDisco.Location = new System.Drawing.Point(46, 414);
            this.btnAgregarDisco.Name = "btnAgregarDisco";
            this.btnAgregarDisco.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnAgregarDisco.Size = new System.Drawing.Size(104, 38);
            this.btnAgregarDisco.TabIndex = 2;
            this.btnAgregarDisco.Text = "Agregar";
            this.btnAgregarDisco.UseVisualStyleBackColor = true;
            this.btnAgregarDisco.Click += new System.EventHandler(this.btnAgregarDisco_Click);
            // 
            // btnModificarDisco
            // 
            this.btnModificarDisco.Location = new System.Drawing.Point(176, 414);
            this.btnModificarDisco.Name = "btnModificarDisco";
            this.btnModificarDisco.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnModificarDisco.Size = new System.Drawing.Size(104, 38);
            this.btnModificarDisco.TabIndex = 3;
            this.btnModificarDisco.Text = "Modificar";
            this.btnModificarDisco.UseVisualStyleBackColor = true;
            this.btnModificarDisco.Click += new System.EventHandler(this.btnModificarDisco_Click);
            // 
            // btnEliminarFisico
            // 
            this.btnEliminarFisico.Location = new System.Drawing.Point(305, 414);
            this.btnEliminarFisico.Name = "btnEliminarFisico";
            this.btnEliminarFisico.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnEliminarFisico.Size = new System.Drawing.Size(104, 38);
            this.btnEliminarFisico.TabIndex = 4;
            this.btnEliminarFisico.Text = "Eliminar Fisico";
            this.btnEliminarFisico.UseVisualStyleBackColor = true;
            this.btnEliminarFisico.Click += new System.EventHandler(this.btnEliminarFisico_Click);
            // 
            // FormDiscos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1171, 470);
            this.Controls.Add(this.btnEliminarFisico);
            this.Controls.Add(this.btnModificarDisco);
            this.Controls.Add(this.btnAgregarDisco);
            this.Controls.Add(this.pibDiscos);
            this.Controls.Add(this.dgvDiscos);
            this.Name = "FormDiscos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Discos";
            this.Load += new System.EventHandler(this.FormDiscos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiscos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pibDiscos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDiscos;
        private System.Windows.Forms.PictureBox pibDiscos;
        private System.Windows.Forms.Button btnAgregarDisco;
        private System.Windows.Forms.Button btnModificarDisco;
        private System.Windows.Forms.Button btnEliminarFisico;
    }
}

