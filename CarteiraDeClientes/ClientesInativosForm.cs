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
    public partial class ClientesInativosForm : Form
    {
        public ClientesInativosForm(List<Cliente> clientesInativos)
        {
            InitializeComponent();
            ConfigurarDataGridView();
            AtualizarDataGridView(clientesInativos);
        }


        private void dataGridViewInativos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void ConfigurarDataGridView()
        {
            dataGridViewInativos.AutoGenerateColumns = false;

            dataGridViewInativos.Columns.Clear();

            // Coluna de ID
            dataGridViewInativos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                HeaderText = "ID",
                Name = "Id"
            });

            // Coluna de Nome
            dataGridViewInativos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Nome",
                HeaderText = "Nome",
                Name = "Nome"
            });

            // Coluna de Email
            dataGridViewInativos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Email",
                HeaderText = "Email",
                Name = "Email"
            });

            // Coluna de Telefone
            dataGridViewInativos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Telefone",
                HeaderText = "Telefone",
                Name = "Telefone"
            });

            // Coluna de Último Pedido
            dataGridViewInativos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "UltimoPedido",
                HeaderText = "Último Pedido",
                Name = "UltimoPedido",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "d" } // Formato de data curta
            });
        }

        private void AtualizarDataGridView(List<Cliente> clientesInativos)
        {
            dataGridViewInativos.DataSource = null;
            dataGridViewInativos.DataSource = clientesInativos;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string nomeCliente = Microsoft.VisualBasic.Interaction.InputBox("Digite o nome do cliente para buscar:", "Buscar Cliente");

        }
    }
}
