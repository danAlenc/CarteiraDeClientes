using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;
using Newtonsoft.Json;

namespace CarteiraDeClientes
{
    public class ImportadorDeClientes
    {
        public List<Cliente> ImportarClientesDoCsv(string caminhoArquivoCsv)
        {
            var clientes = new List<Cliente>();
            var idCounter = 1; // Contador para ID automático

            try
            {
                using (var reader = new StreamReader(caminhoArquivoCsv))
                using (var csv = new CsvReader(reader, new CsvHelper.Configuration.CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HasHeaderRecord = true
                }))
                {
                    var records = csv.GetRecords<dynamic>();

                    foreach (var record in records)
                    {
                        try
                        {
                            // Ajuste aqui para corresponder aos nomes das colunas do CSV
                            var cliente = new Cliente
                            {
                                Id = idCounter++, // Atribuir ID automático
                                Nome = record.Nome,
                                Email = record.Email,
                                Telefone = record.Telefone,
                                UltimoPedido = DateTime.Now // Define a data do último pedido como a data atual
                            };

                            clientes.Add(cliente);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Erro ao processar um registro: {ex.Message}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao abrir o arquivo CSV: {ex.Message}");
            }

            return clientes;
        }

        public void SalvarClientesNoArquivo(List<Cliente> clientes)
        {
            string caminhoArquivo = "clientes.json";
            string json = JsonConvert.SerializeObject(clientes, Formatting.Indented);
            File.WriteAllText(caminhoArquivo, json);
        }
    }
}
