namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.trArvoreLateral = new System.Windows.Forms.TreeView();
            this.dgParametros = new System.Windows.Forms.DataGridView();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnAbrir = new System.Windows.Forms.Button();
            this.salvarConfig = new System.Windows.Forms.SaveFileDialog();
            this.abrirConfig = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dgParametros)).BeginInit();
            this.SuspendLayout();
            // 
            // trArvoreLateral
            // 
            this.trArvoreLateral.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.trArvoreLateral.Location = new System.Drawing.Point(0, 60);
            this.trArvoreLateral.Name = "trArvoreLateral";
            this.trArvoreLateral.Size = new System.Drawing.Size(185, 391);
            this.trArvoreLateral.TabIndex = 0;
            this.trArvoreLateral.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trArvoreLateral_AfterSelect);
            // 
            // dgParametros
            // 
            this.dgParametros.AllowUserToAddRows = false;
            this.dgParametros.AllowUserToDeleteRows = false;
            this.dgParametros.AllowUserToResizeColumns = false;
            this.dgParametros.AllowUserToResizeRows = false;
            this.dgParametros.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgParametros.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgParametros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgParametros.Location = new System.Drawing.Point(183, 0);
            this.dgParametros.Name = "dgParametros";
            this.dgParametros.ReadOnly = true;
            this.dgParametros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgParametros.ShowEditingIcon = false;
            this.dgParametros.Size = new System.Drawing.Size(617, 451);
            this.dgParametros.TabIndex = 1;
            this.dgParametros.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgParametros_CellContentDoubleClick);
            // 
            // btnNovo
            // 
            this.btnNovo.Location = new System.Drawing.Point(0, 0);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(94, 62);
            this.btnNovo.TabIndex = 2;
            this.btnNovo.Text = "Novo";
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // btnAbrir
            // 
            this.btnAbrir.Location = new System.Drawing.Point(90, 0);
            this.btnAbrir.Name = "btnAbrir";
            this.btnAbrir.Size = new System.Drawing.Size(95, 62);
            this.btnAbrir.TabIndex = 3;
            this.btnAbrir.Text = "Abrir";
            this.btnAbrir.UseVisualStyleBackColor = true;
            this.btnAbrir.Click += new System.EventHandler(this.btnAbrir_Click);
            // 
            // salvarConfig
            // 
            this.salvarConfig.AddExtension = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnAbrir);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.dgParametros);
            this.Controls.Add(this.trArvoreLateral);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgParametros)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView trArvoreLateral;
        private System.Windows.Forms.DataGridView dgParametros;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Button btnAbrir;
        private System.Windows.Forms.SaveFileDialog salvarConfig;
        private System.Windows.Forms.OpenFileDialog abrirConfig;
    }
}

