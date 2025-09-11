namespace CarteiraDeClientes
{
    partial class EstoqueForm
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
            this.btnSair = new System.Windows.Forms.Button();
            this.btnCompra = new System.Windows.Forms.Button();
            this.btnDev = new System.Windows.Forms.Button();
            this.dataGridEstoque = new System.Windows.Forms.DataGridView();
            this.lblEstoqueCheio = new System.Windows.Forms.Label();
            this.lblEstoqueVazio = new System.Windows.Forms.Label();
            this.btnSaldoInicial = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEstoque)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSair
            // 
            this.btnSair.Location = new System.Drawing.Point(521, 316);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(75, 23);
            this.btnSair.TabIndex = 0;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // btnCompra
            // 
            this.btnCompra.Location = new System.Drawing.Point(440, 316);
            this.btnCompra.Name = "btnCompra";
            this.btnCompra.Size = new System.Drawing.Size(75, 23);
            this.btnCompra.TabIndex = 1;
            this.btnCompra.Text = "Compra";
            this.btnCompra.UseVisualStyleBackColor = true;
            this.btnCompra.Click += new System.EventHandler(this.btnCompra_Click_1);
            // 
            // btnDev
            // 
            this.btnDev.Location = new System.Drawing.Point(359, 316);
            this.btnDev.Name = "btnDev";
            this.btnDev.Size = new System.Drawing.Size(75, 23);
            this.btnDev.TabIndex = 2;
            this.btnDev.Text = "Devolução";
            this.btnDev.UseVisualStyleBackColor = true;
            // 
            // dataGridEstoque
            // 
            this.dataGridEstoque.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridEstoque.Location = new System.Drawing.Point(12, 12);
            this.dataGridEstoque.Name = "dataGridEstoque";
            this.dataGridEstoque.Size = new System.Drawing.Size(584, 279);
            this.dataGridEstoque.TabIndex = 3;
            // 
            // lblEstoqueCheio
            // 
            this.lblEstoqueCheio.AutoSize = true;
            this.lblEstoqueCheio.Location = new System.Drawing.Point(12, 307);
            this.lblEstoqueCheio.Name = "lblEstoqueCheio";
            this.lblEstoqueCheio.Size = new System.Drawing.Size(35, 13);
            this.lblEstoqueCheio.TabIndex = 4;
            this.lblEstoqueCheio.Text = "label1";
            // 
            // lblEstoqueVazio
            // 
            this.lblEstoqueVazio.AutoSize = true;
            this.lblEstoqueVazio.Location = new System.Drawing.Point(12, 326);
            this.lblEstoqueVazio.Name = "lblEstoqueVazio";
            this.lblEstoqueVazio.Size = new System.Drawing.Size(35, 13);
            this.lblEstoqueVazio.TabIndex = 5;
            this.lblEstoqueVazio.Text = "label1";
            // 
            // btnSaldoInicial
            // 
            this.btnSaldoInicial.Location = new System.Drawing.Point(278, 316);
            this.btnSaldoInicial.Name = "btnSaldoInicial";
            this.btnSaldoInicial.Size = new System.Drawing.Size(75, 23);
            this.btnSaldoInicial.TabIndex = 6;
            this.btnSaldoInicial.Text = "Saldo Inicial";
            this.btnSaldoInicial.UseVisualStyleBackColor = true;
            this.btnSaldoInicial.Click += new System.EventHandler(this.btnSaldoInicial_Click_1);
            // 
            // EstoqueForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 350);
            this.Controls.Add(this.btnSaldoInicial);
            this.Controls.Add(this.lblEstoqueVazio);
            this.Controls.Add(this.lblEstoqueCheio);
            this.Controls.Add(this.dataGridEstoque);
            this.Controls.Add(this.btnDev);
            this.Controls.Add(this.btnCompra);
            this.Controls.Add(this.btnSair);
            this.Name = "EstoqueForm";
            this.Text = "Estoque";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEstoque)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Button btnCompra;
        private System.Windows.Forms.Button btnDev;
        private System.Windows.Forms.DataGridView dataGridEstoque;
        private System.Windows.Forms.Label lblEstoqueCheio;
        private System.Windows.Forms.Label lblEstoqueVazio;
        private System.Windows.Forms.Button btnSaldoInicial;
    }
}