using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarteiraDeClientes
{
    public partial class RegistrarPedidoForm : Form
    {
        public string ItemPedido { get; private set; }
        public decimal Valor { get; private set; }

        public RegistrarPedidoForm()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            // Captura o texto inserido no TextBox e o armazena na propriedade ItemPedido
            ItemPedido = txtItemPedido.Text;
            Valor = numValor.Value;

            // Verifica se o usuário inseriu um texto válido
            if (!string.IsNullOrWhiteSpace(ItemPedido))
            {
                // Define o resultado do formulário como OK e fecha o formulário
                this.DialogResult = DialogResult.OK;
                this.Close();

                // Exibe uma mensagem de sucesso informando que o pedido foi registrado
                MessageBox.Show("Pedido registrado com sucesso!", "Registro de Pedido", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Exibe uma mensagem de aviso se o campo estiver vazio
                MessageBox.Show("Por favor, insira um item válido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void textBoxValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite números, ponto ou vírgula e o controle de backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // Substitui ponto por vírgula, caso o ponto seja pressionado
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }

            // Se já houver uma vírgula no campo e o usuário tentar digitar outra, impede a entrada
            if ((e.KeyChar == ',' || e.KeyChar == '.') && (sender as TextBox).Text.IndexOf(',') > -1)
            {
                e.Handled = true;
            }

            // Limita o número de casas decimais para 2
            TextBox textBox = sender as TextBox;
            if (textBox.Text.Contains(","))
            {
                // Permite apenas dois dígitos após a vírgula
                string[] partes = textBox.Text.Split(',');
                if (partes.Length > 1 && partes[1].Length >= 2 && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void txtValor_Leave(object sender, EventArgs e)
        {
            if (decimal.TryParse(numValor.Text, out decimal valor))
            {
                numValor.Text = valor.ToString("F2");
            }
            else
            {
                MessageBox.Show("Digite um valor válido.");
            }
        }


    }

}
