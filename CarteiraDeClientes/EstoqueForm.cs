using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace CarteiraDeClientes
{
    public partial class EstoqueForm : Form
    {
        private EstoqueGeral estoqueGeral = new EstoqueGeral();

        public EstoqueForm()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.EstoqueForm_Load);
        }

        private void EstoqueForm_Load(object sender, EventArgs e)
        {
            lblEstoqueCheio.ForeColor = Color.Green;
            lblEstoqueVazio.ForeColor = Color.Red;

            ConfigurarDataGridView();
            CarregarDadosEstoque();

            // Se não houver nenhuma movimentação, significa que é o primeiro uso.
            // Opcional: Poderíamos mostrar uma mensagem guiando o usuário a definir o saldo inicial.
            if (!estoqueGeral.Movimentacoes.Any())
            {
                MessageBox.Show("Bem-vindo ao controle de estoque! Se este for o primeiro uso, clique em 'Definir Saldo Inicial' para começar.", "Primeiros Passos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            AtualizarLabelsSaldo();
            AtualizarDataGridView();
        }

        #region Configuração e Atualização da Tela
        // ... (os métodos desta região continuam os mesmos)
        private void ConfigurarDataGridView()
        {
            dataGridEstoque.AutoGenerateColumns = false;
            dataGridEstoque.Columns.Clear();
            dataGridEstoque.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Data", HeaderText = "Data", DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy HH:mm" }, Width = 120 });
            dataGridEstoque.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Tipo", HeaderText = "Tipo", Width = 100 });
            dataGridEstoque.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Produto", HeaderText = "Produto", Width = 150 });
            dataGridEstoque.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Quantidade", HeaderText = "Qtd", Width = 60 });
            dataGridEstoque.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Valor", HeaderText = "Valor Total", DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }, Width = 110 });
        }

        private void AtualizarDataGridView()
        {
            dataGridEstoque.DataSource = null;
            if (estoqueGeral.Movimentacoes != null && estoqueGeral.Movimentacoes.Any())
            {
                dataGridEstoque.DataSource = estoqueGeral.Movimentacoes.OrderByDescending(m => m.Data).ToList();
            }
        }

        private void AtualizarLabelsSaldo()
        {
            lblEstoqueCheio.Text = $"Botijões Cheios (Saldo): {estoqueGeral.SaldoCheios}";
            lblEstoqueVazio.Text = $"Botijões Vazios (Saldo): {estoqueGeral.SaldoVazios}";
            lblEstoqueCheio.Visible = true; // Deixa sempre visível
            lblEstoqueVazio.Visible = true; // Deixa sempre visível
        }
        #endregion

        #region Carregar e Salvar Dados
        // ... (os métodos desta região continuam os mesmos)
        private void CarregarDadosEstoque()
        {
            string caminho = "estoque.json";
            if (File.Exists(caminho))
            {
                estoqueGeral = JsonConvert.DeserializeObject<EstoqueGeral>(File.ReadAllText(caminho)) ?? new EstoqueGeral();
            }
        }

        private void SalvarDadosEstoque()
        {
            File.WriteAllText("estoque.json", JsonConvert.SerializeObject(estoqueGeral, Formatting.Indented));
            AtualizarLabelsSaldo();
            AtualizarDataGridView();
        }
        #endregion

        #region Botões

        // NOVO BOTÃO PARA SALDO INICIAL
        private void btnSaldoInicial_Click_1(object sender, EventArgs e)
        {
            var confirmacao = MessageBox.Show("Atenção!\n\nEsta operação irá APAGAR todo o histórico de movimentações e definir um novo saldo inicial.\n\nIsso só deve ser feito no primeiro uso ou para corrigir um erro grave. Deseja continuar?", "Confirmar Novo Saldo Inicial", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmacao == DialogResult.No)
            {
                return; // Usuário cancelou
            }

            string inputCheios = Interaction.InputBox("Digite a quantidade INICIAL de botijões CHEIOS:", "Saldo Inicial - Cheios", "0");
            if (int.TryParse(inputCheios, out int saldoInicialCheios) && saldoInicialCheios >= 0)
            {
                string inputVazios = Interaction.InputBox("Agora, digite a quantidade INICIAL de botijões VAZIOS:", "Saldo Inicial - Vazios", "0");
                if (int.TryParse(inputVazios, out int saldoInicialVazios) && saldoInicialVazios >= 0)
                {
                    // Zera o histórico
                    estoqueGeral.Movimentacoes.Clear();

                    // Define os novos saldos
                    estoqueGeral.SaldoCheios = saldoInicialCheios;
                    estoqueGeral.SaldoVazios = saldoInicialVazios;

                    // Adiciona um registro no histórico para marcar este evento
                    estoqueGeral.Movimentacoes.Add(new MovimentacaoEstoque
                    {
                        Data = DateTime.Now,
                        Tipo = "Balanço Inicial",
                        Produto = $"Cheios: {saldoInicialCheios}, Vazios: {saldoInicialVazios}",
                        Quantidade = 0,
                        Valor = 0
                    });

                    // Salva tudo e atualiza a tela
                    SalvarDadosEstoque();
                    MessageBox.Show("Novo saldo inicial definido com sucesso!", "Operação Concluída", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnCompra_Click_1(object sender, EventArgs e)
        {
            using (var formCompra = new RegistrarCompraEstoqueForm())
            {
                if (formCompra.ShowDialog() == DialogResult.OK)
                {
                    int quantidade = formCompra.Quantidade;
                    estoqueGeral.SaldoCheios += quantidade;
                    estoqueGeral.SaldoVazios -= quantidade;
                    estoqueGeral.Movimentacoes.Add(new MovimentacaoEstoque { Data = DateTime.Now, Tipo = "Compra", Produto = formCompra.Item, Quantidade = quantidade, Valor = formCompra.Valor });
                    SalvarDadosEstoque();
                    MessageBox.Show($"{quantidade} unidade(s) de '{formCompra.Item}' adicionada(s) ao estoque.", "Sucesso");
                }
            }
        }

        private void btnDev_Click(object sender, EventArgs e)
        {
            string input = Interaction.InputBox("Quantos botijões VAZIOS foram devolvidos ao fornecedor?", "Registrar Devolução", "0");
            if (int.TryParse(input, out int quantidade) && quantidade > 0)
            {
                estoqueGeral.SaldoVazios -= quantidade;
                estoqueGeral.Movimentacoes.Add(new MovimentacaoEstoque { Data = DateTime.Now, Tipo = "Devolução", Produto = "Botijão de Gás", Quantidade = quantidade, Valor = 0 });
                SalvarDadosEstoque();
                MessageBox.Show($"{quantidade} botijões vazios removidos do saldo.", "Sucesso");
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        
    }
}