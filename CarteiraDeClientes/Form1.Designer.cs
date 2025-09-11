namespace CarteiraDeClientes
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dataGridViewClientes = new System.Windows.Forms.DataGridView();
            this.btnRegistrarPedido = new System.Windows.Forms.Button();
            this.btnNotificarInativos = new System.Windows.Forms.Button();
            this.btnCadastrarCliente = new System.Windows.Forms.Button();
            this.btnExcluirCliente = new System.Windows.Forms.Button();
            this.btnPedidosRegistrados = new System.Windows.Forms.Button();
            this.btnBuscarCliente = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.btnMostrarTodos = new System.Windows.Forms.Button();
            this.btnEstoque = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewClientes
            // 
            this.dataGridViewClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewClientes.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewClientes.Name = "dataGridViewClientes";
            this.dataGridViewClientes.Size = new System.Drawing.Size(543, 347);
            this.dataGridViewClientes.TabIndex = 1;
            this.dataGridViewClientes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewClientes_CellContentClick);
            // 
            // btnRegistrarPedido
            // 
            this.btnRegistrarPedido.Location = new System.Drawing.Point(561, 12);
            this.btnRegistrarPedido.Name = "btnRegistrarPedido";
            this.btnRegistrarPedido.Size = new System.Drawing.Size(119, 23);
            this.btnRegistrarPedido.TabIndex = 2;
            this.btnRegistrarPedido.Text = "Registrar Pedido";
            this.btnRegistrarPedido.UseVisualStyleBackColor = true;
            this.btnRegistrarPedido.Click += new System.EventHandler(this.btnRegistrarPedido_Click_1);
            // 
            // btnNotificarInativos
            // 
            this.btnNotificarInativos.Location = new System.Drawing.Point(561, 128);
            this.btnNotificarInativos.Name = "btnNotificarInativos";
            this.btnNotificarInativos.Size = new System.Drawing.Size(119, 23);
            this.btnNotificarInativos.TabIndex = 3;
            this.btnNotificarInativos.Text = "60 Dias sem Pedir";
            this.btnNotificarInativos.UseVisualStyleBackColor = true;
            this.btnNotificarInativos.Click += new System.EventHandler(this.btnNotificarInativos_Click_1);
            // 
            // btnCadastrarCliente
            // 
            this.btnCadastrarCliente.Location = new System.Drawing.Point(561, 70);
            this.btnCadastrarCliente.Name = "btnCadastrarCliente";
            this.btnCadastrarCliente.Size = new System.Drawing.Size(119, 23);
            this.btnCadastrarCliente.TabIndex = 4;
            this.btnCadastrarCliente.Text = "Cadastrar Cliente";
            this.btnCadastrarCliente.UseVisualStyleBackColor = true;
            this.btnCadastrarCliente.Click += new System.EventHandler(this.btnCadastrarCliente_Click);
            // 
            // btnExcluirCliente
            // 
            this.btnExcluirCliente.Location = new System.Drawing.Point(561, 99);
            this.btnExcluirCliente.Name = "btnExcluirCliente";
            this.btnExcluirCliente.Size = new System.Drawing.Size(119, 23);
            this.btnExcluirCliente.TabIndex = 5;
            this.btnExcluirCliente.Text = "Excluir Cliente";
            this.btnExcluirCliente.UseVisualStyleBackColor = true;
            this.btnExcluirCliente.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnPedidosRegistrados
            // 
            this.btnPedidosRegistrados.Location = new System.Drawing.Point(561, 41);
            this.btnPedidosRegistrados.Name = "btnPedidosRegistrados";
            this.btnPedidosRegistrados.Size = new System.Drawing.Size(119, 23);
            this.btnPedidosRegistrados.TabIndex = 6;
            this.btnPedidosRegistrados.Text = "Pedidos Registrados";
            this.btnPedidosRegistrados.UseVisualStyleBackColor = true;
            this.btnPedidosRegistrados.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnBuscarCliente
            // 
            this.btnBuscarCliente.Location = new System.Drawing.Point(561, 157);
            this.btnBuscarCliente.Name = "btnBuscarCliente";
            this.btnBuscarCliente.Size = new System.Drawing.Size(117, 23);
            this.btnBuscarCliente.TabIndex = 7;
            this.btnBuscarCliente.Text = "Buscar Cliente";
            this.btnBuscarCliente.UseVisualStyleBackColor = true;
            this.btnBuscarCliente.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnSair
            // 
            this.btnSair.Location = new System.Drawing.Point(561, 336);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(117, 23);
            this.btnSair.TabIndex = 8;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnMostrarTodos
            // 
            this.btnMostrarTodos.Location = new System.Drawing.Point(561, 186);
            this.btnMostrarTodos.Name = "btnMostrarTodos";
            this.btnMostrarTodos.Size = new System.Drawing.Size(117, 23);
            this.btnMostrarTodos.TabIndex = 9;
            this.btnMostrarTodos.Text = "Mostrar Todos";
            this.btnMostrarTodos.UseVisualStyleBackColor = true;
            this.btnMostrarTodos.Click += new System.EventHandler(this.btnMostrarTodos_Click);
            // 
            // btnEstoque
            // 
            this.btnEstoque.Location = new System.Drawing.Point(561, 215);
            this.btnEstoque.Name = "btnEstoque";
            this.btnEstoque.Size = new System.Drawing.Size(117, 23);
            this.btnEstoque.TabIndex = 10;
            this.btnEstoque.Text = "Estoque";
            this.btnEstoque.UseVisualStyleBackColor = true;
            this.btnEstoque.Click += new System.EventHandler(this.btnEstoque_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 371);
            this.Controls.Add(this.btnEstoque);
            this.Controls.Add(this.btnMostrarTodos);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.btnBuscarCliente);
            this.Controls.Add(this.btnPedidosRegistrados);
            this.Controls.Add(this.btnExcluirCliente);
            this.Controls.Add(this.btnCadastrarCliente);
            this.Controls.Add(this.btnNotificarInativos);
            this.Controls.Add(this.btnRegistrarPedido);
            this.Controls.Add(this.dataGridViewClientes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Carteira de Clientes";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClientes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridViewClientes;
        private System.Windows.Forms.Button btnRegistrarPedido;
        private System.Windows.Forms.Button btnNotificarInativos;
        private System.Windows.Forms.Button btnCadastrarCliente;
        private System.Windows.Forms.Button btnExcluirCliente;
        private System.Windows.Forms.Button btnPedidosRegistrados;
        private System.Windows.Forms.Button btnBuscarCliente;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Button btnMostrarTodos;
        private System.Windows.Forms.Button btnEstoque;
    }
}

