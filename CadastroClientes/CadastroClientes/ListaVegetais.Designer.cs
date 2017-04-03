namespace CadastroClientes.Interface
{
    partial class ListaVegetais
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
            this.dgvVegetal = new System.Windows.Forms.DataGridView();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoGrupo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GrupoVegetal_Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tamanho = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVegetal)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvVegetal
            // 
            this.dgvVegetal.AllowUserToAddRows = false;
            this.dgvVegetal.AllowUserToDeleteRows = false;
            this.dgvVegetal.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvVegetal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVegetal.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.Nome,
            this.CodigoGrupo,
            this.GrupoVegetal_Codigo,
            this.Tamanho});
            this.dgvVegetal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvVegetal.Location = new System.Drawing.Point(0, 0);
            this.dgvVegetal.MultiSelect = false;
            this.dgvVegetal.Name = "dgvVegetal";
            this.dgvVegetal.ReadOnly = true;
            this.dgvVegetal.Size = new System.Drawing.Size(544, 350);
            this.dgvVegetal.TabIndex = 0;
            this.dgvVegetal.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVegetal_CellDoubleClick);
            // 
            // Codigo
            // 
            this.Codigo.DataPropertyName = "Codigo";
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            // 
            // Nome
            // 
            this.Nome.DataPropertyName = "Nome";
            this.Nome.HeaderText = "Nome";
            this.Nome.Name = "Nome";
            this.Nome.ReadOnly = true;
            this.Nome.Width = 200;
            // 
            // CodigoGrupo
            // 
            this.CodigoGrupo.DataPropertyName = "GrupoVegetal";
            this.CodigoGrupo.HeaderText = "Grupo";
            this.CodigoGrupo.Name = "CodigoGrupo";
            this.CodigoGrupo.ReadOnly = true;
            // 
            // GrupoVegetal_Codigo
            // 
            this.GrupoVegetal_Codigo.DataPropertyName = "GrupoVegetal_Codigo";
            this.GrupoVegetal_Codigo.HeaderText = "GrupoVegetal_Codigo";
            this.GrupoVegetal_Codigo.Name = "GrupoVegetal_Codigo";
            this.GrupoVegetal_Codigo.ReadOnly = true;
            this.GrupoVegetal_Codigo.Visible = false;
            // 
            // Tamanho
            // 
            this.Tamanho.DataPropertyName = "Tamanho";
            this.Tamanho.HeaderText = "Tamanho";
            this.Tamanho.Name = "Tamanho";
            this.Tamanho.ReadOnly = true;
            // 
            // ListaVegetais
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 350);
            this.Controls.Add(this.dgvVegetal);
            this.Name = "ListaVegetais";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista Vegetais";
            this.Load += new System.EventHandler(this.Form4_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVegetal)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvVegetal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoGrupo;
        private System.Windows.Forms.DataGridViewTextBoxColumn GrupoVegetal_Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tamanho;
    }
}