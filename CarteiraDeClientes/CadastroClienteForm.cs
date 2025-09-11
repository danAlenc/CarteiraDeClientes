using CarteiraDeClientes;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

public partial class CadastroClienteForm : Form
{
    private List<Cliente> clientes;

    public CadastroClienteForm(List<Cliente> clientes)
    {
        InitializeComponent();
        this.clientes = clientes;
        DefinirIdAutomatico();

       
    }

    protected override void OnShown(EventArgs e)
    {
        base.OnShown(e);
        // Define o foco no campo de nome quando o formulário é exibido
        txtNome.Focus();
    }

    private void DefinirIdAutomatico()
    {
        if (clientes.Count > 0)
        {
            // Define o próximo ID como o maior ID atual + 1
            int proximoId = clientes.Max(c => c.Id) + 1;
            txtId.Text = proximoId.ToString();
        }
        else
        {
            // Se não houver clientes, começa com o ID 1
            txtId.Text = "1";
        }

        // Desabilita a caixa de texto de ID para evitar alterações manuais
        txtId.ReadOnly = true;
    }

    public Cliente NovoCliente { get; private set; }

    private void btnSalvar_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtNome.Text) || string.IsNullOrWhiteSpace(txtEndereco.Text))
        {
            MessageBox.Show("Nome e Endereço são campos obrigatórios.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        // Cria um novo cliente com os dados inseridos
        NovoCliente = new Cliente
        {
            Id = clientes.Any() ? clientes.Max(c => c.Id) + 1 : 1,  // Gera um novo ID único
            Nome = txtNome.Text,
            Email = txtEmail.Text,
            Telefone = txtTelefone.Text,
            Endereco = txtEndereco.Text,
            UltimoPedido = dtpUltimoPedido.Value  // Captura a data selecionada
        };

        this.DialogResult = DialogResult.OK;
        this.Close();
    }
}
