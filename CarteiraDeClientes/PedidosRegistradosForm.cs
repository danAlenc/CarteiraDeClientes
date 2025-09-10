using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace CarteiraDeClientes
{
    public partial class PedidosRegistradosForm : Form
    {
        private List<Pedido> pedidos;

        public PedidosRegistradosForm()
        {
            InitializeComponent();
            pedidos = CarregarPedidosDoArquivo();
            InicializarDataGridView();
            PreencherComboBoxMeses();
            AtualizarDataGridView();
        }

        private void InicializarDataGridView()
        {
            dataGridViewPedidos.Columns.Clear();
            dataGridViewPedidos.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "ID", DataPropertyName = "Id" });
            dataGridViewPedidos.Columns.Add(new DataGridViewTextBoxColumn { Name = "Nome", HeaderText = "Nome", DataPropertyName = "Nome" });
            dataGridViewPedidos.Columns.Add(new DataGridViewTextBoxColumn { Name = "ItemPedido", HeaderText = "Item Pedido", DataPropertyName = "ItemPedido" });
            
            dataGridViewPedidos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Valor",
                HeaderText = "Valor",
                DataPropertyName = "Valor",
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "N2", // Formato com separador de milhar e duas casas decimais
                    Alignment = DataGridViewContentAlignment.MiddleRight // Alinha à direita
                }
            });

            dataGridViewPedidos.Columns.Add(new DataGridViewTextBoxColumn { Name = "UltimoPedido", HeaderText = "Último Pedido", DataPropertyName = "UltimoPedido", DefaultCellStyle = new DataGridViewCellStyle { Format = "d" } });

            dataGridViewPedidos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            

        }

        private void AtualizarDataGridView()
        {
            dataGridViewPedidos.DataSource = null;

            // Ordena os pedidos por data do último pedido em ordem decrescente
            var pedidosOrdenados = pedidos.OrderByDescending(p => p.UltimoPedido).ToList();

            dataGridViewPedidos.DataSource = pedidosOrdenados;
            AtualizarTotal(pedidosOrdenados); // Passa a lista de pedidos ordenados para atualizar o total
        }

        private void AtualizarTotal(List<Pedido> pedidosFiltrados)
        {
            decimal total = pedidosFiltrados.Sum(p => p.Valor);
            lblTotal.Text = $"Total: {total:C}";
        }

        private List<Pedido> CarregarPedidosDoArquivo()
        {
            string caminhoArquivo = "pedidos.json";
            if (File.Exists(caminhoArquivo))
            {
                string json = File.ReadAllText(caminhoArquivo);
                return JsonConvert.DeserializeObject<List<Pedido>>(json) ?? new List<Pedido>();
            }
            return new List<Pedido>();
        }

        private void PreencherComboBoxMeses()
        {
            // Limpa os itens existentes
            comboBoxMes.Items.Clear();

            // Adiciona os nomes dos meses ao ComboBox
            string[] meses = new string[]
            {
        "Janeiro", "Fevereiro", "Março", "Abril", "Maio", "Junho",
        "Julho", "Agosto", "Setembro", "Outubro", "Novembro", "Dezembro"
            };

            comboBoxMes.Items.AddRange(meses);

            // Define o mês atual como selecionado
            int mesAtual = DateTime.Now.Month - 1; // Ajusta para o índice zero-base
            comboBoxMes.SelectedIndex = mesAtual;

            // Adiciona o evento de mudança de seleção
            comboBoxMes.SelectedIndexChanged += ComboBoxMeses_SelectedIndexChanged;
        }

        private void ComboBoxMeses_SelectedIndexChanged(object sender, EventArgs e)
        {
            int mesSelecionado = comboBoxMes.SelectedIndex + 1; // Ajusta o índice para 1-base

            // Filtra os pedidos pelo mês selecionado
            var pedidosFiltrados = pedidos
                .Where(p => p.UltimoPedido.Month == mesSelecionado)
                .OrderByDescending(p => p.UltimoPedido) // Ordena os pedidos por data em ordem decrescente
                .ToList();

            dataGridViewPedidos.DataSource = pedidosFiltrados;
            AtualizarTotal(pedidosFiltrados); // Atualiza o total para os pedidos filtrados
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            string nomeClienteBuscado = Microsoft.VisualBasic.Interaction.InputBox("Digite o nome do cliente:", "Buscar Cliente", "");

            if (!string.IsNullOrWhiteSpace(nomeClienteBuscado))
            {
                var resultados = pedidos.Where(p => p.Nome.IndexOf(nomeClienteBuscado, StringComparison.OrdinalIgnoreCase) >= 0).ToList();

                if (resultados.Count > 0)
                {
                    dataGridViewPedidos.DataSource = resultados;
                    dataGridViewPedidos.Rows[0].Selected = true;
                }
                else
                {
                    MessageBox.Show("Nenhum cliente encontrado com esse nome.", "Busca sem Resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close(); // Fecha o formulário atual
        }

        private void dataGridViewPedidos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var valorDaCelula = dataGridViewPedidos.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                //MessageBox.Show($"Valor da célula: {valorDaCelula}");
            }
        }

        private void btnBuscarPorMes_Click(object sender, EventArgs e)
        {
            /*// Verificar se algum mês foi selecionado
            if (comboBoxMes.SelectedItem != null)
            {
                // Obter o número do mês selecionado
                int mesSelecionado = (int)comboBoxMes.SelectedItem;

                // Filtrar os pedidos pelo mês selecionado
                var pedidosFiltrados = pedidos
                    .Where(p => p.UltimoPedido.Month == mesSelecionado)
                    .ToList();

                // Atualizar o DataGridView com os pedidos filtrados
                dataGridViewPedidos.DataSource = pedidosFiltrados;

                // Atualizar o total para os pedidos filtrados
                AtualizarTotal();
            }
            else
            {
                MessageBox.Show("Por favor, selecione um mês.", "Mês não selecionado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }*/
        }

        


    }
}
