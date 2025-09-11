using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using Newtonsoft.Json;
using Microsoft.VisualBasic;

namespace CarteiraDeClientes
{
    public partial class Form1 : Form
    {
        // SEU CÓDIGO ORIGINAL
        public Form1()
        {
            InitializeComponent();
            ConfigurarDataGridView();
            CarregarDados();
            AtualizarDataGridView();

            // LÓGICA ADICIONADA: Carrega o estoque na inicialização
            CarregarEstoque();

            // SEU CÓDIGO ORIGINAL
            dataGridViewClientes.CellClick += dataGridViewClientes_CellClick;
        }

        // SEU CÓDIGO ORIGINAL
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            SalvarDados();
            // LÓGICA ADICIONADA: Salva o estoque ao fechar
            SalvarEstoque();
            base.OnFormClosing(e);
        }

        // SEU CÓDIGO ORIGINAL
        private List<Cliente> clientes = new List<Cliente>();
        private ImportadorDeClientes importador = new ImportadorDeClientes();

        // LÓGICA ADICIONADA: Variável para controlar o estoque
        private EstoqueGeral estoqueGeral = new EstoqueGeral();

        #region LÓGICA ADICIONADA: Métodos para Carregar e Salvar o Estoque
        private void CarregarEstoque()
        {
            string caminho = "estoque.json";
            if (File.Exists(caminho))
            {
                estoqueGeral = Newtonsoft.Json.JsonConvert.DeserializeObject<EstoqueGeral>(File.ReadAllText(caminho)) ?? new EstoqueGeral();
            }
        }

        private void SalvarEstoque()
        {
            File.WriteAllText("estoque.json", Newtonsoft.Json.JsonConvert.SerializeObject(estoqueGeral, Newtonsoft.Json.Formatting.Indented));
        }
        #endregion

        // SEU CÓDIGO ORIGINAL
        /*private void btnImportar_Click(object sender, EventArgs e)
        {
            // ...
        }*/

        // SEU CÓDIGO ORIGINAL
        private void ExibirClientesNaTela(List<Cliente> clientes)
        {
            dataGridViewClientes.DataSource = null;
            dataGridViewClientes.DataSource = clientes;
        }

        // MÉTODO MODIFICADO: Contém a nova lógica
        private void btnRegistrarPedido_Click_1(object sender, EventArgs e)
        {
            if (dataGridViewClientes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, selecione um cliente para registrar um pedido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CarregarEstoque(); // Carrega o saldo mais recente antes de verificar
            if (estoqueGeral.SaldoCheios <= 0)
            {
                MessageBox.Show("Atenção: Não há botijões cheios no estoque para registrar a venda.", "Estoque Vazio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var cliente = clientes.FirstOrDefault(c => c.Id == (int)dataGridViewClientes.SelectedRows[0].Cells["Id"].Value);
            if (cliente == null) return;

            using (var form = new RegistrarPedidoForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    var novoPedido = new Pedido { Id = cliente.Id, Nome = cliente.Nome, ItemPedido = form.ItemPedido, Valor = form.Valor, UltimoPedido = DateTime.Now };
                    SalvarPedidoNoArquivo(novoPedido);
                    cliente.UltimoPedido = novoPedido.UltimoPedido;

                    // LÓGICA CORRIGIDA E SIMPLIFICADA:
                    estoqueGeral.SaldoCheios--; // Venda DIMINUI cheios
                    estoqueGeral.SaldoVazios++; // Venda AUMENTA vazios

                    estoqueGeral.Movimentacoes.Add(new MovimentacaoEstoque
                    {
                        Data = DateTime.Now,
                        Tipo = "Venda",
                        Produto = form.ItemPedido,
                        Quantidade = 1,
                        Valor = form.Valor
                    });
                    SalvarEstoque();

                    AtualizarDataGridView();

                    string mensagem = $"*NOVO PEDIDO*\n\n" +
                                      $"*Cliente:* {cliente.Nome}\n" +
                                      $"*Endereço:* {cliente.Endereco}\n" +
                                      $"*Item:* {form.ItemPedido}\n" +
                                      $"*Valor:* {form.Valor:C}\n" +
                                      $"*Pagamento:* {form.FormaPagamento}";

                    Clipboard.SetText(mensagem);
                    MessageBox.Show("Pedido Registrado!\n\nO estoque foi atualizado e a mensagem para o entregador foi copiada.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        // O RESTANTE DO SEU CÓDIGO ORIGINAL, SEM ALTERAÇÕES

        private void SalvarPedidoNoArquivo(Pedido pedido)
        {
            string caminhoArquivo = "pedidos.json";
            List<Pedido> pedidos = new List<Pedido>();

            if (File.Exists(caminhoArquivo))
            {
                string json = File.ReadAllText(caminhoArquivo);
                pedidos = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Pedido>>(json) ?? new List<Pedido>();
            }
            else
            {
                pedidos = new List<Pedido>();
            }

            pedidos.Add(pedido);
            File.WriteAllText(caminhoArquivo, Newtonsoft.Json.JsonConvert.SerializeObject(pedidos, Newtonsoft.Json.Formatting.Indented));
        }

        private void SalvarPedidoNoJson(Pedido pedido)
        {
            string caminhoArquivo = "pedidos.json";
            List<Pedido> pedidos = new List<Pedido>();

            if (File.Exists(caminhoArquivo))
            {
                string json = File.ReadAllText(caminhoArquivo);
                pedidos = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Pedido>>(json) ?? new List<Pedido>();
            }

            pedidos.Add(pedido);

            string novoJson = Newtonsoft.Json.JsonConvert.SerializeObject(pedidos, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(caminhoArquivo, novoJson);
        }

        private void SalvarClientesNoArquivo()
        {
            string caminhoArquivo = "clientes.json";
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(clientes, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(caminhoArquivo, json);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnNotificarInativos.Click += btnNotificarInativos_Click_1;
        }

        private void btnNotificarInativos_Click_1(object sender, EventArgs e)
        {
            clientes = CarregarClientesDoArquivo();
            var inativos = clientes.Where(c => (DateTime.Now - c.UltimoPedido).Days > 60).ToList();
            if (inativos.Count > 0)
            {
                using (var inativosForm = new ClientesInativosForm(inativos))
                {
                    inativosForm.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Todos clientes dentro do periodo esperado!.", "Nenhum Inativo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private List<Cliente> CarregarClientesDoArquivo()
        {
            string caminhoArquivo = "clientes.json";
            if (File.Exists(caminhoArquivo))
            {
                string json = File.ReadAllText(caminhoArquivo);
                return Newtonsoft.Json.JsonConvert.DeserializeObject<List<Cliente>>(json);
            }
            return new List<Cliente>();
        }

        private void btnCadastrarCliente_Click(object sender, EventArgs e)
        {
            using (var cadastroForm = new CadastroClienteForm(clientes))
            {
                if (cadastroForm.ShowDialog() == DialogResult.OK)
                {
                    var novoCliente = cadastroForm.NovoCliente;
                    clientes.Add(novoCliente);
                    SalvarClientesNoArquivo();
                    AtualizarDataGridView();
                }
            }
        }

        private void AtualizarDataGridView()
        {
            int? idSelecionado = null;

            // VERIFICAÇÃO DE SEGURANÇA ADICIONADA AQUI
            // 1. Garante que há uma linha selecionada
            if (dataGridViewClientes.SelectedRows.Count > 0)
            {
                var celulaId = dataGridViewClientes.SelectedRows[0].Cells["Id"];
                // 2. Garante que a célula e seu valor não são nulos antes de tentar ler
                if (celulaId != null && celulaId.Value != null)
                {
                    idSelecionado = (int)celulaId.Value;
                }
            }

            dataGridViewClientes.DataSource = null;

            if (clientes.Any())
            {
                // Ordena a lista pela data de último pedido, do mais novo para o mais antigo
                var clientesOrdenados = clientes.OrderByDescending(c => c.UltimoPedido).ToList();
                dataGridViewClientes.DataSource = clientesOrdenados;

                // Tenta encontrar e selecionar a linha que estava selecionada antes (se houver)
                if (idSelecionado.HasValue)
                {
                    foreach (DataGridViewRow row in dataGridViewClientes.Rows)
                    {
                        if ((int)row.Cells["Id"].Value == idSelecionado.Value)
                        {
                            row.Selected = true;
                            // Opcional: rola a grade para a linha selecionada
                            dataGridViewClientes.FirstDisplayedScrollingRowIndex = row.Index;
                            break;
                        }
                    }
                }
            }
        }

        private void ConfigurarDataGridView()
        {
            dataGridViewClientes.AutoGenerateColumns = false;
            dataGridViewClientes.Columns.Clear();
            dataGridViewClientes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "ID", Name = "Id" });
            dataGridViewClientes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Nome", HeaderText = "Nome", Name = "Nome" });
            dataGridViewClientes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Email", HeaderText = "Email", Name = "Email" });
            dataGridViewClientes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Telefone", HeaderText = "Telefone", Name = "Telefone" });
            dataGridViewClientes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "UltimoPedido", HeaderText = "Último Pedido", Name = "UltimoPedido", DefaultCellStyle = new DataGridViewCellStyle { Format = "d" } });
            dataGridViewClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewClientes.MultiSelect = false;
        }

        private void dataGridViewClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewClientes.Rows[e.RowIndex];
                int clienteId = (int)row.Cells["Id"].Value;
                var cliente = clientes.FirstOrDefault(c => c.Id == clienteId);
            }
        }

        private void SalvarDados()
        {
            try
            {
                string json = System.Text.Json.JsonSerializer.Serialize(clientes);
                System.IO.File.WriteAllText("clientes.json", json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar os dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregarDados()
        {
            try
            {
                if (System.IO.File.Exists("clientes.json"))
                {
                    string json = System.IO.File.ReadAllText("clientes.json");
                    clientes = System.Text.Json.JsonSerializer.Deserialize<List<Cliente>>(json) ?? new List<Cliente>();
                }
                else
                {
                    clientes = new List<Cliente>();
                }
            }
            catch (Exception ex)
            {
                clientes = new List<Cliente>();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string buscaTexto = Microsoft.VisualBasic.Interaction.InputBox("Digite o nome ou telefone do cliente:", "Buscar Cliente", "");
            if (!string.IsNullOrEmpty(buscaTexto))
            {
                var resultados = clientes.Where(c => c.Nome.ToLower().Contains(buscaTexto.ToLower()) || c.Telefone.Contains(buscaTexto)).ToList();
                if (resultados.Count > 0)
                {
                    dataGridViewClientes.DataSource = resultados;
                }
                else
                {
                    MessageBox.Show("Nenhum cliente encontrado com esse nome ou telefone.", "Resultado da Busca", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    AtualizarDataGridView();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var pedidosForm = new PedidosRegistradosForm())
            {
                pedidosForm.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridViewClientes.SelectedRows.Count > 0)
            {
                int clienteId = (int)dataGridViewClientes.SelectedRows[0].Cells["Id"].Value;
                var cliente = clientes.FirstOrDefault(c => c.Id == clienteId);
                if (cliente != null)
                {
                    DialogResult result = MessageBox.Show($"Tem certeza que deseja excluir o cliente {cliente.Nome}?", "Confirmação de Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        clientes.Remove(cliente);
                        SalvarClientesNoArquivo();
                        AtualizarDataGridView();
                    }
                }
                else
                {
                    MessageBox.Show("Cliente não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecione um cliente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            AtualizarDataGridView();
        }

        private void dataGridViewClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Pode deixar vazio ou remover se não usar
        }

        private void btnEstoque_Click(object sender, EventArgs e)
        {
            using (var formEstoque = new EstoqueForm())
            {
                formEstoque.ShowDialog();
            }
            // Após fechar a tela de estoque, recarrega os dados para garantir 
            // que a tela principal tenha os saldos mais recentes.
            CarregarEstoque();
        }
    }
}