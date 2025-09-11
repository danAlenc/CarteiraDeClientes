partial class CadastroClienteForm
{
    private void InitializeComponent()
    {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CadastroClienteForm));
            this.labelId = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.labelNome = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.labelEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.labelTelefone = new System.Windows.Forms.Label();
            this.txtTelefone = new System.Windows.Forms.TextBox();
            this.labelUltimoPedido = new System.Windows.Forms.Label();
            this.dtpUltimoPedido = new System.Windows.Forms.DateTimePicker();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.txtEndereco = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelId
            // 
            this.labelId.AutoSize = true;
            this.labelId.Location = new System.Drawing.Point(12, 15);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(21, 13);
            this.labelId.TabIndex = 0;
            this.labelId.Text = "ID:";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(80, 12);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(200, 20);
            this.txtId.TabIndex = 1;
            // 
            // labelNome
            // 
            this.labelNome.AutoSize = true;
            this.labelNome.Location = new System.Drawing.Point(12, 45);
            this.labelNome.Name = "labelNome";
            this.labelNome.Size = new System.Drawing.Size(38, 13);
            this.labelNome.TabIndex = 2;
            this.labelNome.Text = "Nome:";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(80, 42);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(200, 20);
            this.txtNome.TabIndex = 3;
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Location = new System.Drawing.Point(12, 75);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(35, 13);
            this.labelEmail.TabIndex = 4;
            this.labelEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(80, 72);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(200, 20);
            this.txtEmail.TabIndex = 5;
            // 
            // labelTelefone
            // 
            this.labelTelefone.AutoSize = true;
            this.labelTelefone.Location = new System.Drawing.Point(12, 105);
            this.labelTelefone.Name = "labelTelefone";
            this.labelTelefone.Size = new System.Drawing.Size(52, 13);
            this.labelTelefone.TabIndex = 6;
            this.labelTelefone.Text = "Telefone:";
            // 
            // txtTelefone
            // 
            this.txtTelefone.Location = new System.Drawing.Point(80, 102);
            this.txtTelefone.Name = "txtTelefone";
            this.txtTelefone.Size = new System.Drawing.Size(200, 20);
            this.txtTelefone.TabIndex = 7;
            // 
            // labelUltimoPedido
            // 
            this.labelUltimoPedido.AutoSize = true;
            this.labelUltimoPedido.Location = new System.Drawing.Point(-1, 135);
            this.labelUltimoPedido.Name = "labelUltimoPedido";
            this.labelUltimoPedido.Size = new System.Drawing.Size(75, 13);
            this.labelUltimoPedido.TabIndex = 8;
            this.labelUltimoPedido.Text = "Último Pedido:";
            // 
            // dtpUltimoPedido
            // 
            this.dtpUltimoPedido.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpUltimoPedido.Location = new System.Drawing.Point(80, 129);
            this.dtpUltimoPedido.Name = "dtpUltimoPedido";
            this.dtpUltimoPedido.Size = new System.Drawing.Size(200, 20);
            this.dtpUltimoPedido.TabIndex = 9;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(205, 197);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 23);
            this.btnSalvar.TabIndex = 13;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // txtEndereco
            // 
            this.txtEndereco.Location = new System.Drawing.Point(80, 155);
            this.txtEndereco.Name = "txtEndereco";
            this.txtEndereco.Size = new System.Drawing.Size(200, 20);
            this.txtEndereco.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 158);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Endereço:";
            // 
            // CadastroClienteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 232);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtEndereco);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.dtpUltimoPedido);
            this.Controls.Add(this.labelUltimoPedido);
            this.Controls.Add(this.txtTelefone);
            this.Controls.Add(this.labelTelefone);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.labelEmail);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.labelNome);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.labelId);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "CadastroClienteForm";
            this.Text = "Cadastro de Clientes";
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    private System.Windows.Forms.Label labelId;
    private System.Windows.Forms.TextBox txtId;
    private System.Windows.Forms.Label labelNome;
    private System.Windows.Forms.TextBox txtNome;
    private System.Windows.Forms.Label labelEmail;
    private System.Windows.Forms.TextBox txtEmail;
    private System.Windows.Forms.Label labelTelefone;
    private System.Windows.Forms.TextBox txtTelefone;
    private System.Windows.Forms.Label labelUltimoPedido;
    private System.Windows.Forms.DateTimePicker dtpUltimoPedido;
    private System.Windows.Forms.Button btnSalvar;
    private System.Windows.Forms.TextBox txtEndereco;
    private System.Windows.Forms.Label label1;
}
