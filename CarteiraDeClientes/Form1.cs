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
        public Form1()
        {
            InitializeComponent();
            ConfigurarDataGridView(); // Configura o DataGridView
            CarregarDados();          // Carrega os dados do arquivo JSON
            AtualizarDataGridView();  // Atualiza o DataGridView com os dados carregados

            // Associa o evento CellClick
            dataGridViewClientes.CellClick += dataGridViewClientes_CellClick;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            SalvarDados(); // Salva os dados no arquivo JSON
            base.OnFormClosing(e);
        }


        private List<Cliente> clientes = new List<Cliente>();
        private ImportadorDeClientes importador = new ImportadorDeClientes();

        /*private void btnImportar_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            openFileDialog.Title = "Selecione o arquivo CSV para importação";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                var importador = new ImportadorDeClientes();
                var clientes = importador.ImportarClientesDoCsv(filePath);
                importador.SalvarClientesNoArquivo(clientes);

                

                MessageBox.Show("Clientes importados e salvos com sucesso!", "Importação Concluída", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }*/
                               
        private void ExibirClientesNaTela(List<Cliente> clientes)
        {
            // Supondo que você tenha um DataGridView ou ListView para exibir clientes
            dataGridViewClientes.DataSource = null;
            dataGridViewClientes.DataSource = clientes;
        }


        private void btnRegistrarPedido_Click_1(object sender, EventArgs e)
        {
            if (dataGridViewClientes.SelectedRows.Count > 0)
            {
                int clienteId = (int)dataGridViewClientes.SelectedRows[0].Cells["Id"].Value;
                var cliente = clientes.FirstOrDefault(c => c.Id == clienteId);

                if (cliente != null)
                {
                    using (var form = new RegistrarPedidoForm())
                    {
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            Pedido pedido = new Pedido
                            {
                                Id = clienteId,
                                Nome = cliente.Nome,
                                ItemPedido = form.ItemPedido,
                                Valor = form.Valor,
                                UltimoPedido = DateTime.Now
                            };

                            // Salva o pedido em um arquivo JSON
                            SalvarPedidoNoArquivo(pedido);
                            cliente.UltimoPedido = pedido.UltimoPedido;
                            dataGridViewClientes.Refresh();
                        }
                    }
                }
            }
        }

        private void SalvarPedidoNoArquivo(Pedido pedido)
        {
            string caminhoArquivo = "pedidos.json";
            List<Pedido> pedidos = new List<Pedido>();

            if (File.Exists(caminhoArquivo))
            {
                string json = File.ReadAllText(caminhoArquivo);
                pedidos = JsonConvert.DeserializeObject<List<Pedido>>(json) ?? new List<Pedido>();
            }
            else
            {
                pedidos = new List<Pedido>();
            }

            pedidos.Add(pedido);
            File.WriteAllText(caminhoArquivo, JsonConvert.SerializeObject(pedidos, Formatting.Indented));
        }

        private void SalvarPedidoNoJson(Pedido pedido)
        {
            string caminhoArquivo = "pedidos.json";
            List<Pedido> pedidos = new List<Pedido>();

            if (File.Exists(caminhoArquivo))
            {
                string json = File.ReadAllText(caminhoArquivo);
                pedidos = JsonConvert.DeserializeObject<List<Pedido>>(json) ?? new List<Pedido>();
            }

            pedidos.Add(pedido);

            string novoJson = JsonConvert.SerializeObject(pedidos, Formatting.Indented);
            File.WriteAllText(caminhoArquivo, novoJson);
        }


        // Função para salvar os clientes no arquivo JSON
        private void SalvarClientesNoArquivo()
        {
            string caminhoArquivo = "clientes.json";
            string json = JsonConvert.SerializeObject(clientes, Formatting.Indented);
            File.WriteAllText(caminhoArquivo, json);
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            // Associar o evento Click ao botão
            btnNotificarInativos.Click += btnNotificarInativos_Click_1;
        }


        private void btnNotificarInativos_Click_1(object sender, EventArgs e)
        {
            // Carrega a lista de clientes a partir do arquivo JSON
            clientes = CarregarClientesDoArquivo();

            // Filtra os clientes que estão inativos (mais de 60 dias sem pedidos)
            var inativos = clientes.Where(c => (DateTime.Now - c.UltimoPedido).Days > 60).ToList();

            if (inativos.Count > 0)
            {
                // Abre o formulário ClientesInativosForm e passa a lista de inativos
                using (var inativosForm = new ClientesInativosForm(inativos))
                {
                    inativosForm.ShowDialog();  // Abre o formulário como uma caixa de diálogo modal
                }
            }
            else
            {
                // Exibir aviso caso não haja clientes inativos
                MessageBox.Show("Todos os clientes estão ativos. Nenhum cliente está inativo.", "Nenhum Inativo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private List<Cliente> CarregarClientesDoArquivo()
        {
            string caminhoArquivo = "clientes.json";

            if (File.Exists(caminhoArquivo))
            {
                string json = File.ReadAllText(caminhoArquivo);
                return JsonConvert.DeserializeObject<List<Cliente>>(json);
            }

            return new List<Cliente>(); // Retorna uma lista vazia se o arquivo não existir
        }



        private void btnCadastrarCliente_Click(object sender, EventArgs e)
        {
            // Cria uma nova instância do formulário de cadastro
            using (var cadastroForm = new CadastroClienteForm(clientes))
            {
                if (cadastroForm.ShowDialog() == DialogResult.OK)
                {
                    // Adiciona o novo cliente à lista de clientes
                    var novoCliente = cadastroForm.NovoCliente;
                    clientes.Add(novoCliente);

                    // Salva a lista atualizada de clientes no arquivo JSON
                    SalvarClientesNoArquivo();

                    // Atualiza o DataGridView para exibir o novo cliente
                    AtualizarDataGridView();
                }
            }
        }


        private void AtualizarDataGridView()
        {
            // Limpa a fonte de dados atual
            dataGridViewClientes.DataSource = null;

            // Ordena a lista de clientes pelo ID em ordem decrescente (clientes mais recentes primeiro)
            var clientesOrdenados = clientes.OrderByDescending(c => c.Id).ToList();

            // Define a nova fonte de dados
            dataGridViewClientes.DataSource = clientesOrdenados;
        }


        private void ConfigurarDataGridView()
        {
            // Desativa a geração automática de colunas
            dataGridViewClientes.AutoGenerateColumns = false;

            // Limpa colunas existentes
            dataGridViewClientes.Columns.Clear();

            // Adiciona colunas manualmente
            dataGridViewClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                HeaderText = "ID",
                Name = "Id"
            });

            dataGridViewClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Nome",
                HeaderText = "Nome",
                Name = "Nome"
            });

            dataGridViewClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Email",
                HeaderText = "Email",
                Name = "Email"
            });

            dataGridViewClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Telefone",
                HeaderText = "Telefone",
                Name = "Telefone"
            });

            dataGridViewClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "UltimoPedido",
                HeaderText = "Último Pedido",
                Name = "UltimoPedido",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "d" } // Formata a data
            });

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

                // Agora você pode usar o objeto cliente conforme necessário
                // Exemplo: Atualizar informações do cliente ou executar alguma ação
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
                    clientes = new List<Cliente>(); // Cria uma nova lista se o arquivo não existir
                }
            }
            catch (Exception ex)
            {
               // MessageBox.Show($"Erro ao carregar os dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                clientes = new List<Cliente>(); // Cria uma nova lista em caso de erro
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string buscaTexto = Microsoft.VisualBasic.Interaction.InputBox("Digite o nome ou telefone do cliente:", "Buscar Cliente", "");

            if (!string.IsNullOrEmpty(buscaTexto))
            {
                var resultados = clientes.Where(c =>
                    c.Nome.ToLower().Contains(buscaTexto.ToLower()) ||
                    c.Telefone.Contains(buscaTexto)).ToList();

                if (resultados.Count > 0)
                {
                    dataGridViewClientes.DataSource = resultados;
                }
                else
                {
                    MessageBox.Show("Nenhum cliente encontrado com esse nome ou telefone.", "Resultado da Busca", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    AtualizarDataGridView(); // Recarrega a lista completa se não encontrar resultados
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Instancia o formulário de pedidos registrados sem argumentos
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
            AtualizarDataGridView(); // Chama a função que recarrega todos os clientes na tabela

        }

        private void dataGridViewClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
