using System;
using System.Windows.Forms;

namespace CarteiraDeClientes
{
    public partial class RegistrarCompraEstoqueForm : Form
    {
        // ESTAS SÃO AS PROPRIEDADES PÚBLICAS QUE ESTAVAM FALTANDO
        public int Quantidade { get; private set; }
        public string Item { get; private set; }
        public decimal Valor { get; private set; }

        public RegistrarCompraEstoqueForm()
        {
            InitializeComponent();
        }

        private void RegistrarCompraEstoqueForm_Load(object sender, EventArgs e)
        {
            // Foca no primeiro campo para agilizar a digitação
            numQuantidade.Focus();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (numQuantidade.Value > 0 && !string.IsNullOrWhiteSpace(txtItem.Text) && numValor.Value >= 0)
            {
                // Armazena os valores do formulário nas propriedades públicas
                this.Quantidade = (int)numQuantidade.Value;
                this.Item = txtItem.Text;
                this.Valor = numValor.Value;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Por favor, preencha todos os campos com valores válidos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}